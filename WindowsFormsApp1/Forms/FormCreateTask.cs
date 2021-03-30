using ProjectManagmentSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{
    public partial class FormCreateTask : Form
    {
        DBBroker broker = new DBBroker();
        Project project = new Project();
        BindingList<User> listUsers;
        public FormCreateTask(Project project)
        {
            InitializeComponent();
            this.project = project;
            listUsers = new BindingList<User>(broker.getAllUsersWithRole(2));
            foreach (User user in listUsers)
            {
                cmbDevelopers.Items.Add(user);
            }

            cmbDevelopers.Items.Insert(0, "");

            dtpDeadline.MinDate = DateTime.Today;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProjectManagmentSystem.Task task = new ProjectManagmentSystem.Task();
            task.Project = project;
            task.ProjectCode = project.ProjectCode;
            // task.User = (User)cmbDevelopers.SelectedItem;
            if (cmbDevelopers.SelectedItem != null && cmbDevelopers.SelectedItem.ToString() != "")
            {
                task.Assignee = ((User)cmbDevelopers.SelectedItem).Username;
            }
            else
            {
                task.Assignee = "";
            }
            task.Description = tbxDescription.Text;
            task.Deadline = dtpDeadline.Value;
            task.Progress = 0;
            task.Status = 0;
            task.TaskID = broker.returnTaskId();
            project.Tasks.Add(task);

            bool pass = broker.createTask(task);
            if (pass)
            {
                MessageBox.Show("Task added succesfuly");
            }
            else
            {
                MessageBox.Show("System can't save task");
            }
        }
    }
}
