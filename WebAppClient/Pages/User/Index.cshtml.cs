using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using Grpc.Net.Client;
using BlogGrpc;
using Grpc.Core;

namespace WebAppClient.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly UserCrud.UserCrudClient _client;

        public IList<BusinessObject.User> Users { get; set; } = new List<BusinessObject.User>();

        public IndexModel()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7003");
            _client = new UserCrud.UserCrudClient(channel);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var email = HttpContext.Session.GetString("email");
            var authorId = HttpContext.Session.GetString("id");

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(authorId))
            {
                return RedirectToPage("/Login");
            }

            var response = _client.GetAll(new Empty());
            await foreach (var user in response.ResponseStream.ReadAllAsync())
            {
                Users.Add(new BusinessObject.User
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password,
                    Role = user.Role,
                    Status = user.Status
                });
            }

            return Page();
        }
    }
}

