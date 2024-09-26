using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public List<Person> peopleArray = new List<Person>();

        public Form1()
        {
            InitializeComponent();
        }

        private void NewRecord_OnDataSubmitted(int cardNumber, string name, DateTime birthday)
        {
            Person person = new Person(cardNumber, name, birthday);

            peopleArray.Add(person); //массив всех людей

            peopleList.Items.Clear();
            foreach (Person p in peopleArray)
            {
                //список в форме
                peopleList.Items.Add(p._Name + "\t" + p.CalcAge(DateTime.Now).ToString());
            }
        }

        private void ButtonNewRecord_Click(object sender, EventArgs e)
        {
            NewRecord record = new NewRecord(false, peopleArray, -1);


            record.OnDataSubmitted += NewRecord_OnDataSubmitted;
            
            record.ShowDialog();
        }

        private void EditRecord_OnDataSubmitted(int cardNumber, string name, DateTime birthday)
        {
            peopleArray[peopleList.SelectedIndex]._CardNumber = cardNumber;
            peopleArray[peopleList.SelectedIndex]._Name = name;
            peopleArray[peopleList.SelectedIndex]._Birthday = birthday;

            peopleList.Items.Clear();
            foreach (Person p in peopleArray)
            {
                //список в форме
                peopleList.Items.Add(p._Name + "\t" + p.CalcAge(DateTime.Now).ToString());
            }
        }

        private void ButtonEditRecord_Click(object sender, EventArgs e)
        {
            if (peopleList.SelectedItem != null)
            {
                NewRecord record = new NewRecord(true, peopleArray, peopleList.SelectedIndex);

                int index = peopleList.SelectedIndex;
                record.personCardNumber.Text = peopleArray[index]._CardNumber.ToString();
                record.personName.Text = peopleArray[index]._Name;
                record.personBirthday.Value = peopleArray[index]._Birthday;

                record.personCardNumber.Enabled = false;
                record.personBirthday.Enabled = false;

                record.OnDataSubmitted += EditRecord_OnDataSubmitted;

                record.ShowDialog();
            }
        }

        private void ButtonDeleteRecord_Click(object sender, EventArgs e)
        {
            if (peopleList.SelectedItem != null)
            {
                DialogResult dialogResult = MessageBox.Show("you shure?", "confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string person = peopleList.SelectedItem.ToString();
                    int index = peopleList.SelectedIndex;
                    peopleList.Items.RemoveAt(index);
                    peopleArray.RemoveAt(index);
                }
            }
        }
    }
}
