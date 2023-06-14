namespace TopScorers.CSVReader
{
    public interface ICSVParser
    {
        Task<Dictionary<string, int>> Parse(string filePath);
    }
}
