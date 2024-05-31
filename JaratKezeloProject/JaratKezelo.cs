using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaratKezeloProject
{
    public class JaratKezelo
    {
        private class Jarat
        {
            public string JaratSzam { get; set; }
            public string RepterHonnan { get; set; }
            public string RepterHova { get; set; }
            public DateTime Indulas { get; set; }
            public int Keses { get; set; }

            public Jarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
            {
                JaratSzam = jaratSzam;
                RepterHonnan = repterHonnan;
                RepterHova = repterHova;
                Indulas = indulas;
                Keses = 0;
            }
        }

        private List<Jarat> jaratok = new List<Jarat>();

        public void ujJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            if (jaratok.Any(j => j.JaratSzam == jaratSzam))
                throw new ArgumentException("A járatszámnak egyedinek kell lennie!");

            jaratok.Add(new Jarat(jaratSzam, repterHonnan, repterHova, indulas));
        }

        public void keses(string jaratSzam, int keses)
        {
            var jarat = jaratok.FirstOrDefault(j => j.JaratSzam == jaratSzam);
            if (jarat == null)
                throw new ArgumentException("Nem létező járat!");

            jarat.Keses += keses;

            if (jarat.Keses < 0)
            {
                jarat.Keses -= keses;
                throw new Exception("NegativKesesException");
            }
        }

        public DateTime mikorIndul(string jaratSzam)
        {
            var jarat = jaratok.FirstOrDefault(j => j.JaratSzam == jaratSzam);
            if (jarat == null)
                throw new ArgumentException("Nem létező járat!");

            return jarat.Indulas.AddMinutes(jarat.Keses);
        }

        public List<string> jaratokRepuloterrol(string repter)
        {
            return jaratok
                .Where(j => j.RepterHonnan == repter)
                .Select(j => j.JaratSzam)
                .ToList();
        }
    }
}
