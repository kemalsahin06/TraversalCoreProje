namespace TraversalCoreProje.Cors.Queries.DestinationQuery
{
    public class GetDestinationBYIDQuery
    {
        public GetDestinationBYIDQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}
