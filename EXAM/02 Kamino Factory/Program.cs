using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_Kamino_Factory
{

    class DNASeq
    {
        public int longestOnes { get; set; }
        public int startingIndex { get; set; }
        public int sum { get; set; }
        public string fullSeq { get; set; }
        public int placeInLine { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            List<DNASeq> seqs = new List<DNASeq>();

            // longest subsequence of 1
            // starting index
            // sum of elements

            // split, remove !
            // deconstruct command
            // count

            int seqCounter = 1;
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "Clone them!")
                {
                    break;
                }

                // Split line
                int[] command = commandLine
                    .Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(d => int.Parse(d))
                    .ToArray();

                // Get Sum
                int sumOfLine = command.Sum();
                // int startingIndex = command.First(d => d == 1);
                int startingIndex = 0;

                // find longest subs of 1s
                int longestSeq = 0;
                int seqSoFar = 0;
                int lastIndex = 0;
                int counter = 0;
                bool newSeq = true;
                string currentString = "";
                foreach (var element in command)
                {
                    if (element == 1)
                    {
                        if (newSeq)
                        {
                            lastIndex = counter;
                            newSeq = false;
                        }
                        seqSoFar++;
                        if (seqSoFar > longestSeq)
                        {
                            startingIndex = lastIndex;
                            longestSeq = seqSoFar;
                        }
                    }
                    else
                    {
                        seqSoFar = 0;
                        newSeq = true;
                    }
                    counter++;
                    currentString += element + " ";
                }

                // Add the new seq to the list
                DNASeq nextSeq = new DNASeq();
                nextSeq.longestOnes = longestSeq;
                nextSeq.startingIndex = startingIndex;
                nextSeq.sum = sumOfLine;
                nextSeq.fullSeq = currentString.TrimEnd();
                nextSeq.placeInLine = seqCounter;

                seqs.Add(nextSeq);
                seqCounter++;

            }

            // "Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}."
            // "{DNA sequence, joined by space}"

            List<DNASeq> orderedList = seqs
                .OrderByDescending(s => s.longestOnes)
                .ThenBy(s => s.startingIndex)
                .ThenByDescending(s => s.sum)
                .ToList();

            Console.WriteLine($"Best DNA sample {orderedList[0].placeInLine} with sum: {orderedList[0].sum}.");
            Console.WriteLine(orderedList[0].fullSeq);

            // TEST OUTPUT
            // foreach (var seqItem in orderedList)
            // {
            //     Console.WriteLine($"{seqItem.placeInLine}, sbsq {seqItem.longestOnes}, index {seqItem.startingIndex}, sum {seqItem.sum}");
            // }

        }
    }
}
