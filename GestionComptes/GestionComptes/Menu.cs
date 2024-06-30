using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestionComptes
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void compteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        private void operationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "admin" && textBox1.Text == "1234")
            {
                menuStrip1.Enabled = true;
            }
            else {
                MessageBox.Show("nom ou mot pass est incorrect");
            }
        }
    }
}
