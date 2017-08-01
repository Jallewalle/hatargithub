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
    public partial class skapavärldV2 : Form
    {
        public skapavärldV2()
        {
            InitializeComponent();
        }
        Random random = new Random(); //random random
        Ladda_värld laddavärld = new Ladda_värld();


        List<List<int>> VärldsLista = new List<List<int>>();
        string[] test = { "a", "b", "c", "d", "e", "f", "g", "h", "i" ,"j"};

        //saknas: Flytande öar, maskhål, fixa vattnet och mer greor, träd, hus

        //0 air, 1 Grass, 2 stone, 3 dirt, 4 sand, 5 Lava, 6 TopWater , 7 BotWater, 8 trä, 9 löv, 10+ odefinerat
        #region listorna
        List<string> Världen = new List<string>();
        List<int> ExpanderandeVattenX = new List<int>();
        List<int> ExpanderandeVattenY = new List<int>();
        List<int> ExpanderandeVattenXtemp = new List<int>();
        List<int> ExpanderandeVattenYtemp = new List<int>();
        List<int> möjligaVattenX = new List<int>();
        List<int> möjligaVattenY = new List<int>();
        List<int> möjligaVattenLängd = new List<int>();
        #endregion
        #region variabler
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
        int slump;
        int underblock;

        #endregion
        public void getStorlek(int x)
        {
            progressBar1.Value = 0;
            label1.Text = "Hämtar storlek";
            label1.Update();
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
                ybredd = 200;
                ystart = 50;
            }
            else if (storleken == 4)
            {
                xlängd = 20000;
                ybredd = 6000;
                ystart = 2000;
            }
            for (int i = 0; i < ybredd; i++)
            {
                VärldsLista.Add(new List<int>());
                for (int u = 0; u < xlängd; u++)
                {
                    VärldsLista[i].Add(0);
                }
                if (i % (ybredd / 100) == 0)
                {
                    progressBar1.PerformStep();
                }

            }

        }
        public void skapavärlden()
        {
            progressBar1.Value = 0;
            int progress = -1;
            label1.Text = "Skapar terräng";
            label1.Update();
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
                        if (random.Next(0, x) > 15 || x == 0)
                        {
                            if (yplats + ystart < VärldsLista.Count - 1)
                                yplats--;
                        }
                        VärldsLista[ystart + yplats][xplats] = blocktyp;
                        if (yplats <= (ystart * -1) + 1)
                        {
                            biome = random.Next(4, 6);
                            break;
                        }
                        else if (yplats >= (ybredd - ystart) - 1)
                        {
                            biome = random.Next(1, 4);
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
                            biome = random.Next(1, 4);
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
                        
                        underblock = blocktyp;
                        
                        for (int index = 0; index <= i; index++)
                        {
                            VärldsLista[ystart + yplats][xplats] = underblock;
                            if (blocktyp == 1)
                            {
                                underblock = 3;
                            }

                            if (yplats + ystart < VärldsLista.Count - 1)
                                yplats++;
                        }
                        if (stop)
                        {
                            break;
                        }
                        if (blocktyp != 1)
                        {
                            felsök();
                        }
                        if (xplats >= xlängd - 1)
                        {
                            stop = true;
                        }

                        xplats++;
                    }
                }
                else if (biome == 5) // exp ökande
                {

                    int längd = random.Next(1, 8);
                    for (int i = 0; i < längd; i++)
                    {
                        underblock = blocktyp;
                        for (int index = 0; index <= i; index++)
                        {
                            VärldsLista[ystart + yplats][xplats] = underblock;
                            if (blocktyp == 1)
                            {
                                underblock = 3;
                            }
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
                        underblock = blocktyp;
                        for (int index = 0; index <= i; index++)
                        {
                            VärldsLista[ystart + yplats][xplats] = underblock;
                            if (blocktyp == 1)
                            {
                                underblock = 3;
                            }
                            if (yplats + ystart < VärldsLista.Count - 1)
                                yplats++;
                        }
                        if (blocktyp != 1)
                        {
                            felsök();
                        }
                        if (xplats >= xlängd - 1)
                        {
                            stop = true;
                        }

                        xplats++;
                    }
                }
                else if (biome == 7) // ln(x) ökande
                {

                    int längd = random.Next(1, 8);
                    for (int i = längd - 1; i >= 0; i--)
                    {
                        underblock = blocktyp;
                        for (int index = 0; index <= i; index++)
                        {
                            VärldsLista[ystart + yplats][xplats] = underblock;
                            if (blocktyp == 1)
                            {
                                underblock = 3;
                            }
                            if (ystart + yplats > 30)
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
                if (xplats / (VärldsLista[1].Count/100) > progress)
                {
                    progressBar1.PerformStep();
                    progress += 1;
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
            progressBar1.Value = 0;
            label1.Text = "Hämtar namn";
            label1.Update();
            WorldName = x;
        }
        public void felsök()
        {
            
            if (xplats >= xlängd - 1)
            {
                stop = true;
            }
            
            
            underblock = blocktyp;
            
            for (int i = 0; i < 17; i++)
            {
                VärldsLista[ystart + yplats + i][xplats] = underblock;
                if (blocktyp == 1)
                {
                    underblock = 3;
                }
                if (ystart + yplats + i >= VärldsLista.Count - 1)
                {
                    break;
                }
                
            }
        }
        public void underworld()
        {
            label1.Text = "Fyller marken";
            label1.Update();
            progressBar1.Value = 0;
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
                if (index % (VärldsLista[1].Count/100) == 0)
                {
                    progressBar1.PerformStep();
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
                int xlength = random.Next(9, 15);
                int ylength = random.Next(9, 15);
                for (int ylängd = 0; ylängd < xlength; ylängd++)
                {
                    for (int xlängd = 0; xlängd < ylength; xlängd++)
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
            label1.Text = "Placerar grottor";
            label1.Update();
            progressBar1.Value = 0;
            for (int index = 0; index < VärldsLista.Count / 2; index++)
            {
                cavelenght = random.Next(VärldsLista.Count / 100, VärldsLista.Count / 5);
                caveheight = random.Next(1, 8);
                caveboty = random.Next(VärldsLista.Count / 3, VärldsLista.Count - 50);
                cavetopy = caveboty - caveheight;
                xplats = random.Next(0, VärldsLista[1].Count - cavelenght);

                for (int x = 0; x < cavelenght; x++)
                {
                    if (caveboty - cavetopy >= 1 && caveboty < ybredd)
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
                    if ((caveboty - cavetopy) * 2 > cavelenght - x) // när den närmar sig sitt slut börjar den minska
                    {
                        caveboty = caveboty - random.Next(0, 2);
                        cavetopy = cavetopy + random.Next(0, 2);
                    }
                    else if (caveboty + 2 - cavetopy >= 0) //om det är 2 mellanrum kan de röra sig fritt
                    {
                        caveboty = caveboty + random.Next(0, 3) - 1;
                        cavetopy = cavetopy + random.Next(0, 3) - 1;
                    }
                    else if (caveboty + 1 - cavetopy == 0)
                    {
                        if (random.Next(0, 2) == 1) //marken sjunker eller stannar lika
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
                if (index % ((VärldsLista.Count / 2)/100) == 0)
                {
                    progressBar1.PerformStep();
                }

            }

        }
        public void mineralerV2()
        {
            label1.Text = "Placerar mineraler";
            label1.Update();
            progressBar1.Value = 0;
            for (int i = 0; i < VärldsLista.Count; i++)
            {
                xplats = random.Next(0, VärldsLista[1].Count-15);
                yplats = random.Next(VärldsLista.Count / 3, VärldsLista.Count-15);

                blocktyp = 8;
                int xlength = random.Next(5, 15);
                int ylength = random.Next(5, 15);
                for (int ylängd = 0; ylängd < xlength; ylängd++)
                {
                    for (int xlängd = 0; xlängd < ylength; xlängd++)
                    {
                        try
                        {
                            if (VärldsLista[yplats + ylängd][xplats + xlängd] != 0 &&
                                VärldsLista[yplats + ylängd][xplats + xlängd] != 6 &&
                                VärldsLista[yplats + ylängd][xplats + xlängd] != 7 &&
                                random.Next(2) == 0)
                            {
                                VärldsLista[yplats + ylängd][xplats + xlängd] = blocktyp;
                            }
                        }
                        catch (Exception)
                        {

                            // utanför mappen mineralerV2
                        }
                    }
                }
                if (i % (VärldsLista.Count/100) == 0)
                {
                    progressBar1.PerformStep();
                }
            }
        }
        public void skapavatten()
        {
            label1.Text = "Placerar vatten";
            label1.Update();
            progressBar1.Value = 0;

            for (int i = 0; i < VärldsLista.Count / 5; i++)
            {
                stop = false;
                addX = 0;
                vattenslut = 0;
                möjligaVattenX.Clear();
                möjligaVattenY.Clear();
                möjligaVattenLängd.Clear();
                xplats = random.Next(1, VärldsLista[1].Count - 1);
                for (int Y = 0; Y < VärldsLista.Count - 1; Y++)
                {
                    if (VärldsLista[Y + 1][xplats] != 0 && VärldsLista[Y][xplats - 1] != 0 && VärldsLista[Y][xplats] == 0)
                    {
                        try
                        {
                            for (int x = 0; x < 100; x++)
                            {
                                if (VärldsLista[Y][xplats + x] != 0)
                                {
                                    möjligaVattenX.Add(xplats);                 //lägger till alla tillåtna platser
                                    möjligaVattenY.Add(Y);
                                    möjligaVattenLängd.Add(x);
                                    break;
                                }
                            }
                        }
                        catch (Exception)
                        {


                        }

                    }
                }

                //Wallps försök1

                //while (true)
                //{
                //    xplats = random.Next(1, VärldsLista[1].Count);
                //    for (int Y = 0; Y < VärldsLista.Count; Y++)
                //    {
                //        if (VärldsLista[Y][xplats] != 0)
                //        {
                //            yplats = Y - 1;
                //            break;
                //        }
                //    }
                //    while (true)
                //    {
                //        stop = false;
                //        try
                //        {
                //            if (VärldsLista[yplats][xplats - 1] != 0)
                //            {

                //                stop = false;
                //                for (int index = 0; index <= 100; index++)
                //                {
                //                    addX = index;
                //                    if (VärldsLista[yplats][xplats + addX] != 0)
                //                    {
                //                        vattenslut = xplats + addX - 1;
                //                        stop = true;
                //                        break;
                //                    }
                //                    if (addX >= 100 || xplats + addX >= VärldsLista[1].Count - 1)
                //                    {
                //                        stop = true;
                //                    }
                //                    if (stop)
                //                        break;
                //                }
                //                if (stop)
                //                {
                //                    break;
                //                }
                //            }
                //            else
                //            {
                //                if (xplats > 1)
                //                {
                //                    xplats--;
                //                }
                //                else
                //                {
                //                    xplats = 0;
                //                    stop = true;
                //                }

                //            }
                //        }
                //        catch (Exception)
                //        {
                //            stop = true;
                //        }
                //        if (stop)
                //        {
                //            break;
                //        }
                //    }
                //    if (stop)
                //        break;
                //}
                if (möjligaVattenY.Count != 0)
                {
                    slump = random.Next(möjligaVattenY.Count);
                    yplats = möjligaVattenY[slump];
                    vattenstart = xplats;
                    vattenlängd = möjligaVattenLängd[slump];
                        ExpanderandeVattenX.Clear();                    // expanderar vattnet ner, vänster och höger från  y-1 från startpunkten 
                        ExpanderandeVattenY.Clear();
                        ExpanderandeVattenX.Add(vattenstart);
                        ExpanderandeVattenY.Add(yplats);
                        try
                        {
                            while ((ExpanderandeVattenX[0] + ExpanderandeVattenY[0]) != 0)
                            {
                                for (int i2 = 0; i2 < ExpanderandeVattenX.Count(); i2++)
                                {
                                    if (VärldsLista[ExpanderandeVattenY[i2]][ExpanderandeVattenX[i2]] == 0 ||
                                        VärldsLista[ExpanderandeVattenY[i2]][ExpanderandeVattenX[i2]] == 6)
                                    {
                                        try
                                        {
                                            if (VärldsLista[(ExpanderandeVattenY[i2]-1)][ExpanderandeVattenX[i2]] == 0
                                                )
                                            {
                                                VärldsLista[ExpanderandeVattenY[i2]][ExpanderandeVattenX[i2]] = 6;
                                            }
                                            else
                                            {
                                                VärldsLista[ExpanderandeVattenY[i2]][ExpanderandeVattenX[i2]] = 7;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            //test
                                            //testar om han inte är utanför mappen och föröker expandera. temporär lösning.
                                        }
                                        try
                                        {
                                            if (VärldsLista[(ExpanderandeVattenY[i2] + 1)][ExpanderandeVattenX[i2]] == 0 || //kollar neranför
                                                VärldsLista[(ExpanderandeVattenY[i2] + 1)][ExpanderandeVattenX[i2]] == 6)
                                            {
                                                ExpanderandeVattenXtemp.Add(ExpanderandeVattenX[i2]);           // lägger till ytor som ska täckas med vatten i en temporär lista som ska fyllas i nästa tick(när den lopar om while lopen)
                                                ExpanderandeVattenYtemp.Add(ExpanderandeVattenY[i2] + 1);
                                            }
                                        }
                                        catch (Exception)
                                        {

                                            // testar om han inte är utanför mappen och föröker expandera. temporär lösning.
                                        }
                                        try
                                        {
                                            if (VärldsLista[ExpanderandeVattenY[i2]][ExpanderandeVattenX[i2] - 1]==0) //kollar vänster
                                            {
                                                ExpanderandeVattenXtemp.Add(ExpanderandeVattenX[i2] - 1);
                                                ExpanderandeVattenYtemp.Add(ExpanderandeVattenY[i2]);

                                            }
                                        }
                                        catch (Exception)
                                        {

                                            //testar om han inte är utanför mappen och föröker expandera. temporär lösning.
                                        }
                                        try
                                        {
                                            if (VärldsLista[ExpanderandeVattenY[i2]][ExpanderandeVattenX[i2] + 1] == 0) //kollar höger
                                            {
                                                ExpanderandeVattenXtemp.Add(ExpanderandeVattenX[i2] + 1);
                                                ExpanderandeVattenYtemp.Add(ExpanderandeVattenY[i2]);
                                            }
                                        }
                                        catch (Exception)
                                        {

                                            //testar om han inte är utanför mappen och föröker expandera. temporär lösning.
                                        }

                                    }
                                }
                                ExpanderandeVattenX = ExpanderandeVattenXtemp; //listan blir updaterad från temp
                                ExpanderandeVattenY = ExpanderandeVattenYtemp;
                                ExpanderandeVattenXtemp.Clear();        //tömmer temporära listan efter varje  tick
                                ExpanderandeVattenYtemp.Clear();
                                ExpanderandeVattenX.Add(0);             //lägger till 0,0 på slutet för att se om expanderavatten är tom
                                ExpanderandeVattenY.Add(0);  // test
                            }

                        }
                        catch (Exception)
                        {
                            //
                        }
                        // Wallps försök 1
                        //
                        //addY = 1;
                        //while (VärldsLista[yplats + addY][vattenstart + index] == 0 || VärldsLista[yplats + addY][vattenstart + index] == 6)
                        //{
                        //    VärldsLista[yplats + addY][vattenstart + index] = 7;
                        //    if (addY + yplats < VärldsLista.Count - 1)
                        //        addY++;
                        //    else
                        //        break;
                        //}p


                }
                if (i % (VärldsLista.Count / 10)/100 == 0)
                {
                    progressBar1.PerformStep();
                }
            }
        }
        public void floatingislands()
        {
            label1.Text = "skapar öar";
            label1.Update();
            progressBar1.Value = 0;
            int islandlenght = 0;
            int islandheight = 0;
            for (int index = 0; index < VärldsLista.Count / 500; index++)
            {
                islandlenght = random.Next(VärldsLista.Count / 100, VärldsLista.Count / 5);
                islandheight = random.Next(10, 30);
                islandboty = random.Next(VärldsLista.Count / 40, VärldsLista.Count / 4);
                islandtopy = islandboty - islandheight;
                xplats = random.Next(0, VärldsLista[1].Count - islandlenght);

                for (int x = 0; x < islandlenght; x++)
                {
                    if (islandboty - islandtopy >= 1)
                    {
                        for (int air = islandtopy; air <= islandboty; air++)
                        {
                            if (air == islandtopy)
                            {
                                VärldsLista[air][xplats + x] = 1;
                            }
                            else
                            {
                                VärldsLista[air][xplats + x] = 3;
                            }
                            
                        }
                    }
                    else
                    {
                        break;
                    }
                    if ((islandboty - islandtopy) * 2 > islandlenght - x) // när den närmar sig sitt slut börjar den minska
                    {
                        islandboty = islandboty - random.Next(0, 2);
                        islandtopy = islandtopy + random.Next(0, 2);
                    }
                    else if (islandboty + 2 - islandtopy >= 0 && islandtopy >= 10) //om det är 2 mellanrum kan de röra sig fritt
                    {
                        islandboty = islandboty + random.Next(0, 3) - 1;
                        islandtopy = islandtopy + random.Next(0, 3) - 1;
                    }
                    else if (islandboty + 1 - islandtopy == 0)
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
                if (VärldsLista.Count == 3000)
                {
                    progressBar1.Value += 15;
                    progressBar1.PerformStep();
                }
                else
                {
                    progressBar1.Value = 99;
                    progressBar1.PerformStep();
                }

            }

        }
        public void sparavärlden()
        {

            int temp = 1;
            label1.Text = "Sparar världen";
            label1.Update();
            progressBar1.Value = 0;
            Världen.Add(storleken.ToString());

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
                if (Ycoordinate % (ybredd / 100) == 0)
                {
                    progressBar1.PerformStep();
                }

            }

            if (WorldName == "")
            {
                WorldName = random.Next(1000, 10000).ToString();
            }
            System.IO.File.WriteAllLines(@"F:\AAAWorlds\Worlds\" + WorldName + ".txt", Världen);
            laddavärld.öppnavärld("F:\\AAAWorlds\\Worlds\\" + WorldName + ".txt");
            MessageBox.Show("Din värld har blivit sparad med namnet: " + WorldName);

        }
        public void träd()
        {
            for (int i = 0; i < VärldsLista.Count()/10; i++)
            {
                xplats = random.Next(5, VärldsLista[1].Count()-5);
                for (int y = 10; y < VärldsLista.Count()-20; y++)
                {
                    if (VärldsLista[y][xplats] == 1 && VärldsLista[y-1][xplats]== 0)
                    {
                        slump = random.Next(4,7);
                        for (int i2 = 0; i2 < slump ; i2++)
                        {
                            VärldsLista[y-i2 -1][xplats] = 8;
                        }// gör ett träd!
                        if (random.Next(1,2) == 1)
                        {
                            VärldsLista[y - slump - 3][xplats] = 9;
                            VärldsLista[y - slump - 2][xplats-1] = 9;
                            VärldsLista[y - slump - 2][xplats] = 9;
                            VärldsLista[y - slump - 2][xplats+1] = 9;
                            VärldsLista[y - slump - 1][xplats - 2] = 9;
                            VärldsLista[y - slump - 1][xplats - 1] = 9;
                            VärldsLista[y - slump - 1][xplats] = 9;
                            VärldsLista[y - slump - 1][xplats + 1] = 9;
                            VärldsLista[y - slump - 1][xplats + 2] = 9;
                            VärldsLista[y - slump][xplats - 3] = 9;
                            VärldsLista[y - slump][xplats - 2] = 9;
                            VärldsLista[y - slump][xplats - 1] = 9;
                            VärldsLista[y - slump][xplats + 1] = 9;
                            VärldsLista[y - slump][xplats + 2] = 9;
                            VärldsLista[y - slump][xplats + 3] = 9;
                            VärldsLista[y - slump + 1][xplats - 2] = 9;
                            VärldsLista[y - slump + 1][xplats - 1] = 9;
                            VärldsLista[y - slump + 1][xplats + 1] = 9;
                            VärldsLista[y - slump + 1][xplats + 2] = 9;
                            VärldsLista[y - slump + 2][xplats - 1] = 9;
                            VärldsLista[y - slump + 2][xplats + 1] = 9;
                        }
                        else
                        {
                            VärldsLista[y - slump - 1][xplats] = 9;
                            VärldsLista[y - slump - 2][xplats] = 9;
                            VärldsLista[y - slump - 1][xplats - 1] = 9;
                            VärldsLista[y - slump - 1][xplats + 1] = 9;
                            VärldsLista[y - slump][xplats - 2] = 9;
                            VärldsLista[y - slump][xplats - 1] = 9;
                            VärldsLista[y - slump][xplats + 1] = 9;
                            VärldsLista[y - slump][xplats + 2] = 9;
                            VärldsLista[y - slump + 1][xplats - 1] = 9;
                            VärldsLista[y - slump + 1][xplats + 1] = 9;
                        }
                        
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
