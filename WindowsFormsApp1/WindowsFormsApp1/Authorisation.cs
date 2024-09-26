using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Authorisation : Form
    {
        private string passwordForAdminHash = "KVzmcRYG6upaLo8MRwPntw=="; //password 1111 (string admin1111)

        private NewRecord formOwner;
        public Authorisation(NewRecord owner)
        {
            formOwner = owner;
            InitializeComponent();
        }



        private void ComboBoxLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLogin.SelectedItem.ToString() == "admin") textBoxPassword.Enabled = true;
            else textBoxPassword.Enabled = false;
        }

        private string GetHash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        private void ButtonOkAuth_Click(object sender, EventArgs e)
        {
            string loginPassword = GetHash(comboBoxLogin.Text + textBoxPassword.Text);

            if (loginPassword == passwordForAdminHash)
            {
                formOwner.personCardNumber.Enabled = true;
                formOwner.personBirthday.Enabled = true;

                formOwner.BackColor = Color.Aqua;
                formOwner.personCardNumber.BackColor = Color.Peru;
                formOwner.personName.BackColor = Color.Peru;
                formOwner.personBirthday.CalendarForeColor = Color.PaleGoldenrod;

                Close();
            }
        }

        private void ButtonCancelAuth_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Authorisation_Load(object sender, EventArgs e)
        {

        }
    }
}
