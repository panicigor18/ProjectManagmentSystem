
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using DataLayer;
using ProjectManagmentSystem.BusinessLayer;

namespace ProjectManagmentSystem.Forms
{
    
    public partial class FormCreateTask : Form
    {
        UsersLogic usersLogic = new UsersLogic();
        TaskLogic taskLogic = new TaskLogic();
        Project project = new Project();
        BindingList<User> listUsers;
        public FormCreateTask(Project project)
        {
            InitializeComponent();
            this.project = project;
            listUsers = new BindingList<User>((IList<User>)usersLogic.getAllUsersWithRole(2));
            foreach (User user in listUsers)
            {
                cmbDevelopers.Items.Add(user);
            }

            cmbDevelopers.Items.Insert(0, "");
            
            dtpDeadline.MinDate = DateTime.Today;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task task = new Task();
            task.Project = project;
            task.ProjectCode = project.ProjectCode;
            // task.User = (User)cmbDevelopers.SelectedItem;
            if (cmbDevelopers.SelectedItem != null&& cmbDevelopers.SelectedItem.ToString() != "")
            {
                task.Assignee = ((User)cmbDevelopers.SelectedItem).Username;
            }
            else
            {
                task.Assignee = "";
            }
            if (tbxDescription.Text == "")
            {
                MessageBox.Show("Description must have text");
                return;
            }
            task.Description = tbxDescription.Text;
            task.Deadline = dtpDeadline.Value;
            task.Progress = 0;
            task.Status = 0;
            task.TaskID = taskLogic.returnTaskId();
            project.Tasks.Add(task);
            
            bool pass = taskLogic.createTask(task);
            if (pass)
            {
                MessageBox.Show("Task added succesfuly");
            }
            else
            {
                MessageBox.Show("System can't save task");
            }
            refreshInputs();
        }

        private void refreshInputs()
        {
            dtpDeadline.Value = dtpDeadline.MinDate;
            tbxDescription.Text = "";
        }
    }
}
