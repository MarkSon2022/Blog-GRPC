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
using System.Net;
using System.Text;
using BlogGrpc;
using Grpc.Net.Client;

namespace WebAppClient.Pages.User
{
    public class ActivateModel : PageModel
    {
        private readonly UserCrud.UserCrudClient _client;

        public ActivateModel()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7003");
            _client = new UserCrud.UserCrudClient(channel);
        }

        [BindProperty]
        public BusinessObject.User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = HttpContext.Session.GetString("email");
            var authorId = HttpContext.Session.GetString("id");

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(authorId))
            {
                return RedirectToPage("/Login");
            }

            try
            {
                var response = _client.GetById(new GetUserById { Id = id });
                User = new BusinessObject.User
                {
                    Id = response.Id,
                    Username = response.Username,
                    Email = response.Email,
                    Password = response.Password,
                    Role = response.Role,
                    Status = response.Status
                };
                return Page();
            }
            catch
            {
                return RedirectToPage("/Login");
            }
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            var email = HttpContext.Session.GetString("email");
            var authorId = HttpContext.Session.GetString("id");

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(authorId))
            {
                return RedirectToPage("/Login");
            }

            try
            {
                var response = _client.ActivateUser(new ActivateUserRequest { Id = id, Status = true });

                return RedirectToPage("./Index");
            }
            catch
            {
                return RedirectToPage("/Login");
            }
        }
    }
}
