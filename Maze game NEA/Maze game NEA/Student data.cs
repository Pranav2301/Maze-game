using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Maze_game_NEA
{
    public partial class Student_data : Form
    {
        string fullName;
        string[] names;
        string firstName;
        string surname;

        Teacher_Menu teacherMenu;
        public Student_data(Teacher_Menu menu)
        {
            InitializeComponent();
            this.teacherMenu = menu;//instance of teacher menu is created
        }

        public void splitName()
        {
            fullName = nameBox.SelectedItem.ToString();//get full name from nameBox
            names = fullName.Split(' ');//string array containing the fullname separated to first name and surname 
            firstName = names[0];
            surname = names[1];
        }

        private void Student_data_Load(object sender, EventArgs e)
        {
            //establish connection with database
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Main\Documents\Visual Studio 2012\Projects\Maze game NEA\Maze game NEA\loginTest.mdf;Integrated Security=True;Connect Timeout=30");
            sqlcon.Open();
            string getIDQuery = "SELECT teacherID FROM Teacher WHERE username='" + teacherMenu.usernameTxt.Text + "'";
            SqlDataAdapter sqlda = new SqlDataAdapter(getIDQuery, sqlcon);
            DataTable teacherTable = new DataTable();
            sqlda.Fill(teacherTable);
            //checks if the teacher exists in the table
            if (teacherTable.Rows.Count == 1)
            {
                int teacherID = (int)teacherTable.Rows[0][0];//get primary key of the teacher table
                string query = "SELECT FirstName,Surname FROM Student WHERE teacherID='" + teacherID + "'";
                sqlda = new SqlDataAdapter(query, sqlcon);
                DataTable studentTable = new DataTable();
                sqlda.Fill(studentTable);//fills the table with the result of the query
                //checks if there is at least one student in the table
                if (studentTable.Rows.Count >= 1)
                {
                    for (int i = 0; i < studentTable.Rows.Count; i++)
                    {
                        string fullname = (string)studentTable.Rows[i][0]+ " " + (string)studentTable.Rows[i][1];//concatenate first name and surname
                        nameBox.Items.Add(fullname);//adds the full name to nameBox
                    }
                }
            }
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            //establish connection with the database
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Main\Documents\Visual Studio 2012\Projects\Maze game NEA\Maze game NEA\loginTest.mdf;Integrated Security=True;Connect Timeout=30");
            sqlcon.Open();
            SqlDataAdapter sqlda;
            DataTable infoTable; 
            //checks if only the difficulty filter is applied to search the database
            if (difficultyBox.SelectedItem.ToString() != "N/A" && nameBox.SelectedItem.ToString() == "N/A")
            {
                //gathers all the students in the teacher's class that have completed a maze of a certain difficulty 
                string difficultyQuery = "SELECT Student.FirstName, Student.Surname, Maze.Difficulty, Maze.Rows, Maze.Columns, Maze.Score, Maze.Date FROM Student, Maze WHERE (Student.studentID = Maze.studentID) AND (Maze.Difficulty = '" + difficultyBox.SelectedItem.ToString() + "')";
                sqlda = new SqlDataAdapter(difficultyQuery, sqlcon);
                infoTable = new DataTable();
                sqlda.Fill(infoTable);
                mazeData.DataSource = infoTable;
            }
            //checks if only the name filter is applied to search the database 
            else if (nameBox.SelectedItem.ToString() != "N/A" && difficultyBox.SelectedItem.ToString() == "N/A")
            {
                splitName();
                //gathers all the attempts of a particular student in the teacher's class
                string nameQuery = "SELECT Student.FirstName, Student.Surname, Maze.Difficulty, Maze.Rows, Maze.Columns, Maze.Score, Maze.Date FROM Student, Maze WHERE (Student.studentID = Maze.studentID) AND (FirstName = '" + firstName +"') AND (Surname = '" + surname + "')";
                sqlda = new SqlDataAdapter(nameQuery, sqlcon);
                infoTable = new DataTable();
                sqlda.Fill(infoTable);
                mazeData.DataSource = infoTable;
            }
            //checks if both filters is applied to search the database
            else if (difficultyBox.SelectedItem.ToString() != "N/A" && nameBox.SelectedItem.ToString() != "N/A")
            {
                splitName();
                //gathers a particular student's attempts at a maze of a certain difficulty 
                string query = "SELECT Student.FirstName, Student.Surname, Maze.Difficulty, Maze.Rows, Maze.Columns, Maze.Score, Maze.Date FROM Student, Maze WHERE (Student.studentID = Maze.studentID) AND (FirstName = '" + firstName + "') AND (Surname = '" + surname + "') AND (Maze.Difficulty = '" + difficultyBox.SelectedItem.ToString() + "')";
                sqlda = new SqlDataAdapter(query, sqlcon);
                infoTable = new DataTable();
                sqlda.Fill(infoTable);
                mazeData.DataSource = infoTable;
            }
            //checks if neither filter is applied to search the database
            else
            {
                //gathers a particular student's attempts at a maze of a certain difficulty 
                string query = "SELECT Student.FirstName, Student.Surname, Maze.Difficulty, Maze.Rows, Maze.Columns, Maze.Score, Maze.Date FROM Student, Maze WHERE Student.studentID = Maze.studentID";
                sqlda = new SqlDataAdapter(query, sqlcon);
                infoTable = new DataTable();
                sqlda.Fill(infoTable);
                mazeData.DataSource = infoTable;
            }
        }
    }
}
