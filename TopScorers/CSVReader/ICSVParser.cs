namespace TopScorers.CSVReader
{
    public interface ICSVParser
    {
        Dictionary<string, int> Parse(string filePath);
    }
}
