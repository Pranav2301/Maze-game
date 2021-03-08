using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.Drawing.Printing;

namespace Maze_game_NEA
{
    public partial class Student_Maze : Form
    {
        int rows;
        int columns;
        int[,] outputGrid; //2d array that represents the grid for the maze
        int cellSize; //represents the size of each cell in the grid
        Maze maze;
        bool startPress;
        ArrayList validCells;
        int step;
        Stopwatch mazeTime = new Stopwatch();
        int score;

        const int startPoint = 1;
        const int endPoint = 2;
        const int empty = 3;
        const int userRoute = 4;
        const int solution = 5;
        const int easy = 20;
        const int medium = 150;
        const int hard = 300;

        Student_menu studentMenu;

        public class mazeCell
        {
            private int x;
            private int y;
            public bool[] walls;
            private bool visited;
            private mazeCell previous;

            public mazeCell(int x, int y)
            {
                this.x = x;
                this.y = y;
                walls = new bool[] { true, true, true, true }; //top, right, bottom, left
                this.visited = false;
            }

            public int X
            {
                get { return x; }
            }

            public int Y
            {
                get { return y; }
            }

            public bool Visited
            {
                get { return visited; }
                set { visited = value; }
            }


            public mazeCell Previous
            {
                get { return previous; }
                set { previous = value; }
            }

            public override bool Equals(Object other)
            {
                //if (!(other instanceof Cell)) return false;
                if (other.GetType() != typeof(mazeCell))
                    return false;
                mazeCell otherCell = (mazeCell)other;
                return (x == otherCell.x) && (y == otherCell.y);
            }
        }

        public class Maze
        {
            private int mazeHeight;
            private int mazeWidth;
            public int[,] mazeGrid;
            private mazeCell[,] mazeCells;
            private Random rand = new Random();

            public Maze(int height, int width)
            {
                mazeHeight = height;
                mazeWidth = width;
                mazeGrid = new int[height, width];
                createCells();
                mazeGen(getMazeCell(mazeHeight - 1, 0));
            }

            public void createCells()
            {
                mazeCells = new mazeCell[mazeHeight, mazeWidth];
                for (int i = 0; i < mazeHeight; i++)
                {
                    for (int j = 0; j < mazeWidth; j++)
                    {
                        mazeCells[i, j] = new mazeCell(i, j);

                    }
                }
            }

            public mazeCell getMazeCell(int x, int y)
            {
                try
                {
                    return mazeCells[x, y];
                }
                catch (IndexOutOfRangeException)
                {
                    return null;
                }
            }

            public void removeWall(mazeCell current, mazeCell random)
            {
                int checkX = current.Y - random.Y;
                int checkY = current.X - random.X;
                if (checkX == 1)
                {
                    current.walls[3] = false;//remove left wall of current
                    random.walls[1] = false;//remove right wall of random
                }
                else if (checkX == -1)
                {
                    current.walls[1] = false;//remove right wall of current
                    random.walls[3] = false;//remove left wall of random
                }
                if (checkY == 1)
                {
                    current.walls[0] = false;//remove top wall of current
                    random.walls[2] = false;//remove bottom wall of random
                }
                else if (checkY == -1)
                {
                    current.walls[2] = false;//remove bottom wall of current
                    random.walls[0] = false;//remove top wall of random
                }
            }

            public void mazeGen(mazeCell entry)
            {
                mazeCell currentCell;
                Stack visitedCells = new Stack();
                entry.Visited = true;
                visitedCells.Push(entry);
                while (visitedCells.Count != 0)
                {
                    ArrayList neighbourCells = new ArrayList();
                    currentCell = (mazeCell)visitedCells.Pop();
                    mazeCell[] possibleNeighbours = new mazeCell[]{
                        getMazeCell(currentCell.X - 1, currentCell.Y), 
                        getMazeCell(currentCell.X + 1, currentCell.Y),
                        getMazeCell(currentCell.X, currentCell.Y + 1),
                        getMazeCell(currentCell.X, currentCell.Y - 1)
                    };
                    foreach (mazeCell neighbourCell in possibleNeighbours)
                    {
                        if (neighbourCell == null || neighbourCell.Visited)
                        {
                            continue;
                        }
                        else
                        {
                            neighbourCells.Add(neighbourCell);
                        }
                    }
                    if (neighbourCells.Count != 0)
                    {
                        visitedCells.Push(currentCell);
                        mazeCell randomCell = (mazeCell)neighbourCells[rand.Next(neighbourCells.Count)];
                        removeWall(currentCell, randomCell);
                        randomCell.Visited = true;
                        visitedCells.Push(randomCell);
                    }
                }
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
                    rows = rand.Next(10, 20);
                    columns = rand.Next(10, 20);
                }
                else if (difficultyBox.SelectedItem.ToString() == "Medium")
                {
                    rows = rand.Next(40, 50);
                    columns = rand.Next(40, 50);
                }
                else if (difficultyBox.SelectedItem.ToString() == "Hard")
                {
                    rows = rand.Next(60, 80);
                    columns = rand.Next(60, 80);
                }
                if (rows > columns)
                {
                    cellSize = 500 / rows;
                }
                else
                {
                    cellSize = 500 / columns;
                }
                outputGrid = new int[rows, columns];
                drawCells();
                maze = new Maze(rows, columns);
                Invalidate();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select an option from the drop down menu");
            }
        }

