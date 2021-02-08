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
        int rows;
        int columns;
        int[,] mazeGrid; //2d array that represents the grid for the maze
        int cellSize; //represents the size of each cell in the grid

        const int obstacle = 1;
        const int startPoint = 2;
        const int endPoint = 3;
        const int empty = 4;

        Student_menu studentMenu;

        public class cell
        {
            //class that represents the cell of a grid
            private int row;
            private int column;
            public cell prev;
            public cell(int row, int column)
            {
                this.row = row;
                this.column = column;
            }

            public int Row
            {
                get { return row; }
            }

            public int Column
            {
                get { return column; }
            }
        }

        public Student_Maze(Student_menu menu)
        {
            InitializeComponent();
            this.studentMenu = menu;
        }

        public void createGrid()
        {
            Random rand = new Random();
            try
            {
                if (difficultyBox.SelectedItem.ToString() == "Easy")
                {
                    rows = rand.Next(10,20);
                    columns = rand.Next(10,20);
                }
                else if (difficultyBox.SelectedItem.ToString() == "Medium")
                {
                    rows = rand.Next(40,50);
                    columns = rand.Next(40,50);
                }
                else if (difficultyBox.SelectedItem.ToString() == "Hard")
                {
                    rows = rand.Next(60,80);
                    columns = rand.Next(60,80);
                }
                if (rows % 2 == 0)
                {
                    rows = rows - 1;
                }
                if (columns % 2 == 0)
                {
                    columns = columns - 1;
                }
                if (rows > columns)
                {
                    cellSize = 500 / rows;
                }
                else
                {
                    cellSize = 500 / columns;
                }
                mazeGrid = new int[rows, columns];
                cell start = new cell(rows - 2, 1);
                cell end = new cell(1, columns - 2);
                fillGrid(start, end);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select an option from the drop down menu");
            }
            Invalidate();
        }

        public void fillGrid(cell start, cell end) 
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    mazeGrid[i, j] = empty;
                }
            }
            mazeGrid[start.Row, start.Column] = startPoint;
            mazeGrid[end.Row, end.Column] = endPoint;
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            createGrid();
        }

        private void Student_Maze_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Brush brush;
            Rectangle rect;
            brush = new SolidBrush(Color.DarkGray);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    if (mazeGrid[i, j] == empty)
                        brush = new SolidBrush(Color.White);
                    else if (mazeGrid[i, j] == startPoint)
                        brush = new SolidBrush(Color.Red);
                    else if (mazeGrid[i, j] == endPoint)
                        brush = new SolidBrush(Color.Green);
                    else if (mazeGrid[i, j] == obstacle)
                        brush = new SolidBrush(Color.Black);
                    rect = new Rectangle(13 + i * cellSize, 69 + j * cellSize, cellSize - 1, cellSize - 1);
                    graphics.FillRectangle(brush, rect);
                    brush.Dispose();
                }
        }

        }
    }


