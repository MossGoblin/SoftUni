using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Force_Book
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exit string -- Lumpawaroo
            Dictionary<string, string> UserToSide = new Dictionary<string, string>(); // main dictionary - user/side
            Dictionary<string, int> sideNums = new Dictionary<string, int>(); // number of users per side

            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "Lumpawaroo")
                {
                    break;
                }

                string[] operands = commandLine
                    .Split(new char[] { '|', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string side = "";
                string user = "";

                if (commandLine.Contains("|")) // operation JOIN
                {
                    side = operands[0].Trim();
                    user = operands[1].Trim();
                }
                else // operation SWITCH
                {
                    user = operands[0].Trim();
                    side = operands[1].Trim();
                    Console.WriteLine($"{user} joins the {side} side!");
                }

                if (!UserToSide.ContainsKey(user)) // add new user or change an existing one
                {
                    UserToSide.Add(user, side);
                }
                else
                {
                    UserToSide[user] = side;
                }

            }

            // Note down the number of users for each side
            foreach (var sideuser in UserToSide)
            {
                if (!sideNums.ContainsKey(sideuser.Value))
                {
                    sideNums.Add(sideuser.Value, 1);
                }
                else
                {
                    sideNums[sideuser.Value]++;
                }
            }
            
                        
            // To List and Sort the List

            List<KeyValuePair<string, string>> sortedAsList = UserToSide // Sort by user name
                .ToList()
                .OrderBy(s => s.Key)
                .ToList();

            foreach (var sideCount in sideNums.OrderByDescending(sd => sd.Value).ThenBy(sd => sd.Key))
            {
                Console.WriteLine($"Side: {sideCount.Key}, Members: {sideCount.Value}"); // Display Side name and user count
                foreach (var userInSide in sortedAsList.Where(s => s.Value == sideCount.Key)) // Display all users for that side
                {
                    Console.WriteLine($"! {userInSide.Key}");
                }
            }
        }
    }
}
