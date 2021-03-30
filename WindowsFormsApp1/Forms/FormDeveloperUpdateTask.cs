using ProjectManagmentSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{
    public partial class FormDeveloperUpdateTask : Form
    {
        private DBBroker broker = new DBBroker();
        public Task task;
        public FormDeveloperUpdateTask(Task task)
        {
            this.task = task;
            InitializeComponent();
            cmbStatus.DataSource = Enum.GetValues(typeof(Status));
            cmbStatus.SelectedItem = (Status)task.Status;
            txtProgress.Text = (task.Progress * 100).ToString();
            tbxDescription.Text = task.Description;
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {

            task.Description = tbxDescription.Text;

            if (txtProgress.Text != "" && Convert.ToDecimal(txtProgress.Text) <= 100 && Convert.ToDecimal(txtProgress.Text) >= 0)
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

            task.Status = (int)cmbStatus.SelectedItem;
            bool pass = broker.updateTask(task);
            if (pass)
            {
                MessageBox.Show("Task updated succesfuly");
            }
            else
            {
                MessageBox.Show("System can't update task");
            }
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
            if (txtProgress.Text == "100")
            {
                cmbStatus.SelectedItem = Status.Finshed;
            }
            if (txtProgress.Text == "0")
            {
                cmbStatus.SelectedItem = Status.New;
            }
            if (txtProgress.Text != "" && Convert.ToDecimal(txtProgress.Text) < 100 && Convert.ToDecimal(txtProgress.Text) > 0)
            {
                cmbStatus.SelectedItem = Status.In_Progress;
            }
        }
    }
}
