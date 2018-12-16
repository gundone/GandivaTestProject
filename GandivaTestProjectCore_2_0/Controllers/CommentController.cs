using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GandivaTestProject
{
    public class CommentController : Controller
    {
        CommentService _commentService = new CommentService();
        public IActionResult AddComment(string taskIdStr, string commentText)
        {
            var userId = int.Parse(HttpContext.Request.Cookies["CurrentUser"]);
            var taskId = int.Parse(taskIdStr);
            _commentService.Create(taskId, userId, commentText);
            return LocalRedirect($"/Task/Edit/{taskId}");
        }

        public  IActionResult Remove(int id)
        {
            var comment = _commentService.FindById(id);
            var taskId = comment.TaskID;
            _commentService.Remove(comment);
            return LocalRedirect($"/Task/Edit/{taskId}");
        }
    }
}