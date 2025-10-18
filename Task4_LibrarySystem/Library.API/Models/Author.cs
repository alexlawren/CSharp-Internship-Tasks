using System.ComponentModel.DataAnnotations;

namespace Library.API.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get;  set; }
        public DateTime DateOfBirth { get; set; }
    }
}