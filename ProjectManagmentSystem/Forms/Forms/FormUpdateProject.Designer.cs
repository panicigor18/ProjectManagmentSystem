
namespace ProjectManagmentSystem.Forms
{
    partial class FormUpdateProject
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
            this.btnACreateProject = new System.Windows.Forms.Button();
            this.cmbProjectManager = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtProjectCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnACreateProject
            // 
            this.btnACreateProject.Location = new System.Drawing.Point(20, 206);
            this.btnACreateProject.Name = "btnACreateProject";
            this.btnACreateProject.Size = new System.Drawing.Size(279, 49);
            this.btnACreateProject.TabIndex = 13;
            this.btnACreateProject.Text = "Update Project";
            this.btnACreateProject.UseVisualStyleBackColor = true;
            this.btnACreateProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // cmbProjectManager
            // 
            this.cmbProjectManager.FormattingEnabled = true;
            this.cmbProjectManager.Location = new System.Drawing.Point(133, 138);
            this.cmbProjectManager.Name = "cmbProjectManager";
            this.cmbProjectManager.Size = new System.Drawing.Size(166, 21);
            this.cmbProjectManager.TabIndex = 12;
            this.cmbProjectManager.SelectedIndexChanged += new System.EventHandler(this.cmbProjectManager_SelectedIndexChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(133, 86);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(166, 20);
            this.txtName.TabIndex = 11;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtProjectCode
            // 
            this.txtProjectCode.Location = new System.Drawing.Point(133, 32);
            this.txtProjectCode.Name = "txtProjectCode";
            this.txtProjectCode.ReadOnly = true;
            this.txtProjectCode.Size = new System.Drawing.Size(166, 20);
            this.txtProjectCode.TabIndex = 10;
            this.txtProjectCode.TextChanged += new System.EventHandler(this.txtProjectCode_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Project Manager";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Project code:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // FormUpdateProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 450);
            this.Controls.Add(this.btnACreateProject);
            this.Controls.Add(this.cmbProjectManager);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtProjectCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormUpdateProject";
            this.Text = "FormUpdateProject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnACreateProject;
        private System.Windows.Forms.ComboBox cmbProjectManager;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtProjectCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}