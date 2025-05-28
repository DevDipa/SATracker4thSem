using System;
using System.Windows.Forms;
using Dapper;
using System.Drawing;

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
                        ClearFields(); 
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_MouseEnter_1(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.MediumPurple;
        }

        private void btnDelete_MouseLeave_1(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.FromArgb(110, 89, 165);
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.MediumPurple;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = SystemColors.ButtonHighlight;
        }
    }
}
