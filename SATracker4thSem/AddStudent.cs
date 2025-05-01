using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

            // Check if roll number is a valid integer
            if (!int.TryParse(txtRollNo.Text, out int rollNo))
            {
                MessageBox.Show("Roll number must be a valid integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Email format validation
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Phone number format validation (only digits, 7 to 15 characters)
            string phonePattern = @"^\d{7,15}$";
            if (!Regex.IsMatch(txtPhoneNo.Text.Trim(), phonePattern))
            {
                MessageBox.Show("Phone number must be 7 to 15 digits long and contain only numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = Database.GetConnection())
            {
                string query = @"INSERT INTO Students (roll_no, full_name, batch, email, phone_no) 
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
                    int rowsInserted = connection.Execute(query, parameters);
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
                catch (MySqlException ex) when (ex.Number == 1062)
                {
                    MessageBox.Show("A student with this roll number already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

