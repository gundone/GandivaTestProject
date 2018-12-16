using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GandivaTestProject.Models;

namespace GandivaTestProject
{
    public class TaskController : Controller
    {

        TaskService _taskService = new TaskService();
        UserService _userService = new UserService();
        CommentService commentService = new CommentService();

        public IActionResult Index(int page = 1)
        {
            int pageSize = 5;
            var tasks = _taskService.Get(t => true)
                        .OrderBy(t => t.CreateDate)
                        .ToList();
            var tasksPerPages = tasks.Skip((page - 1) * pageSize).Take(pageSize);
            var pageViewModel = new PageViewModel(tasks.Count, page, pageSize);
            var tasksVMList = new TaskListViewModel
            {
                Tasks = tasksPerPages.ToList(),
                Users = _userService.Get(t => true)
                        .OrderBy(u => u.FirstName)
                        .ToList(),
                PageViewModel = pageViewModel
            };
            return View(tasksVMList);
        }

        public IActionResult NewTask()
        {
            var tasksVMList = new TaskListViewModel
            {
                Tasks = _taskService.Get(t => true)
                        .OrderBy(t => t.CreateDate)
                        .ToList(),
                Users = _userService.Get(t => true)
                        .OrderBy(u => u.FirstName)
                        .ToList()
            };
            return View(tasksVMList);
        }

        
        public IActionResult Edit(int id)
        {
            var taskVM = new TaskViewModel
            {
                Task = _taskService.FindById(id),

                AllUsers = _userService.Get(t => true)
                        .OrderBy(u => u.FirstName)
                        .ToList()
            };
            return View(taskVM);
        }

        public IActionResult Update(int id, string title, string description, int creator, int contractor)
        {
            _taskService.Update(id, title, description, creator, contractor);
            return LocalRedirect($"/Task/Edit/{id}");
        }

        public IActionResult Remove(int id)
        {
            _taskService.Remove(id);
            var tasksVMList = new TaskListViewModel
            {
                Tasks = _taskService.Get(t => true)
                       .OrderBy(t => t.CreateDate)
                       .ToList(),
                Users = _userService.Get(t => true)
                       .OrderBy(u => u.FirstName)
                       .ToList()
            };
            return LocalRedirect("/");
        }

        public IActionResult Create(string title, string description, int creator, int contractor)
        {
            var task = new Task
            {
                Title = title,
                Description = description,
                Creator = _userService.FindById(creator),
                Contractor = _userService.FindById(contractor)
            };
            _taskService.Add(task);
            return LocalRedirect("/");
        }
    }
}