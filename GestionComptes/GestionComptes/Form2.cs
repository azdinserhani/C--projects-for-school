﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GestionComptes
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        void ajouter()
        {
            FileStream fs = new FileStream("operation.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(comboBox1.Text + "#" + comboBox2.Text + "#" + comboBox3.Text + "#" + dateTimePicker1.Text + "#" + textBox3.Text);
            sw.Close();
            fs.Close();
            MessageBox.Show("information est bien enregitrer");

        }
        void Lister()
        {
            FileStream fs = new FileStream("operation.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            dataGridView1.Rows.Clear();
            while (sr.Peek() > 1)
            {
                string[] line = sr.ReadLine().Split('#');
                dataGridView1.Rows.Add(line[0], line[1], line[2], line[3], line[4]);
            }
            sr.Close();
            fs.Close();

        }
        void Rechecher()
        {
            FileStream fs = new FileStream("operation.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            dataGridView1.Rows.Clear();
            while (sr.Peek() > 1)
            {
                string[] line = sr.ReadLine().Split('#');
                if (line[0] == comboBox1.Text)
                {
                    comboBox2.Text = line[1];
                    comboBox3.Text = line[2];
                    dateTimePicker1.Text = line[3];
                    textBox3.Text = line[4];
                    break;
                }
            }
            sr.Close();
            fs.Close();


        }
        void RechecherSolde()
        {
            FileStream fs = new FileStream("miage.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            
            while (sr.Peek() > 1)
            {
                string[] line = sr.ReadLine().Split('#');
                if (line[0] == comboBox2.Text)
                {
                    label8.Text = line[4];
                    break;
                }
            }
            sr.Close();
            fs.Close();


        }
        void Modifier()
        {
            string st = "";
            FileStream fs = new FileStream("operation.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            while (sr.Peek() > -1)
            {
                string tocken = sr.ReadLine();
                string[] line = tocken.Split('#');
                if (line[0] != comboBox1.Text)
                {
                    st = st + tocken + "\n";
                }
                else
                {
                    st = st + comboBox1.Text + "#" + comboBox2.Text + "#" + comboBox3.Text + "#" + dateTimePicker1.Text + "#" + textBox3.Text + "\n";
                }
            }
            sr.Close();
            fs.Close();
            FileStream fs1 = new FileStream("operation.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs1);
            sw.Write(st);
            sw.Close();
            fs1.Close();
            MessageBox.Show("information est Modifier");

        }
        void Remplir()
        {
            FileStream fs = new FileStream("operation.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            comboBox1.Items.Clear();
            while (sr.Peek() > 1)
            {
                string[] line = sr.ReadLine().Split('#');
                comboBox1.Items.Add(line[0]);
            }
            sr.Close();
            fs.Close();

        }
        void RemplirC()
        {
            FileStream fs = new FileStream("miage.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            comboBox2.Items.Clear();
            while (sr.Peek() > 1)
            {
                string[] line = sr.ReadLine().Split('#');
                comboBox2.Items.Add(line[0]);
            }
            sr.Close();
            fs.Close();

        }
        void Suppremer()
        {
            string st = "";
            FileStream fs = new FileStream("operation.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            while (sr.Peek() > 1)
            {
                string tocken = sr.ReadLine();
                string[] line = tocken.Split('#');
                if (line[0] != comboBox1.Text)
                {
                    st = st + tocken + "\n";
                }

            }
            sr.Close();
            fs.Close();
            FileStream fs1 = new FileStream("operation.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs1);
            sw.Write(st);
            sw.Close();
            fs1.Close();
            MessageBox.Show("information est bien suppremer");
        }
        void vider() {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
          
            textBox3.Text = "";
        }
        float calculerSolde(float Solde,float mt,string typeOp) {
            if (typeOp == "versement")
            {
                Solde = Solde + mt;
                

            }
            else if (typeOp == "retrait") {
                Solde = Solde - mt;
            }
            return Solde;
        }

        void Modifiersolde()
        {
            string st = "";
            FileStream fs = new FileStream("miage.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            while (sr.Peek() > -1)
            {
                string tocken = sr.ReadLine();
                string[] line = tocken.Split('#');
                if (line[0] != comboBox2.Text)
                {
                    st = st + tocken + "\n";
                }
                else
                {
                    st = st + comboBox2.Text + "#" + line[1] + "#" + line[2] + "#" + line[3] + "#" + calculerSolde(float.Parse(label8.Text), float.Parse(textBox3.Text), comboBox3.Text).ToString() + "\n";
                }
            }
            sr.Close();
            fs.Close();
            FileStream fs1 = new FileStream("miage.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs1);
            sw.Write(st);
            sw.Close();
            fs1.Close();
            MessageBox.Show("information est Modifier");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ajouter();
            Modifiersolde();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lister();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rechecher();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Modifier();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Suppremer();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            vider();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            Remplir();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rechecher();
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            RemplirC();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RechecherSolde();
        }

        
    }
}
