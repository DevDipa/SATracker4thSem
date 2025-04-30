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

namespace SATracker4thSem
{
    public partial class ViewAttendance : Form
    {
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
            string batch = comboBox1.Text;

            for (int i = 6; i >= 0; i--)
            {
                DateTime date = selectedDate.AddDays(-i);
                attendanceData.Rows.Add(
                    date.ToString("yyyy-MM-dd"),
                    batch,
                    45 + i % 4, // Present
                    3 - i % 3,  // Absent
                    i % 4       // Late
                );
            }

            dataGridView1.DataSource = attendanceData;
        }


        public ViewAttendance()
        {
            InitializeComponent();
            dateTimePicker1.ValueChanged += (s, e) => LoadAttendanceData();
            comboBox1.SelectedIndexChanged += (s, e) => LoadAttendanceData();

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
            comboBox1.Items.AddRange(new string[] { "10-A", "10-B", "11-A" }); // sample batch list
            comboBox1.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Today;

            LoadAttendanceData();
        }
    }
}
