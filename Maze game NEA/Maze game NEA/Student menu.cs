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
           var nameRegex = new Regex(@"^[A-z]+$");
           bool validName = nameRegex.IsMatch(name);
           return validName;
       }

       public bool validClass(string Class)
       {
           //regular expression for a string that needs to contain a number between 1 and 13 followed by a capital letter
           var classRegex = new Regex(@"^(([1-9]|1[0123])[A-Z])$");
           bool validClass = classRegex.IsMatch(Class);
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
           fNameResultLbl.Text = "";
           surnameResultLbl.Text = "";
           classResultLbl.Text = "";
           bool validCheck = true;
           if (!validName(firstNameTxt.Text))
           {
               //checks if the first name is appropriate
               fNameResultLbl.ForeColor = System.Drawing.Color.Red;
               fNameResultLbl.Text = "Make sure the first name you entered matches the requirements";
               validCheck = false;
           }
           if (!validName(surnameTxt.Text))
           {
               //checks if the surname is appropriate
               surnameResultLbl.ForeColor = System.Drawing.Color.Red;
               surnameResultLbl.Text = "Make sure the surname you entered matches the requirements";
               validCheck = false;
           }
           if (!validClass(classTxt.Text))
           {
               //checks if the class is appropriate
               classResultLbl.ForeColor = System.Drawing.Color.Red;
               classResultLbl.Text = "Make sure that the class you entered matches the requirements";
               validCheck = false;
           }
           if (!validCheck)
           {
               //if any of the user inputs are invalid, exit out of the main function
               return;
           }
           string firstName = firstNameTxt.Text;
           string surname = surnameTxt.Text;
           string studentClass = classTxt.Text;
           SqlCommand sqlcom; 
           SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Main\Documents\Visual Studio 2012\Projects\Maze game NEA\Maze game NEA\loginTest.mdf;Integrated Security=True;Connect Timeout=30");
           sqlcon.Open();
           if (!checkStudentExists())
           {
               //if student doesn't exist in the DB, write their details to the DB
               string query = "insert into Student(FirstName, Surname, Class) values(@FirstName,@Surname,@Class)";
               sqlcom = new SqlCommand(query, sqlcon);
               sqlcom.Parameters.AddWithValue("FirstName", firstName);
               sqlcom.Parameters.AddWithValue("Surname", surname);
               sqlcom.Parameters.AddWithValue("Class", studentClass);
               sqlcom.ExecuteNonQuery();
           }
           string getIDQuery = "SELECT * FROM Teacher WHERE class='" + studentClass + "'";//Get record where class matches the class entered by the student
           SqlDataAdapter sqlda = new SqlDataAdapter(getIDQuery, sqlcon);
           DataTable teacherTable = new DataTable();
           sqlda.Fill(teacherTable);
           //checks if there is a record in the teacherTable that matches the class entered by the student
           if (teacherTable.Rows.Count == 1)
           {
               int teacherID = (int)teacherTable.Rows[0][0];//get primary key from Teacher table
               string updateQuery = "UPDATE Student SET teacherID = @teacherID WHERE FirstName='" + firstName + "' AND Surname='" + surname + "'";
               sqlcom = new SqlCommand(updateQuery, sqlcon);
               sqlcom.Parameters.AddWithValue("teacherID", teacherID);//add foreign key to the Student table
               sqlcom.ExecuteNonQuery();
           }
           Student_Maze maze = new Student_Maze(this);//open student maze form passing an instance of this form
           this.Hide();
           maze.ShowDialog();
           this.Close();
       }
   }
}
