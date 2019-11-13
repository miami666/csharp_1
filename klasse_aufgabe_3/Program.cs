﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
    Führen Sie bitte die folgende Enumeration ein:
        Sieger (mit den Konstanten ist_A_Mann und ist_B_Mann)
    Führen Sie bitte die beiden folgenden Klassen ein:
        A_Mann
            String: Name
            Integer: x, y
            Bool: ImSpiel
            Methoden:
                a) Name: Jubeln
                   Übergabewerte: Keine
                   Funktion: Konsolenausgabe: "Ich liebe es, wenn ein Plan funktioniert!"
                   Rückgabewert: Keiner
                b) Name: Heulen
                   Übergabewerte: Keine
                   Funktion: Konsolenausgabe: "Ich hasse es, wenn ein Plan scheitert!"
                   Rückgabewert: Keiner 
                c) Name: Grüßen
                   Übergabewerte: eine Variable a vom Typ A-Mann
                   Funktion: Konsolenausgabe: Hallo + Name von a +"!"
                   Rückgabewert: Keiner   
        B_Mann
            String: Name
            Integer: x, y
            Bool: ImSpiel
            Methoden:
                a) Name: Jubeln
                   Übergabewerte: Keine
                   Funktion: Konsolenausgabe: "Wir B-Männer sind Siegertypen!"
                   Rückgabewert: Keiner
                b) Name: Heulen
                   Übergabewerte: Keine
                   Funktion: Konsolenausgabe: "Pah, der A-Mann hatte nur Glück ..."
                   Rückgabewert: Keiner 
                c) Name: Grüßen
                   Übergabewerte: eine Variable b vom Typ B-Mann
                   Funktion: Konsolenausgabe: Hallo + Name von b +"!"
                   Rückgabewert: Keiner 
   Main-Methode:
        - Führen Sie bitte ein Spielfeld ein (wählen Sie selbst Breite und Höhe)
        - Führen Sie 5 Spieler vom Typ A_Mann auf der linken Seite des Spielfelds mit zufälligen Positionen ein
          (Kein Spieler darf auf ein bereits bestzes Feld)
        - Führen Sie 5 Spieler vom Typ B_Mann auf der rechten Seite des Spielfelds mit zufälligen Positionen ein
          (Kein Spieler darf auf ein bereits bestzes Feld) 
        - Jeder A_Mann wird in einer Liste namens 'aListe' abgespeichert
        - Jeder B_Mann wird in einer Liste namens 'bListe' abgespeichert 
        - Die A_Männer werden der Reihe nach "Achim", "Albert", "Anton", "August" oder "Axel" genannt
        - Die B_Männer werden der Reihe nach "Bert", "Benjamin", "Björn", "Bodo" oder "Bruno" genannt
        - Jeder Mann speichert unter x und y die ausgeloste Position und den Wert 'true' bei ImSpiel
        Es startet eine Schleife, pro Durchlauf ...
         - wandern alle Männer auf ein zufälliges Nachbarfeld (falls nicht dabei das Spielfeld verlassen werden würde) 
         - grüßen sich die beiden A_Männer, falls sie auf einem identischen Feld landen
         - grüßen sich die beiden B_Männer, falls sie auf einem identischen Feld landen
         - kämpfen A_Mann gegen B_Mann, falls sie auf einem identischen Feld landen
           + der Sieger wird ausgelost
           + der Sieger jubelt
           + der Verlierer heult
           + beim Verlierer wird ImSpiel auf 'false' gesetzt
           + der verlierer wird aus seiner Liste entfernt
        ... die Schleife endet, falls nur noch Spieler von einem Team übrig geblieben sind 
