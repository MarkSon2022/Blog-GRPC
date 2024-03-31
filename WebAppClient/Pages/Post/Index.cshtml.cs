using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using BlogGrpc;
using Grpc.Net.Client;
using Grpc.Core;

namespace WebAppClient.Pages.Post
{
    public class IndexModel : PageModel
    {
        private readonly PostCrud.PostCrudClient _client;
        private readonly UserCrud.UserCrudClient _userClient;
        private readonly CategoryCrud.CategoryCrudClient _categoryClient;

        public IndexModel()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7003");
            _client = new PostCrud.PostCrudClient(channel);
            _categoryClient = new CategoryCrud.CategoryCrudClient(channel);
            _userClient = new UserCrud.UserCrudClient(channel);
        }

        public IList<BusinessObject.Post>? Post { get; set; } = new List<BusinessObject.Post>();

        public async Task<IActionResult> OnGetAsync()
        {

            var email = HttpContext.Session.GetString("email");
            var authorId = HttpContext.Session.GetString("id");
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(authorId))
            {
                return RedirectToPage("/Login");
            }

            var response = _client.GetAll(new EmptyPost());


            await foreach (var post in response.ResponseStream.ReadAllAsync())
            {
                var postBS = new BusinessObject.Post
                {
                    Id = post.Id,
                    Title = post.Title,
                    Content = post.Content,
                    PublishedAt = post.PublishedAt.ToDateTime().ToLocalTime(),
                    AuthorId = post.AuthorId,
                    CategoryId = post.CategoryId
                };
                var responseAuthor = _userClient.GetById(new GetUserById { Id = post.AuthorId });
                var responseCategory = _categoryClient.GetById(new GetCategoryById { Id = post.CategoryId });

                postBS.Author = new BusinessObject.User();
                postBS.Author.Id = post.AuthorId;
                postBS.Author.Email = responseAuthor.Email;

                postBS.Category = new BusinessObject.Category();
                postBS.Category.Id = responseCategory.Id;
                postBS.Category.Name = responseCategory.Name;
                //
                Post.Add(postBS);
            }
            return Page();
            //return RedirectToPage("/Login");
        }
    }
}
