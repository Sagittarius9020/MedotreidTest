using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace MedotreidTest.Models
{
    public class BookDb
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Start\source\repos\MedotreidTest\MedotreidTest\App_Data\LibraryDb.mdf;Integrated Security=True";

        public IEnumerable<Book> GetBooks() //Вывод всех Книг
        {
            IEnumerable<Book> books = new List<Book>();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT * FROM Books";

                try
                {
                    // Открываем подключение
                    connection.Open();
                    Debug.WriteLine("Connect Open");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            Book book = new Book
                            {
                                Id = (int)reader.GetValue(0),
                                Name = reader.GetValue(1).ToString(),
                                Author = reader.GetValue(2).ToString(),
                                About = reader.GetValue(3).ToString()
                            };
                            Debug.WriteLine(book.Author);
                            ((List<Book>)books).Add(book);
                        }
                    }
                    return books;
                }
               
                finally
                {
                    // если подключение открыто
                    if (connection.State == ConnectionState.Open)
                    {
                        // закрываем подключение
                        connection.Close();

                    }

                }
            }

        }

        public Book Book(int id) //Вывод Книги по Ид
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                Book book = new Book();

                string sqlExpression = $"SELECT * FROM Books WHERE Id = {id}";

                try
                {
                    // Открываем подключение
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            book.Id = (int)reader.GetValue(0);
                            book.Name = reader.GetValue(1).ToString();
                            book.Author = reader.GetValue(2).ToString();
                            book.About = reader.GetValue(3).ToString();
                           
                        }
                    }
                    return book;
                }
                
                finally
                {
                    // если подключение открыто
                    if (connection.State == ConnectionState.Open)
                    {
                        // закрываем подключение
                        connection.Close();

                    }

                }
            }

        }

        public int AddBook(Book book) //Добавление Книги
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = $"INSERT INTO Books (Name, Author, About) VALUES (N'{book.Name}', N'{book.Author}', N'{book.About}')";

                try
                {
                    // Открываем подключение
                    connection.Open();
                    Debug.WriteLine("Connect Open");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    int number = command.ExecuteNonQuery();

                    return number;
                }
                
                finally
                {
                    // если подключение открыто
                    if (connection.State == ConnectionState.Open)
                    {
                        // закрываем подключение
                        connection.Close();

                    }

                }
            }

        }

        public int UpdateBook(Book book) //Изменени Книги по Ид
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = $"UPDATE Books SET Name=N'{book.Name}', Author=N'{book.Author}', About=N'{book.About}' WHERE Id={book.Id}";

                try
                {
                    // Открываем подключение
                    connection.Open();
                    Debug.WriteLine("Connect Open");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    int number = command.ExecuteNonQuery();

                    return number;
                }
                
                finally
                {
                    // если подключение открыто
                    if (connection.State == ConnectionState.Open)
                    {
                        // закрываем подключение
                        connection.Close();

                    }

                }
            }

        }

        


    }

}