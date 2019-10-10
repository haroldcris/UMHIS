using MetroFramework.Forms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umhis.Forms
{
    public partial class PatientSearchDialog : MetroForm
    {
        public Core.Patient SelectedPatient { get; private set; }

        public PatientSearchDialog()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            DataGrid.Rows.Clear();
            DataGrid.AllowUserToAddRows = false;
            DataGrid.AllowUserToDeleteRows = false;


            DataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out var id))
            {
                ShowError(txtId, "Enter Valid Id");
                return;
            }


            SelectedPatient = new Core.Patient();
            if (!SelectedPatient.LoadById(id))
            {
                ShowError(txtId, "Invalid Id");
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void LnkClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void LnkNewRecord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var frm = new PatientInfoDialog())
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                SelectedPatient = frm.PatientItem;
                DialogResult = DialogResult.OK;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (txtSearch.Text == "") return;

            try
            {
                lblStatus.Text = "Searching...";
                lblStatus.Visible = true;
                var items = Core.Patient.SearchByName(txtSearch.Text + "%");

                DataGrid.Rows.Clear();
                foreach (var item in items)
                {
                    var row = DataGrid.Rows.Add();

                    DataGrid.Rows[row].Cells["fieldId"].Value = item.Id;
                    DataGrid.Rows[row].Cells["fieldName"].Value = item.Fullname;
                    DataGrid.Rows[row].Cells["fieldGender"].Value = item.Gender;
                }

                if (DataGrid.Rows.Count < 1)
                    lblStatus.Text = "No Item Found";
                else
                    lblStatus.Visible = false;
            }
            catch (Exception ex)
            {
                lblStatus.Visible = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <0) return;

            txtId.Text = DataGrid.Rows[e.RowIndex].Cells["fieldId"].Value?.ToString();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                txtSearch.Focus();
                txtSearch.SelectAll();
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }


            if (ActiveControl.Name == txtSearch.Name && e.KeyCode == Keys.Enter)
            {
                BtnSearch.PerformClick();
                DataGrid.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            if (ActiveControl.Name == DataGrid.Name  && e.KeyCode == Keys.Enter)
            {
                BtnOpen.PerformClick();
                e.SuppressKeyPress =true;
                e.Handled = true;
            }
        }


        private async void ShowError(Control control, string msg)
        {
            control.Focus();
            panelError.Visible = true;
            lblError.Text = msg;
            await Task.Delay(3000);
            panelError.Visible = false;
        }
    }
}
