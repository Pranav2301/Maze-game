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
    public partial class Information_page : Form
    {
        public Information_page()
        {
            InitializeComponent();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();//open main menu
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }
    }
}
