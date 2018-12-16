using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandivaTestProject.Models
{
    public class TaskListViewModel
    {
        public List<Task> Tasks     { get; set; }
        public List<User> Users     { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
