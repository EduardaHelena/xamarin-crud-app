using Dapper;
using System.Collections.Generic;
using System.Linq;
using XamarinMobileApp.Models;
using User = XamarinMobileApp.Models.User;

namespace XamarinMobileApp.Repositories
{
    public class UserRepository
    {
        public IEnumerable<User> GetAll()
        {
            using (var connection = ConnectionHelper.Create())
            {
                return connection.Query<User, Address, User>(
                    @"SELECT * 
                        FROM User 
                        INNER JOIN Address on user.id = Address.UserId"
                    , (user, address) =>
                    {
                        user.Address = address;
                        return user;
                    });
            }
        }

        public User GetById(int Id)
        {
            using (var connection = ConnectionHelper.Create())
            {
                return connection.Query<User, Address, User>(
                    @"SELECT * 
                        FROM User
                        INNER JOIN Address on user.id = Address.UserId
                        WHERE User.id = @Id"
                    , (user, address) =>
                    {
                        user.Address = address;
                        return user;
                    }, new { Id }
                    ).FirstOrDefault();
            }
        }

        public User Insert(User User)
        {
            using (var connection = ConnectionHelper.Create())
            {
                User.Id = connection.QueryFirst<int>(@"INSERT INTO User
                                     VALUES(NULL, @Name, @LastName, @CPF, @Birthday, @Gender); SELECT last_insert_rowid()", User);

                User.Address.UserId = User.Id;

                User.Address.Id = connection.QueryFirst<int>(@"INSERT INTO Address
                                                          VALUES(NULL, @UserId, @Street, @Number, @District, @City, @State, @AddressComplement, @CEP); 
                                                          SELECT last_insert_rowid()", User.Address);
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

                connection.Execute(@"UPDATE Address 
                                     SET Street = @Street, Number = @Number, District = @District, City = @City, State = @State, AddressComplement = @AddressComplement, CEP = @CEP
                                     WHERE Id = @Id", User.Address);
            }
        }

        public void DeleteById(int Id)
        {
            using (var connection = ConnectionHelper.Create())
            {
                connection.Execute(@"DELETE FROM Address WHERE UserId = @Id", new { Id });

                connection.Execute(@"DELETE FROM User WHERE Id = @Id", new { Id });
            }
        }

    }
}
