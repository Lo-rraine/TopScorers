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
        }
    }
}
