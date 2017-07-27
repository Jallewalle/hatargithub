using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace försök_till_bra_spel
{

    class Ladda_värld
    {
        public static List<List<int>> GlobalVärldsLista = new List<List<int>>();
        public List<List<int>> hämtavärld()
        {
            return GlobalVärldsLista;
        }
        public void öppnavärld(string FilePath)
        {
            string text = System.IO.File.ReadAllText(@FilePath);
            List<List<int>> VärldsLista = new List<List<int>>();
            int xindex = 0;
            int xindexstring = 1;
            int yindex = 0;
            int storlekenx = 0;
            int storlekeny = 0;
            string antal = "";
            char[] Convertera = { 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k' };
            text = text.Trim();
            if (text[0] == '1')
            {
                storlekenx = 10000;
                storlekeny = 3000;
            }
            else if (text[0] == '2')
            {
                storlekenx = 2000;
                storlekeny = 600;
            }
            else if (text[0] == '3')
            {
                storlekenx = 500;
                storlekeny = 150;
            }
            else if (text[0] == '4')
            {
                storlekenx = 24;
                storlekeny = 15;
            }

            for (int i = 0; i < storlekeny; i++)
            {
                VärldsLista.Add(new List<int>());
                while (text[xindexstring] != 'x')
                {
                    if (text[xindexstring] == '\r' || text[xindexstring] == '\n')
                    {
                        xindexstring++;
                    }
                    else if (!Convertera.Contains(text[xindexstring]))
                    {
                        antal += text[xindexstring];
                        xindexstring++;
                    }
                    else if (Convert.ToInt32(antal) > 0 && Convertera.Contains(text[xindexstring]))
                    {
                        for (int index = 0; index < Convert.ToInt32(antal); index++)
                        {
                            VärldsLista[yindex].Add(0);
                            VärldsLista[yindex][xindex] = text[xindexstring];
                            xindex++;
                        }
                        antal = "0";
                        xindexstring++;
                    }
                }
                xindex = 0;
                xindexstring++;
                yindex++;
            }
            //convertera acii-chars till int
            for (int y = 0; y < VärldsLista.Count; y++)
            {
                for (int x = 0; x < VärldsLista[1].Count; x++)
                {
                    for (int blocktyp = 1; blocktyp < Convertera.Length; blocktyp++)
                    {
                        if (VärldsLista[y][x] == Convertera[blocktyp])
                        {
                            VärldsLista[y][x] = blocktyp;
                            break;
                        }
                    }
                }
            }
            GlobalVärldsLista = VärldsLista;          
        }

    }
}
