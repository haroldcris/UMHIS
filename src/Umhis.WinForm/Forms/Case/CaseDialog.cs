using System;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using Umhis.Forms.Patient;

namespace Umhis.Forms
{
    public partial class CaseDialog : MetroForm
    {
        public CaseDialog()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            using (var frm = new PatientSearchDialog())
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                DisplayPatientInfo(frm.SelectedPatient);
            }
        }

        private void DisplayPatientInfo(Core.Patient item)
        {
            txtName.Text       = item.Fullname;
            txtDepartment.Text = item.Department;
            txtGender.Text     = item.Gender;
            txtBirthDate.Text  = item.BirthDate.ToString("dd MMMM yyyy");
            txtBloodType.Text  = item.BloodType;
            txtHeight.Text     = item.Height.ToString("0.00");
            txtWeight.Text     = item.Weight.ToString("0.00");
        }

        private void LnkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "Validation Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
    }
}
