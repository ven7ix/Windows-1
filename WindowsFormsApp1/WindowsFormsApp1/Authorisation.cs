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
    public partial class Authorisation : Form
    {
        public Authorisation()
        {
            InitializeComponent();
        }

        private void comboBoxLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLogin.SelectedItem.ToString() == "admin")
            {
                textBoxPassword.Enabled = true;
            } 
            else textBoxPassword.Enabled = false;
        }
    }
}
