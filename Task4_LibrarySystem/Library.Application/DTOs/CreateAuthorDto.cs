namespace Library.Application.DTOs
{
    public class CreateAuthorDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
    }
}
