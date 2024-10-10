using System;
using System.Collections.Generic;
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
            dataGridViewPeople.AllowUserToAddRows = false;
            dataGridViewPeople.RowHeadersVisible = false;
            dataGridViewPeople.MultiSelect = false;
            dataGridViewPeople.ColumnHeadersVisible = false;

            dataGridViewPeople.Columns.Add("Expand", "");
            //отключение сортировки столбца и изменения данных
            dataGridViewPeople.Columns["Expand"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewPeople.Columns["Expand"].ReadOnly = true;
            dataGridViewPeople.Columns["Expand"].Width = 20;
            dataGridViewPeople.Columns["Expand"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dataGridViewPeople.Columns.Add("Data", "");
            //отключение сортировки столбца
            dataGridViewPeople.Columns["Data"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewPeople.Columns["Data"].Width = 100;
        }

        private void NewRecord_OnDataSubmitted(int cardNumber, string name, DateTime birthday)
        {
            Person person = new Person(cardNumber, name, birthday);
            peopleArray.Add(person);
            AddNewPersonInCell(person);
        }

        //update (?)
        private void AddNewPersonInCell(Person person)
        {
            CustomCell.AddNewCellOnTop(dataGridViewPeople, person._CardNumber.ToString(), WhatGoesToCell.enum_cardNumber);
            CustomCell.NewDependence(person._Name, WhatGoesToCell.enum_name);
            CustomCell.NewDependence(person.CalcAge(DateTime.Now).ToString(), WhatGoesToCell.enum_calcAge);
            CustomCell.NewDependence(1, person._Birthday.ToString("dd.MM.yyyy"), WhatGoesToCell.enum_birthday);
        }

        //update (?)
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

            
            CustomCell.EditDependentCellData(dataGridViewPeople, cardNumber.ToString(), WhatGoesToCell.enum_cardNumber);
            CustomCell.EditDependentCellData(dataGridViewPeople, name, WhatGoesToCell.enum_name);
            CustomCell.EditDependentCellData(dataGridViewPeople, birthday.ToString("dd.MM.yyyy"), WhatGoesToCell.enum_birthday);
            CustomCell.EditDependentCellData(dataGridViewPeople, peopleArray[selected].CalcAge(DateTime.Now).ToString(), WhatGoesToCell.enum_calcAge);
        }

        //update (?)
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

        //update (?)
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

        //update (?)
        private void ButtonNewDependence_Click(object sender, EventArgs e)
        {
            if (dataGridViewPeople.CurrentCell == null) return;
            CustomCell.NewDependence(dataGridViewPeople, WhatGoesToCell.enum_other);
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

        //update (?)
        private void DataGridViewPeople_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewPeople.CurrentCell == null) return;
            if (dataGridViewPeople.CurrentCell.ColumnIndex == 0)
            {
                CustomCell.OpenCell(dataGridViewPeople.CurrentCell.RowIndex, dataGridViewPeople);
            }
        }
    }
}