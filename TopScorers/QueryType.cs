using HotChocolate.Types;
using System.Collections.Generic;
using TopScorers.CSVReader;
using TopScorers.Calculations;

namespace TopScorers
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(q => q.GetTopScorers(default))
                .Type<ListType<StringType>>()
                .Name("topScorers")
                .Description("Retrieve the top scorers");

            descriptor.Field(q => q.GetHighestScore(default))
                .Type<IntType>()
                .Name("highestScore")
                .Description("Retrieve the highest score");
        }
    }
}
