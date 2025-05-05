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
            this.pnlMain.Controls.Add(childForm);  // Make sure pnlMain is the name of the panel with the logo
            this.pnlMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public TeacherDashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

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

        private void btnViewStudents_Click(object sender, EventArgs e)
        {
            pbLogo.SendToBack();
            lblSlogan.SendToBack();
            OpenChildForm(new ViewStudents());

        }
    }
}
