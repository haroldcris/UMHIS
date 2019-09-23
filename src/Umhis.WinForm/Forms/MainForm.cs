using System.Windows.Forms;
using Umhis.Forms.Patient;

namespace Umhis.Forms
{
    public partial class MainForm : RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ribbonButton4_Click(object sender, System.EventArgs e)
        {
            RibbonActionContext.Visible = !RibbonActionContext.Visible;
        }

        private void ribbonButton2_Click(object sender, System.EventArgs e)
        {
            var f = new PatientList();
            //f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Text = "Document " + (MdiChildren.GetLength(0) +1);
            f.Show();
        }

        private void Patient_Click(object sender, System.EventArgs e)
        {
            using (var frm = new PatientList())
            {
                frm.ShowDialog();
            }
        }
    }
}
