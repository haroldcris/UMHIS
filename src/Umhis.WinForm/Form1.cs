using System;
using System.Windows.Forms;
using Umhis.Core.Account;

namespace Umhis.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var user = new UserAccount(Core.EntityRecordStatus.NewRecord);

            user.Username = txtUsername.Text;
            user.Password = PasswordStorage.CreateHash("password");

            if (!user.Save("encoder"))
            {
                MessageBox.Show("Something Went Wrong");
                return;
            }

            MessageBox.Show("File Save");
        }


        private void BtnGetUsers_Click(object sender, EventArgs e)
        {
            var users = UserAccount.GetListOfUsers();

            listBox1.Items.Clear();

            foreach (var item in users)
            {
                listBox1.Items.Add(item);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex <0) return;

            var item = (UserAccount)listBox1.SelectedItem;

            item.RecordStatus = Core.EntityRecordStatus.DeletedRecord;

            if (!item.Save("encoder"))
            {
                MessageBox.Show("Something went wrong");
                return;
            }


            listBox1.Items.Remove(listBox1.SelectedItem);

        }
    }
}