*/
namespace klasse_aufgabe_3
{
    enum Sieger { ist_A_Mann, ist_B_Mann };
    class A_Mann
    {
        Random r = new Random(Guid.NewGuid().GetHashCode());
        public string name;
        public int x, y;
        public bool ImSpiel;
        //public override string ToString()
        //{
        //    return "Name: " + name + "  x: " + x+" y: "+y;
        //}
        public void Jubeln()
        {
            Console.WriteLine("Ich liebe es wenn ein Plan funktioniert");
        }
        public void Heulen()
        {
            Console.WriteLine("Ich hasse es wenn ein Plan scheitert");
        }
        public void Gruessen(A_Mann a)
        {
            Console.WriteLine("Hallo  " + a.name);
        }
        public void zufallsAktion(A_Mann a)
        {
            int actions = r.Next(0, 4);
            switch (actions)
            {
                case 0:
                    if (a.x > 0)
                    {
                        a.x = x - 1;//nach oben (rows)
                    }
                    break;
                case 1:
                    if (a.x < 10)
                    {
                        a.x = x + 1; //nachunten (rows)
                    }
                    break;
                case 2:
                    if (a.y > 0)
                    {
                        a.y = y - 1; //nach links
                    }
                    break;
                case 3:
                    if (a.y < 10)
                    {
                        a.y = y + 1;
                    }
                    break;
            }
        }
    }
    class B_Mann
    {
        Random r = new Random(Guid.NewGuid().GetHashCode());
        public string name;
        public int x, y;
        public bool ImSpiel;
        //public override string ToString()
        //{
        //    return "Name: " + name + "  x: " + x + " y: " + y;
        //}
        public void Jubeln()
        {
            Console.WriteLine("Wir B-Männer sind Siegertypen");
        }
        public void Heulen()
        {
            Console.WriteLine("Pah, der A-Mann hatte nur Glück");
        }
        public void Gruessen(B_Mann b)
        {
            Console.WriteLine("Hallo  " + b.name);
        }
        public int GetX(B_Mann b)
        {
            return b.x;
        }
        public void zufallsAktion(B_Mann b)
        {
            int actions = r.Next(0, 4);
            switch (actions)
            {
                case 0:
                    if (b.x > 0)
                    {
                        b.x = x - 1;//nach oben (rows)
                    }
                    break;
                case 1:
                    if (b.x < 10)
                    {
                        b.x = x + 1; //nachunten (rows)
                    }
                    break;
                case 2:
                    if (b.y > 0)
                    {
                        b.y = y - 1; //nach links
                    }
                    break;
                case 3:
                    if (b.y < 10)
                    {
                        b.y = y + 1;
                    }
                    break;
            }
        }
    }
    class Program
    {
        static void PrintGF(List<A_Mann> a, List<B_Mann> b)
        {
            //gamefield
            int[,] gf = new int[10, 10];
            foreach (A_Mann al in a)
            {
                //Console.WriteLine(al);
                if (al.ImSpiel) { gf[al.x, al.y] = 9; }
            }
            foreach (B_Mann bl in b)
            {
                //Console.WriteLine(bl);
                if (bl.ImSpiel) { gf[bl.x, bl.y] = 8; }
            }

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (gf[y, x] == 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" A");
                        Console.ResetColor();
                    }
                    else if (gf[y, x] == 8)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" B");

