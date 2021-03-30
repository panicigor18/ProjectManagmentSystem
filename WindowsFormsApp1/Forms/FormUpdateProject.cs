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
    public partial class FormUpdateProject : Form
    {
        DBBroker broker = new DBBroker();
        Project project;
        public FormUpdateProject(Project project)
        {
            InitializeComponent();
            txtProjectCode.Text = project.ProjectCode;
            txtName.Text = project.Name;
            cmbProjectManager.DataSource = broker.getAllUsersWithRole(1);
            this.project = project;
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            project.Name = txtName.Text;
            if (txtName.Text != "")
            {
                project.Name = txtName.Text;
            }
            else
            {
                MessageBox.Show("Please enter project Name");
                txtName.Focus();
                txtName.BackColor = Color.Red;
                return;
            }

            project.User = (User)cmbProjectManager.SelectedItem;
            project.ProjectManager = project.User.Username;
            bool pass = broker.updateProject(project);
            if (pass)
            {
                MessageBox.Show("Project updated successfully");
            }
            else
            {
                MessageBox.Show("System can't update project");
            }
        }
    }
}
