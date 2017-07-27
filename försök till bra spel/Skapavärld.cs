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

    class Skapavärld
    {
        Random random = new Random(); //random random
        Ladda_värld laddavärld = new Ladda_värld();
        
        List<List<int>> VärldsLista = new List<List<int>>();
        string[] test = { "a", "b", "c", "d", "e", "f", "g", "h", "i" };

        //saknas: Flytande öar, maskhål, fixa vattnet och mer greor
        //0 air, 1 Grass, 2 stone, 3 dirt, 4 sand, 5 Lava, 6 TopWater , 7 BotWater, 8+ odefinerat
        List<string> Världen = new List<string>();
        int storleken;
        int vattenlängd;
        int vattenstart;
        int vattenslut;
        int xlängd;
        int ybredd;
        int ystart;
        int biome;
        int biomelängd;
        int blocktyp;
        int xplats;
        int yplats;
        int cavetopy;
        int caveboty;
        int islandtopy;
        int islandboty;
        int addX;
        int addY;
        string WorldName;
        string text = "";
        bool stop = false;

        public void getStorlek(int x)
        {
            storleken = x;
            if (storleken == 1)
            {
                xlängd = 10000;
                ybredd = 3000;
                ystart = 1000;
            }
            else if (storleken == 2)
            {
                xlängd = 2000;
                ybredd = 600;
                ystart = 200;
            }
            else if (storleken == 3)
            {
                xlängd = 500;
                ybredd = 150;
                ystart = 50;
            }
            for (int i = 0; i < ybredd; i++)
            {
                VärldsLista.Add(new List<int>());
                for (int u = 0; u < xlängd; u++)
                {
                    VärldsLista[i].Add(0);
                }
            }
        }
        public void skapavärlden()
        {

            for (int biomes = 0; biomes < xlängd / 10; biomes++)
            {
                if (biomes % 3 == 0)
                {
                    biome = random.Next(1, 8);
                    blocktyp = random.Next(1, 6);
                }
                if (biome == 1) //platt mark
                {

                    biomelängd = random.Next(30, 60);
                    for (int x = 0; x < biomelängd; x++)
                    {
                        VärldsLista[ystart + yplats][xplats] = blocktyp;
                        felsök();
                        if (stop)
                        {
                            break;
                        }
                        xplats++;
                    }

                }
                else if (biome == 2) // linj ökande
                {

                    biomelängd = random.Next(30, 60);
                    for (int x = 0; x < biomelängd; x++)
                    {

                        if (random.Next(0, x) < 15)
                        {
                            if (yplats + ystart > 30)
                                yplats--;
                        }
                        else
                        {
                            biome = 3;
                            break;
                        }
                        VärldsLista[ystart + yplats][xplats] = blocktyp;


                        if (yplats <= (ystart * -1) + 1)
                        {
                            biome = random.Next(4, 6);
                            break;
                        }
                        else if (yplats >= (ybredd - ystart) - 1)
                        {
                            biome = random.Next(2, 4);
                            break;
                        }
                        felsök();
                        if (stop)
                        {
                            break;
                        }
                        xplats++;
                    }
                    yplats--;
                }
                else if (biome == 3) //linj sjunkande
                {

                    biomelängd = random.Next(30, 60);
                    for (int x = 0; x < biomelängd; x++)
                    {
                        if (random.Next(0, x) > 15 || x == 0)
                        {
                            if (yplats + ystart < VärldsLista.Count - 1)
                                yplats++;
                        }
                        VärldsLista[ystart + yplats][xplats] = blocktyp;
                        if (yplats <= (ystart * -1) + 1)
                        {
                            biome = random.Next(4, 6);
                            break;
                        }
                        else if (yplats >= (ybredd - ystart) - 1)
                        {
                            biome = random.Next(2, 4);
                            break;
                        }
                        felsök();
                        if (stop)
                        {
                            break;
                        }
                        xplats++;
                    }
                }

                else if (biome == 4) // exp sjunkande
                {

                    int längd = random.Next(1, 8);
                    for (int i = 0; i < längd; i++)
                    {
                        for (int index = 0; index <= i; index++)
                        {
                            VärldsLista[ystart + yplats][xplats] = blocktyp;
                            if (yplats + ystart < VärldsLista.Count - 1)
                                yplats++;
                        }
                        felsök();
                        if (stop)
                        {
                            break;
                        }
                        xplats++;
                    }
                }
                else if (biome == 5) // exp ökande
                {

                    int längd = random.Next(1, 8);
                    for (int i = 0; i < längd; i++)
                    {
                        for (int index = 0; index <= i; index++)
                        {
                            VärldsLista[ystart + yplats][xplats] = blocktyp;
                            if (yplats + ystart > 30)
                                yplats--;
                            else
                            {
                                biome = 4;
                                stop = true;
                                break;
                            }
                        }
                        felsök();
                        if (stop)
                        {
                            break;
                        }
                        xplats++;
                    }
                }
                else if (biome == 6) // 1/x sjunkande
                {

                    int längd = random.Next(1, 8);
                    for (int i = längd - 1; i >= 0; i--)
                    {
                        for (int index = 0; index <= i; index++)
                        {
                            VärldsLista[ystart + yplats][xplats] = blocktyp;
                            if (yplats + ystart < VärldsLista.Count - 1)
                                yplats++;
                        }
                        felsök();
                        xplats++;
                    }
                }
                else if (biome == 7) // ln ökande
                {

                    int längd = random.Next(1, 8);
                    for (int i = längd - 1; i >= 0; i--)
                    {
                        for (int index = 0; index <= i; index++)
                        {
                            VärldsLista[ystart + yplats][xplats] = blocktyp;
                            if (yplats + ystart > 30)
                                yplats--;
                            else
                            {
                                biome = 6;
                                stop = true;
                                break;
                            }
                        }
                        felsök();
                        if (stop)
                        {
                            break;
                        }
                        xplats++;
                    }
                }
                if (xplats >= xlängd - 1)
                {
                    break;
                }
                if (stop)
                {
                    break;
                }
            }
        }
        public void getvärldnamn(string x)
        {
            WorldName = x;
        }
        public void felsök()
        {
            if (xplats >= xlängd - 1)
            {
                stop = true;
            }
            for (int i = 0; i < 7; i++)
            {
                VärldsLista[ystart + yplats + i][xplats] = blocktyp;
                if (ystart + yplats + i >= VärldsLista.Count - 1)
                {
                    break;
                }
            }
        }
        public void underworld()
        {
            for (int index = 0; index < VärldsLista[1].Count; index++)
            {
                int blocksner = 0;
                yplats = VärldsLista.Count - 1;
                try
                {
                    while (VärldsLista[yplats][index] == 0)
                    {
                        yplats--;
                    }
                }
                catch (Exception)
                {
                    //meh
                }
                yplats++;
                for (int index1 = yplats; index1 < VärldsLista.Count; index1++)
                {
                    if (blocksner < VärldsLista.Count / 7)
                    {
                        VärldsLista[index1][index] = 3;
                    }
                    else
                    {
                        VärldsLista[index1][index] = 2;
                    }
                    blocksner++;
                }
            }
        }
        public void mineraler()
        {
            for (int i = 0; i < VärldsLista.Count; i++)
            {
                xplats = random.Next(0, VärldsLista[1].Count);
                yplats = random.Next(VärldsLista.Count / 3, VärldsLista.Count);

                blocktyp = 8;

                for (int ylängd = 0; ylängd < random.Next(3, 20); ylängd++)
                {
                    for (int xlängd = 0; xlängd < random.Next(3, 15 + ylängd); xlängd++)
                    {
                        try
                        {
                            int index = random.Next(1, 5 + xlängd);
                            if (VärldsLista[yplats + ylängd][xplats + xlängd - index] != 0 &&
                                VärldsLista[yplats + ylängd][xplats + xlängd - index] != 6 &&
                                VärldsLista[yplats + ylängd][xplats + xlängd - index] != 7)
                            {
                                VärldsLista[yplats + ylängd][xplats + xlängd - index] = blocktyp;
                            }
                        }
                        catch (Exception)
                        {

                            break;
                        }
                    }
                }
            }
        }
        public void caves()
        {
            int cavelenght = 0;
            int caveheight = 0;
            for (int index = 0; index < VärldsLista.Count / 2; index++)
            {
                cavelenght = random.Next(VärldsLista.Count / 100, VärldsLista.Count / 5);
                caveheight = random.Next(1, 8);
                caveboty = random.Next(VärldsLista.Count / 3, VärldsLista.Count - 50);
                cavetopy = caveboty - caveheight;     
                xplats = random.Next(0, VärldsLista[1].Count - cavelenght);

                for (int x = 0; x < cavelenght; x++)
                {
                    if (caveboty - cavetopy >= 1)
                    {
                        for (int air = cavetopy; air <= caveboty; air++)
                        {
                            VärldsLista[air][xplats + x] = 0;
                        }
                    }
                    else
                    {
                        break;
                    }
                    if (caveboty + 2 - cavetopy >= 0) //om det är 2 mellanrum kan de röra sig fritt
                    {
                        caveboty = caveboty + random.Next(0, 3) - 1;
                        cavetopy = cavetopy + random.Next(0, 3) - 1;
                    }
                    else if (caveboty + 1 - cavetopy == 0) 
                    {
                        if (random.Next(0,2) == 1) //marken sjunker eller stannar lika
                        {
                            caveboty = caveboty + random.Next(0, 2);
                            cavetopy = cavetopy + random.Next(0, 3) - 1;
                        }
                        else //toppen höjs eller stannar lika
                        {
                            caveboty = caveboty + random.Next(0, 3) - 1;
                            cavetopy = cavetopy + random.Next(0, 2) - 1;
                        }
                    }
                }

            }

        }
        public void skapavatten()
        {
            for (int i = 0; i < VärldsLista.Count / 10; i++)
            {
                stop = false;
                addX = 0;
                vattenslut = 0;
                while (true)
                {
                    xplats = random.Next(1, VärldsLista[1].Count);
                    for (int Y = 0; Y < VärldsLista.Count; Y++)
                    {
                        if (VärldsLista[Y][xplats] != 0)
                        {
                            yplats = Y - 1;
                            break;
                        }
                    }
                    while (true)
                    {
                        stop = false;
                        try
                        {
                            if (VärldsLista[yplats][xplats - 1] != 0)
                            {

                                stop = false;
                                for (int index = 0; index <= 100; index++)
                                {
                                    addX = index;
                                    if (VärldsLista[yplats][xplats + addX] != 0)
                                    {
                                        vattenslut = xplats + addX - 1;
                                        stop = true;
                                        break;
                                    }
                                    if (addX >= 100 || xplats + addX >= VärldsLista[1].Count - 1)
                                    {
                                        stop = true;
                                    }
                                    if (stop)
                                        break;
                                }
                                if (stop)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                if (xplats > 1)
                                {
                                    xplats--;
                                }
                                else
                                {
                                    xplats = 0;
                                    stop = true;
                                }

                            }
                        }
                        catch (Exception)
                        {
                            stop = true;
                        }
                        if (stop)
                        {
                            break;
                        }
                    }
                    if (stop)
                        break;
                }
                if (vattenslut > 0)
                {
                    vattenstart = xplats;
                    vattenlängd = vattenslut - vattenstart;
                    for (int index = 0; index <= vattenlängd; index++)
                    {
                        VärldsLista[yplats][vattenstart + index] = 6;
                        addY = 1;
                        while (VärldsLista[yplats + addY][vattenstart + index] == 0 || VärldsLista[yplats + addY][vattenstart + index] == 6)
                        {
                            VärldsLista[yplats + addY][vattenstart + index] = 7;
                            if (addY + yplats < VärldsLista.Count - 1)
                                addY++;
                            else
                                break;
                        }

                    }
                }
            }
        }
        public void floatingislands()
        {
            int islandlenght = 0;
            int islandheight = 0;
            for (int index = 0; index < VärldsLista.Count / 2; index++)
            {
                islandlenght = random.Next(VärldsLista.Count / 100, VärldsLista.Count / 5);
                islandheight = random.Next(1, 15);
                islandboty = random.Next(VärldsLista.Count/50, VärldsLista.Count/3);
                islandtopy = islandboty - islandheight;
                xplats = random.Next(0, VärldsLista[1].Count - islandlenght);

                for (int x = 0; x < islandlenght; x++)
                {
                    if (islandboty - islandtopy >= 1)
                    {
                        for (int air = islandtopy; air <= islandboty; air++)
                        {
                            VärldsLista[air][xplats + x] = 1;
                        }
                    }
                    else
                    {
                        break;
                    }
                    if (islandboty + 2 - cavetopy >= 0 && islandtopy > 1) //om det är 2 mellanrum kan de röra sig fritt
                    {
                        islandboty = islandboty + random.Next(0, 3) - 1;
                        islandtopy = islandtopy + random.Next(0, 3) - 1;
                    }
                    else if (caveboty + 1 - cavetopy == 0)
                    {
                        if (random.Next(0, 2) == 1) //marken sjunker eller stannar lika
                        {
                            islandboty = islandboty + random.Next(0, 2);
                            islandtopy = islandtopy + random.Next(0, 3) - 1;
                        }
                        else //toppen höjs eller stannar lika
                        {
                            islandboty = islandboty + random.Next(0, 3) - 1;
                            islandtopy = islandtopy + random.Next(0, 2) - 1;
                        }
                    }
                }

            }
        }
        public void sparavärlden()
        {
            int temp = 1;
            Världen.Add(storleken.ToString());
            if (WorldName != "")
            {
                for (int Ycoordinate = 0; Ycoordinate < ybredd; Ycoordinate++)
                {
                    for (int Xcoordinate = 0; Xcoordinate < xlängd; Xcoordinate++)
                    {
                        if (Xcoordinate + 1 < VärldsLista[Ycoordinate].Count() - 1)
                        {
                            if (test[VärldsLista[Ycoordinate][Xcoordinate]].ToString() == test[VärldsLista[Ycoordinate][Xcoordinate + 1]].ToString())
                            {
                                temp++;
                            }
                            else
                            {
                                text += temp.ToString();
                                text += test[VärldsLista[Ycoordinate][Xcoordinate]].ToString();
                                temp = 1;
                            }
                        }
                        else
                        {
                            text += temp.ToString();
                            text += test[VärldsLista[Ycoordinate][Xcoordinate]].ToString();
                            temp = 1;
                        }
                    }
                    text += "x";
                    Världen.Add(text);
                    text = "";
                }
                           
                System.IO.File.WriteAllLines(@"F:\AAAWorlds\Worlds\" + WorldName + ".txt", Världen);
                laddavärld.öppnavärld("F:\\AAAWorlds\\Worlds\\" + WorldName + ".txt");
                Form.ActiveForm.Close();

            }
            else
            {
                MessageBox.Show("Döp Världen");
            }
        }
    }
}
