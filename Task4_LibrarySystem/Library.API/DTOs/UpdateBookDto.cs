namespace Library.API.DTOs
{
    public class UpdateBookDto
    {
        private string _title;
        public string Title { get => _title; set { _title = value?.Trim(); } }
        public int PublishedYear { get; set; }
        public int AuthorId { get; set; }
    }
}
