using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormsDemo.Models
{
    public class TaskModel
    {

        public string TaskName { get; set; }

        public IEnumerable<CategoryModel> Categories { get; set; }
        public int Id { get; internal set; }
    }
}