using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using Grpc.Net.Client;
using BlogGrpc;

namespace WebAppClient.Pages.Post
{
    public class DeleteModel : PageModel
    {
        private readonly PostCrud.PostCrudClient _client;
        private readonly UserCrud.UserCrudClient _userClient;
        private readonly CategoryCrud.CategoryCrudClient _categoryClient;

        public DeleteModel()
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
            var responseAuthor = _userClient.GetById(new GetUserById { Id = response.AuthorId });
            var responseCategory = _categoryClient.GetById(new GetCategoryById { Id = response.CategoryId });

            Post = new BusinessObject.Post
            {
                Id = response.Id,
                Title = response.Title,
                Content = response.Content,
                PublishedAt = response.PublishedAt.ToDateTime().ToLocalTime(),
                AuthorId = response.AuthorId,
                CategoryId = response.CategoryId,
            };

            Post.Author = new BusinessObject.User();
            Post.Author.Id = response.AuthorId;
            Post.Author.Email = responseAuthor.Email;
            Post.Author.Username = responseAuthor.Username;

            Post.Category = new BusinessObject.Category();
            Post.Category.Id = responseCategory.Id;
            Post.Category.Name = responseCategory.Name;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var email = HttpContext.Session.GetString("email");
            var authorId = HttpContext.Session.GetString("id");

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(authorId))
            {
                return RedirectToPage("/Login");
            }

            var response = _client.Remove(new GetPostById { Id = id });

            return RedirectToPage("./Index");
        }
    }
}
