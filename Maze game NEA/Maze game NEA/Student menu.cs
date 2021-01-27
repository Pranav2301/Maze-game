using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Maze_game_NEA
{
   public partial class Student_menu : Form
    {

        public Student_menu()
        {
            InitializeComponent();
        }

        public bool validName(string name)
        {
            //regular expression for a string that needs to contain at least one letter
            var nameRegex = new Regex(@"[a-zA-Z]+");
            bool validName = nameRegex.IsMatch(name);
            if (validName == false)
            {
                fNameResultLbl.ForeColor = System.Drawing.Color.Red;
                fNameResultLbl.Text = "Make sure the first name you entered matches the requirements before you press submit";
            }

            else
            {
                fNameResultLbl.ForeColor = System.Drawing.Color.Green;
                fNameResultLbl.Text = "First name is accepted. Press submit once the surname and class are accepted";
            }
            return validName;
        }

        public bool validClass(string Class)
        {
            //regular expression for a string that needs to contain a number between 1 and 13 followed by a capital letter
            var classRegex = new Regex(@"^(([1-9]|1[0123])[A-Z])$");
            bool validClass = classRegex.IsMatch(Class);
            if (validClass == false)
            {
                classResultLbl.ForeColor = System.Drawing.Color.Red;
                classResultLbl.Text = "Make sure that the class you entered matches the requirements";
            }
            else
            {
                classResultLbl.ForeColor = System.Drawing.Color.Green;
                classResultLbl.Text = "Class is accepted. Press submit if all other values are accepted";
            }
            return validClass;
        }

        public bool checkStudentExists()
        {
            //check connection by performing a lookup check in the database
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Main\Documents\Visual Studio 2012\Projects\Maze game NEA\Maze game NEA\loginTest.mdf;Integrated Security=True;Connect Timeout=30");
            sqlcon.Open();
            string existQuery = "SELECT COUNT(*) FROM Student WHERE FirstName='" + firstNameTxt.Text + "' AND Surname ='" + surnameTxt.Text + "'";
            SqlCommand sqlcom = new SqlCommand(existQuery, sqlcon);
            int match = (int)sqlcom.ExecuteScalar();
            //check if what the user enters in the textbox returns from the database
            if (match == 0)
            {
                //0 is assigned to match so username doesn't exist
                return false;
            }
            return true;
        }

        private void enterBtn_Click(object sender, EventArgs e)
        {
            //checks if any of the fields have invalid values
            if (!validName(firstNameTxt.Text) | !validName(surnameTxt.Text) | !validClass(classTxt.Text))
            {
                //ends main function
                return;
            }
            string firstName = firstNameTxt.Text;
            string surname = surnameTxt.Text;
            string studentClass = classTxt.Text;
            if (!checkStudentExists())
            {
                //if student doesn't exist in the DB, write their details to the DB
                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Main\Documents\Visual Studio 2012\Projects\Maze game NEA\Maze game NEA\loginTest.mdf;Integrated Security=True;Connect Timeout=30");
                sqlcon.Open();
                string query = "insert into Student values(@FirstName,@Surname,@Class)";
                SqlCommand sqlcom = new SqlCommand(query, sqlcon);
                sqlcom.Parameters.AddWithValue("FirstName", firstName);
                sqlcom.Parameters.AddWithValue("Surname", surname);
                sqlcom.Parameters.AddWithValue("Class", studentClass);
                sqlcom.ExecuteNonQuery();
            }
            //open maze form and pass an object of this form to it
            Student_Maze maze = new Student_Maze(this);
            this.Hide();
            maze.ShowDialog();
            this.Close();
        }
    } 

}
