using System;
using System.Linq;
using XamarinMobileApp.Models;
using XamarinMobileApp.Repositories;
using Xunit;

namespace XamarinMobileApp.Test
{
    public class UserRepostitoryTests
    {

        [Fact]
        public void Insert()
        {
            var userRepository = new UserRepository();

            TestHelper.DeleteAll();
            var user = TestHelper.newUser();

            var userInsert = userRepository.Insert(user);

            var users = userRepository.GetAll();

            Assert.Single(users);
            Assert.True(userInsert.Id > 0);
        }

        [Fact]
        public void GetById()
        {
            var userRepository = new UserRepository();

            TestHelper.DeleteAll();
            var user = TestHelper.newUser();

            user = userRepository.Insert(user);

            var getUser = userRepository.GetById(user.Id);

            Assert.True(getUser.Id == user.Id);
        }
        
        [Fact]
        public void Update()
        {
            var userRepository = new UserRepository();
            TestHelper.DeleteAll();

            var user = TestHelper.newUser();
            user = userRepository.Insert(user);

            user.Name = "Teste Update";
            user.LastName = "456";
            user.CPF = "888888888888";
            user.Birthday = new DateTime();
            user.Gender = Gender.Female;

            userRepository.Update(user);

            var getUser = userRepository.GetById(user.Id);

            Assert.Equal(user.Name, getUser.Name);
            Assert.Equal(user.LastName, getUser.LastName);
            Assert.Equal(user.CPF, getUser.CPF);
            Assert.Equal(user.Birthday, getUser.Birthday);
            Assert.Equal(user.Gender, getUser.Gender);
        }
        
        [Fact]
        public void DeleteById()
        {
            var userRepository = new UserRepository();
            TestHelper.DeleteAll();

            var user = TestHelper.newUser();
            user = userRepository.Insert(user);
            
            userRepository.DeleteById(user.Id);

            var getUser = userRepository.GetById(user.Id);

            Assert.Null(getUser);
        }
    }
}
