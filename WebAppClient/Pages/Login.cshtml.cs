using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject;
using BusinessObject.ViewModel;
using Newtonsoft.Json;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Configuration;
using System.Security.Claims;
using BlogGrpc;
using Grpc.Net.Client;
using Grpc.Core;


namespace WebAppClient.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserCrud.UserCrudClient _client;

        public LoginModel()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7003");
            _client = new UserCrud.UserCrudClient(channel);
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public LoginRequest LoginVM { get; set; } = default!;

        public string ErrorMessage { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || User == null)
            {
                ModelState.AddModelError(nameof(ErrorMessage), "You do not have permission to do this function");
                return Page();
            }
            else
            {
                try
                {
                    var response = await _client.GetByUsernameAndPasswordAsync(new GetByUsernameAndPasswordRequest { Username = LoginVM.Username, Password = LoginVM.Password });

                    if (response != null)
                    {
                        var getRole = response.Role;
                        if (getRole.Equals("admin"))
                        {
                            HttpContext.Session.SetString("email", response.Email);
                            HttpContext.Session.SetString("id", response.Id);
                            return RedirectToPage("User/Index");
                        }
                        else if (getRole.Equals("staff"))
                        {
                            HttpContext.Session.SetString("email", response.Email);
                            HttpContext.Session.SetString("id", response.Id);
                            return RedirectToPage("/Post/Index");
                        }
                        else
                        {
                            ModelState.AddModelError(nameof(ErrorMessage), "You do not have permission to do this function");
                            return Page();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(ErrorMessage), "You do not have permission to do this function");
                        return Page();
                    }
                }
                catch (RpcException ex)
                {
                    if (ex.Status.StatusCode == Grpc.Core.StatusCode.Unauthenticated)
                    {
                        ModelState.AddModelError(nameof(ErrorMessage), ex.Status.Detail);
                        return Page();
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(ErrorMessage), "An error occurred while processing your request");
                        return Page();
                    }
                }
            }
        }

    }
}
