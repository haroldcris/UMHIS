using System;
using System.Windows.Forms;

namespace Umhis.Forms.Patient
{
    public partial class PatientDialog : Form
    {
        public Core.Patient PatientItem { get; set; }

        public PatientDialog()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, System.EventArgs e)
        {
            txtId.Text = PatientItem.IdNumber;
            txtLastname.Text = PatientItem.Lastname;
            txtFirstname.Text = PatientItem.Firstname;
            txtMiddlename.Text = PatientItem.Middlename;
            cboNameExtension.Text = PatientItem.NameExtension;
            
            comboBox1.Text = PatientItem.Gender;
            
            dtBirthDate.Value = PatientItem.BirthDate;
            cboDepartment.Text = PatientItem.Department;
            
            cboBloodType.Text = PatientItem.BloodType;
            txtHeight.Value = PatientItem.Height;
            txtWeight.Value = PatientItem.Weight;
            
            txtRemarks.Text = PatientItem.Remarks;

        }



        private bool HasBrokenRules()
        {
            errorProvider1.Clear();

            if (txtId.Text == "")
            {
                errorProvider1.SetError(txtId, "Id is required");
                return true;
            }



            return false;
        }


        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (HasBrokenRules()) return;

            try
            {
                PatientItem.IdNumber = txtId.Text;
                PatientItem.Lastname = txtLastname.Text;
                PatientItem.Firstname = txtFirstname.Text;
                PatientItem.Middlename = txtMiddlename.Text;
                PatientItem.NameExtension = cboNameExtension.Text;

                PatientItem.Gender = comboBox1.Text;

                PatientItem.BirthDate = dtBirthDate.Value.Date;
                PatientItem.Department = cboDepartment.Text;

                PatientItem.BloodType = cboBloodType.Text;
                PatientItem.Height = txtHeight.Value;
                PatientItem.Weight = txtWeight.Value;

                PatientItem.Remarks = txtRemarks.Text;

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
