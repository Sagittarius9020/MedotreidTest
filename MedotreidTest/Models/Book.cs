using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedotreidTest.Models
{
    public class Book : IBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string About { get; set; }
        
    }
}