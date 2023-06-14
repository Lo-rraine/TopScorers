namespace TopScorers.Calculations
{
    public class TopScorerCalculator : ITopScorerCalculator
    {
        public void ValidateData(Dictionary<string, int> people)
        {

            if (people.Count == 0)
            {
                throw new ArgumentException("No data available. Validate the data in the file.");
            }
        }

        public List<string> GetTopScorers(Dictionary<string, int> people)
        {
            ValidateData(people);

            //previous implementation
            //int maxScore = people.Values.Max();           
            //List<string> topScorers = people.Where(p => p.Value == maxScore)
            //                                .Select(p => p.Key)
            //                                .OrderBy(name => name)
            //                                .ToList();

            //return topScorers;
            //Uses the people dictionary to get the names of the highest scorers by applying a filter and projection using LINQ. It returns a List<string> containing the names of the top scorers.

            int maxScore = int.MinValue;
            List<string> topScorers = new List<string>();
            foreach (var personScore in people)
            {
                if (personScore.Value > maxScore)
                {
                    maxScore = personScore.Value;
                    topScorers.Clear();
                    topScorers.Add(personScore.Key);
                } else if (personScore.Value == maxScore)
                {
                    topScorers.Add(personScore.Key);
                }
            }

            return topScorers;
           
        }

        public int GetHighestScore(Dictionary<string, int> people)
        {
            ValidateData(people);
          
            return people.Values.Max();

        }

       
    }
}
