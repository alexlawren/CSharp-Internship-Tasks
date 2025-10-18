﻿using System.ComponentModel.DataAnnotations;

namespace Library.API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public int PublishedYear { get; set; }
        public int AuthorId { get; set; }   
    }
}
