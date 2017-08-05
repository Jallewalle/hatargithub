﻿using System;
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
        bool fall = false;
        int move;
        int movepixel;

        //default: blockstorlek = 20, width = 61, height = 30
        //default player position: x = 30,31, y = 14,15,16
        int updown = 1000;
        int blockstorlek = 20;
        int width = 61;
        int height = 30;
        int gravity = 14;
        int jumpheight = 0;
        int movespeedx = 2;
        int movespeedy = 2;
        int playerX = 30;
        int playerY = 13;

        Font drawFont = new Font("Arial", 20);
        #region bildr

        Image Grass = försök_till_bra_spel.Properties.Resources.TopGrass;
        Image Stone = försök_till_bra_spel.Properties.Resources.Stone;
        Image Dirt = försök_till_bra_spel.Properties.Resources.Dirt;
        Image Sand = försök_till_bra_spel.Properties.Resources.Sand;
        Image Water = försök_till_bra_spel.Properties.Resources.Water;
        Image Air = försök_till_bra_spel.Properties.Resources.Air;
        Image Lava = försök_till_bra_spel.Properties.Resources.LAVA;
        Image Tbd = försök_till_bra_spel.Properties.Resources.Tbd;
        Image TopWater = försök_till_bra_spel.Properties.Resources.TopWater;
        Image BotWater = försök_till_bra_spel.Properties.Resources.BotWater;
        Image Löv = försök_till_bra_spel.Properties.Resources.Löv;
        Image Träd = försök_till_bra_spel.Properties.Resources.Träd;
        Image player = försök_till_bra_spel.Properties.Resources.PlayerModel;
        Image playerfall = försök_till_bra_spel.Properties.Resources.PlayerModelHopp;
        #endregion

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
            Blocks.Add(Träd); //9 träd
            Blocks.Add(Löv); //10 löv
            Blocks.Add(Tbd); //99 tbd
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
                        g.DrawImage(Blocks[Blocktyp], (xcord * blockstorlek - move * blockstorlek - movepixel) - blockstorlek, (ycord * blockstorlek - updown * blockstorlek) + jumpheight - blockstorlek, blockstorlek, blockstorlek);
                    }
                }
                if (fall == true)
                {
                    g.DrawImage(playerfall, playerX * blockstorlek - blockstorlek, playerY * blockstorlek);
                }
                else
                {
                    g.DrawImage(player, playerX * blockstorlek - blockstorlek, playerY * blockstorlek);
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
            else if (e.KeyCode == Keys.W  && jump == false && fall == false)
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

            #region gå höger
            if (moveRight && move < Värld[1].Count - width - 1 &&
                Värld[14 + updown][32 + move] == 1 &&
                Värld[15 + updown][32 + move] == 1 &&
                Värld[16 + updown][32 + move] == 1 && 
                jumpheight == 0)
            {
                movepixel += movespeedx;
                if (movepixel >= blockstorlek)
                {
                    move += 1;
                    movepixel = 0;
                    
                }
            }
            else if (moveRight && move < Värld[1].Count - width - 1 &&
                Värld[14 + updown][32 + move] == 1 &&
                Värld[15 + updown][32 + move] == 1 &&
                Värld[16 + updown][32 + move] == 1 &&
                Värld[17 + updown][32 + move] == 1)
            {
                movepixel += movespeedx;
                if (movepixel >= blockstorlek)
                {
                    move += 1;
                    movepixel = 0;

                }
            }
            #endregion

            #region gå vänster
            if (moveLeft && move > 0 &&
                Värld[14 + updown][29 + move] == 1 &&
                Värld[15 + updown][29 + move] == 1 &&
                Värld[16 + updown][29 + move] == 1 &&
                jumpheight == 0)
            {
                movepixel -= movespeedx;
                if (movepixel <= -blockstorlek)
                {
                    move -= 1;
                    movepixel = 0; 
                }
            }
            else if (moveLeft && move > 0 &&
               Värld[14 + updown][29 + move] == 1 &&
               Värld[15 + updown][29 + move] == 1 &&
               Värld[16 + updown][29 + move] == 1 &&
               Värld[17 + updown][29 + move] == 1)
            {
                movepixel -= movespeedx;
                if (movepixel <= -blockstorlek)
                {
                    move -= 1;
                    movepixel = 0;
                }
            }
            #endregion

            #region röra sig ned
            if (moveDown && updown < Värld.Count - height - 1)
            {
                updown += movespeedy;
            }
            #endregion

            #region hoppa
            if (jump && updown > 0)
            {
                if (Värld[13 + updown][30 + move] != 1 ||
                    Värld[13 + updown][31 + move] != 1)
                {
                    gravity = 0;
                }
                else
                {
                    jumpheight += gravity;
                }
                
                
                if (jumpheight >= blockstorlek )
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
                if (gravity < 0)
                {
                    gravity = 14;
                    jump = false;
                }
            }
            if (Värld[17 + updown][30 + move] == 1 &&
                Värld[17 + updown][31 + move] == 1 &&
                jump == false)
            {
                fall = true;
                if (movepixel != 0)
                {
                    if (movepixel > 0 && Värld[17 + updown][32 + move] == 1)
                    {
                        jumpheight--;
                        if (jumpheight == -blockstorlek)
                        {
                            jumpheight = 0;
                            updown++;
                            
                        }
                    }
                    else if (movepixel < 0 && Värld[17 + updown][29 + move] == 1)
                    {
                        jumpheight--;
                        if (jumpheight == -blockstorlek)
                        {
                            jumpheight = 0;
                            updown++;
                            
                        }
                    }
                }
                else
                {
                    jumpheight--;
                    if (jumpheight == -blockstorlek)
                    {
                        jumpheight = 0;
                        updown++;
                        
                    }
                }
            }
            else
            {
                fall = false;
            }
            #endregion

            #region move up
            if (moveUp)
            {
                updown -= movespeedx;
            }
            #endregion

            Refresh();
        }

        private void Spelvärld_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'z')
            {
                if (blockstorlek == 1)
                {
                    blockstorlek = 10;
                    width = 120;
                    height = 60;
                    movespeedx = 20;
                    movespeedy = 20;
                }
                else
                {
                    blockstorlek = 1;
                    width = 1200;
                    height = 600;
                    movespeedx = 200;
                    movespeedy = 200;
                }

            }
        }
    }
}
