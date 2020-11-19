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
    public class DeleteModel : PageModel
    {
        private readonly IUserData userData;
        public User User { get; set; }
        public DeleteModel(IUserData userData)
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

        public IActionResult OnPost(int userId)
        {
            var user = userData.Delete(userId);
            userData.Commit();

            if (user == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"Użytkownik {user.Name} {user.Surname} został usunięty";
            return RedirectToPage("./List");
        }
    }
}