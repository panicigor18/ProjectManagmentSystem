
namespace ProjectManagmentSystem.Forms
{
    partial class FormManageTasks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dvgTasks = new System.Windows.Forms.DataGridView();
            this.btnCreateTask = new System.Windows.Forms.Button();
            this.btnUpdateTask = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgTasks
            // 
            this.dvgTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgTasks.Location = new System.Drawing.Point(36, 108);
            this.dvgTasks.MultiSelect = false;
            this.dvgTasks.Name = "dvgTasks";
            this.dvgTasks.Size = new System.Drawing.Size(612, 228);
            this.dvgTasks.TabIndex = 0;
            // 
            // btnCreateTask
            // 
            this.btnCreateTask.Location = new System.Drawing.Point(36, 374);
            this.btnCreateTask.Name = "btnCreateTask";
            this.btnCreateTask.Size = new System.Drawing.Size(156, 23);
            this.btnCreateTask.TabIndex = 1;
            this.btnCreateTask.Text = "Create Task";
            this.btnCreateTask.UseVisualStyleBackColor = true;
            this.btnCreateTask.Click += new System.EventHandler(this.btnCreateTask_Click);
            // 
            // btnUpdateTask
            // 
            this.btnUpdateTask.Location = new System.Drawing.Point(257, 374);
            this.btnUpdateTask.Name = "btnUpdateTask";
            this.btnUpdateTask.Size = new System.Drawing.Size(156, 23);
            this.btnUpdateTask.TabIndex = 2;
            this.btnUpdateTask.Text = "Update Task";
            this.btnUpdateTask.UseVisualStyleBackColor = true;
            this.btnUpdateTask.Click += new System.EventHandler(this.btnUpdateTask_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.Location = new System.Drawing.Point(492, 374);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(156, 23);
            this.btnDeleteTask.TabIndex = 3;
            this.btnDeleteTask.Text = "Delete Task";
            this.btnDeleteTask.UseVisualStyleBackColor = true;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // FormManageTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 450);
            this.Controls.Add(this.btnDeleteTask);
            this.Controls.Add(this.btnUpdateTask);
            this.Controls.Add(this.btnCreateTask);
            this.Controls.Add(this.dvgTasks);
            this.Name = "FormManageTasks";
            this.Text = "FormManageTasks";
            this.Load += new System.EventHandler(this.FormManageTasks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgTasks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgTasks;
        private System.Windows.Forms.Button btnCreateTask;
        private System.Windows.Forms.Button btnUpdateTask;
        private System.Windows.Forms.Button btnDeleteTask;
    }
}