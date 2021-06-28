using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using User = XamarinMobileApp.Models.User;

namespace XamarinMobileApp.Repositories
{
    public class UserRepository
    {
        public IEnumerable<User> GetAll()
        {
            using (var connection = ConnectionHelper.Create())
            {
                return connection.Query<User>(@"SELECT * FROM User");
            }
        }

        public User GetById(int Id)
        {
            using (var connection = ConnectionHelper.Create())
            {
                return connection.QueryFirstOrDefault<User>(@"SELECT * FROM User WHERE Id = @Id", new { Id });
            }
        }

        public User Insert(User User)
        {
            using (var connection = ConnectionHelper.Create())
            {
                User.Id = connection.QueryFirst<int>(@"INSERT INTO User
                                     VALUES(NULL, @Name, @LastName, @CPF, @Birthday, @Gender); SELECT last_insert_rowid()", User);
                return User;
            }
        }

        public void Update(User User)
        {
            using (var connection = ConnectionHelper.Create())
            {
                connection.Execute(@"UPDATE User 
                                     SET Name = @Name, LastName = @LastName, CPF = @CPF, Birthday = @Birthday, Gender = @Gender 
                                     WHERE Id = @Id", User);
            }
        }

        public void DeleteById(int Id)
        {
            using (var connection = ConnectionHelper.Create())
            {
                connection.Execute(@"DELETE FROM User WHERE Id = @Id", new { Id });
            }
        }

    }
}
