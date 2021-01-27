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
    public partial class Student_Maze : Form
    {
        Student_menu studentMenu;
        public Student_Maze(Student_menu menu)
        {
            InitializeComponent();
            this.studentMenu = menu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
