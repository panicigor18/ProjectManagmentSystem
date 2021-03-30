
namespace WindowsFormsApp1.Forms
{
    partial class FormDeveloperTasks
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
            this.btnUpdateTask = new System.Windows.Forms.Button();
            this.dvgTasks = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dvgTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdateTask
            // 
            this.btnUpdateTask.Location = new System.Drawing.Point(468, 41);
            this.btnUpdateTask.Name = "btnUpdateTask";
            this.btnUpdateTask.Size = new System.Drawing.Size(183, 39);
            this.btnUpdateTask.TabIndex = 6;
            this.btnUpdateTask.Text = "Update Task";
            this.btnUpdateTask.UseVisualStyleBackColor = true;
            // 
            // dvgTasks
            // 
            this.dvgTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgTasks.Location = new System.Drawing.Point(39, 111);
            this.dvgTasks.Name = "dvgTasks";
            this.dvgTasks.Size = new System.Drawing.Size(612, 228);
            this.dvgTasks.TabIndex = 5;
            // 
            // FormDeveloperTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 400);
            this.Controls.Add(this.btnUpdateTask);
            this.Controls.Add(this.dvgTasks);
            this.Name = "FormDeveloperTasks";
            this.Text = "FormDeveloperTasks";
            ((System.ComponentModel.ISupportInitialize)(this.dvgTasks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateTask;
        private System.Windows.Forms.DataGridView dvgTasks;
    }
}