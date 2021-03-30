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
using DataLayer;
namespace ProjectManagmentSystem.Forms
{
    public partial class FormCreateProject : Form
    {
        UsersLogic userLogic = new UsersLogic();
        ProjectLogic projectLogic = new ProjectLogic();
        User userLogged;
        public FormCreateProject(User userLogged)
        {
            InitializeComponent();
            this.userLogged = userLogged;
            if (userLogged.Role == 0) { 
                
                BindingList<User> projectManagers= new  BindingList<User>((List<User>)userLogic.getAllUsersWithRole(1));
                
                    
               
                cmbProjectManager.DataSource = projectManagers;
            }
            else
            {
                cmbProjectManager.Visible = false;
                label3.Visible = false;
            }
            txtProjectCode.Text = projectLogic.randomCodeForProjectCode();
        }

        

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            Project project = new Project();
            project.ProjectCode = txtProjectCode.Text;
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
            switch (userLogged.Role)
            {
                case 0:
                    project.ProjectManager = cmbProjectManager.SelectedItem.ToString();
                    project.User = (User)cmbProjectManager.SelectedItem;
                    break;
                case 1:
                    project.ProjectManager = userLogged.Username;
                    project.User = userLogged;
                    break;
                default:
                    MessageBox.Show("You don't have permision create Project");
                    return;
                    
            }
            
            bool pass= projectLogic.createProject(project);
            if (pass)
            {
                MessageBox.Show("Project saved successfully");
            }
            else
            {
                MessageBox.Show("System can't save project");
            }
            refreshInputs();
        }

        private void refreshInputs()
        {
            txtProjectCode.Text = projectLogic.randomCodeForProjectCode();
            txtName.BackColor = Color.White;
            txtName.Text = "";
        }
    }
}
