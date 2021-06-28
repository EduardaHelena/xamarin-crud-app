using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinMobileApp.Models;
using Dapper;

namespace XamarinMobileApp.Repositories
{
    public class AddressRepository
    {
        public Address GetByUser(int UserId)
        {
            using (var connection =  ConnectionHelper.Create())
            {
                return connection.QueryFirstOrDefault<Address>(@"SELECT * FROM Address WHERE UserId = @UserId", new { UserId });
            }
        }

        public Address Insert(Address Address)
        {
            using (var connection =  ConnectionHelper.Create())
            {
                Address.Id = connection.QueryFirst<int>(@"INSERT INTO Address
                                                          VALUES(NULL, @UserId, @Street, @Number, @District, @City, @State, @AddressComplement, @CEP); 
                                                          SELECT last_insert_rowid()", Address);
                return Address;
            }
        }

        public void Update(Address Address)
        {
            using (var connection =  ConnectionHelper.Create())
            {
                connection.Execute(@"UPDATE Address 
                                     SET Street = @Street, Number = @Number, District = @District, City = @City, State = @State, AddressComplement = @AddressComplement, CEP = @CEP
                                     WHERE Id = @Id", Address);
            }
        }

        public void DeleteById(int Id)
        {
            using (var connection =  ConnectionHelper.Create())
            {
                connection.Execute(@"DELETE FROM Address WHERE Id = @Id", new { Id });
            }
        }
    }
}
