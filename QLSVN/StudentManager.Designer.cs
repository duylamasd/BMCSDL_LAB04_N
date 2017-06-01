namespace QLSVN
{
    partial class StudentManager
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
            this.studentView = new System.Windows.Forms.DataGridView();
            this.apply = new System.Windows.Forms.Button();
            this.studentIDBox = new System.Windows.Forms.TextBox();
            this.fullName = new System.Windows.Forms.TextBox();
            this.birthdayBox = new System.Windows.Forms.TextBox();
            this.addressBox = new System.Windows.Forms.TextBox();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.studentView)).BeginInit();
            this.SuspendLayout();
            // 
            // studentView
            // 
            this.studentView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentView.Location = new System.Drawing.Point(12, 12);
            this.studentView.Name = "studentView";
            this.studentView.Size = new System.Drawing.Size(405, 266);
            this.studentView.TabIndex = 0;
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(438, 254);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(187, 23);
            this.apply.TabIndex = 1;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // studentIDBox
            // 
            this.studentIDBox.Location = new System.Drawing.Point(525, 12);
            this.studentIDBox.Name = "studentIDBox";
            this.studentIDBox.Size = new System.Drawing.Size(100, 20);
            this.studentIDBox.TabIndex = 2;
            // 
            // fullName
            // 
            this.fullName.Location = new System.Drawing.Point(525, 38);
            this.fullName.Name = "fullName";
            this.fullName.Size = new System.Drawing.Size(100, 20);
            this.fullName.TabIndex = 3;
            // 
            // birthdayBox
            // 
            this.birthdayBox.Location = new System.Drawing.Point(525, 64);
            this.birthdayBox.Name = "birthdayBox";
            this.birthdayBox.Size = new System.Drawing.Size(100, 20);
            this.birthdayBox.TabIndex = 4;
            // 
            // addressBox
            // 
            this.addressBox.Location = new System.Drawing.Point(525, 90);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(100, 20);
            this.addressBox.TabIndex = 5;
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(525, 116);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(100, 20);
            this.usernameBox.TabIndex = 7;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(525, 142);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(100, 20);
            this.passwordBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mã SV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(435, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Họ tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ngáy sinh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(435, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Địa chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(435, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Tên đăng nhập";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(435, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Mật khẩu";
            // 
            // StudentManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 290);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.birthdayBox);
            this.Controls.Add(this.fullName);
            this.Controls.Add(this.studentIDBox);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.studentView);
            this.Name = "StudentManager";
            this.Text = "StudentManager";
            ((System.ComponentModel.ISupportInitialize)(this.studentView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView studentView;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.TextBox studentIDBox;
        private System.Windows.Forms.TextBox fullName;
        private System.Windows.Forms.TextBox birthdayBox;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}