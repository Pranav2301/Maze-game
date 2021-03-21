using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
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
        int cellSize;//represents the size of each cell in the grid
        Maze maze;
        bool startPress;//boolean flag which checks if the starting cell has been pressed
        ArrayList validCells;//stores the valid adjacent cells of a cell
        int step;
        Stopwatch mazeTime = new Stopwatch();//keeps track of time taken to complete the maze
        int score;
        Bitmap bitmap;//creates an image of the form
        bool genBtnClick = false;

        const int startPoint = 1;//represents the starting point in outputGrid[]
        const int endPoint = 2;//represents the end point in outputGrid[]
        const int empty = 3;//represents a regular cell in outputGrid[]
        const int userRoute = 4;//represents a cell navigated by the user in outputGrid[]
        const int solution = 5;//represents a cell that is part of the shortest path
        const int easy = 20;//score multiplier for easy difficulty
        const int medium = 150;//score multiplier for medium difficulty
        const int hard = 300;//score multiplier for hard difficulty

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
                walls = new bool[] { true, true, true, true };//top = true, right = true, bottom = true, left = true
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
            private mazeCell[,] mazeCells;//2d mazeCell array used to represent all the cells that make up the maze
            private Random rand = new Random();

            public Maze(int height, int width)
            {
                mazeHeight = height;
                mazeWidth = width;
                createCells();
                mazeGen(getMazeCell(mazeHeight - 1, 0));//creates maze from the bottom left of the grid
            }

            public void createCells()
            {
                //creates mazeCell objects to make up the maze
                mazeCells = new mazeCell[mazeHeight, mazeWidth];
                for (int i = 0; i < mazeHeight; i++)
                {
                    for (int j = 0; j < mazeWidth; j++)
                    {
                        mazeCells[i, j] = new mazeCell(i, j);//populates mazeCells[] with mazeCell objects

                    }
                }
            }

            public mazeCell getMazeCell(int x, int y)
            {
                //gets the mazeCell at the memory location specified by x and y
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
                //Removes walls between current and random
                int checkX = current.Y - random.Y;//checks if random is to the left or right of current
                int checkY = current.X - random.X;//checks if random is above or below current
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
                //generates a maze using DFS algorithm
                mazeCell currentCell;
                Stack visitedCells = new Stack();//keeps track of cells that have been used for generation
                entry.Visited = true;//marks the starting cell as true
                visitedCells.Push(entry);
                while (visitedCells.Count != 0)
                {
                    ArrayList neighbourCells = new ArrayList();
                    currentCell = (mazeCell)visitedCells.Pop();
                    mazeCell[] possibleNeighbours = new mazeCell[]{
                        //gets top cell
                        getMazeCell(currentCell.X - 1, currentCell.Y), 
                        //gets bottom cell
                        getMazeCell(currentCell.X + 1, currentCell.Y),
                        //gets right cell
                        getMazeCell(currentCell.X, currentCell.Y + 1),
                        //gets left cell
                        getMazeCell(currentCell.X, currentCell.Y - 1)
                    };
                    foreach (mazeCell neighbourCell in possibleNeighbours)
                    {
                        //checks if the neighbouring cell isn’t null or not visited
                        if (neighbourCell == null || neighbourCell.Visited)
                        {
                            continue;
                        }
                        else
                        {
                            neighbourCells.Add(neighbourCell);//adds an adjacent cell that hasn’t been visited to the arraylist
                        }
                    }
                    if (neighbourCells.Count != 0)
                    {
                        visitedCells.Push(currentCell);
                        mazeCell randomCell = (mazeCell)neighbourCells[rand.Next(neighbourCells.Count)];//randomly selects a neighbouring cell from the arraylist
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
            this.studentMenu = menu;//an instance of student_menu is created
        }

        public void createGrid()
        {
            //creates grid where maze is displayed
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
                Invalidate();//forces the form to be repainted
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select an option from the drop down menu");
            }
        }

        public void drawCells()
        {
            //sets the state of the cells 
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    outputGrid[i, j] = empty;
                }
            }
            outputGrid[rows - 1, 0] = startPoint;//start point = bottom left cell
            outputGrid[0, columns - 1] = endPoint;//end point = top right cell
        }

        public void checkWalls(int x, int y)
        {
            //checks if the top wall isn’t present
            if (!maze.getMazeCell(x, y).walls[0])
            {
                //adds top wall to arraylist
                validCells.Add(x - 1);
                validCells.Add(y);
            }
            //checks if the right wall isn’t present
            if (!maze.getMazeCell(x, y).walls[1])
            {
                //adds right wall to arraylist
                validCells.Add(x);
                validCells.Add(y + 1);
            }
            //checks if the bottom wall isn’t present
            if (!maze.getMazeCell(x, y).walls[2])
            {
                //adds bottom wall to arraylist
                validCells.Add(x + 1);
                validCells.Add(y);
            }
            //checks if the bottom wall isn’t present
            if (!maze.getMazeCell(x, y).walls[3])
            {
                //adds left wall to arraylist
                validCells.Add(x);
                validCells.Add(y - 1);
            }
        }

        public void backtrack(mazeCell cell)
        {
            //finds the shortest path by backtracking from end point
            mazeCell current = cell;
            while (current.Previous != maze.getMazeCell(rows - 1, 0))
            {
                outputGrid[current.Previous.X, current.Previous.Y] = solution;//mark the previous cell of current as part of the shortest path
                current = current.Previous;//current cell becomes the previous cell of current
            }
            Invalidate();
        }

        public void solveMaze()
        {
            //solves the maze using a BFS algorithm
            ArrayList visitedCells = new ArrayList();
            Queue<mazeCell> unvisitedCells = new Queue<mazeCell>();
            mazeCell currentCell;
            unvisitedCells.Enqueue(maze.getMazeCell(rows - 1, 0));
            //check if the end point cell at the top right has been visited
            while (!visitedCells.Contains(maze.getMazeCell(0, columns - 1)))
            {
                currentCell = unvisitedCells.Dequeue();
                visitedCells.Add(currentCell);//mark current cell as visited
                //check if the top wall isn’t present and not visited
                if (!currentCell.walls[0] && !visitedCells.Contains(maze.getMazeCell(currentCell.X - 1, currentCell.Y)))
                {
                    unvisitedCells.Enqueue(maze.getMazeCell(currentCell.X - 1, currentCell.Y));//enqueue top cell to the queue
                    maze.getMazeCell(currentCell.X - 1, currentCell.Y).Previous = currentCell;//mark the previous cell of the newly explored top cell as currentCell
                }
                //check if the right wall isn’t present and not visited
                if (!currentCell.walls[1] && !visitedCells.Contains(maze.getMazeCell(currentCell.X, currentCell.Y + 1)))
                {
                    unvisitedCells.Enqueue(maze.getMazeCell(currentCell.X, currentCell.Y + 1));//enqueue right cell to the queue
                    maze.getMazeCell(currentCell.X, currentCell.Y + 1).Previous = currentCell;//mark the previous cell of the newly explored right cell as currentCell
                }
                //check if the bottom wall isn’t present and not visited
                if (!currentCell.walls[2] && !visitedCells.Contains(maze.getMazeCell(currentCell.X + 1, currentCell.Y)))
                {
                    unvisitedCells.Enqueue(maze.getMazeCell(currentCell.X + 1, currentCell.Y));//enqueue bottom cell to the queue
                    maze.getMazeCell(currentCell.X + 1, currentCell.Y).Previous = currentCell;//mark the previous cell of the newly explored bottom cell as currentCell
                }
                //check if the left wall isn’t present and not visited
                if (!currentCell.walls[3] && !visitedCells.Contains(maze.getMazeCell(currentCell.X, currentCell.Y - 1)))
                {
                    unvisitedCells.Enqueue(maze.getMazeCell(currentCell.X, currentCell.Y - 1));//enqueue left cell to the queue
                    maze.getMazeCell(currentCell.X, currentCell.Y - 1).Previous = currentCell;//mark the previous cell of the newly explored left cell as currentCell
                }
            }
            backtrack(maze.getMazeCell(0, columns - 1));
        }

        public void printMaze()
        {
            Graphics graphics = this.CreateGraphics();
            bitmap = new Bitmap(this.Size.Width, this.Size.Height, graphics);
            Graphics memoryGraphics = Graphics.FromImage(bitmap);//create graphics object
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);//moves the colour data of the form to the graphics object
            mazePreview.ShowDialog();//show print dialog
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            genBtnClick = true;
            createGrid();
            mazeTime.Start();
        }

        private void Student_Maze_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Brush brush;
            Rectangle rect;
            Pen Pen = new Pen(Color.Black, 2);//used to draw walls
            brush = new SolidBrush(Color.Black);
            rect = new Rectangle(13, 69, columns * cellSize, rows * cellSize);
            e.Graphics.DrawRectangle(Pen, rect);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                {
                    if (outputGrid[i, j] == empty)
                    {
                        brush = new SolidBrush(Color.White);//set the brush to white for elements marked ‘empty’
                    }
                    else if (outputGrid[i, j] == startPoint)
                    {
                        brush = new SolidBrush(Color.Red);//set the brush to red for elements marked ‘startPoint’
                    }
                    else if (outputGrid[i, j] == endPoint)
                    {
                        brush = new SolidBrush(Color.Green);//set the brush to green for elements marked ‘endPoint’
                    }
                    else if (outputGrid[i, j] == userRoute)
                    {
                        brush = new SolidBrush(Color.Yellow);//set the brush to yellow for elements marked ‘userRoute’
                    }
                    else if (outputGrid[i, j] == solution)
                    {
                        brush = new SolidBrush(Color.Turquoise);//set the brush to turquoise for elements marked ‘solution’
                    }
                    rect = new Rectangle(13 + j * cellSize, 69 + i * cellSize, cellSize - 1, cellSize - 1);
                    graphics.FillRectangle(brush, rect);//draw the individual cells and paint them according to the state of the cell
                    brush.Dispose();
                    //draw wall
                    if (maze.getMazeCell(i, j).walls[0])
                    {
                        graphics.DrawLine(Pen, 13 + j * cellSize, 69 + i * cellSize, 13 + (j + 1) * cellSize, 69 + i * cellSize);//draw a black line above the cell
                    }
                    if (maze.getMazeCell(i, j).walls[1])
                    {
                        graphics.DrawLine(Pen, 13 + (j + 1) * cellSize, 69 + i * cellSize, 13 + (j + 1) * cellSize, 69 + (i + 1) * cellSize);//draw a black line to the right of the cell
                    }
                    if (maze.getMazeCell(i, j).walls[2])
                    {
                        graphics.DrawLine(Pen, 13 + j * cellSize, 69 + (i + 1) * cellSize, 13 + (j + 1) * cellSize, 69 + (i + 1) * cellSize);//draw a black line below the cell
                    }
                    if (maze.getMazeCell(i, j).walls[3])
                    {
                        graphics.DrawLine(Pen, 13 + j * cellSize, 69 + i * cellSize, 13 + j * cellSize, 69 + (i + 1) * cellSize);//draw a black line to the left of the cell
                    }
                }
        }

        private void Student_Maze_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                int currentRow = (e.Y - 69) / cellSize;//row where the mouse is clicked
                int currentColumn = (e.X - 13) / cellSize;//column where the mouse is clicked
                //checks if the starting point has been clicked
                if (startPress == false)
                {
                    //checks if mouse is pressed on the starting point
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
                //checks if the mouse is clicked in the bounds of the maze
                if (currentRow >= 0 && currentRow < rows && currentColumn >= 0 && currentColumn < columns)
                {
                    for (int i = 0; i < validCells.Count; i += 2)
                    {
                        //checks if the cell clicked is valid
                        if (currentRow == (int)validCells[i] && currentColumn == (int)validCells[i + 1])
                        {
                            //checks if the end point has been reached 
                            if (outputGrid[currentRow, currentColumn] == endPoint)
                            {
                                mazeTime.Stop();
                                float timeTaken = (float)mazeTime.Elapsed.Minutes * 60 + mazeTime.Elapsed.Seconds;//time taken is converted to seconds
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
                                //establish connection with database
                                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Main\Documents\Visual Studio 2012\Projects\Maze game NEA\Maze game NEA\loginTest.mdf;Integrated Security=True;Connect Timeout=30");
                                sqlcon.Open();
                                string query = "insert into Maze values(@Difficulty,@Rows,@Columns,@Score,@Date,@studentID)";
                                string getIDQuery = "SELECT * FROM Student WHERE FirstName='" + studentMenu.firstNameTxt.Text + "' AND Class='" + studentMenu.classTxt.Text + "'";
                                SqlDataAdapter sqlda = new SqlDataAdapter(getIDQuery, sqlcon);
                                DataTable studentTable = new DataTable();
                                sqlda.Fill(studentTable);//fills the table with the result of the getIDQuery
                                //checks if the student exists in the table
                                if (studentTable.Rows.Count == 1)
                                {
                                    int studentID = (int)studentTable.Rows[0][0];//get primary key of the student table
                                    SqlCommand sqlcom = new SqlCommand(query, sqlcon);
                                    sqlcom.Parameters.AddWithValue("Difficulty", difficultyBox.SelectedItem.ToString());
                                    sqlcom.Parameters.AddWithValue("Rows", rows);
                                    sqlcom.Parameters.AddWithValue("Columns", columns);
                                    sqlcom.Parameters.AddWithValue("Score", score);
                                    sqlcom.Parameters.AddWithValue("Date", DateTime.Now);
                                    sqlcom.Parameters.AddWithValue("studentID", studentID);//add foreign key to the maze table
                                    sqlcom.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                outputGrid[currentRow, currentColumn] = userRoute;//User has navigated this cell.
                                step++;
                                stepLbl.Text = "Steps: " + step.ToString();
                                checkWalls(currentRow, currentColumn);
                            }
                        }
                    }
                }
                Invalidate();//forces the form to be redrawn
            }
            catch (Exception)
            {
                MessageBox.Show("You need to select a cell inside the grid");
            }
        }

        private void Student_Maze_Load(object sender, EventArgs e)
        {
            //check if the teacher is logged in
            if (this.Owner is Teacher_Menu)
            {
                printBtn.Visible = true;
                shortestPathBtn.Visible = true;
            }
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            //check if the generate button is pressed
            if (genBtnClick)
            {
                printMaze();
            }
            else
            {
                MessageBox.Show("You need to generate a maze before you press print");
            }
        }

        private void shortestPathBtn_Click(object sender, EventArgs e)
        {
            //check if the generate button is pressed
            if (genBtnClick)
            {
                solveMaze();
            }
            else
            {
                MessageBox.Show("You need to generate a maze before you display the shortest path");
            }
        }

        private void mazeTimer_Tick(object sender, EventArgs e)
        {
            timeLbl.Text = "Time: " + mazeTime.Elapsed.ToString(@"mm\:ss");
        }

        private void mazePrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

    }
    }
    


