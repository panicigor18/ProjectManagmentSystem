using ProjectManagmentSystem.BusinessLayer;
using ProjectManagmentSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagmentSystem
{
    public partial class FormProjectsAdmin : Form
    {
        ProjectLogic projectLogic = new ProjectLogic();
        BindingList<Project> bindProjects;
        User userLogged;
        public FormProjectsAdmin(User user1)
        {
            InitializeComponent();
            userLogged=user1;
            switch (user1.Role)
            {
                case 0:
                    refreshAdmin();
                    break;
                case 1:
                    refreshProjectManager();
                    break;
                default:
                    break;
            }

            
            
            

           
               
        }

        private void refreshProjectManager()
        {
            bindProjects = new BindingList<Project>(projectLogic.returnAllProjectForPM(userLogged));
            btnDeleteProject.Visible = false;
            btnUpdateProject.Visible = false;
            dvgProjects.DataSource = bindProjects;
            if (bindProjects.Count < 1)
            {
                
                btnManageTasks.Enabled = false;
               
            }
            else
            {
                
                btnManageTasks.Enabled = true;
                
            }
        }

        private void refreshAdmin()
        {
            bindProjects =  new BindingList<Project>(projectLogic.returnAllProject());
            
            dvgProjects.DataSource = bindProjects;
            if (bindProjects.Count < 1)
            {
                btnDeleteProject.Enabled = false;
                btnManageTasks.Enabled = false;
                btnUpdateProject.Enabled = false;
            }
            else
            {
                btnDeleteProject.Enabled = true;
                btnManageTasks.Enabled = true;
                btnUpdateProject.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Project project;
            dvgProjects.Rows[dvgProjects.CurrentCell.RowIndex].Selected = true;
            try
            {
                project = (Project)dvgProjects.SelectedRows[0].DataBoundItem;
            }
            catch (Exception)
            {

                MessageBox.Show("Please select Project");

                return;
            }
            this.Hide();
            FormUpdateProject form = new FormUpdateProject(project);
            form.ShowDialog();
            this.Show();
            refreshAdmin();
        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to delete that project", "Delete project", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                Project project;
                dvgProjects.Rows[dvgProjects.CurrentCell.RowIndex].Selected = true;
                try
                {
                    project = (Project)dvgProjects.SelectedRows[0].DataBoundItem;
                }
                catch (Exception)
                {

                    MessageBox.Show("Please select Project");

                    return;
                }
                bool pass=projectLogic.removeProject(project);
                if (pass)
                {
                    MessageBox.Show("Project deleted successfully");
                }
                else
                {
                    MessageBox.Show("System can't delete project");
                }
               
                refreshAdmin();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            
        }

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCreateProject form = new FormCreateProject(userLogged);
            form.ShowDialog();
            this.Show();
            switch (userLogged.Role)
            {
                case 0:
                    refreshAdmin();
                    break;
                case 1:
                    refreshProjectManager();
                    break;
                default:
                    break;
            }
        }

        private void btnManageTasks_Click(object sender, EventArgs e)
        {
            Project project=new Project();
            dvgProjects.Rows[dvgProjects.CurrentCell.RowIndex].Selected = true;
            try
            {
                project = (Project)dvgProjects.SelectedRows[0].DataBoundItem;
            }
            catch (Exception)
            {

                MessageBox.Show("Please select Project");
                
                return;
            }
            this.Hide();
            FormManageTasks form = new FormManageTasks(project,userLogged);
            form.ShowDialog();
            this.Show();
            switch (userLogged.Role)
            {
                case 0:
                    refreshAdmin();
                    break;
                case 1:
                    refreshProjectManager();
                    break;
                default:
                    break;
            }
        }
    }
}
