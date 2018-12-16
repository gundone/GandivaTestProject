using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandivaTestProject.Models
{
    public class TaskViewModel
    {
        public Task Task { get; set; }
        public List<User> AllUsers { get; set; }
    }
}
