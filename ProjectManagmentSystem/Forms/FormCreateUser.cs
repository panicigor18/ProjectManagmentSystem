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
    public partial class FormCreateUser : Form
    {
        UsersLogic usersLogic = new UsersLogic();
        bool initalCreate;
        public FormCreateUser(bool init)
        {
            InitializeComponent();
            initalCreate = init;
            
            cmbRole.DataSource = Enum.GetValues(typeof(Role));
            if (initalCreate == true)
            {
                cmbRole.SelectedIndex = 0;
                cmbRole.Enabled = false;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            User user = new User();
           
            if (txtUsernam.Text != "" )
            {
                bool UsernameUnique = usersLogic.isUsernameUnique(txtUsernam.Text);
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
                    string ErrorMessage;
                    if (usersLogic.ValidatePassword(txtPasword.Text, out ErrorMessage))
                    {
                        user.Password = txtPasword.Text;
                    }
                    else
                    {
                        MessageBox.Show(ErrorMessage);
                        return;
                    }
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
            bool pass = usersLogic.createUser(user);
            if (pass)
            {
                MessageBox.Show("User saved successfully");
                if (initalCreate)
                {
                    this.Hide();
                    new Form1().ShowDialog();
                }
                
                
            }
            else
            {
                MessageBox.Show("System can't save user");
                
            }
            refreshInputs();
        }

        private void refreshInputs()
        {
            txtUsernam.Text = "";
            txtPasword.Text = "";
            txtConfirmPassword.Text = "";
            txtEmail.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            cmbRole.SelectedIndex = 0;
        }
    }
}
