using TopScorers.Calculations;
using TopScorers.CSVReader;

namespace TopScorers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //
            string csvFilePath = "TestDataPlus.csv";

            // Step 1: Read the CSV file
            ICSVParser csvParser = new CSVParser();
            var people = csvParser.Parse(csvFilePath);


            // Step 2: Calculate top scorers
            ITopScorerCalculator topScorerCalculator = new TopScorerCalculator();
            var topScorerNames = topScorerCalculator.GetTopScorers(people);
            var maxScore = topScorerCalculator.GetHighestScore(people);


            Console.WriteLine("Your Top Scorers:");
            Console.WriteLine($"-----------------");
            foreach (string scorer in topScorerNames)
            {
                Console.WriteLine($"{scorer}");
            }
            Console.WriteLine($"-----------------");
            Console.WriteLine($"Score: {maxScore}");

        }
    }
}
