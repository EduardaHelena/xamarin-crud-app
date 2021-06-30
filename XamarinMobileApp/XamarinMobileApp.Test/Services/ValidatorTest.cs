﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinMobileApp.Services;
using Xunit;

namespace XamarinMobileApp.Test.Services
{
    public class ValidatorTest
    {
        [Fact]
        public void ValidateUser() {
            var validator = new Validator();

            var user = TestHelper.newUser();
            user.Address = TestHelper.newAddress();

            var resultUser = validator.ValidateUser(user);

            Assert.False(resultUser.HasError);
        }

        [Fact]
        public void ValidateCPFUser()
        {
            var validator = new Validator();

            var user = TestHelper.newUser();

            user.CPF = "123";
            var resultUserSmallCPF = validator.ValidateUser(user);

            user.CPF = "123234234234234";
            var resultUserBigCPF = validator.ValidateUser(user);

            Assert.True(resultUserSmallCPF.HasError);
            Assert.Single(resultUserSmallCPF.ErrorMessages);

            Assert.True(resultUserBigCPF.HasError);
            Assert.Single(resultUserBigCPF.ErrorMessages);
        }

        [Fact]
        public void ValidateBirthdayUser()
        {
            var validator = new Validator();

            var user = TestHelper.newUser();

            user.Birthday = DateTime.Today.AddYears(-17);
            var resultUserSmallAge = validator.ValidateUser(user);

            user.Birthday = DateTime.Today.AddYears(-19);
            var resultUserBigAge = validator.ValidateUser(user);

            Assert.True(resultUserSmallAge.HasError);
            Assert.Single(resultUserSmallAge.ErrorMessages);

            Assert.False(resultUserBigAge.HasError);
            Assert.Empty(resultUserBigAge.ErrorMessages);
        }

        [Fact]
        public void ValidateCEPUser()
        {
            var validator = new Validator();

            var user = TestHelper.newUser();

            user.Address.CEP = "123";
            var resultUserSmallCEP = validator.ValidateUser(user);

            user.Address.CEP = "12323232323";
            var resultUserBigCEP = validator.ValidateUser(user);

            Assert.True(resultUserSmallCEP.HasError);
            Assert.Single(resultUserSmallCEP.ErrorMessages);

            Assert.True(resultUserBigCEP.HasError);
            Assert.Single(resultUserBigCEP.ErrorMessages);
        }

    }
}
