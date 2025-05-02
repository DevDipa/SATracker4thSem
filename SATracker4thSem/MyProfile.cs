using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SATracker4thSem
{
    public partial class MyProfile : Form
    {
        private static string connectionString = "server=localhost;uid=root;pwd=;database=SATracker_db;";

        public MyProfile()
        {
            InitializeComponent();
            txtMyRollNo.KeyPress += txtMyRollNo_KeyPress;
            txtMyRollNo.TextChanged += tbRollNotobeUpdated_TextChanged;



        }

        private void tbRollNotobeUpdated_TextChanged(object sender, EventArgs e)
        {

            // Clear other fields to avoid showing stale data
            txtFullName.Clear();
            txtBatch.Clear();
            txtEmail.Clear();
            txtPhoneNo.Clear();

            if (int.TryParse(txtMyRollNo.Text, out int rollNo) && txtMyRollNo.Text.Length >= 3)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "SELECT full_name, batch, email, phone_no FROM Students WHERE roll_no = @rollNo";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@rollNo", rollNo);

                        try
                        {
                            conn.Open();
                            MySqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                txtFullName.Text = reader["full_name"].ToString();
                                txtBatch.Text = reader["batch"].ToString();
                                txtEmail.Text = reader["email"].ToString();
                                txtPhoneNo.Text = reader["phone_no"].ToString();
                            }

                            reader.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error fetching profile: " + ex.Message);
                        }
                    }
                }
            }
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
    }
}
