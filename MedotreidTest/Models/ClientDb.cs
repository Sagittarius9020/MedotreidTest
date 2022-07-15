using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MedotreidTest.Models
{
    public class ClientDb
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Start\source\repos\MedotreidTest\MedotreidTest\App_Data\LibraryDb.mdf;Integrated Security=True";

        public IEnumerable<Client> GetClient() //Вывод всех Клиентов
        {
            IEnumerable<Client> clients = new List<Client>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = "SELECT * FROM Clients";

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
                            Client client = new Client
                            {
                                Id = (int)reader.GetValue(0),
                                Surname = reader.GetValue(1).ToString(),
                                Name = reader.GetValue(2).ToString(),
                                SecondName = reader.GetValue(3).ToString()
                            };
                            
                            ((List<Client>)clients).Add(client);
                        }
                    }
                    return clients;
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

        public Client Client(int id) //Вывод  по Ид
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                Client client = new Client();

                string sqlExpression = $"SELECT * FROM Clients WHERE Id = {id}";

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
                            client.Id = (int)reader.GetValue(0);
                            client.Surname = reader.GetValue(1).ToString();
                            client.Name = reader.GetValue(2).ToString();
                            client.SecondName = reader.GetValue(3).ToString();

                        }
                    }
                    return client;
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

        public int AddClient(Client client) //Добавление Клиента
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = $"INSERT INTO Clients (Surname, Name, SecondName) VALUES (N'{client.Surname}', N'{client.Name}', N'{client.SecondName}')";

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