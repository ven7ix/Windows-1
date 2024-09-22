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
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonNewRecord_Click(object sender, EventArgs e)
        {
            NewRecord record = new NewRecord();
            record.Owner = this;
            record.ShowDialog();
        }

        private void buttonEditRecord_Click(object sender, EventArgs e)
        {
            NewRecord record = new NewRecord();
            record.Owner = this;

            if (peopleList.SelectedItem != null)
            {
                string person = peopleList.SelectedItem.ToString();
                string[] personData = person.Split('\t');

                record.personCardNumber.Text = personData[0];
                record.personName.Text = personData[1];
                record.personBirthday.Text = personData[2];

                record.personCardNumber.Enabled = false;
                record.personBirthday.Enabled = false;
                
                record.ShowDialog();

                peopleList.Items.RemoveAt(peopleList.SelectedIndex);
            }
        }

        private void buttonDeleteRecord_Click(object sender, EventArgs e)
        {
            if (peopleList.SelectedItem != null)
            {
                DialogResult dialogResult = MessageBox.Show("you shure?", "confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string person = peopleList.SelectedItem.ToString();
                    peopleList.Items.RemoveAt(peopleList.SelectedIndex);
                }
            } 
            else
            {
                MessageBox.Show("you haven't selected record");
            }
        }

    }
}
