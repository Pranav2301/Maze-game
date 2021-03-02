using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Maze_game_NEA
{
    public partial class Print_menu : Form
    {
        Student_menu menu;
        Student_Maze maze;
        public Print_menu()
        {
            InitializeComponent();
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            menu = new Student_menu();
            maze = new Student_Maze(menu);
            maze.createGrid();
        }

        private void Print_menu_Paint(object sender, PaintEventArgs e)
        {
            menu = new Student_menu();
            maze = new Student_Maze(menu);
            //maze.mazePaint(e);

            //btnMyButton.Click += new EventHandler(firstForm.MethodThatHasCodeToRun);
            //pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
        }
    }
}
