using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using BlogGrpc;
using Grpc.Net.Client;

namespace WebAppClient.Pages.User
{
    public class CreateModel : PageModel
    {
        private readonly UserCrud.UserCrudClient _client;

        public CreateModel()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7003");
            _client = new UserCrud.UserCrudClient(channel);
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BusinessObject.User User { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || User == null)
            {
                return Page();
            }

            var email = HttpContext.Session.GetString("email");
            var authorId = HttpContext.Session.GetString("id");

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(authorId))
            {
                return RedirectToPage("/Login");
            }

            var response = _client.Add(new BlogGrpc.User {
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
