namespace TopScorers.Calculations
{
    public interface ITopScorerCalculator
    {
        List<string> GetTopScorers(Dictionary<string, int> people);
        int GetHighestScore(Dictionary<string, int> people);
    }
}
