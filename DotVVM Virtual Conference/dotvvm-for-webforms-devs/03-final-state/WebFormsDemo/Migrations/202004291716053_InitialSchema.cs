namespace WebFormsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Color = c.String(maxLength: 4000),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaskCategoryEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryEntities", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.TaskEntities", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.TaskEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskCategoryEntities", "TaskId", "dbo.TaskEntities");
            DropForeignKey("dbo.TaskCategoryEntities", "CategoryId", "dbo.CategoryEntities");
            DropIndex("dbo.TaskCategoryEntities", new[] { "CategoryId" });
            DropIndex("dbo.TaskCategoryEntities", new[] { "TaskId" });
            DropTable("dbo.TaskEntities");
            DropTable("dbo.TaskCategoryEntities");
            DropTable("dbo.CategoryEntities");
        }
    }
}
