namespace TopScorers.Calculations
{
    public class TopScorerCalculator : ITopScorerCalculator
    {
        public List<string> GetTopScorers(Dictionary<string, int> people)
        {
            //check if people is empty then terminate else continue with the programme
            if (people.Count == 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR! Corrupted Data file Validate the data in the file :) ");
                Console.ResetColor();
                Console.WriteLine("Programme aborted");
                Environment.Exit(1);
            }


            int maxScore = people.Values.Max();           
            List<string> topScorers = people.Where(p => p.Value == maxScore)
                                            .Select(p => p.Key)
                                            .OrderBy(name => name)
                                            .ToList();

            return topScorers;
            //Uses the people dictionary to get the names of the highest scorers by applying a filter and projection using LINQ. It returns a List<string> containing the names of the top scorers.
        }

        public int GetHighestScore(Dictionary<string, int> people)
        {
            //check if people is empty then terminate else continue with the programme
            if (people.Count == 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: ERROR! Corrupted Data file. Validate the data in the file.");
                Console.ResetColor();
                Console.WriteLine("Programme aborted");
                Environment.Exit(1);
            }

            return people.Values.Max();
        }
    }
}
