using HotChocolate;
using System.Collections.Generic;
using TopScorers.CSVReader;
using TopScorers.Calculations;
using HotChocolate.Resolvers;

namespace TopScorers
{
    public class Query
    {
        private readonly ICSVParser _csvParser;
        private readonly ITopScorerCalculator _topScorerCalculator;
        public const string  csvFilePath = "TestDataa.csv";



        public Query(ICSVParser csvParser, ITopScorerCalculator topScorerCalculator)
        {
            _csvParser = csvParser;
            _topScorerCalculator = topScorerCalculator;
           
        }

        
        public List<string> GetTopScorers(IResolverContext context)
        {
           
            var people = _csvParser.Parse(csvFilePath);
            return _topScorerCalculator.GetTopScorers(people);
        }

        public int GetHighestScore(IResolverContext context)
        {         
            var people = _csvParser.Parse(csvFilePath);
            return _topScorerCalculator.GetHighestScore(people);
        }
    }
}
