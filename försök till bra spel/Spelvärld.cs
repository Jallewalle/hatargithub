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
    public partial class Spelvärld : Form
    {

        Ladda_värld laddavärld = new Ladda_värld();
        List<List<int>> Värld = new List<List<int>>();
        List<Image> Blocks = new List<Image>();
        bool moveRight = false;
        bool moveLeft = false;
        bool moveUp = false;
        bool moveDown = false;
        bool jump = false;
        int move;
        //default: blockstorlek = 20, width = 60, height = 29
        int updown = 1000;
        int blockstorlek = 20;
        int width = 60;
        int height = 29;
        int gravity = 14;
        int jumpheight = 0;
        Font drawFont = new Font("Arial", 20);
        Image Grass = försök_till_bra_spel.Properties.Resources.Grass;
        Image Stone = försök_till_bra_spel.Properties.Resources.Stone;
        Image Dirt = försök_till_bra_spel.Properties.Resources.Dirt;
        Image Sand = försök_till_bra_spel.Properties.Resources.Sand;
        Image Water = försök_till_bra_spel.Properties.Resources.Water;
        Image Air = försök_till_bra_spel.Properties.Resources.Air;
        Image Lava = försök_till_bra_spel.Properties.Resources.LAVA;
        Image Tbd = försök_till_bra_spel.Properties.Resources.Tbd;
        Image TopWater = försök_till_bra_spel.Properties.Resources.TopWater;
        Image BotWater = försök_till_bra_spel.Properties.Resources.BotWater;
        public Spelvärld()
        {
            InitializeComponent();
            Blocks.Add(Air); //0
            Blocks.Add(Air); //1
            Blocks.Add(Grass); //2
            Blocks.Add(Stone); //3
            Blocks.Add(Dirt); //4
            Blocks.Add(Sand); //5
            Blocks.Add(Lava); //6
            Blocks.Add(TopWater); //7
            Blocks.Add(BotWater); //8
            Blocks.Add(Tbd); //9
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Värld = laddavärld.hämtavärld();

            try
            {
                for (int ycord = updown; ycord < updown + height + 1; ycord++)
                {
                    for (int xcord = move; xcord < move + width + 1; xcord++)
                    {
                        int Blocktyp = Värld[ycord][xcord];
                        g.DrawImage(Blocks[Blocktyp], (xcord * blockstorlek - move * blockstorlek) - blockstorlek, (ycord * blockstorlek - updown * blockstorlek) + jumpheight - blockstorlek, blockstorlek, blockstorlek);
                    }
                }
            }
            catch (Exception)
            {
                //lel
            }
            g.DrawString(move.ToString(), drawFont, Brushes.Black, 0F, 10F);
            g.DrawString(updown.ToString(), drawFont, Brushes.Black, 0F, 30F);

        }

        private void Spelvärld_KeyDown(object sender, KeyEventArgs e)
        {
            timer1.Enabled = true;
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = true;
            }
            else if (e.KeyCode == Keys.W && moveUp != true)
            {
                jump = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                moveUp = true;
            }
        }
        private void Spelvärld_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            else if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                moveDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                moveUp = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (moveRight && move < Värld[1].Count - width - 1)
            {
                move = move + 1;
            }
            if (moveLeft && move > 0)
            {
                move = move - 1;
            }
            if (moveDown && updown < Värld.Count - height - 1)
            {
                updown = updown + 1;
            }
            if (jump && updown > 0)
            {
                jumpheight +=gravity;
                if (jumpheight >= blockstorlek)
                {
                    updown--;
                    jumpheight = 0;
                }
                if (jumpheight <= -1 * blockstorlek)
                {
                    updown++;
                    jumpheight = 0;
                }
                gravity--;
                if (gravity < -14)
                {
                    gravity = 14;
                    jump = false;
                }
            }
            if (moveUp)
            {
                updown = updown - 1;
            }
            Refresh();
        }
    }
}
