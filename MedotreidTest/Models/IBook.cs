using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedotreidTest.Models
{
    public interface IBook
    {
        // Id Книги
        int Id { get; set; }
        // Название книги
        string Name { get; set; }
        // Автор книги
        string Author { get; set; }
        // Описание книги
        string About { get; set; }
    }
}
