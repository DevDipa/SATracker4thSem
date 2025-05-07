using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SATracker4thSem
{
    public partial class MarkAttendance : Form
    {
        private static string connectionString = "server=localhost;uid=root;pwd=;database=SATracker_db;";
        private string _batch;
        private DateTime _date;
        private bool _isInitializedFromDateBatch = false;

        public MarkAttendance()
        {
            InitializeComponent();
            InitializeGrid();
            cbBatch.SelectedIndexChanged += cbBatch_SelectedIndexChanged;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

        public MarkAttendance(string batch, DateTime date) : this()
        {
            _batch = batch;
            _date = date;
            _isInitializedFromDateBatch = true;


            InitializeGrid();

            dateTimePicker.Value = _date;
            cbBatch.SelectedItem = _batch; // triggers cbBatch_SelectedIndexChanged

            // Delay loading until data is fully initialized
            this.Shown += (s, e) => LoadPreviousAttendance();
        }

        private void MarkAttendance_Load(object sender, EventArgs e)
        {
            InitializeGrid();

            // Disable Saturdays in the DateTimePicker
            dateTimePicker.ValueChanged += (s, p) =>
            {
                if (dateTimePicker.Value.DayOfWeek == DayOfWeek.Saturday)
                {
                    MessageBox.Show("Saturday is a holiday. Please select a working day.");
                    // Automatically move to next day (Sunday)
                    dateTimePicker.Value = dateTimePicker.Value.AddDays(1);
                }
            };

        }

        private void InitializeGrid()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("studentId", "Roll No.");
            dataGridView1.Columns.Add("studentName", "Name");

            DataGridViewButtonColumn statusColumn = new DataGridViewButtonColumn
            {
                Name = "Status",
                HeaderText = "STATUS",
                Text = "MARK",
                UseColumnTextForButtonValue = false
            };
            dataGridView1.Columns.Add(statusColumn);

            dataGridView1.Columns["studentId"].ReadOnly = true;
            dataGridView1.Columns["studentName"].ReadOnly = true;

            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 12);
        }

        private void cbBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedBatch = cbBatch.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedBatch)) return;

            dataGridView1.Rows.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT roll_no, full_name FROM Students WHERE batch = @batch";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@batch", selectedBatch);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            int index = dataGridView1.Rows.Add();
                            dataGridView1.Rows[index].Cells["studentId"].Value = row["roll_no"];
                            dataGridView1.Rows[index].Cells["studentName"].Value = row["full_name"];
                            dataGridView1.Rows[index].Cells["Status"].Value = ""; // initially blank
                        }
                    }
                }
            }

            if (_isInitializedFromDateBatch)
            {
                LoadPreviousAttendance();
                _isInitializedFromDateBatch = false; // prevent reloading multiple times
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Status"].Index && e.RowIndex >= 0)
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                void AddItem(string label, Color color)
                {
                    var item = new ToolStripMenuItem(label);
                    item.Click += (s, args) => SetStatus(e.RowIndex, label, color);
                    menu.Items.Add(item);
                }

                AddItem("PRESENT", Color.LightGreen);
                AddItem("ABSENT", Color.LightCoral);
                AddItem("LATE", Color.PeachPuff);

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

        private void btnSaveAttendance_Click(object sender, EventArgs e)
        {

            DateTime selectedDate = dateTimePicker.Value.Date;

           
            string batch = cbBatch.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(batch))
            {
                MessageBox.Show("Please select a batch.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string rollNo = row.Cells["studentId"].Value?.ToString();
                            string status = row.Cells["Status"].Value?.ToString();

                            if (!string.IsNullOrEmpty(rollNo) && !string.IsNullOrEmpty(status))
                            {
                                string query = @"
                                    INSERT INTO Attendance (std_roll, attendance_date, status, batch)
                                    VALUES (@roll, @date, @status, @batch)
                                    ON DUPLICATE KEY UPDATE
                                        status = VALUES(status);";

                                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                                {
                                    cmd.Parameters.AddWithValue("@roll", rollNo);
                                    cmd.Parameters.AddWithValue("@date", selectedDate);
                                    cmd.Parameters.AddWithValue("@status", status);
                                    cmd.Parameters.AddWithValue("@batch", batch);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                   

                    MessageBox.Show("Attendance saved successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving attendance: " + ex.Message);
            }
        }

        private void LoadPreviousAttendance()
        {
            string batch = _batch ?? cbBatch.SelectedItem?.ToString();
            DateTime date = _date != default ? _date : dateTimePicker.Value.Date;

            if (string.IsNullOrEmpty(batch)) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT std_roll, status FROM Attendance WHERE batch = @batch AND attendance_date = @date";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@batch", batch);
                        cmd.Parameters.AddWithValue("@date", date);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Dictionary<string, string> attendanceMap = new Dictionary<string, string>();
                            while (reader.Read())
                            {
                                string rollNo = reader["std_roll"].ToString();
                                string status = reader["status"].ToString();
                                attendanceMap[rollNo] = status;
                            }

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                string roll = row.Cells["studentId"].Value?.ToString();
                                if (roll != null && attendanceMap.ContainsKey(roll))
                                {
                                    row.Cells["Status"].Value = attendanceMap[roll];
                                    switch (attendanceMap[roll])
                                    {
                                        case "PRESENT": row.Cells["Status"].Style.BackColor = Color.LightGreen; break;
                                        case "ABSENT": row.Cells["Status"].Style.BackColor = Color.LightCoral; break;
                                        case "LATE": row.Cells["Status"].Style.BackColor = Color.PeachPuff; break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading previous attendance: " + ex.Message);
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

            DateTime selectedDate = dateTimePicker.Value.Date;

            // Check for Saturday
            if (selectedDate.DayOfWeek == DayOfWeek.Saturday)
            {
                MessageBox.Show("Saturday is a holiday. Attendance marking is disabled for this date.", "Holiday", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Check for holiday
            if (IsHoliday(selectedDate))
            {
                MessageBox.Show("This date is marked as a holiday. Attendance marking is disabled.", "Holiday", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private bool IsHoliday(DateTime date)
        {
            bool isHoliday = false;
            string connStr = "server=localhost;user=root;database=SATracker_db;password=;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Holidays WHERE HolidayDate = @date";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@date", date.Date);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    isHoliday = count > 0;
                }
            }

            return isHoliday;
        }

    }
}
