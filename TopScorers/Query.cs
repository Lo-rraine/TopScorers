//Query class to define all the resolver methods that should be executed
//When the corresponding fields are queried in the GraphQL Schema

using TopScorers.CSVReader;
using TopScorers.Calculations;
using HotChocolate.Resolvers;

namespace TopScorers
{
    public class Query
    {
        private readonly ICSVParser _csvParser;
        private readonly ITopScorerCalculator _topScorerCalculator;
        public const string  csvFilePath = "TestData.csv";

        //constructor for dependency injection
        public Query(ICSVParser csvParser, ITopScorerCalculator topScorerCalculator)
        {
            _csvParser = csvParser;
            _topScorerCalculator = topScorerCalculator;
           
        }
        
        public async Task<List<string>> GetTopScorers(IResolverContext context)
        {          
            var people = await _csvParser.Parse(csvFilePath);
            return _topScorerCalculator.GetTopScorers(people);
        }

        public async Task<int> GetHighestScore(IResolverContext context)//IResolverContext parameter, provides access to the execution context of the resolver.
        {         
            var people = await _csvParser.Parse(csvFilePath);
            return _topScorerCalculator.GetHighestScore(people);
        }
    }
}
