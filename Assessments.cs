using System;
using System.Windows.Forms;

namespace Assessments
{
    public partial class Assessments : Form
    {
        public Assessments()
        {
            InitializeComponent();
        }

        private void closToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Settings.IsLoggedIn)
            {

                LoginPage log = new LoginPage();
                log.MdiParent = this;
                log.Show();
                Settings.IsLoggedIn = true;
            }
        }


    }
}
