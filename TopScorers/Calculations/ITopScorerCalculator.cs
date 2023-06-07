namespace TopScorers.Calculations
{
    public interface ITopScorerCalculator
    {
        List<string> GetTopScorers(Dictionary<string, int> people);
    }
}
