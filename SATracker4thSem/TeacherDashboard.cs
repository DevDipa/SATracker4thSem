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
    }
}
