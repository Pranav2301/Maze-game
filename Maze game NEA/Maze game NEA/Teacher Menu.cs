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
    public partial class Teacher_Menu : Form
    {
        public Teacher_Menu()
        {
            InitializeComponent();
        }
        private void checkOption()
        {
            //checks what option is selected by the user and opens the corresponding form
            try
            {
                if (optionBox.SelectedItem.ToString() == "Student data")
                {
                    //student data form is opened
                    Student_data studentPage = new Student_data(this);
                    this.Hide();
                    studentPage.ShowDialog();
                    this.Close();
                }

                else if (optionBox.SelectedItem.ToString() == "Print menu")
                {
                    //print menu form is opened
                    //Print_menu printPage = new Print_menu();
                    Student_menu menu = new Student_menu();
                    Student_Maze maze = new Student_Maze(menu);
                    this.Hide();
                    maze.ShowDialog(this);
                    //printPage.ShowDialog();
                    this.Close();
                }
            }
            catch (NullReferenceException)
            {
                //exception is thrown if user doesn't select an option
                MessageBox.Show("Select an option from the drop down menu");
            }
        }
        public void teacherLogin()
        {
            //establish connection with database
            string username = usernameTxt.Text;
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Main\Documents\Visual Studio 2012\Projects\Maze game NEA\Maze game NEA\mazeDtb.mdf;Integrated Security=True;Connect Timeout=30");
            string loginQuery = "SELECT * FROM Teacher WHERE username='" + username + "'";
            SqlDataAdapter sqlda = new SqlDataAdapter(loginQuery, sqlcon);
            //all the data from the table is selected and it tries to find username and password entered by the user
            DataTable loginTable = new DataTable();
            sqlda.Fill(loginTable);
           //checks if username exists in the database
            if (loginTable.Rows.Count == 1)
            {
                //retrieve salt for that user
                string salt = loginTable.Rows[0][4].ToString();
                Registration_page reg = new Registration_page();
                //use SHA1 hash on the password entered by the user combined with the salt
                string password = reg.SHAhash(passwordTxt.Text + salt);
                //checks if hashed value matches the value in the database
                if (password == loginTable.Rows[0][2].ToString())
                {
                    //successful login
                    checkOption();
                }
                else
                {
                    verificationLbl.ForeColor = System.Drawing.Color.Red;
                    verificationLbl.Text = "Password is incorrect. Please try again";
                }
            }
            else
            {
                verificationLbl.ForeColor = System.Drawing.Color.Red; 
                verificationLbl.Text = "Username or password is incorrect. Please try again";
            }
            //presence check on username field
            if (usernameTxt.Text == "")
            {
                userLbl.ForeColor = System.Drawing.Color.Red;
                userLbl.Text = "The username field should not be blank";
            }
            //presence check on password field
            if (passwordTxt.Text == "")
            {
                passLbl.ForeColor = System.Drawing.Color.Red;
                passLbl.Text = "Make sure you enter a password";
            }
        } 

        private void enterBtn_Click(object sender, EventArgs e)
        {
            verificationLbl.Text = "";
            userLbl.Text = "";
            passLbl.Text = "";
            teacherLogin();
        }

        private void regLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration_page regPage = new Registration_page();
            this.Hide();
            regPage.ShowDialog();
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
