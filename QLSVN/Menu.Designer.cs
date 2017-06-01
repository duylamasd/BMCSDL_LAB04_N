namespace QLSVN
{
    partial class Menu
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
            this.classManager = new System.Windows.Forms.Button();
            this.scoreManager = new System.Windows.Forms.Button();
            this.employeeManage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // classManager
            // 
            this.classManager.Location = new System.Drawing.Point(78, 58);
            this.classManager.Name = "classManager";
            this.classManager.Size = new System.Drawing.Size(75, 23);
            this.classManager.TabIndex = 0;
            this.classManager.Text = "Classes";
            this.classManager.UseVisualStyleBackColor = true;
            this.classManager.Click += new System.EventHandler(this.classManager_Click);
            // 
            // scoreManager
            // 
            this.scoreManager.Location = new System.Drawing.Point(78, 129);
            this.scoreManager.Name = "scoreManager";
            this.scoreManager.Size = new System.Drawing.Size(75, 23);
            this.scoreManager.TabIndex = 1;
            this.scoreManager.Text = "Score";
            this.scoreManager.UseVisualStyleBackColor = true;
            this.scoreManager.Click += new System.EventHandler(this.scoreManager_Click);
            // 
            // employeeManage
            // 
            this.employeeManage.Location = new System.Drawing.Point(78, 190);
            this.employeeManage.Name = "employeeManage";
            this.employeeManage.Size = new System.Drawing.Size(75, 23);
            this.employeeManage.TabIndex = 2;
            this.employeeManage.Text = "Employees";
            this.employeeManage.UseVisualStyleBackColor = true;
            this.employeeManage.Click += new System.EventHandler(this.employeeManage_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 271);
            this.Controls.Add(this.employeeManage);
            this.Controls.Add(this.scoreManager);
            this.Controls.Add(this.classManager);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button classManager;
        private System.Windows.Forms.Button scoreManager;
        private System.Windows.Forms.Button employeeManage;
    }
}