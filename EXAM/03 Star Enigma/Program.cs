using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04_Force_Book
{
    class Order
    {
        public string Name { get; set; }
        public long Pop { get; set; }
        public string Type { get; set; }
        public long Numbers { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<Order> orderList = new List<Order>();
            int attackedPlanets = 0;
            int destroyedPlanets = 0;

            for (int ii = 0; ii < num; ii++)
            {
                string nextMessage = Console.ReadLine();


                // DECODE
                StringBuilder decoder = new StringBuilder();
                Regex letterMatch = new Regex(@"[starSTAR]");
                MatchCollection allLetters = letterMatch.Matches(nextMessage);

                int decoderStep = allLetters.Count;
                for (int jj = 0; jj < nextMessage.Length; jj++)
                {
                    char newChar = (char)((int)nextMessage[jj] - decoderStep);
                    decoder.Append(newChar);
                }
                string decodedMessage = string.Concat(decoder);

                // planet name, population, attack type ('A', as attack or 'D', as destruction) and soldier count.
                // name -- starts after '@' and contains only letters from the Latin alphabet
                // pop -- starts after ':' and is an Integer
                // type -- "A"(attack) or "D"(destruction) and must be surrounded by "!"
                // soldier count starts after "->" and should be an Integer.

                // PARSE
                Regex pattern = new Regex(@".*@([a-zA-Z]+).*:(\d+).*\!([AD])\!.*->(\d+)"); // need to trim the @ in front

                Match splitMessage = pattern.Match(decodedMessage);

                if (splitMessage.Groups.Count < 4)
                {
                    continue;
                }

                string name = splitMessage.Groups[1].ToString();
                long pop = long.Parse(splitMessage.Groups[2].ToString());
                string type = splitMessage.Groups[3].ToString();
                long count = long.Parse(splitMessage.Groups[4].ToString());

                Order nextOrder = new Order(); // new object
                nextOrder.Name = name;
                nextOrder.Pop = pop;
                nextOrder.Type = type;
                nextOrder.Numbers = count;

                // can there be duplicate entries??

                orderList.Add(nextOrder); // add object to list

                if (type == "A")
                {
                    attackedPlanets++;
                }
                else
                {
                    destroyedPlanets++;
                }
            }

            // sorting and printing

            Console.WriteLine($"Attacked planets: {attackedPlanets}");
            if (attackedPlanets > 0)
            {
                foreach (Order planet in orderList.Where(pl => pl.Type == "A").OrderBy(pln => pln.Name))
                {
                    Console.WriteLine($"-> {planet.Name}");
                }
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets}");
            if (destroyedPlanets > 0)
            {
                foreach (Order planet in orderList.Where(pl => pl.Type == "D").OrderBy(pln => pln.Name))
                {
                    Console.WriteLine($"-> {planet.Name}");
                }
            }
        }
    }
}
