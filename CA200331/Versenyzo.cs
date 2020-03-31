using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA200331
{
    class Versenyzo
    {
        public string Nev { get; set; }
        public bool Ferfi { get; set; }
        public string Egyesulet { get; set; }
        public int[] Pontok { get; set; }

        public int OsszPont
        {
            get
            {
                int op = 0;
                var p = Pontok.OrderByDescending(x => x).ToArray();
                op += p[6] != 0 ? 10 : 0;
                op += p[7] != 0 ? 10 : 0;
                Array.Resize(ref p, 6);
                op += p.Sum();
                return op;
            }
        }

        public Versenyzo(string s)
        {
            var t = s.Split(';');
            Nev = t[0];
            Ferfi = t[1] == "Felnott ferfi";
            Egyesulet = t[2] == "n.a." ? null : t[2];
            Pontok = new int[8];
            for (int i = 3; i < t.Length; i++)
                Pontok[i - 3] = int.Parse(t[i]);
        }

    }
}
