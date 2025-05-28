using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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

        private void ViewAttendance_Load(object sender, EventArgs e)
        {
           
            cbBatch.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Today;

            LoadAttendanceData();
        }

        private void btnUpdateAttendance_Click(object sender, EventArgs e)
        {

            // Find the parent TeacherDashboard
            Form parentForm = this.TopLevelControl as Form;
            if (parentForm is TeacherDashboard dashboard)
            {
                // Access the OpenChildForm method via reflection or make it public
                var method = typeof(TeacherDashboard).GetMethod("OpenChildForm", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (method != null)
                {
                    string batch = cbBatch.SelectedItem.ToString();  
                    DateTime date = dateTimePicker1.Value;

                    method.Invoke(dashboard, new object[] { new MarkAttendance(batch, date) });

                }
            }
            else
            {
                MessageBox.Show("Parent dashboard not found. Cannot open MarkAttendance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateDetails_MouseEnter_1(object sender, EventArgs e)
        {
            btnUpdateDetails.BackColor = Color.MediumPurple;
        }

        private void btnUpdateDetails_MouseLeave_1(object sender, EventArgs e)
        {
            btnUpdateDetails.BackColor = Color.FromArgb(110, 89, 165);
        }

        private void btnPrintAttendance_MouseEnter_1(object sender, EventArgs e)
        {
            btnPrintAttendance.BackColor = Color.MediumPurple;
        }

        private void btnPrintAttendance_MouseLeave_1(object sender, EventArgs e)
        {
            btnPrintAttendance.BackColor = Color.FromArgb(110, 89, 165);
        }
    }
}
