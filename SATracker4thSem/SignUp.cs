using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace SATracker4thSem
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

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

            // VALIDATIONS
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // DATABASE INSERT
            using (IDbConnection db = new MySqlConnection("server=localhost;uid=root;pwd=;database=SATracker_db"))
            {
                try
                {
                    // Check if username already exists
                    var existing = db.QueryFirstOrDefault<string>("SELECT username FROM Users WHERE username = @Username", new { Username = username });

                    if (existing != null)
                    {
                        MessageBox.Show("Username already exists. Please choose another.", "Duplicate User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Insert new user
                    string insertQuery = @"INSERT INTO Users (username, password, role) 
                                   VALUES (@Username, @Password, @Role)";

                    db.Execute(insertQuery, new { Username = username, Password = password, Role = role });

                    MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Close SignUp form after success
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    
}
}
