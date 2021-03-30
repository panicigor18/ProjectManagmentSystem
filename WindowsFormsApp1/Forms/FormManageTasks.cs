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
    public partial class FormManageTasks : Form
    {
        DBBroker broker = new DBBroker();
        BindingList<Task> bindTasks;
        Project project;
        
        public FormManageTasks(Project project, User userLogged)
        {
            
            InitializeComponent();
            this.project = project;
            if (userLogged.Role == 1)
            {
                btnDeleteTask.Visible = false;
            }
            refresh();
            
        }

        private void refresh()
        {
            bindTasks = new BindingList<Task>(broker.returnAllTasksForProject(project));
            foreach (var task in bindTasks)
            {
                task.ProgressInPercentes = Convert.ToDecimal(task.Progress * 100);
                task.StatusTemp = (Status)task.Status;
            }
            foreach (DataGridViewRow row in dvgTasks.Rows)
            {
                row.Cells[1].Style.BackColor = Color.Red;
            }
            dvgTasks.DataSource = bindTasks;
            if (bindTasks.Count < 1)
            {
                btnDeleteTask.Enabled = false;
                btnUpdateTask.Enabled = false;
            }
            else
            {
                btnDeleteTask.Enabled = true;
                btnUpdateTask.Enabled = true;
            }
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCreateTask form = new FormCreateTask(project);
            form.ShowDialog();
            this.Show();
            refresh();
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            Task task;
            dvgTasks.Rows[dvgTasks.CurrentCell.RowIndex].Selected = true;
            try
            {
                task = (Task)dvgTasks.SelectedRows[0].DataBoundItem;
            }
            catch (Exception)
            {

                MessageBox.Show("Please select Task");
                
                return;
            }
            this.Hide();
            FormUpdateTask form = new FormUpdateTask(task);
            form.ShowDialog();
            this.Show();
            refresh();
        }

        private void FormManageTasks_Load(object sender, EventArgs e)
        {

        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            Task task;
            dvgTasks.Rows[dvgTasks.CurrentCell.RowIndex].Selected = true;
            try
            {
                task = (Task)dvgTasks.SelectedRows[0].DataBoundItem;
            }
            catch (Exception)
            {

                MessageBox.Show("Please select Task");
                
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Do you want to delete that task", "Delete task", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool pass=broker.removeTask(task);
                if (pass)
                {
                    MessageBox.Show("Task deleted successfully");
                }
                else
                {
                    MessageBox.Show("System can't delete task");
                }
                refresh();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            
        }
    }
}
