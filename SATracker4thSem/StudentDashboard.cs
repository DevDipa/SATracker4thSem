using System;
using System.Windows.Forms;
using System.Drawing;


namespace SATracker4thSem
{
    public partial class StudentDashboard : Form
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
            this.pnlMain1.Controls.Add(childForm);  
            this.pnlMain1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public StudentDashboard(string username)
        {
            InitializeComponent();
            txtStudent.Text = username;
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

        private void btnMyAttendannce_Click(object sender, EventArgs e)
        {
            pbLogo.SendToBack();
            lblSlogan.SendToBack();
            OpenChildForm(new MyAttendance());
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            pbLogo.SendToBack();
            lblSlogan.SendToBack();
            OpenChildForm(new MyProfile());
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Firebrick;
            btnExit.ForeColor = SystemColors.Control;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(110, 89, 165);
            btnExit.ForeColor = SystemColors.Control;
        }

        private void btnDashboard_MouseEnter(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.MediumPurple;
        }

        private void btnDashboard_MouseLeave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(110, 89, 165);
        }

        private void btnMyProfile_MouseEnter(object sender, EventArgs e)
        {
            btnMyProfile.BackColor = Color.MediumPurple;
        }

        private void btnMyProfile_MouseLeave(object sender, EventArgs e)
        {
            btnMyProfile.BackColor = Color.FromArgb(110, 89, 165);
        }

        private void btnMyAttendannce_MouseEnter(object sender, EventArgs e)
        {
            btnMyAttendannce.BackColor = Color.MediumPurple;
        }

        private void btnMyAttendannce_MouseLeave(object sender, EventArgs e)
        {
            btnMyAttendannce.BackColor = Color.FromArgb(110, 89, 165);
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
