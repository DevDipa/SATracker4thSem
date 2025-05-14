using System;
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
    }
}
