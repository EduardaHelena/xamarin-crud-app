using System.Collections.Generic;
using System.Text;
using XamarinMobileApp.Models;
using XamarinMobileApp.Repositories;

namespace XamarinMobileApp.Services
{
    public class UserService
    {
        UserRepository userRepository = new UserRepository();
        Validator validator = new Validator();

        public IEnumerable<User> GetAll()
        {
       
            var userRepository = new UserRepository();
            var users = userRepository.GetAll();

            return users;
        }

        public User GetById(int userId)
        {
            var user = userRepository.GetById(userId);
            return user;
        }

        public Result<User> CreateUser(User user)
        {
            var resultUser = validator.ValidateUser(user);

            if (resultUser.HasError)
                return resultUser;

            resultUser.Data = userRepository.Insert(user);

            return resultUser;
        }
        public Result<User> UpdateUser (User user)
        {
            var resultUser = validator.ValidateUser(user);

            if (resultUser.HasError)
                return resultUser;

            userRepository.Update(user);

            return resultUser;
        }

        public void DeleteUser(int userID)
        {
            userRepository.DeleteById(userID);
        }
    }
}
