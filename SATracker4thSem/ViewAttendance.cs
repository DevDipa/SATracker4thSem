using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace SATracker4thSem
{
    public partial class ViewAttendance : Form
    {
        private static string connectionString = "server=localhost;uid=root;pwd=;database=SATracker_db;";

        DataTable attendanceData;

        private void LoadAttendanceData()
        {
        
            attendanceData = new DataTable();
            attendanceData.Columns.Add("Date");
            attendanceData.Columns.Add("Batch");
            attendanceData.Columns.Add("Present");
            attendanceData.Columns.Add("Absent");
            attendanceData.Columns.Add("Late");

            DateTime selectedDate = dateTimePicker1.Value;
            string batch = cbBatch.Text;

            using (var connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                for (int i = 6; i >= 0; i--)
                {
                    DateTime date = selectedDate.AddDays(-i);
                    string dateString = date.ToString("dd/MM/yyyy");

                    var query = @"
                SELECT status, COUNT(*) AS count
                FROM Attendance
                WHERE attendance_date = @Date AND batch = @Batch
                GROUP BY status";

                    var result = connection.Query(query, new { Date = date, Batch = batch });

                    int present = 0, absent = 0, late = 0;

                    foreach (var row in result)
                    {
                        string status = row.status;
                        int count =(int) row.count;

                        switch (status.ToUpper())
                        {
                            case "PRESENT": present = count; break;
                            case "ABSENT": absent = count; break;
                            case "LATE": late = count; break;
                        }
                    }

                    attendanceData.Rows.Add(dateString, batch, present, absent, late);
                }
            }

            dataGridView1.DataSource = attendanceData;
        }

        


        public ViewAttendance()
        {
            InitializeComponent();
            dateTimePicker1.ValueChanged += (s, e) => LoadAttendanceData();
            cbBatch.SelectedIndexChanged += (s, e) => LoadAttendanceData();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSaveAttendance_Click(object sender, EventArgs e)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            PrintPreviewDialog previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDoc;
            previewDialog.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ViewAttendance_Load(object sender, EventArgs e)
        {
           
            cbBatch.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Today;

            LoadAttendanceData();
        }
    }
}
