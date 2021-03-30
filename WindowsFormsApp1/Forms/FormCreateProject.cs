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
    public partial class FormCreateProject : Form
    {
        DBBroker broker = new DBBroker();
        User userLogged;
        public FormCreateProject(User userLogged)
        {
            InitializeComponent();
            this.userLogged = userLogged;
            if (userLogged.Role == 0) { cmbProjectManager.DataSource = broker.getAllUsersWithRole(1); }
            else
            {
                cmbProjectManager.Visible = false;
                label3.Visible = false;
            }
            txtProjectCode.Text = randomCodeForProjectCode();
        }

        private string randomCodeForProjectCode()
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";
            letters = letters.ToUpper();

            string random = "";
            bool pass = false;
            while (!pass)
            {
                random = "";
                Random rn = new Random();
                for (int i = 0; i < 3; i++)
                {
                    random += letters[rn.Next(0, 25)] + "" + (rn.Next(0, 9));
                }
                Project project = broker.IsProjectCodeUnique(random);
                if (project == null)
                {
                    pass = true;
                }

            }


            return random;
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

            bool pass = broker.createProject(project);
            if (pass)
            {
                MessageBox.Show("Project saved successfully");
            }
            else
            {
                MessageBox.Show("System can't save project");
            }
        }
    }
}
