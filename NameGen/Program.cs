using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameGen
{
    class Program
    {
        public static char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        public static char[] consonants = "bcdfghjklmnpqrstvwxyz".ToCharArray(); //bcdfghjklmnpqrstvwxyz
        public static char[] vowels = "aeiou".ToCharArray();
        static void Main(string[] args)
        {
            Random rand = new Random();
            int letterCount = rand.Next() % 2 + 3;
            List<char> seed = new List<char>();
            for (int i = 0; i < letterCount; i++)
            {
                int index = rand.Next() % consonants.Length;
                if (!seed.Contains(consonants[index]))
                {
                    seed.Add(consonants[index]);
                    Console.Write(consonants[index] + ",");
                }
                else
                {
                    i--;
                }
            }
            Console.WriteLine();
            IEnumerable<IEnumerable<char>> p = GetPermutations<char>(seed, letterCount);
            List<string> names = new List<string>();
            foreach (IEnumerable<char> c in p) {
                string gen = generateName(c, rand);
                names.Add(gen);
                if (scoreName(gen) < 1) { continue; }
                //Console.WriteLine(gen + " - " + scoreName(gen));
            }
            names = names.OrderBy(item => scoreName(item)).Reverse().ToList();
            foreach (string i in names)
            {
                if (scoreName(i) < 0) {
                    break;
                }
                Console.WriteLine(i + " - " + scoreName(i));
            }
            Console.ReadLine();
        }
        public static string generateName(IEnumerable<char> seed, Random r)
        {
            //Add more randomness
            for (int i = 0; i < r.Next() % 5 + 1; i++) {
                r.Next();
            }
            string output = "";
            //Random r = new Random();
            foreach (char l in seed) {
                if (l != seed.First())
                {
                    int v = r.Next() % vowels.Length;
                    output += vowels[v];
                }
                if (l == seed.Last())
                {
                    int ae = r.Next() % 2;
                    if (ae == 0) {
                        output += l;
                    }
                }
                else {
                    output += l;
                }
            }
            return output;
        }
        static int scoreName(string name) {
            List<string> goods = new List<string> { "az", "ax", "ar", "ah", "aj", "aw", "al", "ma", "ri", "em", "mer", "ey", "el", "eg", "ej", "il",
                    "is", "ix", "it", "ow", "os", "or", "ore", "oh", "od", "qu", "un", "on", "ok", "ko", "ur", "us", "uv", "ay", "ya", "yer", "yn", "wyn", "yu", "ca", "dat", "ed",
                        "id", "ul", "let", "cyn", "kin", "jid"};
            List<string> bads = new List<string> { "ad", "at", "dac", "ry", "gow", "wif", "mugo", "gy", "ruwe", "ryfy", "wemy", "mef", "for", "fire", "ack", "uk", "yk", "ym", "yt", "og",
                       "hu", "ho", "go", "og", "jo", "oj", "fo", "ro", "uh", "muh", "bruh", "ef", "jef", "bo", "yd", "late", "ci", "gyz", "zum", "xual", "yj", "xu", "gyc", "gyk", "zo", "ho",
                        "neko", "rice", "od", "go", "hipi", "bah", "nice", "ixi", "zor", "aq", "eq", "uq", "iq"};
            int score = goods.Count(item => name.Contains(item)) - bads.Count(item => name.Contains(item));
            return score;
        }
        static IEnumerable<IEnumerable<T>>
                GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
    }
}
