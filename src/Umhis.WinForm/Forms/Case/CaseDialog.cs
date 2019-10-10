using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace Umhis.Forms
{
    public partial class CaseDialog : MetroForm
    {
        private Core.Patient _selectedPatient;
        private TreatmentHistoryDialog _historyDialog;
        public CaseDialog()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            lnkHistory.Enabled = false;

            using (var frm = new PatientSearchDialog())
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                _selectedPatient = frm.SelectedPatient;
                DisplayPatientInfo();
                lnkHistory.Enabled = true;

                if (_historyDialog != null && _historyDialog.Visible)
                {
                    _selectedPatient.LoadTreatmentHistory();
                    _historyDialog.Show();
                    _historyDialog.RefreshData(_selectedPatient.TreatmentHistoryItems);
                }
            }
        }

        private void DisplayPatientInfo()
        {
            txtName.Text       = _selectedPatient.Fullname;
            txtDepartment.Text = _selectedPatient.Department;
            txtGender.Text     = _selectedPatient.Gender;
            txtBirthDate.Text  = _selectedPatient.BirthDate.ToString("dd MMMM yyyy");
            txtAge.Text        = _selectedPatient.Age.ToString();
            txtBloodType.Text  = _selectedPatient.BloodType;
            txtHeight.Text     = _selectedPatient.Height.ToString("0.00");
            txtWeight.Text     = _selectedPatient.Weight.ToString("0.00");
        }

        private void LnkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var treatment = new Core.TreatmentHistory()
                {
                    PatientId   = _selectedPatient.Id,
                    Condition   = txtCondition.Text,
                    DateTreated = dtDate.Value ,
                    Treatment   = txtTreatment.Text ,
                    Remarks     = txtRemarks.Text
                };

                if (!treatment.Save(AppSession.CurrentUser.Username)) return;

                _selectedPatient.TreatmentHistoryItems.Add(treatment);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void lnkHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _selectedPatient.LoadTreatmentHistory();

            if (_historyDialog == null || _historyDialog.Visible == false)
            {
                _historyDialog = new TreatmentHistoryDialog(_selectedPatient.TreatmentHistoryItems);
                _historyDialog.Show(this);
            }
            else
            {
                _historyDialog.RefreshData(_selectedPatient.TreatmentHistoryItems);
            }
        }
    }
}
