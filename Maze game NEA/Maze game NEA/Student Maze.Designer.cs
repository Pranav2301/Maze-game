namespace Maze_game_NEA
{
    partial class Student_Maze
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Student_Maze));
            this.homeBtn = new System.Windows.Forms.Button();
            this.helpBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.difficultyBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.generateBtn = new System.Windows.Forms.Button();
            this.stepLbl = new System.Windows.Forms.Label();
            this.timeLbl = new System.Windows.Forms.Label();
            this.mazeTimer = new System.Windows.Forms.Timer(this.components);
            this.scoreLbl = new System.Windows.Forms.Label();
            this.mazePrint = new System.Drawing.Printing.PrintDocument();
            this.mazePreview = new System.Windows.Forms.PrintPreviewDialog();
            this.printBtn = new System.Windows.Forms.Button();
            this.shortestPathBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // homeBtn
            // 
            this.homeBtn.BackgroundImage = global::Maze_game_NEA.Properties.Resources.Home_icon;
            this.homeBtn.Location = new System.Drawing.Point(0, 0);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(48, 48);
            this.homeBtn.TabIndex = 4;
            this.homeBtn.UseVisualStyleBackColor = true;
            // 
            // helpBtn
            // 
            this.helpBtn.BackColor = System.Drawing.Color.Red;
            this.helpBtn.Location = new System.Drawing.Point(621, 5);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(77, 39);
            this.helpBtn.TabIndex = 6;
            this.helpBtn.Text = "Help";
            this.helpBtn.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(251, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Maze";
            // 
            // difficultyBox
            // 
            this.difficultyBox.FormattingEnabled = true;
            this.difficultyBox.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.difficultyBox.Location = new System.Drawing.Point(621, 61);
            this.difficultyBox.Name = "difficultyBox";
            this.difficultyBox.Size = new System.Drawing.Size(66, 21);
            this.difficultyBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(568, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Difficulty";
            // 
            // generateBtn
            // 
            this.generateBtn.Location = new System.Drawing.Point(612, 88);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(75, 23);
            this.generateBtn.TabIndex = 10;
            this.generateBtn.Text = "Generate";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // stepLbl
            // 
            this.stepLbl.AutoSize = true;
            this.stepLbl.Location = new System.Drawing.Point(253, 44);
            this.stepLbl.Name = "stepLbl";
            this.stepLbl.Size = new System.Drawing.Size(0, 13);
            this.stepLbl.TabIndex = 11;
            // 
            // timeLbl
            // 
            this.timeLbl.AutoSize = true;
            this.timeLbl.Location = new System.Drawing.Point(326, 44);
            this.timeLbl.Name = "timeLbl";
            this.timeLbl.Size = new System.Drawing.Size(0, 13);
            this.timeLbl.TabIndex = 13;
            // 
            // mazeTimer
            // 
            this.mazeTimer.Enabled = true;
            this.mazeTimer.Tick += new System.EventHandler(this.mazeTimer_Tick);
            // 
            // scoreLbl
            // 
            this.scoreLbl.AutoSize = true;
            this.scoreLbl.Location = new System.Drawing.Point(389, 44);
            this.scoreLbl.Name = "scoreLbl";
            this.scoreLbl.Size = new System.Drawing.Size(0, 13);
            this.scoreLbl.TabIndex = 15;
            // 
            // mazePrint
            // 
            this.mazePrint.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.mazePrint_PrintPage);
            // 
            // mazePreview
            // 
            this.mazePreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.mazePreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.mazePreview.ClientSize = new System.Drawing.Size(400, 300);
            this.mazePreview.Document = this.mazePrint;
            this.mazePreview.Enabled = true;
            this.mazePreview.Icon = ((System.Drawing.Icon)(resources.GetObject("mazePreview.Icon")));
            this.mazePreview.Name = "mazePreview";
            this.mazePreview.Visible = false;
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(612, 158);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 23);
            this.printBtn.TabIndex = 12;
            this.printBtn.Text = "Print";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Visible = false;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // shortestPathBtn
            // 
            this.shortestPathBtn.Location = new System.Drawing.Point(612, 117);
            this.shortestPathBtn.Name = "shortestPathBtn";
            this.shortestPathBtn.Size = new System.Drawing.Size(75, 35);
            this.shortestPathBtn.TabIndex = 14;
            this.shortestPathBtn.Text = "Shortest path";
            this.shortestPathBtn.UseVisualStyleBackColor = true;
            this.shortestPathBtn.Visible = false;
            this.shortestPathBtn.Click += new System.EventHandler(this.shortestPathBtn_Click);
            // 
            // Student_Maze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(699, 652);
            this.Controls.Add(this.scoreLbl);
            this.Controls.Add(this.shortestPathBtn);
            this.Controls.Add(this.timeLbl);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.stepLbl);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.difficultyBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.helpBtn);
            this.Controls.Add(this.homeBtn);
            this.Name = "Student_Maze";
            this.Text = "Student_Maze";
            this.Load += new System.EventHandler(this.Student_Maze_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Student_Maze_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Student_Maze_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Button helpBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox difficultyBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Label stepLbl;
        private System.Windows.Forms.Label timeLbl;
        private System.Windows.Forms.Timer mazeTimer;
        private System.Windows.Forms.Label scoreLbl;
        private System.Drawing.Printing.PrintDocument mazePrint;
        private System.Windows.Forms.PrintPreviewDialog mazePreview;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button shortestPathBtn;

    }
}