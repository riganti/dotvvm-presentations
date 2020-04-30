using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebFormsDemo.Data
{
    public class TasksDbContext : DbContext
    {

        public TasksDbContext() : base("DB")
        {
        }


        public DbSet<TaskEntity> Tasks { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<TaskCategoryEntity> TaskCategories { get; set; }

    }
}