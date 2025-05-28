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


        //Login button logic
        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.MediumPurple;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(110, 89, 165);
        }

        //Exit button logic
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_MouseEnter_1(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Firebrick;
        }

        private void btnExit_MouseLeave_1(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(110, 89, 165);
        }

        //Minimize button logic
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMinimize_MouseEnter(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.Firebrick;
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.FromArgb(110, 89, 165);
        }
    }
}

