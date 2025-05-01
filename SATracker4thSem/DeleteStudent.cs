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
    public partial class DeleteStudent : Form
    {
        public DeleteStudent()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbRollNotobeDeleted_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tbRollNotobeDeleted.Text, out int rollNo))
            {
                using (var conn = Database.GetConnection())
                {
                    var student = conn.QueryFirstOrDefault<Student>(
                        "SELECT * FROM Students WHERE roll_no = @RollNo",
                        new { RollNo = rollNo });

                    if (student != null)
                    {
                        cbBatch.Text = student.batch;
                        txtFullName.Text = student.full_name;
                        txtRollNo.Text = student.roll_no.ToString();
                        txtEmail.Text = student.email;
                        txtPhoneNo.Text = student.phone_no;
                    }
                    else
                    {
                        ClearFields(); // optional, clears the fields
                    }
                }
            }
        }

        private void ClearFields()
        {
            cbBatch.Text = "";
            txtFullName.Clear();
            txtRollNo.Clear();
            txtEmail.Clear();
            txtPhoneNo.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            if (!int.TryParse(tbRollNotobeDeleted.Text, out int rollNo))
            {
                MessageBox.Show("Invalid Roll No.");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (var conn = Database.GetConnection())
                {
                    var rowsAffected = conn.Execute("DELETE FROM Students WHERE roll_no = @RollNo", new { RollNo = rollNo });

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Student deleted successfully.");
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Student not found or already deleted.");
                    }
                }
            }
        

    }
}
}
