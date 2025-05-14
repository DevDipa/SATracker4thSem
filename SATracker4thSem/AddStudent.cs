using Dapper;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SATracker4thSem
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Input Validation
            if (string.IsNullOrWhiteSpace(txtRollNo.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(cbBatch.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNo.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Roll number validation
            if (!int.TryParse(txtRollNo.Text.Trim(), out int rollNo))
            {
                MessageBox.Show("Roll number must be a valid integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Full name validation
            string fullNamePattern = @"^[A-Za-z. ]+$";
            if (!Regex.IsMatch(txtFullName.Text.Trim(), fullNamePattern))
            {
                MessageBox.Show("Full name can only contain alphabets, dots, and spaces.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Email format validation
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Phone number validation (10 digits)
            string phonePattern = @"^\d{10}$";
            if (!Regex.IsMatch(txtPhoneNo.Text.Trim(), phonePattern))
            {
                MessageBox.Show("Phone number must be 10 digits long and contain only numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = Database.GetConnection())
            {
                // Check for existing roll number, email, or phone number
                string checkQuery = @"SELECT COUNT(*) FROM Students 
                              WHERE roll_no = @RollNo 
                                 OR email = @Email 
                                 OR phone_no = @PhoneNo";

                int count = connection.ExecuteScalar<int>(checkQuery, new
                {
                    RollNo = rollNo,
                    Email = txtEmail.Text.Trim(),
                    PhoneNo = txtPhoneNo.Text.Trim()
                });

                if (count > 0)
                {
                    MessageBox.Show("A student with this Roll No, Email, or Phone No already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insert query
                string insertQuery = @"INSERT INTO Students (roll_no, full_name, batch, email, phone_no) 
                               VALUES (@RollNo, @FullName, @Batch, @Email, @PhoneNo)";

                var parameters = new
                {
                    RollNo = rollNo,
                    FullName = txtFullName.Text.Trim(),
                    Batch = cbBatch.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    PhoneNo = txtPhoneNo.Text.Trim()
                };

                try
                {
                    int rowsInserted = connection.Execute(insertQuery, parameters);
                    if (rowsInserted > 0)
                    {
                        MessageBox.Show("Student added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearFields()
        {
           
            txtRollNo.Clear();
            txtFullName.Clear();
            cbBatch.SelectedIndex = -1;
            txtEmail.Clear();
            txtPhoneNo.Clear();
        }

    }
}

