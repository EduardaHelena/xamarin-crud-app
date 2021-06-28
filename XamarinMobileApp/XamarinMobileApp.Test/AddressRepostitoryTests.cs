using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinMobileApp.Models;
using XamarinMobileApp.Repositories;
using Xunit;

namespace XamarinMobileApp.Test
{
    public class AddressRepostitoryTests
    {

        public Address newAddress()
        {
            TestHelper.DeleteAll();
            var userRepository = new UserRepository();

            var user = TestHelper.newUser();

            user = userRepository.Insert(user);

            var address = new Address();
            address.UserId = user.Id;
            address.Street = "Rua 123";
            address.Number = 456;
            address.District = "Otpx";
            address.City = "Xpto";
            address.State = "Xpto Otpx";
            address.CEP = 12345678;

            return address;
        }

        [Fact]
        public void GetByUser() {
            TestHelper.DeleteAll();

            var address = newAddress();
            var addressRepository = new AddressRepository();

            addressRepository.Insert(address);

            var getAddress = addressRepository.GetByUser(address.UserId);

            Assert.NotNull(getAddress);

            Assert.Equal(address.UserId, getAddress.UserId);
            Assert.Equal(address.Street, getAddress.Street);
            Assert.Equal(address.Number, getAddress.Number);
            Assert.Equal(address.District, getAddress.District);
            Assert.Equal(address.City, getAddress.City);
            Assert.Equal(address.State, getAddress.State);
            Assert.Equal(address.CEP, getAddress.CEP);
        }
    }
}
