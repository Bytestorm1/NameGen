using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameGen
{
    class Program
    {
        public static int maxPlanets = 7;
        public static int habitabilityMax = 100;
        /**
         * 0-15 is Barren
         * 15-60 is minable
         * 60-85 is harsh-habitable
         * 85-100 is habitable
         **/
        public enum STAR_TYPE
        {
            M = 1,
            K = 2,
            G = 3,
            F = 4,
            A = 5,
            B = 6,
            O = 7
        }
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------\n" +
                "PLANET GEN IN CASE YOU FORGOT\n" +
                "----------------------------------------");
            Random r = new Random();
            int p = r.Next() % maxPlanets + 1;
            int sType = 8 - p;
            int HorC = r.Next() % 2;
            for (int i = 0; i < p; i++)
            {
                Console.WriteLine(i + 1 + ": ");
                int h = r.Next() % 101;
                Console.WriteLine("Habitability: " + h + "%");
                if (h <= 15)
                {
                    Console.WriteLine("Barren - No minable resources");
                }
                else if (h <= 60)
                {
                    Console.WriteLine("Uninhabitable - Resources available to mine");
                }
                else if (h <= 85)
                {
                    Console.WriteLine("Harsh-Habitable - Hostile Environment");
                    if (HorC == 1)
                    {
                        if (sType > (int)STAR_TYPE.K)
                        {
                            sType--;
                        }
                        else if (sType < (int)STAR_TYPE.K)
                        {
                            sType++;
                        }
                    }
                    else
                    {
                        if (sType > (int)STAR_TYPE.F)
                        {
                            sType--;
                        }
                        else if (sType < (int)STAR_TYPE.F)
                        {
                            sType++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Habitable");
                    if (sType > (int)STAR_TYPE.G)
                    {
                        sType--;
                    }
                    else if (sType < (int)STAR_TYPE.G)
                    {
                        sType++;
                    }
                }
            }
            Console.WriteLine("Star type: " + (STAR_TYPE)sType + "-Class");

            Console.WriteLine("Enter 'y' to continue");
            string ae = Console.ReadLine();
            if (ae == "y")
            {
                Main(new string[1]);
            }
        }
    }
}
