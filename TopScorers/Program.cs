using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        string csvFilePath = "TestData.csv"; // Replace with the actual file path

        Dictionary<string, int> people = new Dictionary<string, int>();

        // Step 1: Read the CSV file
        string[] csvLines = File.ReadAllLines(csvFilePath);

        // Step 2: Parse the CSV data
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

        // Step 3: Output the data
        foreach (KeyValuePair<string, int> person in people)
        {
            Console.WriteLine($"{person.Key}: {person.Value}");
        }

        int maxScore = int.MinValue;
        List<string> topScorers = new List<string>();

        foreach (KeyValuePair<string, int> person in people)
        {
            if (person.Value > maxScore)
            {
                maxScore = person.Value;
                topScorers.Clear(); // Clear the previous top scorers
                topScorers.Add(person.Key); // Add the new top scorer
            } else if (person.Value == maxScore)
            {
                topScorers.Add(person.Key); // Add additional top scorer with the same score
            }
        }

        Console.WriteLine("Given a list, here are your Top Scorers:");
        foreach (string scorer in topScorers)
        {
            Console.WriteLine($"{scorer}: {maxScore}");
        }
    }
}
