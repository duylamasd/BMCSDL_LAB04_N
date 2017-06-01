namespace QLSVN
{
    partial class ClassManager
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
            this.classTableView = new System.Windows.Forms.DataGridView();
            this.classList = new System.Windows.Forms.ListBox();
            this.studentManage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.classTableView)).BeginInit();
            this.SuspendLayout();
            // 
            // classTableView
            // 
            this.classTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.classTableView.Location = new System.Drawing.Point(12, 12);
            this.classTableView.Name = "classTableView";
            this.classTableView.Size = new System.Drawing.Size(240, 263);
            this.classTableView.TabIndex = 0;
            // 
            // classList
            // 
            this.classList.FormattingEnabled = true;
            this.classList.Location = new System.Drawing.Point(276, 12);
            this.classList.Name = "classList";
            this.classList.Size = new System.Drawing.Size(158, 160);
            this.classList.TabIndex = 1;
            // 
            // studentManage
            // 
            this.studentManage.Location = new System.Drawing.Point(276, 188);
            this.studentManage.Name = "studentManage";
            this.studentManage.Size = new System.Drawing.Size(157, 25);
            this.studentManage.TabIndex = 2;
            this.studentManage.Text = "Student Manager";
            this.studentManage.UseVisualStyleBackColor = true;
            this.studentManage.Click += new System.EventHandler(this.studentManage_Click);
            // 
            // ClassManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 287);
            this.Controls.Add(this.studentManage);
            this.Controls.Add(this.classList);
            this.Controls.Add(this.classTableView);
            this.Name = "ClassManager";
            this.Text = "ClassManager";
            ((System.ComponentModel.ISupportInitialize)(this.classTableView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView classTableView;
        private System.Windows.Forms.ListBox classList;
        private System.Windows.Forms.Button studentManage;
    }
}