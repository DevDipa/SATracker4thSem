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
         
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error");
                return;
            }

            using (IDbConnection db = new MySqlConnection("Server=localhost;Database=SATracker_db;Uid=root;Pwd=;"))
            {
                try
                {
                    string sql = "SELECT * FROM Users WHERE username = @Username AND password = @Password";
                    var user = db.QueryFirstOrDefault<User>(sql, new { Username = username, Password = password });

                    if (user != null)
                    {
                        if (user.Role == "Teacher")
                        {
                            TeacherDashboard td = new TeacherDashboard();
                            td.Show();
                            this.Hide();
                        }
                        else if (user.Role == "Student")
                        {
                            StudentDashboard sd = new StudentDashboard();
                            sd.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
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
    }
}

