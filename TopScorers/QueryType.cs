//GraphQL Schema definition Tab
namespace TopScorers
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(q => q.GetTopScorers(default))
                .Type<ListType<StringType>>()
                .Name("topScorers")
                .Description("Retrieves the top scorers from a csv file");

            descriptor.Field(q => q.GetHighestScore(default))
                .Type<IntType>()
                .Name("highestScore")              
                .Description("Retrieves the highest score");
        }
    }
}
