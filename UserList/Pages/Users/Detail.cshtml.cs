using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserList.Core;
using UserList.Data;

namespace UserList.Pages.Users
{
    public class DetailModel : PageModel
    {
        private readonly IUserData userData;
        [TempData]
        public string Message { get; set; }
        public User User { get; set; }
        public DetailModel(IUserData userData)
        {
            this.userData = userData;
        }
        public IActionResult OnGet(int userId)
        {
            User = userData.GetById(userId);
            if (User == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}