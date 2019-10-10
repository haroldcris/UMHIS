using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Umhis.Forms
{
    public partial class PatientInfoDialog : MetroForm
    {
        public Core.Patient PatientItem { get; set; }

        public PatientInfoDialog()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, System.EventArgs e)
        {
            if (PatientItem == null) return;

            DisplayData();
        }


        private void DisplayData()
        {
            txtId.Text            = PatientItem.Id.ToString();
            txtLastname.Text      = PatientItem.Lastname;
            txtFirstname.Text     = PatientItem.Firstname;
            txtMiddlename.Text    = PatientItem.Middlename;
            cboNameExtension.Text = PatientItem.NameExtension;

            cboGender.Text        = PatientItem.Gender;

            dtBirthDate.Value     = PatientItem.BirthDate;
            cboDepartment.Text    = PatientItem.Department;

            cboBloodType.Text     = PatientItem.BloodType;
            txtHeight.Value       = PatientItem.Height;
            txtWeight.Value       = PatientItem.Weight;

            txtRemarks.Text       = PatientItem.Remarks;
        }



        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (HasBrokenRules()) return;

            try
            {
                PatientItem.Lastname      = txtLastname.Text;
                PatientItem.Firstname     = txtFirstname.Text;
                PatientItem.Middlename    = txtMiddlename.Text;
                PatientItem.NameExtension = cboNameExtension.Text;

                PatientItem.Gender        = cboGender.Text;

                PatientItem.BirthDate     = dtBirthDate.Value.Date;
                PatientItem.Department    = cboDepartment.Text;

                PatientItem.BloodType     = cboBloodType.Text;
                PatientItem.Height        = txtHeight.Value;
                PatientItem.Weight        = txtWeight.Value;

                PatientItem.Remarks       = txtRemarks.Text;

                PatientItem.Save("encoder"); //Todo: Replace "encoder" with current user

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }


        private bool HasBrokenRules()
        {
            if (txtId.Text == "")
                return ShowValidationError(txtId, "Id is required");


            if (string.IsNullOrWhiteSpace(txtLastname.Text))
                return ShowValidationError(txtLastname, "Lastname is required");

            if (string.IsNullOrWhiteSpace(txtFirstname.Text))
                return ShowValidationError(txtFirstname, "Firstname is required");

            if (string.IsNullOrWhiteSpace(cboDepartment.Text))
                return ShowValidationError(cboDepartment, "Department is required");

            if (cboGender.Text == "")
                return ShowValidationError(cboGender, "Gender is required");

            if (cboBloodType.Text == "")
                return ShowValidationError(cboBloodType, "Blood Type is required");

            if (txtHeight.Value == 0)
                return ShowValidationError(txtHeight, "Invalid Height Value");

            if (txtWeight.Value == 0)
                return ShowValidationError(txtWeight, "Invalid Weight Value");


            return false;
        }


        private bool ShowValidationError(Control ctrl, string errorMessage)
        {
            ShowError(ctrl, errorMessage);
            ctrl.Focus();
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
