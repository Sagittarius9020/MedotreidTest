using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MedotreidTest.Models
{
    public class ExtraditionDb
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Start\source\repos\MedotreidTest\MedotreidTest\App_Data\LibraryDb.mdf;Integrated Security=True";

        public IEnumerable<Extradition> GetExtradition() //Вывод выданных книг
        {
            IEnumerable<Extradition> extraditions = new List<Extradition>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT * FROM Extraditions WHERE DateReturn IS NULL";

                try
                {
                    BookDb bdb = new BookDb();
                    ClientDb cdb = new ClientDb();
                    // Открываем подключение
                    connection.Open();
                    Debug.WriteLine("Connect Open");
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            Extradition extradition = new Extradition
                            {
                                Id = (int)reader.GetValue(0),
                                BookId = (int)reader.GetValue(1),
                                ClientId = (int)reader.GetValue(2),
                                DateExtrdition = Convert.ToDateTime(reader.GetValue(3)),
                                Book = bdb.Book((int)reader.GetValue(1)),
                                Client = cdb.Client((int)reader.GetValue(2))
                            };

                            ((List<Extradition>)extraditions).Add(extradition);
                        }
                    }
                    return extraditions;
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

        public Extradition ExtraditionBook(int id) //Вывод выданной Книги
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Extradition extradition = new Extradition();
                
                string sqlExpression = $"SELECT * FROM Extraditions WHERE Id = {id}";

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
                            extradition.Id = (int)reader.GetValue(0);
                            extradition.BookId = (int)reader.GetValue(1);
                            extradition.ClientId = (int)reader.GetValue(2);
                            extradition.DateExtrdition = Convert.ToDateTime(reader.GetValue(3));

                        }
                    }
                    return extradition;
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

        public int ExtraditionBook(Extradition extradition) //Выдача книги
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string date = $"{extradition.DateExtrdition.Year}-{extradition.DateExtrdition.Month}-{extradition.DateExtrdition.Day}";
                string sqlExpression = $"INSERT INTO Extraditions (BookId, ClientId, DateExtradition) VALUES ('{extradition.BookId}', '{extradition.ClientId}', '{date}')";

                try
                {
                    // Открываем подключение
                    connection.Open();
                    Debug.WriteLine("Connect Open "+ sqlExpression);
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

        public int ReturnBook(Extradition extradition) //Возврат Книги
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string date = $"{extradition.DateReturn.Year}-{extradition.DateReturn.Month}-{extradition.DateReturn.Day}";
                string sqlExpression = $"UPDATE Extraditions SET DateReturn='{date}' WHERE Id={extradition.Id}";

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