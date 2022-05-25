namespace livraria.net.core.Query
{
    public class BookQuery : IQueryBase
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Isbn { get; set; }
        public int? Pages { get; set; }
        public int? Chapters { get; set; }
        public int? PublisherId { get; set; }
        public int? AuthorId { get; set; }
        public int? Limit { get; set; } = 10;
        public int? Offset { get; set; }
        public string Sort { get; set; }
    }
}
