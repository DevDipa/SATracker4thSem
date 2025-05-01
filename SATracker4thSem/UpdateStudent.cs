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
                        txtRollNo.Text = student.roll_no.ToString(); // editable if needed
                        txtEmail.Text = student.email;
                        txtPhoneNo.Text = student.phone_no;
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
          
            // Basic validation
            if (string.IsNullOrWhiteSpace(tbRollNotobeUpdated.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(cbBatch.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNo.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Parse the original roll number (from the search box)
            if (!int.TryParse(tbRollNotobeUpdated.Text.Trim(), out int rollNo))
            {
                MessageBox.Show("Invalid Roll Number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var conn = Database.GetConnection())
            {
                string query = @"UPDATE Students 
                         SET full_name = @FullName, 
                             batch = @Batch, 
                             email = @Email, 
                             phone_no = @PhoneNo 
                         WHERE roll_no = @RollNo"; // roll_no is NOT changed

                var result = conn.Execute(query, new
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
    }
}
