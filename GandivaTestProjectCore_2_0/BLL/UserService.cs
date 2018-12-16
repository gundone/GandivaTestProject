using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandivaTestProject
{
    public class UserService : IGenericService<User>
    {
        UserRepository _repo = new UserRepository();

        public IEnumerable<User> Get(Func<User, bool> predicate)
        {
            return _repo.Get(predicate);
        }


        public User FindById(int id)
        {
            return _repo.FindById(id);
        }

        public void Remove(User user)
        {
            _repo.Remove(user);
        }

        public void SaveChanges()
        {
            _repo.SaveChanges();
        }

        internal void Update(int id, string firstname, string surname, string secondaryname)
        {
            _repo.Update(id, firstname, surname, secondaryname);
        }

        internal void RemoveById(int id)
        {
            _repo.RemoveById(id);
        }

        internal void Create(string firstname, string surname, string secondaryname)
        {
            _repo.Create(firstname, surname, secondaryname);
        }
    }
}
