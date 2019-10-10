using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Umhis.Core;

namespace Umhis.Forms
{
    public partial class TreatmentHistoryDialog : MetroForm
    {
        private List<TreatmentHistory> _treatmentHistoryItems;
        public TreatmentHistoryDialog(IEnumerable<TreatmentHistory> treatmentHistoryItems)
        {
            _treatmentHistoryItems = treatmentHistoryItems.ToList();

            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            Grid.Columns.Clear();
            Grid.AutoGenerateColumns =false;

            CreateGridColumn("Date", "Date", 80);
            CreateGridColumn("Diagnosis", "Diagnosis", 400);
            CreateGridColumn("Treatment", "Treatment", 300);

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
            DisplayToGrid();
        }

        private void DisplayToGrid()
        {
            try
            {
                Grid.Rows.Clear();
                foreach (var item in _treatmentHistoryItems.OrderBy(_ => _.DateTreated))
                {
                    var rowIndex = Grid.Rows.Add();
                    DisplayToGridRow(item, Grid.Rows[rowIndex]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
            }
            finally
            {
                lblStatus.Visible = false;
            }
        }

        private static void DisplayToGridRow(TreatmentHistory item, DataGridViewRow row)
        {
            row.Cells["Date"].Value       = item.DateTreated.ToString("dd MMM yyyy");
            row.Cells["Treatment"].Value     = item.Treatment;
            row.Cells["Diagnosis"].Value     = item.Condition;
            row.Tag = item;
        }


        public void RefreshData(IEnumerable<TreatmentHistory> treatmentHistoryItems)
        {
            _treatmentHistoryItems = treatmentHistoryItems.ToList();
            DisplayToGrid();
        }
    }
}