                        Console.ResetColor();
                    }
                    else { Console.Write(" 0"); }
                }
                Console.WriteLine(); //next line
            }
            Console.WriteLine("\n\n");
        }

        Random r = new Random(Guid.NewGuid().GetHashCode());
        static void Main(string[] args)
        {
            int[,] spielfeld =
            {
                {1,1,1,1,1,1,1,1,1,1 },
                {1,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,1 },
                {1,0,0,0,0,0,0,0,0,1 },
                {1,1,1,1,1,1,1,1,1,1 }
            };
            for (int y = 0; y < spielfeld.GetLength(1); y++)
            {
                for (int x = 0; x < spielfeld.GetLength(0); x++)
                {
                    if (spielfeld[y, x] == 0)
                    {
                        Console.Write(" ");
                    }
                    else if (spielfeld[y, x] == 1)
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            var nums = Enumerable.Range(0, 10).ToArray();
            var numsb = Enumerable.Range(0, 10).ToArray();
            // Shuffle the array
            for (int i = 0; i < 5; ++i)
            {
                int randomIndex = rnd.Next(nums.Length);
                int temp = nums[randomIndex];
                nums[randomIndex] = nums[i];
                nums[i] = temp;
            }
            // Now your array is randomized and you can simply print them in order
            for (int i = 0; i < 5; ++i)
                Console.WriteLine(nums[i]);
            var a1 = new A_Mann() { name = "Achim", x = nums[0], y = rnd.Next(0, spielfeld.GetLength(1)), ImSpiel = true };
            var a2 = new A_Mann() { name = "Albert", x = nums[1], y = rnd.Next(0, spielfeld.GetLength(1)), ImSpiel = true };
            var a3 = new A_Mann() { name = "Alex", x = nums[2], y = rnd.Next(0, spielfeld.GetLength(1)), ImSpiel = true };
            var a4 = new A_Mann() { name = "Anton", x = nums[3], y = rnd.Next(0, spielfeld.GetLength(1)), ImSpiel = true };
            var a5 = new A_Mann() { name = "August", x = nums[4], y = rnd.Next(0, spielfeld.GetLength(1)), ImSpiel = true };
            List<A_Mann> aliste = new List<A_Mann>();
            aliste.Add(a1);
            aliste.Add(a2);
            aliste.Add(a3);
            aliste.Add(a4);
            aliste.Add(a5);
            // Shuffle the array
            for (int i = 0; i < 5; ++i)
            {
                int randomIndex = rnd.Next(nums.Length);
                int temp = numsb[randomIndex];
                numsb[randomIndex] = nums[i];
                numsb[i] = temp;
            }
            // Now your array is randomized and you can simply print them in order
            for (int i = 0; i < 5; ++i)
                Console.WriteLine(numsb[i]);
            var b1 = new B_Mann() { name = "Bert", x = numsb[0], y = rnd.Next(0, spielfeld.GetLength(1)), ImSpiel = true };
            var b2 = new B_Mann() { name = "Benjamin", x = numsb[1], y = rnd.Next(0, spielfeld.GetLength(1)), ImSpiel = true };
            var b3 = new B_Mann() { name = "Bjoern", x = numsb[2], y = rnd.Next(0, spielfeld.GetLength(1)), ImSpiel = true };
            var b4 = new B_Mann() { name = "Bodo", x = numsb[3], y = rnd.Next(0, spielfeld.GetLength(1)), ImSpiel = true };
            var b5 = new B_Mann() { name = "Bruno", x = numsb[4], y = rnd.Next(0, spielfeld.GetLength(1)), ImSpiel = true };
            List<B_Mann> bliste = new List<B_Mann>();
            bliste.Add(b1);
            bliste.Add(b2);
            bliste.Add(b3);
            bliste.Add(b4);
            bliste.Add(b5);
            do
            {
                foreach (A_Mann al in aliste)
                {
                    al.zufallsAktion(al);
                }
                foreach (B_Mann bl in bliste)
                {
                    bl.zufallsAktion(bl);
                }
                foreach (A_Mann al in aliste.ToList())
                {
                    foreach (B_Mann bl in bliste.ToList())
                    {
                        if (bl.x == al.x && bl.y == al.y)
                        {
                            Console.WriteLine("B-mann " + bl.x + bl.y + "A_mann " + al.x + al.y);
                            int gewinner = rnd.Next(2);
                            switch (gewinner)
                            {
                                case (int)Sieger.ist_A_Mann:
                                    al.Jubeln();
                                    bl.Heulen();
                                    bl.ImSpiel = false;
                                    bliste.Remove(bl);
                                    Console.WriteLine("A: " + aliste.Count());
                                    Console.WriteLine("B: " + bliste.Count());
                                    break;
                                case (int)Sieger.ist_B_Mann:
                                    bl.Jubeln();
                                    al.Heulen();
                                    al.ImSpiel = false;
                                    aliste.Remove(al);
                                    Console.WriteLine("A: " + aliste.Count());
                                    Console.WriteLine("B: " + bliste.Count());
                                    break;
                            }
                        }
                    }
                }

            } while (aliste.Count() > 0 && bliste.Count() > 0);
            Console.ReadKey();
        }
    }
}
