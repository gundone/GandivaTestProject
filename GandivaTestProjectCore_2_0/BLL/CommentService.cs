using System;
using System.Collections.Generic;

namespace GandivaTestProject
{
    public class CommentService : IGenericService<Comment>
    {
        CommentRepository _repo = new CommentRepository();

        public IEnumerable<Comment> Get(Func<Comment, bool> predicate)
        {
            return _repo.Get(predicate);
        }

        public Comment FindById(int id)
        {
            return _repo.FindById(id);
        }

        public void Remove(Comment comment)
        {
            _repo.Remove(comment);
        }

        public void RemoveMany(IEnumerable<Comment> comments)
        {
            foreach (var c in comments)
            {
                _repo.Remove(c);
            }
        }
        public void RemoveMany(params Comment[] comments)
        {
            RemoveMany(comments);
        }

        public void Create(int taskId, int userId, string commentText)
        {
            _repo.Create(taskId, userId, commentText);
        }

        public void SaveChanges()
        {
            _repo.SaveChanges();
        }
    }
}
