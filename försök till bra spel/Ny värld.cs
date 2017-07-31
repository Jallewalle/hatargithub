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

        Skapavärld skapavärld = new Skapavärld();
        skapavärldV2 skapavärld2 = new skapavärldV2();

        public Ny_värld()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        int storlek;
        string name;

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            storlek = 1;
            skapa();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            storlek = 2;
            skapa();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            storlek = 3;
            skapa();

        }
        
        private void skapa()
        {
            skapavärld2.Show();
            skapavärld2.progressBar2.Value += 10;

            skapavärld2.getStorlek(storlek);
            skapavärld2.progressBar2.Value += 10;

            skapavärld2.skapavärlden();
            skapavärld2.progressBar2.Value += 10;

            name = textBox1.Text;
            skapavärld2.getvärldnamn(name);
            skapavärld2.progressBar2.Value += 10;

            skapavärld2.underworld();
            skapavärld2.progressBar2.Value += 10;

            skapavärld2.caves();
            skapavärld2.progressBar2.Value += 10;

            skapavärld2.floatingislands();
            skapavärld2.progressBar2.Value += 10;

            skapavärld2.mineralerV2();
            skapavärld2.progressBar2.Value += 10;

            skapavärld2.skapavatten();
            skapavärld2.progressBar2.Value += 10;

            skapavärld2.sparavärlden();
            skapavärld2.progressBar2.Value += 10;

        }
        public void updatelabel()
        {
            label2.Update();
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

        private void progressBar1_Click(object sender, EventArgs e)
        {
        
    }
}
}
