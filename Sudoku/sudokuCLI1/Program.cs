﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sudokuCLI1
{
    class Feladvany
    {
        public string Kezdo { get; private set; }
        public int Meret { get; private set; }

        public Feladvany(string sor)
        {
            Kezdo = sor;
            Meret = Convert.ToInt32(Math.Sqrt(sor.Length));
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void Kirajzol()
        {
            for (int i = 0; i < Kezdo.Length; i++)
            {
                if (Kezdo[i] == '0')
                {
                    Console.Write(".");
                }
                else
                {
                    Console.Write(Kezdo[i]);
                }
                if (i % Meret == Meret - 1)
                {
                    Console.WriteLine();
                }
            }
        }
    }
    internal class Program
    {
        
        static List<Feladvany> feladvanyLista = new List<Feladvany>();
        static Random rnd= new Random();
        public static void Beolvasas()
        {
            StreamReader sr = new StreamReader("feladvanyok.txt");
            string sor = "";


            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                feladvanyLista.Add(new Feladvany(sor));
            }
            sr.Close();
        }

        static void Main(string[] args)
        {
            Beolvasas();


            Console.WriteLine($"3. feladat: Beolvasva {feladvanyLista.Count} feladvány ");
            Console.Write("4. feladat: Kérem a feladvány méretét [4..9]: ");
            int bekertSzam = 0;

            bekertSzam = int.Parse(Console.ReadLine());
            while (bekertSzam > 9 || bekertSzam < 4)
            {
                Console.Write("4. feladat: Kérem a feladvány méretét [4..9]: ");
                bekertSzam = int.Parse(Console.ReadLine());
            }
            int count = 0;
            List<Feladvany> kivalasztottFeladvanyok = new List<Feladvany>();
            foreach (var item in feladvanyLista)
            {
                if (item.Meret == bekertSzam)
                {
                    kivalasztottFeladvanyok.Add(new Feladvany(item.Kezdo));
                    count++;
                }
            }
            Console.WriteLine($"{bekertSzam}x{bekertSzam} méretű feladványból {count} darab van tárolva");

            int kivalasztottSorszam=rnd.Next(count);
            Console.WriteLine("5. feladat: A kiválasztott feladvány:");
            Console.WriteLine(kivalasztottFeladvanyok[kivalasztottSorszam].Kezdo);
            double nullak = 0;
            double sorLength = Math.Pow(kivalasztottFeladvanyok[kivalasztottSorszam].Meret,2);
            foreach (var mezo in kivalasztottFeladvanyok[kivalasztottSorszam].Kezdo)
            {
                if (mezo!='0')
                {
                    nullak++;
                }
            }
            double arany =nullak / sorLength * 100;
            int IntArany = Convert.ToInt32(arany);
            Console.WriteLine($"6. feladat: A feladvány kitöltöttsége: {IntArany}%");
            Console.WriteLine("7. feladat: A feladvány kirajzolva: ");
            kivalasztottFeladvanyok[kivalasztottSorszam].Kirajzol();
            string fileName = "sudoku" + bekertSzam + ".txt";
            StreamWriter sw = new StreamWriter(fileName);
            foreach (var item in kivalasztottFeladvanyok)
            {
                sw.WriteLine(item.Kezdo);
            }
            sw.Close();
            Console.WriteLine($"8. feladat: {fileName} állomány {count} darab feladvánnyal létrehozva");
            Console.ReadKey();
        }
    }
}
