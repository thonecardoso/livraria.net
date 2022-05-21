namespace livraria.net.api.Dto
{
    public class BookResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Isbn { get; set; }
        public int Pages { get; set; }
        public int Chapters { get; set; }
        public int PublisherId { get; set; }
        public int AuthorId { get; set; }
    }
}