        public void drawCells()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    outputGrid[i, j] = empty;
                }
            }
            outputGrid[rows - 1, 0] = startPoint;
            outputGrid[0, columns - 1] = endPoint;
        }

        public void checkWalls(int x, int y)
        {
            validCells = new ArrayList();
            if (!maze.getMazeCell(x, y).walls[0])
            {
                validCells.Add(x - 1);
                validCells.Add(y);
            }
            if (!maze.getMazeCell(x, y).walls[1])
            {
                validCells.Add(x);
                validCells.Add(y + 1);
            }
            if (!maze.getMazeCell(x, y).walls[2])
            {
                validCells.Add(x + 1);
                validCells.Add(y);
            }
            if (!maze.getMazeCell(x, y).walls[3])
            {
                validCells.Add(x);
                validCells.Add(y - 1);
            }
        }

        public void backtrack(mazeCell cell)
        {
            mazeCell current = cell;
            while (current.Previous != maze.getMazeCell(rows - 1, 0))
            {
                outputGrid[current.Previous.X, current.Previous.Y] = solution;
                current = current.Previous;
            }
            Invalidate();
        }

        public void solveMaze()
        {
            ArrayList visitedCells = new ArrayList();
            Queue<mazeCell> unvisitedCells = new Queue<mazeCell>();
            mazeCell currentCell;
            unvisitedCells.Enqueue(maze.getMazeCell(rows - 1, 0));
            while (!visitedCells.Contains(maze.getMazeCell(0, columns - 1)))
            {
                currentCell = unvisitedCells.Dequeue();
                visitedCells.Add(currentCell);
                if (!currentCell.walls[0] && !visitedCells.Contains(maze.getMazeCell(currentCell.X - 1, currentCell.Y)))
                {
                    unvisitedCells.Enqueue(maze.getMazeCell(currentCell.X - 1, currentCell.Y));
                    maze.getMazeCell(currentCell.X - 1, currentCell.Y).Previous = currentCell;
                }
                if (!currentCell.walls[1] && !visitedCells.Contains(maze.getMazeCell(currentCell.X, currentCell.Y + 1)))
                {
                    unvisitedCells.Enqueue(maze.getMazeCell(currentCell.X, currentCell.Y + 1));
                    maze.getMazeCell(currentCell.X, currentCell.Y + 1).Previous = currentCell;
                }
                if (!currentCell.walls[2] && !visitedCells.Contains(maze.getMazeCell(currentCell.X + 1, currentCell.Y)))
                {
                    unvisitedCells.Enqueue(maze.getMazeCell(currentCell.X + 1, currentCell.Y));
                    maze.getMazeCell(currentCell.X + 1, currentCell.Y).Previous = currentCell;
                }
                if (!currentCell.walls[3] && !visitedCells.Contains(maze.getMazeCell(currentCell.X, currentCell.Y - 1)))
                {
                    unvisitedCells.Enqueue(maze.getMazeCell(currentCell.X, currentCell.Y - 1));
                    maze.getMazeCell(currentCell.X, currentCell.Y - 1).Previous = currentCell;
                }
            }
            backtrack(maze.getMazeCell(0, columns - 1));
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            createGrid();
            mazeTime.Start();
        }

        private void Student_Maze_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Brush brush;
            Rectangle rect;
            Pen Pen = new Pen(Color.Black, 2);
            brush = new SolidBrush(Color.Black);
            rect = new Rectangle(13, 69, columns * cellSize, rows * cellSize);
            e.Graphics.DrawRectangle(Pen, rect);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    if (outputGrid[i, j] == empty)
                    {
                        brush = new SolidBrush(Color.White);
                    }
                    else if (outputGrid[i, j] == startPoint)
                    {
                        brush = new SolidBrush(Color.Red);
                    }
                    else if (outputGrid[i, j] == endPoint)
                    {
                        brush = new SolidBrush(Color.Green);
                    }
                    else if (outputGrid[i, j] == userRoute)
                    {
                        brush = new SolidBrush(Color.Yellow);
                    }
                    else if (outputGrid[i, j] == solution)
                    {
                        brush = new SolidBrush(Color.Blue);
                    }
                    rect = new Rectangle(13 + j * cellSize, 69 + i * cellSize, cellSize - 1, cellSize - 1);
                    graphics.FillRectangle(brush, rect);
                    brush.Dispose();
                    //draw wall
                    if (maze.getMazeCell(i, j).walls[0])
                    {
                        graphics.DrawLine(Pen, 13 + j * cellSize, 69 + i * cellSize, 13 + (j + 1) * cellSize, 69 + i * cellSize);
                    }
                    if (maze.getMazeCell(i, j).walls[1])
                    {
                        graphics.DrawLine(Pen, 13 + (j + 1) * cellSize, 69 + i * cellSize, 13 + (j + 1) * cellSize, 69 + (i + 1) * cellSize);
                    }
                    if (maze.getMazeCell(i, j).walls[2])
                    {
                        graphics.DrawLine(Pen, 13 + j * cellSize, 69 + (i + 1) * cellSize, 13 + (j + 1) * cellSize, 69 + (i + 1) * cellSize);
                    }
                    if (maze.getMazeCell(i, j).walls[3])
                    {
                        graphics.DrawLine(Pen, 13 + j * cellSize, 69 + i * cellSize, 13 + j * cellSize, 69 + (i + 1) * cellSize);
                    }
                }
        }

        private void Student_Maze_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int currentRow = (e.Y - 69) / cellSize;
                int currentColumn = (e.X - 13) / cellSize;
                if (startPress == false)
                {
                    if (outputGrid[currentRow, currentColumn] == startPoint)
                    {
                        startPress = true;
                        checkWalls(currentRow, currentColumn);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("You need to begin from the start point");
                        return;
                    }
                }

                if (currentRow >= 0 && currentRow < rows && currentColumn >= 0 && currentColumn < columns)
                {
                    for (int i = 0; i < validCells.Count; i += 2)
                    {
                        if (currentRow == (int)validCells[i] && currentColumn == (int)validCells[i + 1])
                        {
                            if (outputGrid[currentRow, currentColumn] == endPoint)
                            {
                                mazeTime.Stop();
                                float timeTaken = (float)mazeTime.Elapsed.Minutes * 60 + mazeTime.Elapsed.Seconds;
                                MessageBox.Show("Congratulations you reached the end.");
                                switch (difficultyBox.SelectedItem.ToString())
                                {
                                    case "Easy":
                                        score = (int)(easy * step / timeTaken);
                                        break;
                                    case "Medium":
                                        score = (int)(medium * step / timeTaken);
                                        break;
                                    case "Hard":
                                        score = (int)(hard * step / timeTaken);
                                        break;
                                }
                                scoreLbl.Text = "Score: " + score.ToString();
                            }
                            else
                            {
                                outputGrid[currentRow, currentColumn] = userRoute;
                                step++;
                                stepLbl.Text = "Steps: " + step.ToString();
                                checkWalls(currentRow, currentColumn);
                            }
                        }
                    }
                }
                Invalidate();
            }
            catch (Exception)
            {
                MessageBox.Show("You need to select a cell inside the grid");
            }
        }

        private void Student_Maze_Load(object sender, EventArgs e)
        {
            if (this.Owner is Teacher_Menu)
            {
                printNoSol.Visible = true;
                printSol.Visible = true;
            }
        }

        private void printNoSol_Click(object sender, EventArgs e)
        {
            solveMaze();
        }

        private void mazeTimer_Tick(object sender, EventArgs e)
        {
            time.Text = "Time: " + mazeTime.Elapsed.ToString(@"mm\:ss");
        }
    }

    }


