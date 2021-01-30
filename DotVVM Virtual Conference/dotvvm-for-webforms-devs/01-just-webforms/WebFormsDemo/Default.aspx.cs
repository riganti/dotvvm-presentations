using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsDemo.Models;
using WebFormsDemo.Services;

namespace WebFormsDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadTasks();
            }
        }

        private void LoadTasks()
        {
            Tasks.DataSource = new TasksService().GetTasks();
            Tasks.DataBind();
        }

        private void LoadCategories()
        {
            NewTaskCategories.DataSource = new CategoriesService().GetCategories();
            NewTaskCategories.DataBind();
        }

        protected void AddTask_Click(object sender, EventArgs e)
        {
            var taskName = NewTaskName.Text;
            var categoryIds = NewTaskCategories.Items.OfType<ListItem>()
                .Where(i => i.Selected)
                .Select(i => int.Parse(i.Value))
                .ToList();

            new TasksService().AddTask(taskName, categoryIds);

            NewTaskName.Text = string.Empty;
            NewTaskCategories.ClearSelection();

            LoadTasks();
        }

        protected void Tasks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var innerRepeater = (Repeater)e.Item.FindControl("TaskCategories");
                var taskModel = (TaskModel)e.Item.DataItem;
                innerRepeater.DataSource = taskModel.Categories;
                innerRepeater.DataBind();
            }
        }

    }
}