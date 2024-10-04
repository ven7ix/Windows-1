using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public List<Person> peopleArray = new List<Person>();

        public enum WhatGoesToCell
        {
            enum_cardNumber, enum_name, enum_birthday, enum_calcAge, enum_other
        };

        public Form1()
        {
            InitializeComponent();

            //создание начальной таблицы
            dataGridViewPeople.Columns.Add("dataGridViewPeople", "");
            //откллючение сортировки столбца
            dataGridViewPeople.Columns["dataGridViewPeople"].SortMode = DataGridViewColumnSortMode.NotSortable;
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

            AddNewPersonInCell(person);
        }

        private void AddNewPersonInCell(Person person)
        {
            CustomCell.AddNewCellOnTop(dataGridViewPeople, person._Name, WhatGoesToCell.enum_name);
            CustomCell.NewDependence(person._CardNumber.ToString(), WhatGoesToCell.enum_cardNumber);
            CustomCell.NewDependence(person.CalcAge(DateTime.Now).ToString(), WhatGoesToCell.enum_calcAge);
            CustomCell.NewDependence(1, person._Birthday.ToString("dd.MM.yyyy"), WhatGoesToCell.enum_birthday);
        }

        private void dataGridViewPeople_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CustomCell.OpenCell(dataGridViewPeople.CurrentCell.RowIndex, dataGridViewPeople);
            dataGridViewPeople.Refresh();
        }

        private void ButtonNewRecord_Click(object sender, EventArgs e)
        {
            NewRecord record = new NewRecord(false, peopleArray, -1);
            record.OnDataSubmitted += NewRecord_OnDataSubmitted;
            record.ShowDialog();
        }

        private void EditRecord_OnDataSubmitted(int cardNumber, string name, DateTime birthday)
        {
            //для CustomCell надо будет пересчитывать индекс
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
                DialogResult dialogResult1 = MessageBox.Show("you shure?", "confirmation", MessageBoxButtons.YesNo);
                if (dialogResult1 == DialogResult.Yes)
                {
                    int index = peopleList.SelectedIndex;
                    peopleList.Items.RemoveAt(index);
                    peopleArray.RemoveAt(index);
                }
            }

            if (dataGridViewPeople.CurrentCell == null) return;
            DialogResult dialogResult = MessageBox.Show("you shure?", "confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int selected = dataGridViewPeople.CurrentCell.RowIndex;
                CustomCell.DeleteDependence(selected, dataGridViewPeople);
                //peopleArray.RemoveAt(selected); наверное придется передавать в CustomCell
            }
        }

        private void ButtonNewDependence_Click(object sender, EventArgs e)
        {
            if (dataGridViewPeople.CurrentCell == null) return;
            CustomCell.NewDependence(dataGridViewPeople.CurrentCell.RowIndex, WhatGoesToCell.enum_other);
        }

        private void dataGridViewPeople_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridViewPeople.CurrentCell == null) return;
            CustomCell.EnterEditCell(dataGridViewPeople);
        }

        private void dataGridViewPeople_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewPeople.CurrentCell == null) return;
            CustomCell.ExitEditCell(dataGridViewPeople);
        }
    }
}
