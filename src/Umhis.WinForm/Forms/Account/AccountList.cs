using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Umhis.Core;

namespace Umhis.Forms.Account
{
    public partial class AccountList : MetroForm
    {
        public AccountList()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            Grid.Columns.Clear();
            Grid.AutoGenerateColumns =false;

            CreateGridColumn("Id", "Id", 40);
            CreateGridColumn("DisplayName", "Display Name", 80);
            CreateGridColumn("Username", "Username", 100);
            CreateGridColumn("Level", "Level", 100);
            CreateGridColumn("Active", "Active", colItem: new DataGridViewCheckBoxColumn());

            Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private DataGridViewColumn CreateGridColumn(string name, string header, int colWidth = 50, DataGridViewColumn colItem = null)
        {
            if (colItem == null)
                colItem = new DataGridViewTextBoxColumn();

            colItem.Name = name;
            colItem.HeaderText = header;
            colItem.Width = colWidth;

            Grid.Columns.Add(colItem);
            return colItem;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Refresh();
            LoadItems();
        }

        private void LoadItems()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                lblStatus.Visible = true;
                var items = UserAccount.GetItems();

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

        private void DisplayToGrid(IEnumerable<UserAccount> items)
        {
            try
            {
                Grid.Rows.Clear();
                foreach (var item in items)
                {
                    var rowIndex = Grid.Rows.Add();
                    DisplayToGridRow(item, Grid.Rows[rowIndex]);
                }

                Grid.Sort(Grid.Columns[1] ?? throw new InvalidOperationException(), System.ComponentModel.ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
            }
        }

        private static void DisplayToGridRow(UserAccount item, DataGridViewRow row)
        {
            row.Cells["Id"].Value                = item.Id;
            row.Cells["DisplayName"].Value       = item.DisplayName;
            row.Cells["Username"].Value          = item.Username;

            row.Cells["Level"].Value             = item.SecurityLevel;

            row.Cells["Active"].Value             = item.Active;
            //row.Cells["Active"].ValueType = typeof(bool);

            row.Tag = item;
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

            var newItem = new UserAccount();
            using (var frm = new AccountInfoDialog())
            {
                frm.UserAccountItem = newItem;
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                DisplayToGridRow(newItem, Grid.Rows[Grid.Rows.Add()]);
            }
        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var item = (UserAccount)Grid.CurrentRow?.Tag;
            if (item == null) return;
            using (var frm = new AccountInfoDialog())
            {
                frm.UserAccountItem = item;
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                DisplayToGridRow(item, Grid.CurrentRow);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            var item = (UserAccount)Grid.CurrentRow?.Tag;
            if (item == null) return;

            var answer = MessageBox.Show("Do you want to delete this record?", "Confirm Delete",
                                            MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (answer != DialogResult.Yes) return;

            try
            {
                item.Delete(AppSession.CurrentUser.Username);
                Grid.Rows.Remove(Grid.CurrentRow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
