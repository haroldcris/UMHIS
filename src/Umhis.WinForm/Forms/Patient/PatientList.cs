using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Umhis.Forms
{
    public partial class PatientList : MetroForm
    {
        public PatientList()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            Grid.Columns.Clear();
            Grid.AutoGenerateColumns =false;

            CreateGridColumn("Id", "Id", 40);
            CreateGridColumn("Name", "Name", 200);
            CreateGridColumn("Gender", "Gender");
            CreateGridColumn("BloodType", "Blood Type");
            CreateGridColumn("Age", "Age");

            Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void CreateGridColumn(string name, string header, int colWidth = 50)
        {
            var col = Grid.Columns.Add(name, header);
            Grid.Columns[col].Width = colWidth;
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
                var items = Core.Patient.GetItems();

                DisplayToGrid(items);
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

        private void DisplayToGrid(IEnumerable<Core.Patient> items)
        {
            try
            {
                Grid.Rows.Clear();
                foreach (var item in items)
                {
                    var rowIndex = Grid.Rows.Add();
                    DisplayToGridRow(item, Grid.Rows[rowIndex]);
                }

                Grid.Sort(Grid.Columns["Name"] ?? throw new InvalidOperationException(), System.ComponentModel.ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
            }
        }

        private static void DisplayToGridRow(Core.Patient patient, DataGridViewRow row)
        {
            row.Cells["Id"].Value         = patient.Id;
            row.Cells["Name"].Value       = patient.Fullname;
            row.Cells["Gender"].Value     = patient.Gender;

            row.Cells["BloodType"].Value = patient.BloodType;
            row.Cells["Age"].Value = patient.Age;


            row.Tag = patient;
        }

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            BtnEdit.PerformClick();
        }


        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var newItem = new Core.Patient();
            using (var frm = new PatientInfoDialog())
            {
                frm.PatientItem = newItem;
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                DisplayToGridRow(newItem, Grid.Rows[Grid.Rows.Add()]);
            }
        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var item = (Core.Patient)Grid.CurrentRow?.Tag;
            if (item == null) return;
            using (var frm = new PatientInfoDialog())
            {
                frm.PatientItem = item;
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                DisplayToGridRow(item, Grid.CurrentRow);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var item = (Core.Patient)Grid.CurrentRow?.Tag;
            if (item == null) return;

            var answer = MessageBox.Show("Do you want to delete this record?", "Confirm Delete",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (answer != DialogResult.Yes) return;

            try
            {
                if(item.Delete())
                    Grid.Rows.Remove(Grid.CurrentRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
