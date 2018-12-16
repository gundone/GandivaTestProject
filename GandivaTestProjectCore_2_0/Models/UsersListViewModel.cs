using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandivaTestProject.Models
{
    public class UsersListViewModel
    {
        public List<User> Users { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
