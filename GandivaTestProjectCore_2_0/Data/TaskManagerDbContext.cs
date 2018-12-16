using Microsoft.EntityFrameworkCore;
using System;

namespace GandivaTestProject
{
    public class TaskManagerDbContext : DbContext, IDbContextProvider
    {
        #region Public Properties

        //public DbSet<User> Users { get; set; }

        public  DbSet<User> Users { get; set; }

        public  DbSet<Task> Tasks { get; set; }

        public DbSet<Comment> Comments { get; set; }

        #endregion

        public TaskManagerDbContext()
        {
            
        }

        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Task>().ToTable("Tasks");
            modelBuilder.Entity<Comment>().ToTable("Comments");
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<Task>()
                .HasOne(t => t.Creator)
                .WithMany(u => u.CreatedTasks)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Task>()
                .HasOne(b => b.Contractor)
                .WithMany(a => a.ContractedTasks)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Comment>()
                .HasOne(c=>c.Task)
                .WithMany(t => t.TaskComments)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Creator)
                .WithMany(u => u.UserComments)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

        #region Create Sample Data
        public async void CreateSampleData()
        {
            #region Users
            var luke = new User
            {
                FirstName = "Luke",
                SecondaryName = "Anakin",
                Surname = "Skywalker",
                CreateDate = DateTime.Now,
                IsActual = true
            };

            var khan = new User
            {
                FirstName = "Han",
                SecondaryName = "***",
                Surname = "Solo",
            };

            var vader = new User
            {
                FirstName = "Darth Vader",
                SecondaryName = "The Force",
                Surname = "***",
              
            };

            var chewbacca = new User
            {
                FirstName = "Chewbacca",
                SecondaryName = "***",
                Surname = "***",
              
            };

            var yoda = new User
            {
                FirstName = "Magister Yoda",
                SecondaryName = "***",
                Surname = "***",
              
            };
            #endregion

            #region Tasks
            var usingForce = new Task
            {
                Title = "Use the Force, Luke",
                Description = "The jedi's force is the Force of Universe",
                Creator = yoda,
                Contractor = luke,
            };

            var lukeVsVader = new Task
            {
                Title = "Slay Darth Vader",
                Description = "I belive I can.",
                Creator = luke,
                Contractor = luke,
            };

            var turningToDarkSide = new Task
            {
                Title = "Turn Luke to the Dark Side",
                Description = "Dark side has the Death Star. And cookies.",
                Creator = vader,
                Contractor = vader,
            };
            #endregion

            #region Comments
            var comment0 = new Comment
            {
                Creator = yoda,
                Task = usingForce,
                Description = "Remember, a Jedi's strength flows from the Force. But beware: Anger, fear, aggression - the dark side, are they.",
            };

            var comment1 = new Comment
            {
                Creator = vader,
                Task = lukeVsVader,
                Description = "***Heavy Breathing***",
            };

            var comment2 = new Comment
            {
                Creator = vader,
                Task = lukeVsVader,
                Description = "Luke, I'm your father!",
            };

            var comment3 = new Comment
            {
                Creator = vader,
                Task        = turningToDarkSide,
                Description = "We got Death Star!",
            };

            var comment4 = new Comment
            {
                Creator = khan,
                Task = lukeVsVader,
                Description = "Let’s keep a little optimism here.",
            };

            var comment5 = new Comment
            {
                Creator = vader,
                Task = turningToDarkSide,
                Description = "Perhaps I can find new ways to motivate him.",
            };

            var comment6 = new Comment
            {
                Creator = chewbacca,
                Task = usingForce,
                Description = "RWGRRRAUGH",
            };

            var comment7 = new Comment
            {
                Creator = chewbacca,
                Task = usingForce,
                Description = "RRRAARRWHHGWWR",
            };

            var comment8 = new Comment
            {
                Creator = luke,
                Task = lukeVsVader,
                Description = "Soon I’ll be dead, and you with me.",
            };

            var comment9 = new Comment
            {
                Creator = vader,
                Task = lukeVsVader,
                Description = "Impressive. Most impressive. Obi-Wan has taught you well. ",
            };
            #endregion
            
            Users.AddRange(luke, vader, khan, chewbacca, yoda);
            Tasks.AddRange(usingForce, lukeVsVader, turningToDarkSide);
            Comments.AddRange(comment0, comment1, comment2, comment3,
                comment4, comment5, comment6, comment7, comment8, comment9);
            SaveChanges();
        }

        public TaskManagerDbContext GetContext()
        {
            return this;
        }
        #endregion
    }
}
