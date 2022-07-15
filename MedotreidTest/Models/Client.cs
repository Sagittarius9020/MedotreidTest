using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedotreidTest.Models
{
    public class Client : IClient
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
    }
}