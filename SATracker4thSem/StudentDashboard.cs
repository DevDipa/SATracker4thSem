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

        private string _username; // Store the username of the Student 
        public StudentDashboard(string username)
        {
            InitializeComponent();
            _username = username;
            txtStudent.Text = _username;
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
    }
}
