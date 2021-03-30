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

namespace ProjectManagmentSystem.Forms
{
    
    public partial class FormUpdateTask : Form
    {
        BindingList<User> listUsers;
        UsersLogic usersLogic = new UsersLogic();
        TaskLogic taskLogic = new TaskLogic();
        public Task task;
        public FormUpdateTask(Task task)
        {
            InitializeComponent();
            this.task = task;
            cmbStatus.DataSource = Enum.GetValues(typeof(Status));
            listUsers = new BindingList<User>((IList<User>)usersLogic.getAllUsersWithRole(2));
            
            cmbDevelopers.Items.Insert(0, "");
            foreach (User user in listUsers)
            {
                
                cmbDevelopers.Items.Add(user);
                
         
            }
            int i = getCurrentIndex(listUsers);
            cmbDevelopers.SelectedIndex = i;
            
            cmbDevelopers.SelectedItem = task.Assignee;
            
            dtpDeadline.Value = (DateTime)task.Deadline;
            cmbStatus.SelectedItem = (Status)task.Status;
            txtProgress.Text = (task.Progress*100).ToString();
            tbxDescription.Text = task.Description;
        }

        private int getCurrentIndex(BindingList<User> listUsers)
        {
            
            int index = 0;
            foreach (var user in listUsers)
            {
                if (user.Username != task.Assignee)
                {
                    index++;
                }
                else
                {
                    return ++index;
                }
            }
            return index; 
            
        }

        private void FormUpdateTask_Load(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Status status;
            Enum.TryParse<Status>(cmbStatus.SelectedValue.ToString(), out status);
            if (status == Status.Finshed)
            {
                txtProgress.Text = "100";
            }
            if (status == Status.New)
            {
                txtProgress.Text = "0";
            }
        }

        private void txtProgress_TextChanged(object sender, EventArgs e)
        {
            txtProgress.BackColor = Color.White;
            if (txtProgress.Text == "100")
            {
                cmbStatus.SelectedItem = Status.Finshed;
            }
            if (txtProgress.Text == "0")
            {
                cmbStatus.SelectedItem = Status.New;
            }
            if(txtProgress.Text!=""&&Decimal.Parse(txtProgress.Text)<100&& Decimal.Parse(txtProgress.Text) > 0)
            {
                cmbStatus.SelectedItem = Status.In_Progress;
            }
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            if (cmbDevelopers.SelectedItem.ToString() != ""&&cmbDevelopers.SelectedItem.ToString()!=null)
            {
                task.Assignee = ((User)cmbDevelopers.SelectedItem).Username;
            }
            else
            {
                task.Assignee = "";
            }
            task.Description = tbxDescription.Text;
            task.Deadline = dtpDeadline.Value;
            if(txtProgress.Text!=""&& Convert.ToDecimal(txtProgress.Text) <= 100&& Convert.ToDecimal(txtProgress.Text) >= 0)
            {
                task.Progress = (Convert.ToDecimal(txtProgress.Text) / 100);
            }
            else
            {
                MessageBox.Show("Progress must be between 0 and 100 percent");
                txtProgress.BackColor = Color.Red;
                txtProgress.Focus();
                return;
            }
            
            task.Status =(int)cmbStatus.SelectedItem;
            bool pass = taskLogic.updateTask(task);
            if (pass)
            {
                MessageBox.Show("Task updated succesfuly");
            }
            else
            {
                MessageBox.Show("System can't update task");
            }
            this.Close();
        }
    }
}
