
namespace WindowsFormsApp1.Forms
{
    partial class FormProjectsAdmin
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
            this.btnManageTasks = new System.Windows.Forms.Button();
            this.dvgProjects = new System.Windows.Forms.DataGridView();
            this.btnDeleteProject = new System.Windows.Forms.Button();
            this.btnUpdateProject = new System.Windows.Forms.Button();
            this.btnCreateProject = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgProjects)).BeginInit();
            this.SuspendLayout();
            // 
            // btnManageTasks
            // 
            this.btnManageTasks.Location = new System.Drawing.Point(289, 390);
            this.btnManageTasks.Name = "btnManageTasks";
            this.btnManageTasks.Size = new System.Drawing.Size(193, 41);
            this.btnManageTasks.TabIndex = 9;
            this.btnManageTasks.Text = "Manage Tasks";
            this.btnManageTasks.UseVisualStyleBackColor = true;
            // 
            // dvgProjects
            // 
            this.dvgProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgProjects.Location = new System.Drawing.Point(12, 128);
            this.dvgProjects.Name = "dvgProjects";
            this.dvgProjects.Size = new System.Drawing.Size(762, 218);
            this.dvgProjects.TabIndex = 8;
            // 
            // btnDeleteProject
            // 
            this.btnDeleteProject.Location = new System.Drawing.Point(591, 390);
            this.btnDeleteProject.Name = "btnDeleteProject";
            this.btnDeleteProject.Size = new System.Drawing.Size(183, 41);
            this.btnDeleteProject.TabIndex = 7;
            this.btnDeleteProject.Text = "Delete Project";
            this.btnDeleteProject.UseVisualStyleBackColor = true;
            // 
            // btnUpdateProject
            // 
            this.btnUpdateProject.Location = new System.Drawing.Point(11, 390);
            this.btnUpdateProject.Name = "btnUpdateProject";
            this.btnUpdateProject.Size = new System.Drawing.Size(183, 41);
            this.btnUpdateProject.TabIndex = 6;
            this.btnUpdateProject.Text = "Update Project";
            this.btnUpdateProject.UseVisualStyleBackColor = true;
            // 
            // btnCreateProject
            // 
            this.btnCreateProject.Location = new System.Drawing.Point(11, 23);
            this.btnCreateProject.Name = "btnCreateProject";
            this.btnCreateProject.Size = new System.Drawing.Size(183, 83);
            this.btnCreateProject.TabIndex = 5;
            this.btnCreateProject.Text = "Create new Project";
            this.btnCreateProject.UseVisualStyleBackColor = true;
            // 
            // FormProjectsAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnManageTasks);
            this.Controls.Add(this.dvgProjects);
            this.Controls.Add(this.btnDeleteProject);
            this.Controls.Add(this.btnUpdateProject);
            this.Controls.Add(this.btnCreateProject);
            this.Name = "FormProjectsAdmin";
            this.Text = "FormProjectsAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.dvgProjects)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageTasks;
        private System.Windows.Forms.DataGridView dvgProjects;
        private System.Windows.Forms.Button btnDeleteProject;
        private System.Windows.Forms.Button btnUpdateProject;
        private System.Windows.Forms.Button btnCreateProject;
    }
}