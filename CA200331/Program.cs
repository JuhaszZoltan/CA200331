using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA200331
{
    class Program
    {
        static List<Versenyzo> versenyzok;
        static void Main()
        {
            F02();
            F03();
            F04();
            F06();
            F07();
            F08();
            Console.ReadKey();
        }

        private static void F08()
        {
            versenyzok
                .Where(v => !(v.Egyesulet is null))
                .GroupBy(v => v.Egyesulet)
                .Where(y => y.Count() > 2)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Key} - {x.Count()}"));
        }

        private static void F07()
        {
            var sw = new StreamWriter(@"..\..\Res\osszpontff.txt");
            versenyzok
                .Where(v => v.Ferfi)
                .ToList()
                .ForEach(v => sw.WriteLine($"{v.Nev};{v.OsszPont}"));
            sw.Close();
        }

        private static void F06()
        {
            var n = versenyzok
                .Where(v => !v.Ferfi)
                .OrderByDescending(v => v.OsszPont)
                .First();

            Console.WriteLine($"N: {n.Nev} - P: {n.OsszPont} - E: {n.Egyesulet}");
        }

        private static void F04()
        {
            var c = versenyzok.Count(v => !v.Ferfi);

            Console.WriteLine("F4: {0:0.00}%", c / (float)versenyzok.Count * 100);
        }

        private static void F03()
        {
            Console.WriteLine($"F3: {versenyzok.Count}");
        }

        private static void F02()
        {
            versenyzok = new List<Versenyzo>();
            var sr = new StreamReader(@"..\..\Res\fob2016.txt", Encoding.UTF8);
            while (!sr.EndOfStream)
                versenyzok.Add(new Versenyzo(sr.ReadLine()));
            sr.Close();
        }
    }
}
