using System;
using System.Windows.Forms;
using Dapper;
using System.Text.RegularExpressions;
using System.Drawing;   

namespace SATracker4thSem
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                btnHide.BringToFront();
                txtPassword.PasswordChar = '\0';

            }
        }

        private void btnShowC_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.PasswordChar == '*')
            {
                btnHideC.BringToFront();
                txtConfirmPassword.PasswordChar = '\0';

            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnHideC_Click(object sender, EventArgs e)
        {
           
            if (txtConfirmPassword.PasswordChar == '\0')
            {
                btnShowC.BringToFront();
                txtConfirmPassword.PasswordChar = '*';

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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string email = txtEmail.Text.Trim();
            string role = rbTeacher.Checked ? "Teacher" : rbStudent.Checked ? "Student" : "";

            if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please select a role (Teacher or Student).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Username validation (alphanumeric, 3–20 characters)
            string usernamePattern = @"^[a-zA-Z0-9]{3,20}$";
            if (!Regex.IsMatch(username, usernamePattern))
            {
                MessageBox.Show("Username must be alphanumeric and 3–20 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password strength (min 6 chars, 1 uppercase, 1 digit)
            string passwordPattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!#@+-_]).{6,}$";
            if (!Regex.IsMatch(password, passwordPattern))
            {
                MessageBox.Show("Password must be at least 6 characters and include 1 uppercase letter and 1 number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password match check
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Email format validation
            string emailPattern = @"^[a-zA-Z0-9_+-.%$]+@[a-zA-z0-9-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Database Duplicate Check & Insert ---
            using (var connection = Database.GetConnection())
            {
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE username = @Username";
                int exists = connection.ExecuteScalar<int>(checkQuery, new { Username = username });

                if (exists > 0)
                {
                    MessageBox.Show("Username already taken. Please choose another.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check for duplicate email
                string emailCheckQuery = "SELECT COUNT(*) FROM Users WHERE email = @Email";
                int emailExists = connection.ExecuteScalar<int>(emailCheckQuery, new { Email = email });

                if (emailExists > 0)
                {
                    MessageBox.Show("An account with this email already exists.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insert new user
                string insertQuery = @"INSERT INTO Users (username, password, role, email) 
                       VALUES (@Username, @Password, @Role, @Email)";

                var result = connection.Execute(insertQuery, new
                {
                    Username = username,
                    Password = password,
                    Role = role,
                    Email = email
                });

                if (result > 0)
                {
                    MessageBox.Show("Account created successfully! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to create account. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            this.Hide();

            LoginForm loginForm = new LoginForm();
            loginForm.FormClosed += (s, args) => this.Close();
            loginForm.Show();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Firebrick;
            btnClose.ForeColor = Color.White;   
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(110, 89, 165);
            btnClose.ForeColor = SystemColors.Control;
        }

        private void btnSubmit_MouseEnter(object sender, EventArgs e)
        {
            btnShow.BackColor = Color.MediumPurple;
        }

        private void btnSubmit_MouseLeave(object sender, EventArgs e)
        {
            btnShow.BackColor = Color.FromArgb(110, 89, 165);
        }
    }
}
