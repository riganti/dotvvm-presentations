using System.Collections.Generic;

namespace WebFormsDemo.Data
{
    public class CategoryEntity
    {

        public int Id { get; set; }

        public string Color { get; set; }

        public string Name { get; set; }

        public virtual ICollection<TaskCategoryEntity> Tasks { get; set; } = new List<TaskCategoryEntity>();

    }
}