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
        

        public NewRecord()
        {
            InitializeComponent();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            Form1 list = Owner as Form1;



            Person person = new Person
            {
                CardNumber = Int32.Parse(personCardNumber.Text),
                Name = personName.Text,
                Birthday = personBirthday.Value
            };

            list.peopleList.Items.Add(person.CardNumber.ToString() + "\t" + person.Name + "\t" + person.Birthday.ToString("dd.MM.yyyy"));

            

            Close();
        }
        private void buttonDeny_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewRecord_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.L)
            {
                Authorisation authorisation = new Authorisation();
                authorisation.Show();
            }
        }
    }
}
