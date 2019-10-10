using System.Windows.Forms;
using Umhis.Forms.Account;

namespace Umhis.Forms
{
    public partial class MainForm : RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();

            InitializeGrid();

            btnUser.Text = $"Welcome {AppSession.CurrentUser.DisplayName} [{AppSession.CurrentUser.SecurityLevel}]";

            BtnDoctor.Visible = false;
            BtnMedicine.Visible = false;
        }

        private void InitializeGrid()
        {
            Grid.Columns.Clear();
            Grid.AutoGenerateColumns =false;

            CreateGridColumn("Id", "Id", 50);
            CreateGridColumn("CaseNum", "Case Number", 50);
            CreateGridColumn("Name", "Patient Name", 250);
            CreateGridColumn("Department", "Department", 100).FillWeight = 100;

            CreateGridColumn("Remarks", "Remarks", 400);

            Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid.Rows.AddCopies(0, 10);
        }

        private DataGridViewColumn CreateGridColumn(string name, string header, int colWidth = 50)
        {
            var col = Grid.Columns.Add(name, header);
            Grid.Columns[col].Width = colWidth;
            return Grid.Columns[col];
        }


        private void BtnNewCase_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (var frm = new CaseDialog())
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;
            }
        }

        private void BtnPatientMasterList_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (var frm = new PatientList())
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;
            }
        }

        private void BtnUserAccounts_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (var frm = new AccountList())
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;
            }
        }

        private void BtnOpenPatientInfo_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            using (var frm = new PatientSearchDialog())
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                using (var patientForm = new PatientInfoDialog())
                {
                    patientForm.PatientItem = frm.SelectedPatient;
                    patientForm.ShowDialog(this);
                }
            }
        }

        private void BtnChangePassword_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            using (var frm = new ChangePasswordDialog())
            {
                frm.ShowDialog(this);
            }
        }
    }
}
