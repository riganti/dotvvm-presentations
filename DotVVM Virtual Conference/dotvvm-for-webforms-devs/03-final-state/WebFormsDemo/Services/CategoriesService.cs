using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsDemo.Data;
using WebFormsDemo.Models;

namespace WebFormsDemo.Services
{
    public class CategoriesService
    {

        public List<CategoryModel> GetCategories()
        {
            using (var db = new TasksDbContext())
            {
                return db.Categories
                    .Select(c => new CategoryModel()
                    {
                        Id = c.Id,
                        CategoryColor = c.Color,
                        CategoryName = c.Name
                    })
                    .ToList();
            }
        }

    }
}