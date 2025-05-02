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
        public StudentDashboard()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            // Confirm logout (optional but recommended)
            var result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Open LoginForm in a new thread-safe context
                this.Hide();  // Hide TeacherDashboard first

                LoginForm loginForm = new LoginForm();
                loginForm.FormClosed += (s, args) => this.Close(); // Ensure app closes if login form is closed
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
    }
}
