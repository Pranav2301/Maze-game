namespace Maze_game_NEA
{
    partial class Print_menu
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
            this.generateBtn = new System.Windows.Forms.Button();
            this.difficultyBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
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
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Print menu";
            // 
            // helpBtn
            // 
            this.helpBtn.BackColor = System.Drawing.Color.Red;
            this.helpBtn.Location = new System.Drawing.Point(619, 5);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(77, 39);
            this.helpBtn.TabIndex = 5;
            this.helpBtn.Text = "Help";
            this.helpBtn.UseVisualStyleBackColor = false;
            // 
            // generateBtn
            // 
            this.generateBtn.Location = new System.Drawing.Point(619, 129);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(75, 23);
            this.generateBtn.TabIndex = 6;
            this.generateBtn.Text = "Generate";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // difficultyBox
            // 
            this.difficultyBox.FormattingEnabled = true;
            this.difficultyBox.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.difficultyBox.Location = new System.Drawing.Point(621, 102);
            this.difficultyBox.Name = "difficultyBox";
            this.difficultyBox.Size = new System.Drawing.Size(66, 21);
            this.difficultyBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(568, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Difficulty";
            // 
            // Print_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 652);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.difficultyBox);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.helpBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.homeBtn);
            this.Name = "Print_menu";
            this.Text = "Print_menu";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Print_menu_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button helpBtn;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.ComboBox difficultyBox;
        private System.Windows.Forms.Label label2;
    }
}