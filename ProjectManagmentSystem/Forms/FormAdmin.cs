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
    public partial class FormAdmin : Form
    {
        public User user1;
        public FormAdmin(User user)
        {
            user1=user;
            InitializeComponent();
            this.FormClosed += MyClosedHandler;
        }

        private void MyClosedHandler(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            
            form.ShowDialog();
            
        }

        private void btnProjects_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProjectsAdmin forma = new FormProjectsAdmin(user1);
            forma.ShowDialog();
            this.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormUsersAdmin forma = new FormUsersAdmin(user1);
            forma.ShowDialog();
            this.Show();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }


    }
}
