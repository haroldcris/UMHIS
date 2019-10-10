using MetroFramework.Forms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Umhis.Core;

namespace Umhis.Forms
{
    public partial class ChangePasswordDialog : MetroForm
    {
        public ChangePasswordDialog()
        {
            InitializeComponent();
            this.ConvertEnterKeyToTab();
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (HasBrokenRules()) return;

            try
            {
                var user = AppSession.CurrentUser;

                user.Password = PasswordSecurity.CreateHash(txtPassword.Text);
                user.Save(AppSession.CurrentUser.Username);

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }


        private bool HasBrokenRules()
        {
            var oldHash = PasswordSecurity.CreateHash(txtOldPassword.Text);

            if (AppSession.CurrentUser.Password != oldHash)
                return ShowValidationError(txtPassword, "Old Password is INVALID");


            if (string.IsNullOrWhiteSpace(txtPassword.Text))
                return ShowValidationError(txtPassword, "Password is required");

            if (txtPassword.Text != txtRePassword.Text)
            {
                return ShowValidationError(txtRePassword, "Passwords do NOT match!");
            }

            return false;
        }


        private bool ShowValidationError(Control ctrl, string errorMessage)
        {
            ctrl.Focus();
            ShowError(errorMessage);
            return true;
        }

        private async void ShowError(string errorMessage)
        {
            panelError.Visible = true;
            lblError.Text = errorMessage;
            await Task.Delay(3000);
            panelError.Visible = false;
        }

        private void LnkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

    }
}
