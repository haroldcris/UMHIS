using System.Windows.Forms;

namespace Umhis.Forms
{
    public static class FormHelper
    {
        public static void ConvertEnterKeyToTab(this Form form)
        {
            form.KeyDown += Form_KeyDown;
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.Handled = true;
            e.SuppressKeyPress = true;
            SendKeys.Send("{tab}");
        }
    }
}
