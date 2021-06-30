using Dapper;
using System;
using XamarinMobileApp.Models;
using XamarinMobileApp.Repositories;

namespace XamarinMobileApp.Test
{
    public class TestHelper
    {
        public static void DeleteAll()
        {
            using (var connection =  ConnectionHelper.Create())
            {
                connection.Execute(@"DELETE FROM Address");
                connection.Execute(@"DELETE FROM User");
            }
        }

        public static Address newAddress()
        {
            var address = new Address();
            address.Street = "Rua 123";
            address.Number = "456";
            address.District = "Otpx";
            address.City = "Xpto";
            address.State = "Xpto Otpx";
            address.CEP = "12345678";

            return address;
        }

        public static User newUser()
        {
            var user = new User();
            user.Name = "Teste";
            user.LastName = "123";
            user.CPF = "12345678913";
            user.Birthday = DateTime.Today.AddYears(-19);
            user.Gender = 0;
            user.Address = newAddress();
            return user;
        }

    }
}
