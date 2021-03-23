namespace Maze_game_NEA
{
    partial class Registration_page
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
            this.label1 = new System.Windows.Forms.Label();
            this.helpBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.submitBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.userResultLbl = new System.Windows.Forms.Label();
            this.passResultLbl = new System.Windows.Forms.Label();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.classTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.classResultLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(173, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Registration Page";
            // 
            // helpBtn
            // 
            this.helpBtn.BackColor = System.Drawing.Color.Red;
            this.helpBtn.Location = new System.Drawing.Point(529, 5);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(77, 39);
            this.helpBtn.TabIndex = 4;
            this.helpBtn.Text = "Help";
            this.helpBtn.UseVisualStyleBackColor = false;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password";
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.submitBtn.Location = new System.Drawing.Point(534, 362);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(77, 39);
            this.submitBtn.TabIndex = 9;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.BackgroundImage = global::Maze_game_NEA.Properties.Resources.Home_icon;
            this.homeBtn.Location = new System.Drawing.Point(0, 0);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(48, 48);
            this.homeBtn.TabIndex = 2;
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // userResultLbl
            // 
            this.userResultLbl.AutoSize = true;
            this.userResultLbl.Location = new System.Drawing.Point(125, 263);
            this.userResultLbl.Name = "userResultLbl";
            this.userResultLbl.Size = new System.Drawing.Size(0, 13);
            this.userResultLbl.TabIndex = 10;
            // 
            // passResultLbl
            // 
            this.passResultLbl.AutoSize = true;
            this.passResultLbl.Location = new System.Drawing.Point(125, 290);
            this.passResultLbl.Name = "passResultLbl";
            this.passResultLbl.Size = new System.Drawing.Size(0, 13);
            this.passResultLbl.TabIndex = 11;
            // 
            // usernameTxt
            // 
            this.usernameTxt.Location = new System.Drawing.Point(225, 171);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(138, 20);
            this.usernameTxt.TabIndex = 12;
            // 
            // passwordTxt
            // 
            this.passwordTxt.Location = new System.Drawing.Point(225, 199);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.Size = new System.Drawing.Size(138, 20);
            this.passwordTxt.TabIndex = 13;
            // 
            // classTxt
            // 
            this.classTxt.Location = new System.Drawing.Point(225, 225);
            this.classTxt.Name = "classTxt";
            this.classTxt.Size = new System.Drawing.Size(138, 20);
            this.classTxt.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Class";
            // 
            // classResultLbl
            // 
            this.classResultLbl.AutoSize = true;
            this.classResultLbl.Location = new System.Drawing.Point(125, 317);
            this.classResultLbl.Name = "classResultLbl";
            this.classResultLbl.Size = new System.Drawing.Size(0, 13);
            this.classResultLbl.TabIndex = 16;
            // 
            // Registration_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 411);
            this.Controls.Add(this.classResultLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.classTxt);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.usernameTxt);
            this.Controls.Add(this.passResultLbl);
            this.Controls.Add(this.userResultLbl);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.helpBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.homeBtn);
            this.Name = "Registration_page";
            this.Text = "Registration_page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button helpBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Label userResultLbl;
        private System.Windows.Forms.Label passResultLbl;
        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.TextBox classTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label classResultLbl;
    }
}