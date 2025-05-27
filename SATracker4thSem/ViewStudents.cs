using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace SATracker4thSem
{
    public partial class ViewStudents : Form
    {
        public ViewStudents()
        {
            InitializeComponent();
            cbBatch.SelectedIndexChanged += cbBatch_SelectedIndexChanged;

        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void btnPrintRecord_Click(object sender, EventArgs e)
        {

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDoc;
            previewDialog.ShowDialog();
        }

        private void ViewStudents_Load(object sender, EventArgs e)
        {
            try
            {

                cbBatch.SelectedIndex = 0;

                dataGridView1.AutoGenerateColumns = true;

                // Clear previous data
                dataGridView1.DataSource = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing ViewStudents: " + ex.Message);
            }

        }

        private void cbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBatch = cbBatch.SelectedItem.ToString();
            LoadStudentsByBatch(selectedBatch);
        }


        private void LoadStudentsByBatch(string batch)
        {
            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT roll_no AS 'Roll No.', full_name AS 'Name', email AS 'Email', phone_no AS 'Phone No.' FROM Students WHERE batch = @batch";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@batch", batch);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }
        }

        private void btnPrintRecord_MouseEnter(object sender, EventArgs e)
        {
            btnPrintRecord.BackColor = Color.MediumPurple;
        }

        private void btnPrintRecord_MouseLeave(object sender, EventArgs e)
        {
            btnPrintRecord.BackColor = Color.FromArgb(110, 89, 165); 
        }
    }

}

