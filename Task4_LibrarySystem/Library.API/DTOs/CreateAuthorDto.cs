namespace Library.API.DTOs
{
    public class CreateAuthorDto
    {
        private string _name;
        public string Name { get => _name; set { _name = value?.Trim(); } }
        public DateTime? DateOfBirth { get; set; }
    }
}
