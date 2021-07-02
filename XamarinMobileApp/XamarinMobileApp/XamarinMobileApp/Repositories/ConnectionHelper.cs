using Dapper;
using Microsoft.Data.Sqlite;

namespace XamarinMobileApp.Repositories
{
    public static class ConnectionHelper
    {
        public static void CreateTables()
        {
            using (var connection = Create())
            {
                connection.Execute(
                           @"CREATE TABLE IF NOT EXISTS User (
	                        Id INTEGER PRIMARY KEY,
	                        Name VARCHAR NOT NULL,
	                        LastName VARCHAR NOT NULL,
	                        CPF VARCHAR(11) NOT NULL UNIQUE,
	                        Birthday DATE NOT NULL,
                            Gender INTEGER
                        )");

                connection.Execute(
                    @"CREATE TABLE IF NOT EXISTS Address (
	                    Id INTEGER PRIMARY KEY,
                        UserId INTEGER NOT NULL,
                        Street VARCHAR NOT NULL, 
                        Number VARCHAR(8) NOT NULL, 
                        District VARCHAR NOT NULL, 
                        City VARCHAR NOT NULL, 
                        State VARCHAR NOT NULL, 
                        AddressComplement VARCHAR,
                        CEP VARCHAR(8) NOT NULL,
                        FOREIGN KEY (UserId) REFERENCES User (Id)
                    )");
            }
        }

        public static SqliteConnection Create()
        {
            var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            var path = System.IO.Path.Combine(basePath, "sqlite.db");
            
            return new SqliteConnection($"Data Source={path}");
        }

    }
}
