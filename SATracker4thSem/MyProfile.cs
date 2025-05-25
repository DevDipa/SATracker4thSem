using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace SATracker4thSem
{
    public partial class MyProfile : Form
    {


        public MyProfile()
        {
            InitializeComponent();
            txtMyRollNo.KeyPress += txtMyRollNo_KeyPress;
            txtMyRollNo.TextChanged += tbRollNotobeUpdated_TextChanged;
        }

        private void tbRollNotobeUpdated_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtMyRollNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtMyRollNo_Leave(object sender, EventArgs e)
        {


        }

        private void btnView_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtBatch.Clear();
            txtEmail.Clear();
            txtPhoneNo.Clear();

            if (!int.TryParse(txtMyRollNo.Text, out int rollNo) || txtMyRollNo.Text.Length < 3)
            {

                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                using (var cmd = new MySqlCommand("SELECT full_name, batch, email, phone_no FROM Students WHERE roll_no = @rollNo", conn))
                {
                    cmd.Parameters.AddWithValue("@rollNo", rollNo);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFullName.Text = reader["full_name"].ToString();
                            txtBatch.Text = reader["batch"].ToString();
                            txtEmail.Text = reader["email"].ToString();
                            txtPhoneNo.Text = reader["phone_no"].ToString();
                        }
                        else
                        {

                            MessageBox.Show("No student found with that Roll No.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching profile: " + ex.Message);
            }
        }
    }
}