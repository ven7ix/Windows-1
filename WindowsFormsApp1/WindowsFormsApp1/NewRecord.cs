﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class NewRecord : Form
    {
        private readonly bool _callerButton;
        private bool adminMode = false;
        private bool textChanged = false;

        public event Action<int, string, DateTime> OnDataSubmitted;

        private readonly List<Person> _peopleArray;
        private readonly int _index;

        public NewRecord(bool callerButton, List<Person> peopleArray, int index)
        {
            _peopleArray = peopleArray;
            _callerButton = callerButton;
            _index = index;
            InitializeComponent();
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            if (personCardNumber.Text.Length != 5) MessageBox.Show("Card number must be 5 caracters long");
            if (personName.Text.Length <= 0) MessageBox.Show("Person's name must be at least 1 caracter long");
            if (personBirthday.Value > DateTime.Now) MessageBox.Show("Person's birthday cannot be in future");
            if (personCardNumber.Text.Length == 5 && personName.Text.Length > 0 && personBirthday.Value <= DateTime.Now)
            {
                int cardNumber = int.Parse(personCardNumber.Text);
                string name = personName.Text;
                DateTime birthday = personBirthday.Value;

                //начало доп задания (в списке не может быть одинаковых айди)
                int indexPos = 0;
                foreach (Person p in _peopleArray)
                {
                    if (cardNumber == p._CardNumber)
                    {
                        if (_index != -1)
                        {
                            if (_peopleArray[indexPos] == _peopleArray[_index]) continue;
                        }
                        MessageBox.Show("Existing id");
                        return;
                    }
                    indexPos++;
                }
                //конец доп задания

                OnDataSubmitted?.Invoke(cardNumber, name, birthday);

                Close();
            }
        }

        private void ButtonDeny_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewRecord_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.L && _callerButton)
            {
                Authorisation authorisation = new Authorisation(this);
                adminMode = true;
                authorisation.Show();
            }
        }

        private void PersonCardNumber_TextChanged(object sender, EventArgs e)
        {
            if (adminMode) textChanged = true;

            //проверка на 0 в начале строки card
            if (personCardNumber.Text.Length > 0 && personCardNumber.Text[0] == '0')
            {
                personCardNumber.Text = personCardNumber.Text.Replace(personCardNumber.Text[0].ToString(), "");
                personCardNumber.SelectionStart = personCardNumber.Text.Length;
            }
            
            //проверка на символ в строке card
            foreach (char c in personCardNumber.Text) {
                if (!Char.IsDigit(c))
                {
                    personCardNumber.Text = personCardNumber.Text.Replace(c.ToString(), "");
                    personCardNumber.SelectionStart = personCardNumber.Text.Length;
                }
            }
        }

        private void NewRecord_MouseMove(object sender, MouseEventArgs e)
        {
            if (!textChanged) return;
            if (e.Location.X > buttonAccept.Left - 10 && buttonAccept.Left > 5)
            {
                buttonAccept.Left -= 1;
            }
            else if (e.Location.X < buttonAccept.Right + 10 && buttonAccept.Right < Width - 5)
            {
                buttonAccept.Left += 1;
            }
            if (e.Location.Y > buttonAccept.Top - 10 && buttonAccept.Top > 5)
            {
                buttonAccept.Top -= 1;
            }
            else if (e.Location.Y < buttonAccept.Bottom + 10 && buttonAccept.Bottom < Height - buttonAccept.Height / 2 - 5)
            {
                buttonAccept.Top += 1;
            }
        }
    }
}