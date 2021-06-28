﻿using Microsoft.Data.Sqlite;
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
            using (var connection = new SqliteConnection("Data Source=sqlite.db"))
            {
                return connection.QueryFirstOrDefault<Address>(@"SELECT * FROM Address WHERE UserId = @UserId", new { UserId });
            }
        }

        public Address Insert(Address Address)
        {
            using (var connection = new SqliteConnection("Data Source=sqlite.db"))
            {
                Address.Id = connection.QueryFirst<int>(@"INSERT INTO Address
                                                          VALUES(NULL, @UserId, @Street, @Number, @District, @City, @State, @AddressComplement, @CEP); 
                                                          SELECT last_insert_rowid()", Address);
                return Address;
            }
        }
    }
}