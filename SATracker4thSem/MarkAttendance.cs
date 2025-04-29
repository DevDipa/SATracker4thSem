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
    public partial class MarkAttendance : Form
    {
        public MarkAttendance()
        {
            InitializeComponent();

            dataGridView1.CellContentClick += dataGridView1_CellContentClick;

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

            // Example rows
            dataGridView1.Rows.Add("2023001", "John Doe");
            dataGridView1.Rows.Add("2023002", "Jane Smith");
            dataGridView1.Rows.Add("2023003", "Robert Johnson");

            // Make Roll No. and Name columns read-only
            dataGridView1.Columns["studentId"].ReadOnly = true;
            dataGridView1.Columns["studentName"].ReadOnly = true;

            // Optional: font styling
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 12);

            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }

    }
}
