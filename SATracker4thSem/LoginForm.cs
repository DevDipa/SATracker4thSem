using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SATracker4thSem
{
    public partial class LoginForm : Form
    {
        string connectionString = "Server=localhost;Database=SATracker_db;Uid=root;Pwd=;";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var conn = Database.GetConnection())
            {
                string query = "SELECT * FROM Users WHERE username = @Username AND password = @Password";
                var user = conn.QueryFirstOrDefault(query, new
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text.Trim()
                });

                if (user != null)
                {
                    string role = user.role;
                    string username = user.username;

                    if (role == "Teacher")
                    {
                        TeacherDashboard td = new TeacherDashboard(username);
                        td.Show();
                    }
                    else if (role == "Student")
                    {
                        StudentDashboard sd = new StudentDashboard(username);
                        sd.Show();
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid credentials.");
                }
            }


        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if(txtPassword.PasswordChar=='*')
            {
                btnHide.BringToFront();
                txtPassword.PasswordChar = '\0';
               
            }
            
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                txtPassword.PasswordChar = '*';

            }
        }

        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp su = new SignUp();
            su.Show();
            this.Hide();
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPasssword fm = new ForgotPasssword();
            fm.Show();
        }
    }
}

