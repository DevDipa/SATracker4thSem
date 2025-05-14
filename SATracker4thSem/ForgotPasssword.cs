using Dapper;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SATracker4thSem
{
    public partial class ForgotPasssword : Form
    {
        public ForgotPasssword()
        {
            InitializeComponent();
        }

        private void btnShowC_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.PasswordChar == '*')
            {
                btnHideC.BringToFront();
                txtConfirmPassword.PasswordChar = '\0';

            }
        }

        private void btnHideC_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.PasswordChar == '\0')
            {
                btnShowC.BringToFront();
                txtConfirmPassword.PasswordChar = '*';

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.PasswordChar == '*')
            {
                btnHide.BringToFront();
                txtNewPassword.PasswordChar = '\0';

            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                txtNewPassword.PasswordChar = '*';

            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
        
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Field validation
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Email format check
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Invalid email format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Password match check
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = Database.GetConnection())
            {
                // First verify if user exists
                var user = conn.QueryFirstOrDefault<User>(
                    "SELECT * FROM Users WHERE username = @Username AND email = @Email",
                    new { Username = username, Email = email });

                if (user == null)
                {
                    MessageBox.Show("No user found with provided credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the password
                string updateQuery = "UPDATE Users SET password = @Password WHERE id = @Id";

                int rows = conn.Execute(updateQuery, new { Password = newPassword, Id = user.Id });

                if (rows > 0)
                {
                    MessageBox.Show("Password reset successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    LoginForm loginForm = new LoginForm();
                    loginForm.Show();
                }
                else
                {
                    MessageBox.Show("Failed to reset password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    
}
}
