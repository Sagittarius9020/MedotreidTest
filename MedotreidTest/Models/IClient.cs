using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedotreidTest.Models
{
    interface IClient
    {
        // Id Клиента
        int Id { get; set; }
        // Фамилия Клиента
        string Surname { get; set; }
        // Имя клиента
        string Name { get; set; }
        // Отчество клиента
        string SecondName { get; set; }
        
    }
}
