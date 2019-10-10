using System.Windows.Forms;

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
            BtnCaseMasterList.Visible = false;
        }

        private void InitializeGrid()
        {
            Grid.Columns.Clear();
            Grid.AutoGenerateColumns =false;

            CreateGridColumn("Id", "Id");
            CreateGridColumn("CaseNum", "Case Number");
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
                frm.ShowDialog(this) ;
            }
        }

        private void BtnPatientMasterList_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (var frm = new PatientList())
            {
                frm.ShowDialog(this);
            }
        }

        private void BtnUserAccounts_Click(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (var frm = new AccountList())
            {
                frm.ShowDialog(this) ;
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
