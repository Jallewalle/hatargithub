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
    public partial class minimap : Form
    {
        public minimap()
        {
            InitializeComponent();
        }
        Random rand = new Random();

        List<List<int>> värld = new List<List<int>>();
        string name;
        int xlängd;
        int yhöjd;
        Bitmap bmp = new Bitmap(10000, 3000);
        public void createmap(List<List<int>> x, int längd, int höjd)
        {
            värld = x;
            xlängd = längd;
            yhöjd = höjd;
            name = rand.Next(10000, 100000).ToString();

            if (xlängd > 10000)
            {
                xlängd = 10000;
                yhöjd = 3000;

                färglägg(0, 0);
                name += 1;
                färglägg(0, 3000);
                name += 1;
                färglägg(10000, 0);
                name += 1;
                färglägg(10000, 3000);
            }
            else
            {
                färglägg(0,0);
            }
     
        }
        public void färglägg(int startx, int starty)
        {
            progressBar1.Value = 0;
            
            for (int i = 0; i < xlängd; i++)
            {
                for (int index = 0; index < yhöjd; index++)
                {
                    if (värld[index + starty][i + startx] == 1)
                    {
                        bmp.SetPixel(i, index, Color.Cyan);
                    }
                    else if (värld[index + starty][i + startx] == 2)
                    {
                        bmp.SetPixel(i, index, Color.Green);
                    }
                    else if (värld[index + starty][i + startx] == 3)
                    {
                        bmp.SetPixel(i, index, Color.DarkSlateGray);
                    }
                    else if (värld[index + starty][i + startx] == 4)
                    {
                        bmp.SetPixel(i, index, Color.SandyBrown);
                    }
                    else if (värld[index + starty][i + startx] == 5)
                    {
                        bmp.SetPixel(i, index, Color.Yellow);
                    }
                    else if (värld[index + starty][i + startx] == 6)
                    {
                        bmp.SetPixel(i, index, Color.Brown);
                    }
                    else if (värld[index + starty][i + startx] == 7)
                    {
                        bmp.SetPixel(i, index, Color.Blue);
                    }
                    else if (värld[index + starty][i + startx] == 8)
                    {
                        bmp.SetPixel(i, index, Color.DarkBlue);
                    }
                    else if (värld[index + starty][i + startx] == 9)
                    {
                        bmp.SetPixel(i, index, Color.SaddleBrown);
                    }
                    else if (värld[index + starty][i + startx] == 10)
                    {
                        bmp.SetPixel(i, index, Color.LightGreen);
                    }
                    else
                    {
                        bmp.SetPixel(i, index, Color.Pink);
                    }

                }
                if (i % 100 == 0)
                {
                    progressBar1.Value += 1;
                }

            }
            //minimap.ActiveForm.Close();
            bmp.Save("F:\\AAAWorlds\\Textures\\WorldMap\\" + name + ".png");
        }
        private void minimap_Load(object sender, EventArgs e)
        {
            
        }
    }
}
