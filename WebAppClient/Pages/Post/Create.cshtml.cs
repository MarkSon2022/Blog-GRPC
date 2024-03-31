using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Net.NetworkInformation;
using System.Text;
using System.Net.Http.Headers;
using BlogGrpc;
using Grpc.Net.Client;
using Grpc.Core;
using Microsoft.Extensions.Hosting;
using Google.Protobuf.WellKnownTypes;

namespace WebAppClient.Pages.Post
{
    public class CreateModel : PageModel
    {
        private readonly PostCrud.PostCrudClient _client;
        private readonly CategoryCrud.CategoryCrudClient _categoryClient;

        public CreateModel()
        {

            var channel = GrpcChannel.ForAddress("https://localhost:7003");
            _client = new PostCrud.PostCrudClient(channel);
            _categoryClient = new CategoryCrud.CategoryCrudClient(channel);
        }

        public async Task<IActionResult> OnGet()
        {
            var email = HttpContext.Session.GetString("email");
            var authorId = HttpContext.Session.GetString("id");

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(authorId))
            {
                return RedirectToPage("/Login");
            }

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

            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");

            return Page();


        }

        [BindProperty]
        public BusinessObject.Post Post { get; set; } = new BusinessObject.Post()!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
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

            var responsePost = _client.Add(new BlogGrpc.Post
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
