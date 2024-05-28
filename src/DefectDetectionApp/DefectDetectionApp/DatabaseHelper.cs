using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace DefectDetectionApp
{
    public class DatabaseHelper
    {
        private const string DatabaseFileName = "results.db";
        private const string ConnectionString = "Data Source=" + DatabaseFileName;

        public DatabaseHelper()
        {
            // если не существует файла базы данных, то создаем его
            if (!File.Exists(DatabaseFileName))
            {
                SQLiteConnection.CreateFile(DatabaseFileName);
                
            }
            // если таблицы не существует, то создаем ее
            if (!CheckTableExists())
            {
                CreateResultsTable();
            }
        }

        // метод проверки существования таблицы результатов
        private bool CheckTableExists()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                // пробуем получить таблицу
                string checkTableQuery = "SELECT name FROM sqlite_master WHERE type='table' AND name='Results'";

                using (var command = new SQLiteCommand(checkTableQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }
        
        // метод создания таблицы
        private void CreateResultsTable()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string tableCreationQuery = @"CREATE TABLE Results (
                                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        FileName TEXT,
                                        DefectCount INTEGER,
                                        DefectCoordinates TEXT
                                      );";

                using (var command = new SQLiteCommand(tableCreationQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // метод сохранения результатов детекции
        public void SaveResult(string fileName, int defectCount, Detection[] defectCoordinates)
        {
            string defectCoordinatesJson = JsonConvert.SerializeObject(defectCoordinates);

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string insertQuery = @"INSERT INTO Results (FileName, DefectCount, DefectCoordinates) 
                                   VALUES (@FileName, @DefectCount, @DefectCoordinates)";

                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@FileName", fileName);
                    command.Parameters.AddWithValue("@DefectCount", defectCount);
                    command.Parameters.AddWithValue("@DefectCoordinates", defectCoordinatesJson);
                    command.ExecuteNonQuery();
                }
            }
        }

        // метод получения всех данных из таблицы
        public List<DataShowFormat> GetAllResults()
        {
            List<DataShowFormat> results = new List<DataShowFormat>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string selectQuery = "SELECT Id, FileName, DefectCount, DefectCoordinates FROM Results";

                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new DataShowFormat
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FileName = reader["FileName"].ToString(),
                            DefectCount = Convert.ToInt32(reader["DefectCount"]),
                            DefectCoordinates = reader["DefectCoordinates"].ToString()
                        });
                    }
                }
            }
            return results;
        }

        // метод удаления всех данных из таблицы
        public void ClearDatabase()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM Results";
                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}
