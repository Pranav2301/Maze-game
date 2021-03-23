namespace Maze_game_NEA
{
    partial class Student_menu
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
            this.homeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.helpBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.firstNameTxt = new System.Windows.Forms.TextBox();
            this.surnameTxt = new System.Windows.Forms.TextBox();
            this.enterBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.classTxt = new System.Windows.Forms.TextBox();
            this.fNameResultLbl = new System.Windows.Forms.Label();
            this.surnameResultLbl = new System.Windows.Forms.Label();
            this.classResultLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // homeBtn
            // 
            this.homeBtn.BackgroundImage = global::Maze_game_NEA.Properties.Resources.Home_icon;
            this.homeBtn.Location = new System.Drawing.Point(0, 0);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(48, 48);
            this.homeBtn.TabIndex = 3;
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Student Menu";
            // 
            // helpBtn
            // 
            this.helpBtn.BackColor = System.Drawing.Color.Red;
            this.helpBtn.Location = new System.Drawing.Point(529, 5);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(77, 39);
            this.helpBtn.TabIndex = 5;
            this.helpBtn.Text = "Help";
            this.helpBtn.UseVisualStyleBackColor = false;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Class";
            // 
            // firstNameTxt
            // 
            this.firstNameTxt.Location = new System.Drawing.Point(251, 146);
            this.firstNameTxt.Name = "firstNameTxt";
            this.firstNameTxt.Size = new System.Drawing.Size(138, 20);
            this.firstNameTxt.TabIndex = 14;
            // 
            // surnameTxt
            // 
            this.surnameTxt.Location = new System.Drawing.Point(251, 181);
            this.surnameTxt.Name = "surnameTxt";
            this.surnameTxt.Size = new System.Drawing.Size(138, 20);
            this.surnameTxt.TabIndex = 15;
            // 
            // enterBtn
            // 
            this.enterBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.enterBtn.Location = new System.Drawing.Point(531, 362);
            this.enterBtn.Name = "enterBtn";
            this.enterBtn.Size = new System.Drawing.Size(77, 39);
            this.enterBtn.TabIndex = 16;
            this.enterBtn.Text = "Enter";
            this.enterBtn.UseVisualStyleBackColor = false;
            this.enterBtn.Click += new System.EventHandler(this.enterBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Surname";
            // 
            // classTxt
            // 
            this.classTxt.Location = new System.Drawing.Point(251, 213);
            this.classTxt.Name = "classTxt";
            this.classTxt.Size = new System.Drawing.Size(138, 20);
            this.classTxt.TabIndex = 18;
            // 
            // fNameResultLbl
            // 
            this.fNameResultLbl.AutoSize = true;
            this.fNameResultLbl.Location = new System.Drawing.Point(125, 263);
            this.fNameResultLbl.Name = "fNameResultLbl";
            this.fNameResultLbl.Size = new System.Drawing.Size(0, 13);
            this.fNameResultLbl.TabIndex = 19;
            // 
            // surnameResultLbl
            // 
            this.surnameResultLbl.AutoSize = true;
            this.surnameResultLbl.Location = new System.Drawing.Point(125, 290);
            this.surnameResultLbl.Name = "surnameResultLbl";
            this.surnameResultLbl.Size = new System.Drawing.Size(0, 13);
            this.surnameResultLbl.TabIndex = 20;
            // 
            // classResultLbl
            // 
            this.classResultLbl.AutoSize = true;
            this.classResultLbl.Location = new System.Drawing.Point(125, 317);
            this.classResultLbl.Name = "classResultLbl";
            this.classResultLbl.Size = new System.Drawing.Size(0, 13);
            this.classResultLbl.TabIndex = 21;
            // 
            // Student_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 411);
            this.Controls.Add(this.classResultLbl);
            this.Controls.Add(this.surnameResultLbl);
            this.Controls.Add(this.fNameResultLbl);
            this.Controls.Add(this.classTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.enterBtn);
            this.Controls.Add(this.surnameTxt);
            this.Controls.Add(this.firstNameTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.helpBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.homeBtn);
            this.Name = "Student_menu";
            this.Text = "Student_menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button helpBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button enterBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label fNameResultLbl;
        private System.Windows.Forms.Label surnameResultLbl;
        private System.Windows.Forms.Label classResultLbl;
        public System.Windows.Forms.TextBox firstNameTxt;
        public System.Windows.Forms.TextBox surnameTxt;
        public System.Windows.Forms.TextBox classTxt;
    }
}