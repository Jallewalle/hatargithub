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
        public void createmap(List<List<int>> x)
        {
            värld = x;
            name = rand.Next(10000, 100000).ToString();
            Bitmap bmp = new Bitmap(10000, 3000);
            
            for (int i = 0; i < 10000; i++)
            {
                for (int index = 0; index < 3000; index++)
                {
                    if (värld[index][i] == 1)
                    {
                        bmp.SetPixel(i, index, Color.Cyan);
                    }
                    else if (värld[index][i] == 2)
                    {
                        bmp.SetPixel(i, index, Color.Green);
                    }
                    else if (värld[index][i] == 3)
                    {
                        bmp.SetPixel(i, index, Color.DarkSlateGray);
                    }
                    else if (värld[index][i] == 4)
                    {
                        bmp.SetPixel(i, index, Color.SandyBrown);
                    }
                    else if (värld[index][i] == 5)
                    {
                        bmp.SetPixel(i, index, Color.Yellow);
                    }
                    else if (värld[index][i] == 6)
                    {
                        bmp.SetPixel(i, index, Color.Brown);
                    }
                    else if (värld[index][i] == 7 || värld[index][i] == 8)
                    {
                        bmp.SetPixel(i, index, Color.DarkBlue);
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
            minimap.ActiveForm.Close();
            bmp.Save("F:\\AAAWorlds\\Textures\\WorldMap\\" + name + ".png");
        }

        private void minimap_Load(object sender, EventArgs e)
        {
            
        }
    }
    
}
