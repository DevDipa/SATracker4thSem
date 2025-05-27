using System;
using System.Windows.Forms;
using System.Drawing;

namespace SATracker4thSem
{
    public partial class TeacherDashboard : Form
    {
        private Form activeForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(childForm);  
            this.pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        //To store the username of the teacher
        private string _username; 
        public TeacherDashboard(string username)
        {
            InitializeComponent();
            _username = username;
            txtTeacher.Text = _username;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            pbLogo.SendToBack();
            lblSlogan.SendToBack();
            OpenChildForm(new MarkAttendance());

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            pbLogo.SendToBack();
            lblSlogan.SendToBack();
            OpenChildForm(new AddStudent());

        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            pbLogo.SendToBack();
            lblSlogan.SendToBack();
            OpenChildForm(new UpdateStudent());

        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            pbLogo.SendToBack();
            lblSlogan.SendToBack();
            OpenChildForm(new DeleteStudent());

        }

        private void btnViewAttendance_Click(object sender, EventArgs e)
        {
            pbLogo.SendToBack();
            lblSlogan.SendToBack();
            OpenChildForm(new ViewAttendance());

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            
            var result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();  

                LoginForm loginForm = new LoginForm();
                loginForm.FormClosed += (s, args) => this.Close(); 
                loginForm.Show();
            }
        }

        private void btnViewStudents_Click(object sender, EventArgs e)
        {
            pbLogo.SendToBack();
            lblSlogan.SendToBack();
            OpenChildForm(new ViewStudents());

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

            pbLogo.SendToBack();
            lblSlogan.SendToBack();
            OpenChildForm(new Dashboard());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Firebrick;
            btnExit.ForeColor = SystemColors.Control ;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(110, 89, 165) ;
            btnExit.ForeColor = SystemColors.Control;
        }

        private void btnDashboard_MouseHover(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.MediumPurple;
        }

        private void btnMarkAttendance_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.MediumPurple;
        }

        private void btnDashboard_MouseEnter(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.MediumPurple;
        }

        private void btnDashboard_MouseLeave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(110, 89, 165);
        }

        private void btnMarkAttendance_MouseEnter_1(object sender, EventArgs e)
        {
            btnMarkAttendance.BackColor = Color.MediumPurple;
        }

        private void btnMarkAttendance_MouseLeave(object sender, EventArgs e)
        {
            btnMarkAttendance.BackColor = Color.FromArgb(110, 89, 165);
        }

        private void btnViewAttendance_MouseEnter(object sender, EventArgs e)
        {
            btnViewAttendance.BackColor = Color.MediumPurple;
        }

        private void btnViewAttendance_MouseLeave(object sender, EventArgs e)
        {
            btnViewAttendance.BackColor = Color.FromArgb(110, 89, 165);
        }

        private void btnViewStudents_MouseEnter(object sender, EventArgs e)
        {
            btnViewStudents.BackColor = Color.MediumPurple;
        }

        private void btnViewStudents_MouseLeave(object sender, EventArgs e)
        {
            btnViewStudents.BackColor = Color.FromArgb(110, 89, 165);
        }

        private void btnAddStudent_MouseEnter(object sender, EventArgs e)
        {
            btnAddStudent.BackColor = Color.MediumPurple;
        }

        private void btnAddStudent_MouseLeave(object sender, EventArgs e)
        {
            btnAddStudent.BackColor = Color.FromArgb(110, 89, 165);
        }

        private void btnUpdateStudent_MouseEnter(object sender, EventArgs e)
        {
            btnUpdateStudent.BackColor = Color.MediumPurple;
        }

        private void btnUpdateStudent_MouseLeave(object sender, EventArgs e)
        {
            btnUpdateStudent.BackColor = Color.FromArgb(110, 89, 165);
        }

        private void btnDeleteStudent_MouseEnter(object sender, EventArgs e)
        {
            btnDeleteStudent.BackColor = Color.MediumPurple;
        }

        private void btnDeleteStudent_MouseLeave(object sender, EventArgs e)
        {
            btnDeleteStudent.BackColor = Color.FromArgb(110, 89, 165);
        }

        private void btnLogOut_MouseEnter(object sender, EventArgs e)
        {
            btnLogOut.BackColor = Color.MediumPurple;
        }

        private void btnLogOut_MouseLeave(object sender, EventArgs e)
        {
            btnLogOut.BackColor = Color.FromArgb(110, 89, 165);
        }

        private void btnMinimize_MouseEnter(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.Firebrick;
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.FromArgb(110, 89, 165);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
