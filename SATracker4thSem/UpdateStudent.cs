using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Dapper; 

namespace SATracker4thSem
{
    public partial class UpdateStudent : Form
    {
        public UpdateStudent()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbRollNotobeUpdated_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tbRollNotobeUpdated.Text.Trim(), out int rollNo))
            {
                using (var conn = Database.GetConnection())
                {
                    var student = conn.QueryFirstOrDefault<Student>("SELECT * FROM Students WHERE roll_no = @RollNo", new { RollNo = rollNo });

                    if (student != null)
                    {
                        cbBatch.Text = student.batch;
                        txtFullName.Text = student.full_name;
                        txtRollNo.Text = student.roll_no.ToString(); 
                        txtEmail.Text = student.email;
                        txtPhoneNo.Text = student.phone_no;
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Basic input validation
            if (string.IsNullOrWhiteSpace(tbRollNotobeUpdated.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(cbBatch.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNo.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate roll number (used for locating the student)
            if (!int.TryParse(tbRollNotobeUpdated.Text.Trim(), out int rollNo))
            {
                MessageBox.Show("Invalid Roll Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            // Phone number validation
            string phonePattern = @"^\d{10}$";
            if (!Regex.IsMatch(txtPhoneNo.Text.Trim(), phonePattern))
            {
                MessageBox.Show("Phone number must be 10 digits long and contain only numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = Database.GetConnection())
            {
                // Check for duplicate email or phone number in other students
                string checkQuery = @"SELECT COUNT(*) FROM Students 
                              WHERE (email = @Email OR phone_no = @PhoneNo) 
                              AND roll_no != @RollNo"; // exclude current student

                int count = conn.ExecuteScalar<int>(checkQuery, new
                {
                    Email = txtEmail.Text.Trim(),
                    PhoneNo = txtPhoneNo.Text.Trim(),
                    RollNo = rollNo
                });

                if (count > 0)
                {
                    MessageBox.Show("Email or Phone Number already exists for another student.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Proceed to update
                string updateQuery = @"UPDATE Students 
                               SET full_name = @FullName, 
                                   batch = @Batch, 
                                   email = @Email, 
                                   phone_no = @PhoneNo 
                               WHERE roll_no = @RollNo";

                int result = conn.Execute(updateQuery, new
                {
                    FullName = txtFullName.Text.Trim(),
                    Batch = cbBatch.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    PhoneNo = txtPhoneNo.Text.Trim(),
                    RollNo = rollNo
                });

                if (result > 0)
                {
                    MessageBox.Show("Student details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Update failed. The student with that Roll No. may not exist.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ClearFields()
        {
            tbRollNotobeUpdated.Clear();
            txtRollNo.Clear();
            txtFullName.Clear();
            cbBatch.SelectedIndex = -1;
            txtEmail.Clear();
            txtPhoneNo.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
