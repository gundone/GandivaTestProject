using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GandivaTestProject
{
    public class TaskRepository : EFGenericRepository<Task>
    {
        public TaskRepository(IDbContextProvider context)
            : base(context)
        {

        }
      
        public TaskRepository()
            : base (IoC.TaskManagerDbContext)
        {

        }

        public override Task FindById(int id)
        {
            var task = _context
                .Tasks
                .Include(u => u.Contractor)
                .Include(u => u.Creator)
                .Where(t => t.ID == id && t.IsActual)
                .FirstOrDefault();

            var comments = _context.Comments.Include(u => u.Creator).Where(c => c.TaskID == id && c.IsActual);

            task.TaskComments = comments.ToList();
            return task;
        }

        public override IEnumerable<Task> Get(Func<Task, bool> predicate)
        {
            return _context
                .Tasks
                .Include(u => u.Contractor)
                .Include(u => u.Creator)
                .Where(predicate)
                .Where(t=>t.IsActual)
                .AsEnumerable();
        }

        public override void Remove(Task item)
        {
            item.IsActual = false;
            SaveChanges();
        }

        public void Update(int id, string title, string description, int creator, int contractor)
        {
            var users = new UserRepository();
            var tasks = new TaskRepository();
            var t = tasks.FindById(id);
            t.Title = title;
            t.Description = description;
            t.Creator = users.FindById(creator);
            t.Contractor = users.FindById(contractor);
            SaveChanges();
        }

        public void RemoveById(int id)
        {
            var comments = new CommentService();
            var t = FindById(id);
            comments.RemoveMany(comments.Get(c => c.TaskID == id));
            Remove(t);
            SaveChanges();
        }
    }
}
