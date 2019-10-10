using MetroFramework.Forms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umhis.Forms
{
    public partial class LogInDialog : MetroForm
    {
        public LogInDialog()
        {
            InitializeComponent();
            this.ConvertEnterKeyToTab();
        }

        private void LnkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private async void BtnLogIn_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                panelConnecting.Visible = true;
                lblError.Visible = false;

                var msg = "";
                var result = await Task.Run(() => AppSession.CreateNewSession(txtUsername.Text, txtPassword.Text, out msg));

                if (!result)
                {
                    lblError.Visible = true;
                    lblError.Text = msg;
                    return;
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = ex.Message;
            }
            finally
            {
                txtUsername.Focus();
                txtUsername.SelectAll();
                panelConnecting.Visible = false;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
