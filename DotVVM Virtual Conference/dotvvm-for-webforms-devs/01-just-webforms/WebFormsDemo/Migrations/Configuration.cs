namespace WebFormsDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebFormsDemo.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<WebFormsDemo.Data.TasksDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebFormsDemo.Data.TasksDbContext context)
        {
            context.Categories.AddOrUpdate(new CategoryEntity()
            {
                Name = "Top priority",
                Color = "primary"
            });
            context.Categories.AddOrUpdate(new CategoryEntity()
            {
                Name = "Personal",
                Color = "secondary"
            });
            context.Categories.AddOrUpdate(new CategoryEntity()
            {
                Name = "Project A",
                Color = "warning"
            });
            context.Categories.AddOrUpdate(new CategoryEntity()
            {
                Name = "Project B",
                Color = "danger"
            });
        }
    }
}
