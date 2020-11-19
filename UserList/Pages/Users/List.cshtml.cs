using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using UserList.Core;
using UserList.Data;

namespace UserList.Pages.Users
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IUserData userData;

        public string Message { get; set; }
        public IEnumerable<User> Users { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config,
                         IUserData userData)
        {
            this.config = config;
            this.userData = userData;
        }

        public void OnGet(string searchTerm)
        {
            SearchTerm = searchTerm;
            Message = config["Message"];
            Users = userData.GetUserBySurname(SearchTerm);
        }
    }
}