using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Runtime.Filters;
using DotVVM.Framework.ViewModel;
using WebFormsDemo.Models;
using WebFormsDemo.Services;

namespace WebFormsDemo.v2.ViewModels
{
    [Authorize]
    public class DefaultViewModel : SiteViewModel
    {
        private readonly TasksService tasksService;
        private readonly CategoriesService categoriesService;

        public string NewTaskName { get; set; }
        
        public List<int> SelectedCategoryIds { get; set; } = new List<int>();

        [Bind(Direction.ServerToClientFirstRequest)]
        public List<CategoryModel> Categories => categoriesService.GetCategories();
        
        public List<TaskModel> Tasks { get; set; }


        public DefaultViewModel(TasksService tasksService, CategoriesService categoriesService)
        {
            this.tasksService = tasksService;
            this.categoriesService = categoriesService;
        }

        public void OnAddTaskClick()
        {
            tasksService.AddTask(NewTaskName, SelectedCategoryIds);
            
            NewTaskName = string.Empty;
            SelectedCategoryIds.Clear();
        }

        public override Task PreRender()
        {
            Tasks = tasksService.GetTasks();

            return base.PreRender();
        }

    }
}

