using ProjectManagmentSystem.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using DataLayer;
namespace ProjectManagmentSystem.Forms
{
    public partial class FormDeveloperTasks : Form
    {
        UsersLogic usersLogic = new UsersLogic();
        TaskLogic taskLogic = new TaskLogic();
        BindingList<Task> bindTasks;
        User user;
        public FormDeveloperTasks(User user)
        {
            InitializeComponent();
            this.user = user;
            refresh();
        }

        private void refresh()
        {
            bindTasks = new BindingList<Task>(usersLogic.returnAllTasksForUser(user));
            foreach (var task in bindTasks)
            {
                task.ProgressInPercentes = Convert.ToDecimal(task.Progress * 100);
                task.StatusTemp = (Status)task.Status;
            }
            dvgTasks.DataSource = bindTasks;
            dvgTasks.ReadOnly = true;
           
            if (bindTasks.Count < 1)
            {
                
                btnUpdateTask.Enabled = false;
            }
            else
            {
               
                btnUpdateTask.Enabled = true;
            }
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            Task task;
            dvgTasks.Rows[dvgTasks.CurrentCell.RowIndex].Selected = true;
            try
            {
                task = (Task)dvgTasks.SelectedRows[0].DataBoundItem;
            }
            catch (Exception)
            {

                MessageBox.Show("Please select Task");

                return;
            }
            if (task.Assignee == "")
            {
                MessageBox.Show("You can't change task which is not assitgned to you");
                return;
            }
            this.Hide();
            FormDeveloperUpdateTask form = new FormDeveloperUpdateTask(task);
            form.ShowDialog();
            this.Show();
            refresh();
        }
    }
}
