using MedotreidTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedotreidTest.ViewModels
{
    public class ExtraditionViewModel
    {
        public int Id { get; set; }
        
        public int BookId { get; set; }
        
        public int ClientId { get; set; }
       
        public virtual Book Book { get; set; }

        public virtual Client Client { get; set; }
    }
}