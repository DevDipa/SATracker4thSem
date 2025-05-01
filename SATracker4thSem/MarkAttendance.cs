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
using Dapper;

namespace SATracker4thSem
{
    public partial class MarkAttendance : Form
    {
        private static string connectionString = "server=localhost;uid=root;pwd=;database=SATracker_db;";

        public MarkAttendance()
        {
            InitializeComponent();

            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            cbBatch.SelectedIndexChanged += cbBatch_SelectedIndexChanged;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure click is on the Status column and a valid row
            if (e.ColumnIndex == dataGridView1.Columns["Status"].Index && e.RowIndex >= 0)
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                ToolStripMenuItem present = new ToolStripMenuItem("PRESENT");
                present.Click += (s, args) =>
                {
                    SetStatus(e.RowIndex, "PRESENT", Color.FromArgb(144, 238, 144)); // Light green
                };

                ToolStripMenuItem absent = new ToolStripMenuItem("ABSENT");
                absent.Click += (s, args) =>
                {
                    SetStatus(e.RowIndex, "ABSENT", Color.FromArgb(255, 182, 193)); // Light red
                };

                ToolStripMenuItem late = new ToolStripMenuItem("LATE");
                late.Click += (s, args) =>
                {
                    SetStatus(e.RowIndex, "LATE", Color.FromArgb(255, 218, 185)); // Light orange
                };

                menu.Items.Add(present);
                menu.Items.Add(absent);
                menu.Items.Add(late);

                var dgv = sender as DataGridView;
                var rect = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                Point location = dgv.PointToScreen(new Point(rect.X, rect.Y + rect.Height));
                menu.Show(location);
            }
        }

        private void SetStatus(int rowIndex, string status, Color color)
        {
            dataGridView1.Rows[rowIndex].Cells["Status"].Value = status;
            dataGridView1.Rows[rowIndex].Cells["Status"].Style.BackColor = color;
        }



        private void MarkAttendance_Load(object sender, EventArgs e)
        {
            // Setup DataGridView columns
            dataGridView1.Columns.Add("studentId", "Roll No.");
            dataGridView1.Columns.Add("studentName", "Name");

            // Add a button column for status
            DataGridViewButtonColumn statusColumn = new DataGridViewButtonColumn();
            statusColumn.Name = "Status";
            statusColumn.HeaderText = "STATUS";
            statusColumn.Text = "MARK";
            statusColumn.UseColumnTextForButtonValue = false;  // Allow dynamic text
            dataGridView1.Columns.Add(statusColumn);

            // Make Roll No. and Name columns read-only
            dataGridView1.Columns["studentId"].ReadOnly = true;
            dataGridView1.Columns["studentName"].ReadOnly = true;

            // Optional: font styling
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 12);

            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }
            


        

        private void cbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {


            string selectedBatch = cbBatch.SelectedItem.ToString();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT roll_no, full_name FROM Students WHERE batch = @batch";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@batch", selectedBatch);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        int index = dataGridView1.Rows.Add();
                        dataGridView1.Rows[index].Cells["studentId"].Value = row["roll_no"];
                        dataGridView1.Rows[index].Cells["studentName"].Value = row["full_name"];
                        dataGridView1.Rows[index].Cells["Status"].Value = ""; // default empty
                    }
                }
            }
        }

        

        private void btnSaveAttendance_Click(object sender, EventArgs e)
        {

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    int rollNo = Convert.ToInt32(row.Cells["studentId"].Value);
                    string status = row.Cells["Status"].Value?.ToString();

                    if (!string.IsNullOrEmpty(status))
                    {
                        string query = "INSERT INTO Attendance (std_roll, attendance_date, status, batch) " +
                                       "VALUES (@roll, @date, @status, @batch)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@roll", rollNo);
                        cmd.Parameters.AddWithValue("@date", dateTimePicker.Value.Date);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@batch", cbBatch.SelectedItem.ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Attendance saved successfully!");
            }
        }

    }
}



