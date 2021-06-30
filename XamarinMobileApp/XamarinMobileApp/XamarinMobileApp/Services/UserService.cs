using System.Text;
using XamarinMobileApp.Models;
using XamarinMobileApp.Repositories;

namespace XamarinMobileApp.Services
{
    public class UserService
    {
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
