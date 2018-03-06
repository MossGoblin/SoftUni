using System;

namespace _01_Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            // • The amount of money Ivan Cho has – floating - point number in range[0.00…1, 000.00]
            // • The count of students – integer in range[0…100]
            // • The price of lightsabers for a single sabre – floating - point number in range[0.00…100.00]
            // • The price of robes for a single robe – floating - point number in range[0.00…100.00]
            // • The price of belts for a single belt – floating - point number in range[0.00…100.00]

            decimal totalMoney = decimal.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            decimal lsPrice = decimal.Parse(Console.ReadLine());
            decimal robePrice = decimal.Parse(Console.ReadLine());
            decimal beltPrice = decimal.Parse(Console.ReadLine());

            // get total needed money

            int freebelts = 0;

            if (students > 6)
            {
                freebelts = (students / 6);

            }

            // int robesNeeded = students;
            // int lsNeeded = (int)Math.Ceiling(students * 1.10);
            // int beltsNeeded = students - freebelts;
            // 
            // decimal totalRobes = robesNeeded * robePrice;
            // decimal totalBelts = beltsNeeded * beltPrice;
            // decimal totalLS = lsNeeded * lsPrice;

            decimal totalRobes = students * robePrice;
            decimal totalBelts = (students - freebelts) * beltPrice;
            decimal totalLS = ((int)Math.Ceiling(students * 1.10)) * lsPrice;

            decimal totalNeededMoney = totalRobes + totalBelts + totalLS;

            //test output
            if (totalNeededMoney <= totalMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {totalNeededMoney:f2}lv.");
            }
            else
            {
                decimal neededMoney = totalNeededMoney - totalMoney;
                Console.WriteLine($"Ivan Cho will need {neededMoney:f2}lv more.");
            }
        }
    }
}
