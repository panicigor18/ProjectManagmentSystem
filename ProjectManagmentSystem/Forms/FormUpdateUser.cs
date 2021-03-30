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
    public partial class FormUpdateUser : Form
    {
        public string oldUsername;
        private DBBroker broker = new DBBroker();
        public User user;
        public FormUpdateUser(User user)
        {
            InitializeComponent();
            this.user = user;
            oldUsername = user.Username;
            txtUsernam.Text = user.Username;
            txtPasword.Text = user.Password;
            txtConfirmPassword.Text = user.Password;
            txtEmail.Text = user.Email;
            txtName.Text = user.Name;
            txtSurname.Text = user.Surname;
            cmbRole.DataSource = Enum.GetValues(typeof(Role));
            cmbRole.SelectedItem = (Role)user.Role;
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (txtUsernam.Text != "")
            {
                bool UsernameUnique = broker.isUsernameUnique(txtUsernam.Text);
                if (UsernameUnique||txtUsernam.Text==oldUsername)
                {
                    user.Username = txtUsernam.Text;
                }
                else
                {
                    MessageBox.Show("Username is not unique");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Username is empty");
                return;
            }
            if (txtPasword.Text != "")
            {
                if (txtPasword.Text == txtConfirmPassword.Text)
                {
                    user.Password = txtPasword.Text;
                }
                else
                {
                    MessageBox.Show("Passwords must be same");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Password is empty");
                return;
            }
            if (txtEmail.Text != "")
            {
                user.Email = txtEmail.Text;
            }
            else
            {
                MessageBox.Show("Email is empty");
                return;
            }
            if (txtName.Text != "")
            {
                user.Name = txtName.Text;
            }
            else
            {
                MessageBox.Show("Name is empty");
                return;
            }
            if (txtSurname.Text != "")
            {
                user.Surname = txtSurname.Text;
            }
            else
            {
                MessageBox.Show("Surname is empty");
                return;
            }
            if (cmbRole.SelectedItem != null)
            {
                user.Role = (int)cmbRole.SelectedItem;
            }
            else
            {
                MessageBox.Show("Please select a role");
                return;
            }
            
            bool pass = broker.updateUser(user,oldUsername);
            //change username in tasks
            if (pass)
            {
                MessageBox.Show("User updated successfully");
                return;
            }
            else
            {
                MessageBox.Show("System can't update user");
                return;
            }
        }
    }
}
