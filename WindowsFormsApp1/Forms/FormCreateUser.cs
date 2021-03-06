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
    public partial class FormCreateUser : Form
    {
        DBBroker broker = new DBBroker();
        public FormCreateUser()
        {
            InitializeComponent();
            cmbRole.DataSource = Enum.GetValues(typeof(Role));
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            User user = new User();

            if (txtUsernam.Text != "")
            {
                bool UsernameUnique = broker.isUsernameUnique(txtUsernam.Text);
                if (UsernameUnique)
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
            user.Role = (int)cmbRole.SelectedItem;
            bool pass = broker.createUser(user);
            if (pass)
            {
                MessageBox.Show("User saved successfully");
                return;
            }
            else
            {
                MessageBox.Show("System can't save user");
                return;
            }

        }
    }
}
