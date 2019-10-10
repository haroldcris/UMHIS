using MetroFramework.Forms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Umhis.Core;

namespace Umhis.Forms
{
    public partial class AccountInfoDialog : MetroForm
    {
        public UserAccount UserAccountItem { get; set; }

        public AccountInfoDialog()
        {
            InitializeComponent();
            this.ConvertEnterKeyToTab();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (UserAccountItem == null) return;

            DisplayData();
        }


        private void DisplayData()
        {
            txtId.Text            = UserAccountItem.Id.ToString();
            txtName.Text          = UserAccountItem.DisplayName;
            txtUsername.Text      = UserAccountItem.Username;
            txtPassword.Text      = UserAccountItem.Password;
            txtRePassword.Text    = UserAccountItem.Password;

            chkAdmin.Checked = UserAccountItem.SecurityLevel == "Admin";
            chkDisabled.Checked = UserAccountItem.Active == false;
        }



        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (HasBrokenRules()) return;

            try
            {
                UserAccountItem.DisplayName      = txtName.Text;
                UserAccountItem.Username         = txtUsername.Text;

                var hash = PasswordSecurity.CreateHash(txtPassword.Text);
                if (hash != UserAccountItem.Password)
                    UserAccountItem.Password = hash;

                UserAccountItem.SecurityLevel    = chkAdmin.Checked ? "Admin" : "User";
                UserAccountItem.Active           = !chkDisabled.Checked;

                UserAccountItem.Save(AppSession.CurrentUser.Username);

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }


        private bool HasBrokenRules()
        {
            errorProvider1.Clear();

            if (txtId.Text == "")
                return ShowValidationError(txtId, "Id is required");

            if (string.IsNullOrWhiteSpace(txtName.Text))
                return ShowValidationError(txtName, "Display Name is required");

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
                return ShowValidationError(txtUsername, "Username is required");

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
            ShowError(ctrl, errorMessage);
            return true;
        }

        private async void ShowError(Control control, string errorMessage)
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
