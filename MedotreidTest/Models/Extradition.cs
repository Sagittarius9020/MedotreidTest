using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedotreidTest.Models
{
    public class Extradition
    {
        // Id записи
        public int Id { get; set; }
        // Id книги
        public int BookId { get; set; }
        // Id клиента
        public int ClientId { get; set; }
        // Дата выдачи
        public DateTime DateExtrdition { get; set; }
        // Дата возврата
        public DateTime DateReturn{ get; set; }
        

        public virtual Book Book { get; set; }

        public virtual Client Client { get; set; }
    }
}