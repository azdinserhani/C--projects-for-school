using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TPFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void nouveau() {
            comboBox1.Text = "";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Focus();
        }
        void enregistrer() { 
        FileStream fs = new FileStream("miage.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(comboBox1.Text + "#" + textBox1.Text + "#" + textBox2.Text + "#" + textBox3.Text);
            sw.Close();
            fs.Close();
            MessageBox.Show("les infos est bien enregistrer");
        }
        void lister() {
            FileStream fs = new FileStream("miage.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            dataGridView1.Rows.Clear();
            while (sr.Peek() > -1)
            {
                string[] line = sr.ReadLine().Split('#');
                dataGridView1.Rows.Add(line[0], line[1], line[2], line[3]);
            }
            sr.Close();
            fs.Close();
        }
        void rechercher() {
            FileStream fs = new FileStream("miage.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() > -1)
            {
                string[] line = sr.ReadLine().Split('#');
                if (line[0] == comboBox1.Text)
                {
                    textBox1.Text = line[1];
                    textBox2.Text = line[2];
                    textBox3.Text = line[3];
                }
            }
            sr.Close();
            fs.Close();
        }
        void remplir() {
            FileStream fs = new FileStream("miage.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            comboBox1.Items.Clear();
            while (sr.Peek() > -1)
            {
                string[] line = sr.ReadLine().Split('#');
                comboBox1.Items.Add(line[0]);
            }
            sr.Close();
            fs.Close();
        }
        void supprimer() {
            string st = "";
            FileStream fs = new FileStream("miage.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() > -1)
            {

                string token = sr.ReadLine();
                string[] line = token.Split('#');
                if (line[0] != comboBox1.Text)
                {
                    st = st + token + "\n";
                }
            }
            sr.Close();
            fs.Close();

            FileStream fs2 = new FileStream("miage.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);
            sw.Write(st);
            sw.Close();
            fs2.Close();
            MessageBox.Show("Les infos est bien supprimer");
        }
        void modifier()
        {
            string st = "";
            FileStream fs = new FileStream("miage.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() > -1)
            {

                string token = sr.ReadLine();
                string[] line = token.Split('#');
                if (line[0] != comboBox1.Text)
                {
                    st = st + token + "\n";
                }
                else {
                    st = st + comboBox1.Text + "#" + textBox1.Text + "#" + textBox2.Text + "#" + textBox3.Text  +"\n";
                }
            }
            sr.Close();
            fs.Close();

            FileStream fs2 = new FileStream("miage.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);
            sw.Write(st);
            sw.Close();
            fs2.Close();
            MessageBox.Show("Les infos est bien modifier");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            enregistrer();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            lister();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rechercher();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            remplir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rechercher(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez vous supprimer ?", "supprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                supprimer();
                nouveau();
                lister();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez vous modifier ?", "modifier", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                modifier();
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            nouveau();
        }
    }
}
