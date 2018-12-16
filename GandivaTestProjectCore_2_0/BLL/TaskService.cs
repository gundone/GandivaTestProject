using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandivaTestProject
{
    public class TaskService : IGenericService<Task>
    {
        TaskRepository _repo = new TaskRepository();

        public IEnumerable<Task> Get(Func<Task, bool> predicate)
        {
            return _repo.Get(predicate);
        }

        public Task FindById(int id)
        {
            return _repo.FindById(id);
        }

        public void Remove(Task user)
        {
            _repo.Remove(user);
        }

        public void Remove(int id)
        {
            _repo.RemoveById(id);
        }

        public void SaveChanges()
        {
            _repo.SaveChanges();
        }

        public void Update(int ID, string title, string description, int creator, int contractor)
        {
            _repo.Update(ID, title, description, creator, contractor);
        }

        public void Add(Task t)
        {
            _repo.AddRange(t);
        }
    }
}
