using System.Collections.Generic;
using System.Text;
using XamarinMobileApp.Models;
using XamarinMobileApp.Repositories;

namespace XamarinMobileApp.Services
{
    public class UserService
    {
        public IEnumerable<User> GetAll()
        {
       
            var userRepository = new UserRepository();
            var users = userRepository.GetAll();

            return users;
        }

        public User GetById(int userId)
        {

            var userRepository = new UserRepository();
            var user = userRepository.GetById(userId);

            return user;
        }

        public Result<User> CreateUser(User user)
        {
            var validator = new Validator();

            var resultUser = validator.ValidateUser(user);

            if (resultUser.HasError)
                return resultUser;

            var userRepository = new UserRepository();
            resultUser.Data = userRepository.Insert(user);

            return resultUser;
        }


    }
}
