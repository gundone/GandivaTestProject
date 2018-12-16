using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GandivaTestProject.Models;

namespace GandivaTestProject
{ 
    public class UsersController : Controller
    {
        UserService _userService = new UserService();


        public IActionResult Index(int page)
        {
            int pageSize = 5;
            var users = _userService
                       .Get(t => true)
                       .ToList();
            var usersPerPages = users.Skip((page - 1) * pageSize).Take(pageSize);
            var pageViewModel = new PageViewModel(users.Count, page, pageSize);
            var usersVM = new UsersListViewModel
            {
                Users = usersPerPages.ToList(),
                PageViewModel = pageViewModel
            };
            return View(usersVM);
        }

        public IActionResult Update(int id, string firstname, string surname, string secondaryname)
        {
            _userService.Update(id, firstname, surname, secondaryname);
            return LocalRedirect($"/Users");
        }

        public IActionResult Remove(int id)
        {
            _userService.RemoveById(id);
            return LocalRedirect($"/Users");
        }

        public IActionResult Create(string firstname, string surname, string secondaryname)
        {
            _userService.Create(firstname, surname, secondaryname);
            return LocalRedirect($"/Users");
        }
    

        [HttpPost]
        public void SetCurrent(int id)
        {
            HttpContext.Response.Cookies.Append("CurrentUser", id.ToString());
            return;
        }
    }
}