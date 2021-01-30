using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsDemo.Data;
using WebFormsDemo.Models;

namespace WebFormsDemo.Services
{
    public class TasksService
    {

        public List<TaskModel> GetTasks()
        {
            using (var db = new TasksDbContext())
            {
                return db.Tasks
                    .Select(t => new TaskModel()
                    {
                        Id = t.Id,
                        TaskName = t.Name,
                        Categories = t.Categories
                            .Select(c => new CategoryModel()
                            {
                                Id = c.CategoryId,
                                CategoryName = c.Category.Name,
                                CategoryColor = c.Category.Color
                            })
                    })
                    .ToList();
            }
        }

        public void AddTask(string taskName, List<int> categoryIds)
        {
            using (var db = new TasksDbContext())
            {
                var task = new TaskEntity()
                {
                    Name = taskName
                };
                foreach (var categoryId in categoryIds)
                {
                    task.Categories.Add(new TaskCategoryEntity()
                    {
                        CategoryId = categoryId
                    });
                }
                db.Tasks.Add(task);
                db.SaveChanges();
            }
        }
    }
}