namespace QLSVN
{
    partial class ScoreManager
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
            this.scoreView = new System.Windows.Forms.DataGridView();
            this.studentIDBox = new System.Windows.Forms.TextBox();
            this.subjectIDBox = new System.Windows.Forms.TextBox();
            this.scoreBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.apply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scoreView)).BeginInit();
            this.SuspendLayout();
            // 
            // scoreView
            // 
            this.scoreView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scoreView.Location = new System.Drawing.Point(12, 12);
            this.scoreView.Name = "scoreView";
            this.scoreView.Size = new System.Drawing.Size(293, 281);
            this.scoreView.TabIndex = 0;
            // 
            // studentIDBox
            // 
            this.studentIDBox.Location = new System.Drawing.Point(387, 12);
            this.studentIDBox.Name = "studentIDBox";
            this.studentIDBox.Size = new System.Drawing.Size(133, 20);
            this.studentIDBox.TabIndex = 1;
            // 
            // subjectIDBox
            // 
            this.subjectIDBox.Location = new System.Drawing.Point(387, 62);
            this.subjectIDBox.Name = "subjectIDBox";
            this.subjectIDBox.Size = new System.Drawing.Size(133, 20);
            this.subjectIDBox.TabIndex = 2;
            // 
            // scoreBox
            // 
            this.scoreBox.Location = new System.Drawing.Point(387, 109);
            this.scoreBox.Name = "scoreBox";
            this.scoreBox.Size = new System.Drawing.Size(133, 20);
            this.scoreBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã SV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mã học phần";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Điểm";
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(314, 157);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(206, 23);
            this.apply.TabIndex = 7;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // ScoreManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 305);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scoreBox);
            this.Controls.Add(this.subjectIDBox);
            this.Controls.Add(this.studentIDBox);
            this.Controls.Add(this.scoreView);
            this.Name = "ScoreManager";
            this.Text = "ScoreManager";
            ((System.ComponentModel.ISupportInitialize)(this.scoreView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView scoreView;
        private System.Windows.Forms.TextBox studentIDBox;
        private System.Windows.Forms.TextBox subjectIDBox;
        private System.Windows.Forms.TextBox scoreBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button apply;
    }
}