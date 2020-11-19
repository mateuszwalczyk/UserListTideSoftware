using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserList.Core;
using UserList.Data;

namespace UserList.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly IUserData userData;
        // przeczytaj o tym 
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public User User { get; set; }
        public IEnumerable<SelectListItem> Gender { get; set; }

        public EditModel(IUserData userData,
                         IHtmlHelper htmlHelper)
        {
            this.userData = userData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? userId)
        {
            Gender = htmlHelper.GetEnumSelectList<Gender>();
            if (userId.HasValue)
            {
                User = userData.GetById(userId.Value);
            }
            else
            {
                User = new User();
            }
            if (User == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            // POCZYTAJ
            if (!ModelState.IsValid)
            {
                Gender = htmlHelper.GetEnumSelectList<Gender>();
                return Page();
            }
            if (User.Id > 0)
            {
                userData.Update(User);
            }
            else
            {
                userData.Add(User);
            }
            userData.Commit();
            TempData["Message"] = "User Saved!";
            return RedirectToPage("./Detail", new { userId = User.Id });
        }
    }
}