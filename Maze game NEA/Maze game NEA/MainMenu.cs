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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void teacherBtn_Click(object sender, EventArgs e)
        {
            Teacher_Menu teacher = new Teacher_Menu();
            this.Hide();
            teacher.ShowDialog();
            this.Close();
        }

        private void studentBtn_Click(object sender, EventArgs e)
        {
            Student_menu student = new Student_menu();
            this.Hide();
            student.ShowDialog();
            this.Close();
        }
    }
}
