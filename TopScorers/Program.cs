﻿using TopScorers.Calculations;
using TopScorers.CSVReader;

namespace TopScorers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //
            string csvFilePath = "TestData.csv";

            // Step 1: Read the CSV file
            ICSVParser csvParser = new CSVParser();

            Dictionary<string, int> people = csvParser.Parse(csvFilePath);


            // Step 2: Calculate top scorers
            ITopScorerCalculator topScorerCalculator = new TopScorerCalculator(); //we call this an object
            List<string> topScorers = topScorerCalculator.GetTopScorers(people);

            Console.WriteLine("Your Top Scorers:");
            foreach (string scorer in topScorers)
            {
                Console.WriteLine($"{scorer}: {people[scorer]}");
            }

        }
    }
}
