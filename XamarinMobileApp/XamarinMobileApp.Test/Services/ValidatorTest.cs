using System;
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

    }
}
