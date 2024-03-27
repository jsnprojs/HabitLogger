﻿using Microsoft.Data.Sqlite;

namespace HabitLogger;

internal class Program
{
    static string connectionString = @"Data Source=habit-Tracker.db";
    static void Main(string[] args)
    {
        using (var connection = new SqliteConnection(connectionString))
        {

            connection.Open();
            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText =
                @"CREATE TABLE IF NOT EXISTS drinking_water (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Date TEXT,
                        Quantity INTEGER
                        )";

            tableCmd.ExecuteNonQuery();

            connection.Close();

            static void GetUserInput()
            {
                Console.Clear();
                bool closeApp = false;
                while (closeApp == false)
                {
                    Console.WriteLine("\n\nMAIN MENU");
                    Console.WriteLine("\nWhat would you like to do?");
                    Console.WriteLine("\nType 0 to Close Application.");
                    Console.WriteLine("Type 1 to View All Records.");
                    Console.WriteLine("Type 2 to Insert Record.");
                    Console.WriteLine("Type 3 to Delete Record.");
                    Console.WriteLine("Type 4 to Update Record.");
                    Console.WriteLine("------------------------------------------\n");

                    string command = Console.ReadLine();

                    switch (command)
                    {
                        case "0":
                            Console.WriteLine("\nGoodbye!\n");
                            closeApp = true;
                            Environment.Exit(0);
                            break;
                        case "1":
                            GetAllRecords();
                            break;
                        case "2":
                            Insert();
                            break;
                        case "3":
                            Delete();
                            break;
                        case "4":
                            Update();
                            break;
                        default:
                            Console.WriteLine("\nInvalid Command. Please type a number from 0 to 4.\n");
                            break;
                    }
                }

            }
        }
    }
}