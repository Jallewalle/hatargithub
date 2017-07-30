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

        //Form form = new Form();
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
        public void progressbar()
        {
            progressBar1.Value += 65;
            progressBar1.PerformStep();
        }
        public void progressBarTotalUpdate(int value)
        {
            try
            {
                progressBarTotal.Value += value;
            }
            catch (Exception)
            {

                progressBarTotal.Value = 100;
            }

        }
        private void skapa()
        {
            
            progressbar();
            label2.Text = "Hämtar storlek";
            label2.Update();
            skapavärld.getStorlek(storlek);
            progressBarTotalUpdate(11);

            progressBar1.Value = 0;
            label2.Text = "Skapar terräng";
            updatelabel();
            skapavärld.skapavärlden();
            progressBarTotalUpdate(11);

            progressBar1.Value = 0;
            label2.Text = "Namnger";
            updatelabel();
            name = textBox1.Text;
            skapavärld.getvärldnamn(name);
            progressBarTotalUpdate(11);

            progressBar1.Value = 0;
            label2.Text = "Lägger ut jord och sten";
            updatelabel();
            skapavärld.underworld();
            progressBarTotalUpdate(11);

            progressBar1.Value = 0;
            label2.Text = "Skapar grottor";
            updatelabel();
            skapavärld.caves();
            progressBarTotalUpdate(11);

            progressBar1.Value = 0;
            label2.Text = "Skapar öar";
            updatelabel();
            skapavärld.floatingislands();
            progressBarTotalUpdate(11);

            progressBar1.Value = 0;
            label2.Text = "Skapar mineraler";
            updatelabel();
            skapavärld.mineralerV2();
            progressBarTotalUpdate(11);

            progressBar1.Value = 0;
            label2.Text = "Skapar vatten";
            updatelabel();
            skapavärld.skapavatten();
            progressBarTotalUpdate(11);
            
            progressBar1.Value = 0;
            label2.Text = "Sparar";
            updatelabel();
            skapavärld.sparavärlden();
            progressBarTotalUpdate(12);
            
            label2.Text = "";
            updatelabel();
            MessageBox.Show("Sparat");
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
