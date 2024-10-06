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

        //заменить enum на что-то другое (массив мб)
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
            CustomCell.AddNewCellOnTop(dataGridViewPeople, person._CardNumber.ToString(), WhatGoesToCell.enum_cardNumber);
            CustomCell.NewDependence(person._Name, WhatGoesToCell.enum_name);
            CustomCell.NewDependence(person.CalcAge(DateTime.Now).ToString(), WhatGoesToCell.enum_calcAge);
            CustomCell.NewDependence(1, person._Birthday.ToString("dd.MM.yyyy"), WhatGoesToCell.enum_birthday);
        }

        private void DataGridViewPeople_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CustomCell.OpenCell(dataGridViewPeople.CurrentCell.RowIndex, dataGridViewPeople);
            dataGridViewPeople.Update();
        }

        private void ButtonNewRecord_Click(object sender, EventArgs e)
        {
            NewRecord record = new NewRecord(false, peopleArray, -1);
            record.OnDataSubmitted += NewRecord_OnDataSubmitted;
            record.ShowDialog();
        }

        private void EditRecord_OnDataSubmitted(int cardNumber, string name, DateTime birthday)
        {
            //пересчитываем индекс для peopleArray
            int selected = CustomCell.IndexOfSelectedInPeopleArray(dataGridViewPeople.CurrentCell.RowIndex);
            peopleArray[selected]._CardNumber = cardNumber;
            peopleArray[selected]._Name = name;
            peopleArray[selected]._Birthday = birthday;

            int cellIndex = CustomCell.IndexOfSelectedRootCell(dataGridViewPeople.CurrentCell.RowIndex);
            CustomCell.EditDependentCellData(cellIndex, cardNumber.ToString(), WhatGoesToCell.enum_cardNumber);
            CustomCell.EditDependentCellData(cellIndex, name, WhatGoesToCell.enum_name);
            CustomCell.EditDependentCellData(cellIndex, birthday.ToString("dd.MM.yyyy"), WhatGoesToCell.enum_birthday);
            CustomCell.EditDependentCellData(cellIndex, peopleArray[selected].CalcAge(DateTime.Now).ToString(), WhatGoesToCell.enum_calcAge);

            dataGridViewPeople.Update();
        }

        private void ButtonEditRecord_Click(object sender, EventArgs e)
        {
            if (dataGridViewPeople.CurrentCell == null) return;

            int index = CustomCell.IndexOfSelectedInPeopleArray(dataGridViewPeople.CurrentCell.RowIndex);
            if (index == -1) MessageBox.Show("Somethig Went Wrong");
            NewRecord record = new NewRecord(true, peopleArray, index);

            record.personCardNumber.Text = peopleArray[index]._CardNumber.ToString();
            record.personName.Text = peopleArray[index]._Name;
            record.personBirthday.Value = peopleArray[index]._Birthday;

            record.personCardNumber.Enabled = false;
            record.personBirthday.Enabled = false;

            record.OnDataSubmitted += EditRecord_OnDataSubmitted;

            record.ShowDialog();
        }

        private void ButtonDeleteRecord_Click(object sender, EventArgs e)
        {
            if (dataGridViewPeople.CurrentCell == null) return;
            DialogResult dialogResult = MessageBox.Show("you shure?", "confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int selected = dataGridViewPeople.CurrentCell.RowIndex;

                if (CustomCell.IndexOfSelectedRootCell(selected) == selected)
                {
                    peopleArray.RemoveAt(CustomCell.IndexOfSelectedInPeopleArray(selected));
                }

                CustomCell.DeleteDependence(selected, dataGridViewPeople);
            }
        }

        private void ButtonNewDependence_Click(object sender, EventArgs e)
        {
            if (dataGridViewPeople.CurrentCell == null) return;
            CustomCell.NewDependence(dataGridViewPeople.CurrentCell.RowIndex, WhatGoesToCell.enum_other);
            dataGridViewPeople.Update();
        }

        private void DataGridViewPeople_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridViewPeople.CurrentCell == null) return;
            CustomCell.EnterEditCell(dataGridViewPeople);
        }

        private void DataGridViewPeople_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewPeople.CurrentCell == null) return;
            CustomCell.ExitEditCell(dataGridViewPeople);

            int selected = dataGridViewPeople.CurrentCell.RowIndex;

            if (CustomCell.CellWhatInfoStored(selected).ToString() == WhatGoesToCell.enum_name.ToString())
            {
                peopleArray[CustomCell.IndexOfSelectedInPeopleArray(selected)]._Name = CustomCell.CellValue(selected);
            }
        }
    }
}