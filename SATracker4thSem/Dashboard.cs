using Dapper;
using System;
using System.Windows.Forms;

namespace SATracker4thSem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadTotalStudentCount();
            LoadPresentTodayCount();
            LoadAbsentTodayCount();
            LoadLateTodayCount();
        }


        private void LoadTotalStudentCount()
        {
            using (var conn = Database.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Students";
                int count = conn.QueryFirstOrDefault<int>(query);
                txtTotalStudents.Text = count.ToString();
            }
        }

        private void LoadPresentTodayCount()
        {
            using (var conn = Database.GetConnection())
            {
                string query = @"SELECT COUNT(*) 
                         FROM Attendance 
                         WHERE attendance_date = CURDATE() AND status = 'PRESENT'";
                int count = conn.QueryFirstOrDefault<int>(query);
                txtPresentToday.Text = count.ToString();
            }
        }

        private void LoadAbsentTodayCount()
        {
            using (var conn = Database.GetConnection())
            {
                string query = @"SELECT COUNT(*) 
                         FROM Attendance 
                         WHERE attendance_date = CURDATE() AND status = 'ABSENT'";
                int count = conn.QueryFirstOrDefault<int>(query);
                txtAbsentToday.Text = count.ToString();
            }
        }

        private void LoadLateTodayCount()
        {
            using (var conn = Database.GetConnection())
            {
                string query = @"SELECT COUNT(*) 
                         FROM Attendance 
                         WHERE attendance_date = CURDATE() AND status = 'LATE'";
                int count = conn.QueryFirstOrDefault<int>(query);
                txtLateToday.Text = count.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
