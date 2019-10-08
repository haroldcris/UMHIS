using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Umhis.Forms.Patient
{
    public partial class PatientSearchDialog : MetroForm
    {
        public Core.Patient SelectedPatient { get; private set; }

        public PatientSearchDialog()
        {
            InitializeComponent();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            //SelectedPatient = new Core.Patient();
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
            }
        }
    }
}
