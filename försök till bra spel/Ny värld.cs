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
            progressBar1.Value = 0;
        }
        private void skapa()
        {
            skapavärld.getStorlek(storlek);
            label2.Text = "Hämtar storlek";

            skapavärld.skapavärlden();
            label2.Text = "Skapar terräng";

            name = textBox1.Text;
            skapavärld.getvärldnamn(name);
            label2.Text = "Namnger";

            skapavärld.underworld();
            label2.Text = "Lägger ut jord och sten";

            skapavärld.caves();
            label2.Text = "Skapar grottor";

            skapavärld.floatingislands();
            label2.Text = "Skapar öar";

            skapavärld.mineraler();
            label2.Text = "Skapar mineraler";

            skapavärld.skapavatten();
            label2.Text = "Skapar vatten";

            skapavärld.sparavärlden();
            label2.Text = "Sparar";



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
