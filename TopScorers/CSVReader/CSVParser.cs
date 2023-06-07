namespace TopScorers.CSVReader
{
    public class CSVParser : ICSVParser
    {
        public Dictionary<string, int> Parse(string filePath)
        {
            string[] csvLines = File.ReadAllLines(filePath);
            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 1; i < csvLines.Length; i++) // Start from index 1 to exclude the header row
            {
                string[] columns = csvLines[i].Split(',');

                if (columns.Length >= 3)
                {
                    string firstName = columns[0];
                    string secondName = columns[1];
                    int score;

                    if (int.TryParse(columns[2], out score))
                    {
                        string fullName = $"{firstName} {secondName}";
                        people[fullName] = score;
                    }
                }
            }

            return people;
        }
    }
}
