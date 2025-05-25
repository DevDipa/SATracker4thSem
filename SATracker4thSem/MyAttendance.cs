using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace SATracker4thSem
{
    public partial class MyAttendance : Form
    {
        private static string connectionString = "server=localhost;uid=root;pwd=;database=SATracker_db;";
        public MyAttendance()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FetchAttendance()
        {
            if (string.IsNullOrWhiteSpace(cbBatch.Text) || string.IsNullOrWhiteSpace(txtMyRollNo.Text))
            {
                MessageBox.Show("Please enter both Batch and Roll No.");
                return;
            }

            if (!int.TryParse(txtMyRollNo.Text, out int rollNo))
            {
                MessageBox.Show("Invalid Roll Number. Please enter a numeric value.");
                return;
            }

            string batch = cbBatch.Text;
            dataGridView1.Rows.Clear();

            using (MySqlConnection con = Database.GetConnection()) 
            {
                string query = @"
            SELECT 
                A.attendance_date AS Date, 
                S.full_name AS Name, 
                A.batch AS Batch, 
                A.status AS Status
            FROM Attendance A
            JOIN Students S ON A.std_roll = S.roll_no
            WHERE A.std_roll = @rollNo 
              AND A.batch = @batch
              AND A.attendance_date >= CURDATE() - INTERVAL 7 DAY
            ORDER BY A.attendance_date DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@rollNo", rollNo);
                    cmd.Parameters.AddWithValue("@batch", batch);

                    try
                    {
                        con.Open();
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(
                                Convert.ToDateTime(reader["Date"]).ToString("dd/MM/yyyy"),
                                reader["Name"].ToString(),
                                reader["Batch"].ToString(),
                                reader["Status"].ToString()
                            );
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error fetching data: " + ex.Message);
                    }
                }
            }
        }



        private void MyAttendance_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Date";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Batch";
            dataGridView1.Columns[3].Name = "Status";
        }

        private void btnLoadAttendance_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void btnPrintAttendance_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLoadAttendance1_Click(object sender, EventArgs e)
        {
            FetchAttendance();
        }

        private void btnPrintAttendance1_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDoc;
            previewDialog.ShowDialog();
        }
    }
}
