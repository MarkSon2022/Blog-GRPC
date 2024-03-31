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

namespace WebAppClient.Pages.User
{
    public class EditModel : PageModel
    {
        private readonly UserCrud.UserCrudClient _client;
        public EditModel()
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

            var response = _client.Update(new BlogGrpc.User
            {
                Id = User.Id,
                Username = User.Username,
                Email = User.Email,
                Password = User.Password,
                Role = User.Role,
                Status = true,
            });
            return RedirectToPage("./Index");
        }


    }
}
