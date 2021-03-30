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
using DataLayer;
namespace ProjectManagmentSystem
{
    public partial class Form1 : Form
    {
        UsersLogic usersLogic = new UsersLogic();
        ProjectLogic projectLogic = new ProjectLogic();
        public Form1()
        {
            InitializeComponent();
            if (usersLogic.reaturnAllUsers().Count == 0)
            {
                bool init = true;
                new FormCreateUser(init).ShowDialog();
                this.Hide();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (usersLogic.reaturnAllUsers().Count == 0)
            {
                bool init = true;
                new FormCreateUser(init).ShowDialog();
                this.Hide();
            }
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            User user = usersLogic.Login(username, password);
                
          
                if (user != null)
                {
                    if (user.Role == 0)
                    {
                        this.Hide();
                        FormAdmin forma = new FormAdmin(user);
                        forma.Text = "Welcome "+user.Name+" "+user.Surname;
                        forma.ShowDialog();
                        this.Show();
                    this.Refresh();
                    }
                    if (user.Role == 1)
                    {
                        this.Hide();
                        FormProjectsAdmin forma = new FormProjectsAdmin(user);
                        forma.Text = "Welcome " + user.Name + " " + user.Surname;
                        forma.ShowDialog();
                        this.Show();
                    this.Refresh();
                }
                if (user.Role == 2)
                {
                    this.Hide();
                    FormDeveloperTasks forma = new FormDeveloperTasks(user);
                    forma.Text = "Welcome " + user.Name + " " + user.Surname;
                    forma.ShowDialog();
                    this.Show();
                    this.Refresh();

                }


            }
                else
                {
                MessageBox.Show("Wrong username or password");
                return;
            }
                //var studentName = context.Users.SqlQuery(@"select * from Users where Username='++' AND Password='igor'").FirstOrDefault<User>();
            }
        }
    }

