namespace TopScorers.Calculations
{
    public class TopScorerCalculator : ITopScorerCalculator
    {
        public List<string> GetTopScorers(Dictionary<string, int> people)
        {
            int maxScore = people.Values.Max();
            List<string> topScorers = people.Where(p => p.Value == maxScore)
                                            .Select(p => p.Key)
                                            .ToList();

            return topScorers;
            //Uses the people dictionary to get the names of the highest scorers by applying a filter and projection using LINQ. It returns a List<string> containing the names of the top scorers.
        }
    }
}
