namespace TopScorers.Calculations
{
    public interface ITopScorerCalculator
    {
        void ValidateData(Dictionary<string, int> people);
        List<string> GetTopScorers(Dictionary<string, int> people);
        int GetHighestScore(Dictionary<string, int> people);
    }
}
