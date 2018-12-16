using Microsoft.Extensions.DependencyInjection;
using System;

namespace GandivaTestProject
{
    public static class IoC
    {
        public static TaskManagerDbContext TaskManagerDbContext => IocContainer.Provider.GetService<TaskManagerDbContext>();
    }
    public static class IocContainer
    {
        public static ServiceProvider Provider { get; set; }
    }
}
