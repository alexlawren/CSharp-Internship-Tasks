﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.DTOs
{
    public class AuthorWithBooksDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BookCount { get; set; }
    }
}
