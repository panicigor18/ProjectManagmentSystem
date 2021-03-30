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
    public partial class Form1 : Form
    {
        DBBroker broker = new DBBroker();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            User user = broker.Login(username, password);
          
                if (user != null)
                {
                    if (user.Role == 0)
                    {
                        this.Hide();
                        FormAdmin forma = new FormAdmin(user);
                        forma.Text = "Welcome "+user.Name+" "+user.Surname;
                        forma.ShowDialog();
                        this.Show();
                    }
                    if (user.Role == 1)
                    {
                        this.Hide();
                        FormProjectsAdmin forma = new FormProjectsAdmin(user);
                        forma.Text = "Welcome " + user.Name + " " + user.Surname;
                        forma.ShowDialog();
                        this.Show();
                    }
                if (user.Role == 2)
                {
                    this.Hide();
                    FormDeveloperTasks forma = new FormDeveloperTasks(user);
                    forma.Text = "Welcome " + user.Name + " " + user.Surname;
                    forma.ShowDialog();
                    this.Show();
                }


            }
                else
                {
                    lblProslo.Text = "Some error with login";
                }
                //var studentName = context.Users.SqlQuery(@"select * from Users where Username='++' AND Password='igor'").FirstOrDefault<User>();
            }
        }
    }

