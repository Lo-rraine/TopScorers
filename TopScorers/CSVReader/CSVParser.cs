namespace TopScorers.CSVReader
{
    public class CSVParser : ICSVParser
    {
        public Dictionary<string, int> Parse(string filePath)
        {
            Dictionary<string, int> people = new Dictionary<string, int>();

            try
            {
                string[] csvLines = File.ReadAllLines(filePath);
                for (int i = 1; i < csvLines.Length; i++) 
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
            }
            catch (IOException ex)
            {
                // Handle file IO exceptions
                Console.BackgroundColor = ConsoleColor.Red;          
                Console.WriteLine($"Error occurred while reading the CSV file: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine("Programme aborted");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                // Handle any other unexpected exceptions
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred during CSV parsing: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine("Programme aborted");
                Environment.Exit(1);
            }
            return people;
        }
    }
}
