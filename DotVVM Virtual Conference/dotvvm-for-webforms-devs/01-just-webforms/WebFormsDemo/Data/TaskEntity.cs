using System.Collections.Generic;

namespace WebFormsDemo.Data
{
    public class TaskEntity
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<TaskCategoryEntity> Categories { get; set; } = new List<TaskCategoryEntity>();

    }
}