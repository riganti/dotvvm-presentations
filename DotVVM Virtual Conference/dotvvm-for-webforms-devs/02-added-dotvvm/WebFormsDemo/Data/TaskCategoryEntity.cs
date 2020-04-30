namespace WebFormsDemo.Data
{
    public class TaskCategoryEntity
    {

        public int Id { get; set; }

        public int TaskId { get; set; }

        public TaskEntity Task { get; set; }

        public int CategoryId { get; set; }

        public CategoryEntity Category { get; set; }

    }
}