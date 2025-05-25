using Dapper;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace SATracker4thSem
{
    public partial class LoginForm : Form
    {
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

        //Password show/hide logic

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
            ForgotPassword fm = new ForgotPassword();
            fm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Firebrick;
            btnExit.ForeColor = SystemColors.Control;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {

            btnExit.BackColor = Color.FromArgb(110, 89, 165); 
            btnExit.ForeColor = SystemColors.Control;
        }
    }
}

