using ProjectManagmentSystem.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagmentSystem.Forms
{
    public partial class FormUpdateProject : Form
    {
        ProjectLogic projectLogic = new ProjectLogic();
        UsersLogic usersLogic = new UsersLogic();
        Project project;
        public FormUpdateProject(Project project)
        {
            InitializeComponent();
            txtProjectCode.Text = project.ProjectCode;
            txtName.Text = project.Name;
            cmbProjectManager.DataSource = usersLogic.getAllUsersWithRole(1);
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
            bool pass = projectLogic.updateProject(project);
            if (pass)
            {
                MessageBox.Show("Project updated successfully");
            }
            else
            {
                MessageBox.Show("System can't update project");
            }
            this.Close();
        }

        private void cmbProjectManager_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtName.BackColor = Color.White;
        }

        private void txtProjectCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
