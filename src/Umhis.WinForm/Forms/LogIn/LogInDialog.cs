using MetroFramework.Forms;
using System.Windows.Forms;

namespace Umhis.Forms
{
    public partial class LogInDialog : MetroForm
    {
        public LogInDialog()
        {
            InitializeComponent();
        }

        private void LnkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Close();
            Application.Exit();
        }

        private void BtnLogIn_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
