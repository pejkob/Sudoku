using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sudokuCLI1
{
    internal class Program
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


        static void Main(string[] args)
        {
            List<Feladvany> feladvanyLista = new List<Feladvany>();
            StreamReader sr = new StreamReader("feladvanyok.txt");
            string sor = "";
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                feladvanyLista.Add(new Feladvany(sor));
            }

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
            foreach (var item in feladvanyLista)
            {
                if (item.Meret==bekertSzam)
                {
                    count++;
                }
            }
            Console.WriteLine($"{bekertSzam}x{bekertSzam} méretű feladványból {count} darab van tárolva");
            Console.ReadKey();
        }
    }
}
