namespace TopScorers.CSVReader
{
    public class CSVParser : ICSVParser
    {
        public async Task <Dictionary<string, int>> Parse(string filePath)
        {
            Dictionary<string, int> people = new Dictionary<string, int>();

            try
            {
                string[] csvLines = await File.ReadAllLinesAsync(filePath);

                for (int i = 1; i < csvLines.Length; i++)
                {
                    string[] columns = csvLines[i].Split(',');

                    try
                    {
                        if (columns.Length >= 3)
                        {
                            string firstName = columns[0];
                            string secondName = columns[1];
                            int score;

                            try
                            {
                                if (int.TryParse(columns[2], out score))
                                {
                                    string fullName = $"{firstName} {secondName}";
                                    people[fullName] = score;
                                } else
                                {
                                    throw new FormatException();
                                }
                            }

                            catch (FormatException ex)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ex.Message} value {columns[2]} on row {i}");
                                Console.ResetColor();
                                continue;
                            }

                        }
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine($"ERROR: {ex.Message} on row {i}");
                        Console.ResetColor();
                        continue;
                    }
                }

            }
            catch (FileNotFoundException ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine("Programme aborted");
                Environment.Exit(1);
            }
            
            return people;
        }
    }
}
