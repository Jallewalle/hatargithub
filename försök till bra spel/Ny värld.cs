using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace försök_till_bra_spel
{
    public partial class Ny_värld : Form
    {

        Form form = new Form();
        Skapavärld skapavärld = new Skapavärld();

        public Ny_värld()
        {
            InitializeComponent();
        }

        int storlek;
        string name;

        private void button1_Click(object sender, EventArgs e)
        {
            storlek = 1;
            skapa();
            uncheck();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            storlek = 2;
            skapa();
            uncheck();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            storlek = 3;
            skapa();
            uncheck();
        }
        private void uncheck()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
        }
        private void skapa()
        {
            skapavärld.getStorlek(storlek);
            checkBox1.Checked = true;

            skapavärld.skapavärlden();
            checkBox2.Checked = true;

            name = textBox1.Text;
            skapavärld.getvärldnamn(name);
            checkBox3.Checked = true;

            skapavärld.underworld();
            checkBox4.Checked = true;

            skapavärld.caves();
            checkBox5.Checked = true;

            skapavärld.floatingislands();

            skapavärld.mineraler();
            checkBox6.Checked = true;

            skapavärld.skapavatten();
            checkBox7.Checked = true;

            skapavärld.sparavärlden();
            checkBox8.Checked = true;

            

            MessageBox.Show("Sparat");
        }
        public int setstorlek(int x)
        {
            x = storlek;
            return x;
        }



        public string setvärldnamn()
        {
            return name;
        }

        
        
    }
}
