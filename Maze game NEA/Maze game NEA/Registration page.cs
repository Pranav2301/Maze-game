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
using System.Security.Cryptography;

namespace Maze_game_NEA
{
    public partial class Registration_page : Form
    {
        public Registration_page()
        {
            InitializeComponent();
        }

        public bool validUsername(string user)
        {
            //regular expression for a string that needs to contain at least one letter
            var userRegex = new Regex(@"^[A-z]+$");
            bool validUser = userRegex.IsMatch(user);
            if (validUser == false)
            {
                userResultLbl.ForeColor = System.Drawing.Color.Red;
                userResultLbl.Text = "Make sure your username matches the requirements before you press submit";
            }

            else if (checkUserExists())
            {
                userResultLbl.ForeColor = System.Drawing.Color.Red;
                userResultLbl.Text = "Username already exists. Re-enter another username.";
            }

            else
            {
                userResultLbl.ForeColor = System.Drawing.Color.Green;
                userResultLbl.Text = "Username is accepted. Press submit once the password is also accepted";
            }
            return validUser;
        }

        public bool validPass(string pass)
        {
            //regular expression for a password that needs to contain a minimum of 8 characters with at least one upper and lower case letter, one digit and one special character
            var passRegex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            bool passValid = passRegex.IsMatch(pass);
            if (passValid == false)
            {
                passResultLbl.ForeColor = System.Drawing.Color.Red;
                passResultLbl.Text = "Make sure your password matches the requirements";
            }
            else
            {
                passResultLbl.ForeColor = System.Drawing.Color.Green;
                passResultLbl.Text = "Password is accepted. Press submit if the username is also accepted";
            }
            return passValid;
        }

        public bool validClass(string Class)
        {
            //regular expression for a string that needs to contain a number between 1 and 13 followed by a capital letter
            var classRegex = new Regex(@"^(([1-9]|1[0123])[A-Z])$");
            bool validClass = classRegex.IsMatch(Class);
            if (validClass == false)
            {
                classResultLbl.ForeColor = System.Drawing.Color.Red;
                classResultLbl.Text = "Make sure the class you entered matches the requirements";
            }
            else
            {
                classResultLbl.ForeColor = System.Drawing.Color.Green;
                classResultLbl.Text = "Class is accepted. Press enter submitted the username and password is accepted";
            }
            return validClass;
        }

        public string genSalt()
        {
            //function randomly creates a salt when called
            byte[] salt;
            //fills salt with 16 random values
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            StringBuilder saltStr = new StringBuilder();
            foreach (var character in salt)
            {
                //appends all the values in salt to saltStr
                saltStr.Append(character.ToString());
            }
            return saltStr.ToString();
        }
        public string SHAhash(string text)
        //applies SHA1 encryption to the text passed into the function
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            sha1.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] hashValue = sha1.Hash;
            StringBuilder hash = new StringBuilder();
            foreach (var character in hashValue)
            {
                //change each character of the hashValue to its hexadecimal value and append it to hash 
                hash.Append(character.ToString("x2"));
            }
            return hash.ToString();
        }

        public bool checkUserExists()
        {
            //check connection by performing a lookup check in the database
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Main\Documents\Visual Studio 2012\Projects\Maze game NEA\Maze game NEA\mazeDtb.mdf;Integrated Security=True;Connect Timeout=30");
            sqlcon.Open();
            string existQuery = "SELECT COUNT(*) FROM Teacher WHERE username='" + usernameTxt.Text + "'";
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

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (!validUsername(usernameTxt.Text) | !validPass(passwordTxt.Text) | !validClass(classTxt.Text))
            {
                return;
            }
            string teacherUser = usernameTxt.Text;
            string salt = genSalt();
            string teacherPass = SHAhash(passwordTxt.Text + salt);
            string teacherClass = classTxt.Text;
            //establish connection with database
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Main\Documents\Visual Studio 2012\Projects\Maze game NEA\Maze game NEA\mazeDtb.mdf;Integrated Security=True;Connect Timeout=30");
            sqlcon.Open();
            string query = "insert into Teacher values(@username,@password,@class,@salt)";
            SqlCommand sqlcom = new SqlCommand(query, sqlcon);
            sqlcom.Parameters.AddWithValue("username", teacherUser);
            sqlcom.Parameters.AddWithValue("password", teacherPass);
            sqlcom.Parameters.AddWithValue("class", teacherClass);
            sqlcom.Parameters.AddWithValue("salt", salt);
            sqlcom.ExecuteNonQuery();
            string getIDQuery = "SELECT * FROM Teacher WHERE class='" + teacherClass + "'";//Get record where class matches the class entered by the student
            SqlDataAdapter sqlda = new SqlDataAdapter(getIDQuery, sqlcon);
            DataTable teacherTable = new DataTable();
            sqlda.Fill(teacherTable);
            //checks if there is a record in the teacherTable that matches the class entered by the student
            if (teacherTable.Rows.Count == 1)
            {
                int teacherID = (int)teacherTable.Rows[0][0];//get primary key from Teacher table
                string updateQuery = "UPDATE Student SET teacherID = @teacherID WHERE Class='" + teacherClass + "'";
                sqlcom = new SqlCommand(updateQuery, sqlcon);
                sqlcom.Parameters.AddWithValue("teacherID", teacherID);//add foreign key to the Student table
                sqlcom.ExecuteNonQuery();
            }
            //user is taken back to the teacherMenu form after registration is successful
            Teacher_Menu menuForm = new Teacher_Menu();
            this.Hide();
            menuForm.ShowDialog();
            this.Close();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            MainMenu menu = new MainMenu();//open main menu
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            Information_page help = new Information_page();//open information page
            this.Hide();
            help.ShowDialog();
            this.Close();
        }
    } 
}


