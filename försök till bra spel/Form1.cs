using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace försök_till_bra_spel
{
    public partial class Start : Form
    {
        Ny_värld nyvärld = new Ny_värld();
        Spelvärld spelvärld = new Spelvärld();
        Ladda_värld laddavärld = new Ladda_värld();
        Skapavärld skapavärld = new Skapavärld();
        minimap map = new minimap();

        string valdmap;
        public Start()
        {
            InitializeComponent();
        }

        public void labeltext()
        {
            label_name.Text = "Värld: " + nyvärld.setvärldnamn();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                nyvärld.Show();
                labeltext();
            }
            catch (Exception)
            {
                MessageBox.Show("HAHA RÄKAD");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                spelvärld.Show();
                
            }
            catch (Exception)
            {
                
                MessageBox.Show("HAHA RÄKAD");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
                valdmap = ofd.FileName;
                laddavärld.öppnavärld(valdmap);
                label_name.Text = valdmap;
                
            }
            
        }

        private void Start_Activated(object sender, EventArgs e)
        {
            labeltext();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            map.Show();
            map.createmap(laddavärld.hämtavärld());
        }
    }
}
