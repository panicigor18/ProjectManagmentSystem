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
    public partial class FormUsersAdmin : Form
    {
        UsersLogic usersLogic = new UsersLogic();
        ProjectLogic projectLogic = new ProjectLogic();
        BindingList<User> bindUsers;
        public FormUsersAdmin(User user1)
        {
            InitializeComponent();
            refreshGrid();
        }

        private void refreshGrid()
        {
            bindUsers = new BindingList<User>(usersLogic.reaturnAllUsers());
            foreach (User user in bindUsers)
            {
                user.rolee = (Role)user.Role;
            }
            dgvUsers.DataSource=bindUsers;
            if (bindUsers.Count < 1)
            {
                btnDeleteUser.Enabled = false;
                btnUpdateUser.Enabled = false;
            }
            else
            {
                btnDeleteUser.Enabled = true;
                btnUpdateUser.Enabled = true;
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCreateUser form = new FormCreateUser(false);
            form.ShowDialog();
            this.Show();
            refreshGrid();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            User user;
            dgvUsers.Rows[dgvUsers.CurrentCell.RowIndex].Selected = true;
            try
            {
                user = (User)dgvUsers.SelectedRows[0].DataBoundItem;
            }
            catch (Exception)
            {

                MessageBox.Show("Please select Task");

                return;
            }
            DialogResult dialogResult = MessageBox.Show("Do you want to delete that user", "Delete user", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var projectsForPM = projectLogic.returnAllProjectForPM(user);
                if (projectsForPM.Count > 0)
                {
                    MessageBox.Show($"You must delete all project where {user} is Project Manager or reassign to another Project Manager and then you can delete {user}");
                    return;
                }

                bool pass=usersLogic.removeUser(user);
                if (pass)
                {
                    MessageBox.Show("User deleted successfully");
                }
                else
                {
                    MessageBox.Show("System can't delete user");
                }
                refreshGrid();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
           
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            User user;
            dgvUsers.Rows[dgvUsers.CurrentCell.RowIndex].Selected = true;
            try
            {
                user = (User)dgvUsers.SelectedRows[0].DataBoundItem;
            }
            catch (Exception)
            {

                MessageBox.Show("Please select User");

                return;
            }
            this.Hide();
            FormUpdateUser form = new FormUpdateUser(user);
            form.ShowDialog();
            this.Show();
            refreshGrid();
        }
    }
}
