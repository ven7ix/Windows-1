using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;



namespace WindowsFormsApp1
{
    public partial class NewRecord : Form
    {
        public bool CallerButton { get; set; }

        public event Action<int, string, DateTime> OnDataSubmitted;

        public NewRecord()
        {
            InitializeComponent();
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            if (personCardNumber.Text.Length == 5)
            {
                int cardNumber = int.Parse(personCardNumber.Text);
                string name = personName.Text;
                DateTime birthday = personBirthday.Value;

                OnDataSubmitted?.Invoke(cardNumber, name, birthday);
                //то же самое, что и - if (OnDataSubmitted != null) OnDataSubmitted(cardNumber, name, birthday);

                Close();
            }
        }
        private void ButtonDeny_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewRecord_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.L && CallerButton)
            {
                Authorisation authorisation = new Authorisation(this);
                
                authorisation.Show();
            }
        }

        private void PersonCardNumber_TextChanged(object sender, EventArgs e)
        {
            if (BackColor == Color.Aqua) buttonAcceptMove.Enabled = true;
        }

        private void ButtonAcceptMove_Tick(object sender, EventArgs e)
        {
            if (buttonAccept.Right + 1 < Size.Width) buttonAccept.Left += 1;
            else buttonAccept.Location = new Point(0, buttonAccept.Location.Y);
        }

        private void PersonCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
