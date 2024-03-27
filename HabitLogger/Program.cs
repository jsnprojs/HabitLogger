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
        }
    }
}