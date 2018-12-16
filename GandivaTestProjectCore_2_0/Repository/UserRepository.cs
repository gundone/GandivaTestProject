using System;
using Microsoft.EntityFrameworkCore;

namespace GandivaTestProject
{
    public class UserRepository : EFGenericRepository<User>
    {
        public UserRepository(IDbContextProvider context)
            : base(context)
        {
           
        }

        public UserRepository()
            : base(IoC.TaskManagerDbContext)
        {

        }

        public override void Remove(User item)
        {
            item.IsActual = false;
            SaveChanges();
        }

        public void Update(int id, string firstname, string surname, string secondaryname)
        {
            var u = FindById(id);
            u.FirstName = firstname;
            u.Surname = surname;
            u.SecondaryName = secondaryname;
            SaveChanges();
        }

        public void RemoveById(int id)
        {
            var u = FindById(id);
            Remove(u);
        }

        public void Create(string firstname, string surname, string secondaryname)
        {
            var u = new User
            {
                FirstName = firstname,
                SecondaryName = secondaryname,
                Surname = surname
            };
            _context.Users.Add(u);
            SaveChanges();
        }
    }
}
