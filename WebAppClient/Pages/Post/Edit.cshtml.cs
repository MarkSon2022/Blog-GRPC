using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using BlogGrpc;
using Grpc.Net.Client;
using Grpc.Core;
using Microsoft.Extensions.Hosting;
using Google.Protobuf.WellKnownTypes;

namespace WebAppClient.Pages.Post
{
    public class EditModel : PageModel
    {
        private readonly PostCrud.PostCrudClient _client;
        private readonly UserCrud.UserCrudClient _userClient;
        private readonly CategoryCrud.CategoryCrudClient _categoryClient;

        public EditModel()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7003");
            _client = new PostCrud.PostCrudClient(channel);
            _categoryClient = new CategoryCrud.CategoryCrudClient(channel);
            _userClient = new UserCrud.UserCrudClient(channel);
        }

        [BindProperty]
        public BusinessObject.Post Post { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var email = HttpContext.Session.GetString("email");
            var authorId = HttpContext.Session.GetString("id");
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(authorId))
            {
                return RedirectToPage("/Login");
            }

            var response = _client.GetById(new GetPostById { Id = id });
            Post = new BusinessObject.Post
            {
                Id = response.Id,
                Title = response.Title,
                Content = response.Content,
                PublishedAt = response.PublishedAt.ToDateTime().ToLocalTime(),
                AuthorId = response.AuthorId,
                CategoryId = response.CategoryId
            };

            //add to author id
            Post.AuthorId = authorId;

            //select categories
            List<BusinessObject.Category>? categories = new List<BusinessObject.Category>();
            var responseCategory = _categoryClient.GetAll(new EmptyCategory());
            await foreach (var category in responseCategory.ResponseStream.ReadAllAsync())
            {
                categories.Add(new BusinessObject.Category
                {
                    Id = category.Id,
                    Name = category.Name,
                });
            }
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", Post.CategoryId);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var email = HttpContext.Session.GetString("email");
            var authorId = HttpContext.Session.GetString("id");
            
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(authorId))
            {
                return RedirectToPage("/Login");
            }

            var response = _client.Update(new BlogGrpc.Post
            {
                Id = Post.Id,
                Title = Post.Title,
                Content = Post.Content,
                PublishedAt = Timestamp.FromDateTime(Post.PublishedAt.ToUniversalTime()),
                AuthorId = Post.AuthorId,
                CategoryId = Post.CategoryId
            });

            return RedirectToPage("./Index");
        }


    }
}
