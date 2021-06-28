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
        [Fact]
        public void Insert()
        {
            TestHelper.DeleteAll();

            var address = TestHelper.newAddress();
            var addressRepository = new AddressRepository();

            var addressInsert = addressRepository.Insert(address);

            Assert.True(addressInsert.Id > 0);
        }

        [Fact]
        public void GetByUser() {
            TestHelper.DeleteAll();

            var address = TestHelper.newAddress();
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

        [Fact]
        public void Update()
        {
            var addressRepository = new AddressRepository();
            TestHelper.DeleteAll();

            var address = TestHelper.newAddress();
            address = addressRepository.Insert(address);

            address.Street = "Rua Teste Update 123";
            address.Number = 789;
            address.District = "Xpto";
            address.City = "Otpx";
            address.State = "Update Otpx Xpto";
            address.CEP = 87654321;

            addressRepository.Update(address);

            var getaddress = addressRepository.GetByUser(address.UserId);

            Assert.Equal(address.Street, getaddress.Street);
            Assert.Equal(address.Number, getaddress.Number);
            Assert.Equal(address.District, getaddress.District);
            Assert.Equal(address.City, getaddress.City);
            Assert.Equal(address.State, getaddress.State);
            Assert.Equal(address.CEP, getaddress.CEP);
        }

        [Fact]
        public void DeleteById()
        {
            var addressRepository = new AddressRepository();
            TestHelper.DeleteAll();

            var address = TestHelper.newAddress();
            address = addressRepository.Insert(address);

            addressRepository.DeleteById(address.Id);

            var getaddress = addressRepository.GetByUser(address.UserId);

            Assert.Null(getaddress);
        }
    }
}
