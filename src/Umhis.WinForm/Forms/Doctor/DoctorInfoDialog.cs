using System;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Umhis.Forms.Doctor
{
    public partial class DoctorInfoDialog : MetroForm
    {
        public Core.Patient PatientItem { get; set; }

        public DoctorInfoDialog()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, System.EventArgs e)
        {
            if (PatientItem == null) return;
            //txtId.Text            = PatientItem.IdNumber;
            txtLastname.Text      = PatientItem.Lastname;
            txtFirstname.Text     = PatientItem.Firstname;
            txtMiddlename.Text    = PatientItem.Middlename;
            cboNameExtension.Text = PatientItem.NameExtension;
            
            txtRemarks.Text       = PatientItem.Remarks;

        }



        private bool HasBrokenRules()
        {
            errorProvider1.Clear();

            if (txtId.Text == "")
                return ShowValidationError(txtId, "Id is required");


            if (string.IsNullOrWhiteSpace(txtLastname.Text))
                return ShowValidationError(txtLastname, "Lastname is required");

            if (string.IsNullOrWhiteSpace(txtFirstname.Text))
                return ShowValidationError(txtFirstname, "Firstname is required");

            return false;
        }


        private bool ShowValidationError(Control ctrl, string message)
        {
            errorProvider1.SetError(ctrl, message);
            ctrl.Focus();
            return true;
        }


        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (HasBrokenRules()) return;

            try
            {
                //PatientItem.IdNumber      = txtId.Text;
                PatientItem.Lastname      = txtLastname.Text;
                PatientItem.Firstname     = txtFirstname.Text;
                PatientItem.Middlename    = txtMiddlename.Text;
                PatientItem.NameExtension = cboNameExtension.Text;

                PatientItem.Remarks       = txtRemarks.Text;

                PatientItem.Save("encoder");

                DialogResult = DialogResult.OK;                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}
