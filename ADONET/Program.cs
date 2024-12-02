using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main(string[] args)
    {
        // Chaîne de connexion
        string connectionString = "Server=127.0.0.1;Port=3306;Database=Northwind;Uid=root;";

        // Connexion à la base de données
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                // Ouvrir la connexion
                connection.Open();
                Console.WriteLine("Connexion réussie à la base de données.");

                // Préparer une commande SQL
                string query = "SELECT ID, Product_Name, List_Price FROM Products";
                MySqlCommand command = new MySqlCommand(query, connection);

                // Exécuter la commande et lire les données
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["ProductID"]}, Nom: {reader["ProductName"]}, Prix: {reader["UnitPrice"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }
        }
    }
}

