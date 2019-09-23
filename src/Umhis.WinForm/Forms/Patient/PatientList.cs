using System;
using System.Windows.Forms;

namespace Umhis.Forms.Patient
{
    public partial class PatientList : Form
    {
        public PatientList()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            InitializeGrid();
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            Refresh();
            LoadItems();
        }


        private void LoadItems()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                lblStatus.Visible = true;
                var patientList = Core.Patient.GetItems();

                Grid.DataSource = patientList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                lblStatus.Visible = false;
            }
            
        }


        private void InitializeGrid()
        {
            Grid.Columns.Clear();
            //Grid.Rows.Clear();

            Grid.AutoGenerateColumns =false;
            

            CreateGridColumn("Id", "Id");
            CreateGridColumn("Name", "Name",200);

            Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        private void CreateGridColumn(string name, string header, int colWidth = 50)
        {
            var col = Grid.Columns.Add(name, header);
            Grid.Columns[col].Width = colWidth;
        }

        private void Grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (var r = 0; r < e.RowCount; r++)
            {
                var row = Grid.Rows[e.RowIndex + r];
                var patient = (Core.Patient) row.DataBoundItem;

                row.Cells["Id"].Value = patient.Id;
                row.Cells["Name"].Value = patient.Fullname;
            }

        }



        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var newItem = new Core.Patient();
            using (var frm = new PatientDialog())
            {
                frm.PatientItem = newItem;
                if (frm.ShowDialog() != DialogResult.OK) return;
                LoadItems();
            }
        }

       

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var item = (Core.Patient)Grid.CurrentRow?.DataBoundItem;
            if (item == null) return;

            using (var frm = new PatientDialog())
            {
                frm.PatientItem = item;
                if (frm.ShowDialog() != DialogResult.OK) return;
                LoadItems();
            }
        }
    }
}
