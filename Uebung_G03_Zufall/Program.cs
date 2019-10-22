﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Schreiben Sie bitte ein C#-Programm, in dem ...
 - in einer for-Schleife 3 Millionen Zahlen zwischen (beiderseits einschließlich) 1 und 3 ausgelost werden
   + pro Durchlauf wird gezählt, ob eine 1, 2, oder 3 gelost wurde
 - nach der Schleife wird der prozentuale Anteil der 1-en, 2-en und 3-en ausgegeben

 Hinweise:
 a) Auch if-Klauseln und switch-case-Anweisungen können "1 zu 1" aus ANSI C übernommen werden
 b) Ebenfalls wie in ANSI C können wir mittels (double)Integer1/Integer2 das Divisionsergebnis zweier Integerzahl als double ausgeben
 c) Ein double x kann für ein Integer i mittels Math.Round(x,i) auf i Nachkommastellen gerundet werden
 */
namespace Uebung_G03_Zufall
{
    class Program
    {
        static void Main(string[] args)
        {
            Random zufallsGenerator = new Random();
            int randNr;

            int eins = 0;
            int zwei = 0;
            int drei = 0;
            int maximum = 3000000;
            
           
            for(int i=0;i<3000000;i++)
            {
                randNr = zufallsGenerator.Next(1, 4);
                if (randNr==1)
                {
                    eins++;
                }
                else if (randNr==2)
                {
                    zwei++;
                }
                else if (randNr==3)
                {
                    drei++;
                }
            }
           
            //int pro2 = (res2 / 3000000) * 100;
            //int pro3 = (res3 / 3000000) * 100;

            Console.WriteLine("1: " + ((double)eins / (double)maximum) * 100 +"%" );
            Console.WriteLine("2: " + ((double)zwei / (double)maximum) * 100 + "%");
            Console.WriteLine("3: " + ((double)drei / (double)maximum) * 100 + "%");
            Console.ReadKey();
        }
    }
}