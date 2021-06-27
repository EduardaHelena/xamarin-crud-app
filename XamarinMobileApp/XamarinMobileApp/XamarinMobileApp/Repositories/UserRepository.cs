using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Microsoft.Data.Sqlite;
using User = XamarinMobileApp.Models.User;

namespace XamarinMobileApp.Repositories
{
    public class UserRepository
    {
        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqliteConnection("Data Source=sqlite.db"))
            {
                return connection.Query<User>(@"SELECT * FROM User");
            }
        }
        public User GetById(int Id)
        {
            using (var connection = new SqliteConnection("Data Source=sqlite.db"))
            {
                return connection.QueryFirstOrDefault<User>(@"SELECT * FROM User WHERE Id = @Id", new { Id });
            }
        }

        public User Insert(User User) {
            using (var connection = new SqliteConnection("Data Source=sqlite.db"))
            {
                User.Id = connection.QueryFirst<int>(@"INSERT INTO User
                                     VALUES(NULL, @Name, @LastName, @CPF, @Birthday, @Gender); SELECT last_insert_rowid()", User);
                return User;
            }
        }

        public void DeleteAll() {
            using (var connection = new SqliteConnection("Data Source=sqlite.db"))
            {
                connection.Execute(@"DELETE FROM User");
            }
        }
    }
}
