using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace GandivaTestProject
{
    public class CommentRepository : EFGenericRepository<Comment>
    {
        public CommentRepository(IDbContextProvider context)
            : base(context)
        {

        }

        public CommentRepository()
            : base(IoC.TaskManagerDbContext)
        {

        }

        public IEnumerable<Comment> FindByTaskId(int id)
        {
            return _context.Comments
                .Include(c=>c.Creator)
                .Where(t => t.Task.ID == id && t.IsActual);
        }

        public void Create(int taskId, int userId, string commentText)
        {
            _context.Comments.Add(new Comment {
                Task = _context.Tasks.Find(taskId),
                Creator = _context.Users.Find(userId),
                Description = commentText
            });
            SaveChanges();
        }

        public override void Remove(Comment item)
        {
            var c = _context.Comments.Find(item.ID);
            c.IsActual = false;
            SaveChanges();
        }
    }
}
