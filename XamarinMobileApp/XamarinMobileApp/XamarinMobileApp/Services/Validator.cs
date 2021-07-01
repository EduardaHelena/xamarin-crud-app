using System;
using System.Collections.Generic;
using System.Linq;
using XamarinMobileApp.Models;

namespace XamarinMobileApp.Services
{
    public class Validator
    {
        public Result<User> ValidateUser (User user) {
            var result = new Result<User>();

            if (user == null)
                user = new User();

            if (string.IsNullOrWhiteSpace(user.Name))
                result.ErrorMessages.Add("O Nome é obrigatorio");

            if (string.IsNullOrWhiteSpace(user.LastName))
                result.ErrorMessages.Add("Sobrenome é obrigatorio");

            if (string.IsNullOrWhiteSpace(user.CPF))
                result.ErrorMessages.Add("CPF é obrigatorio");
            else if (user.CPF.Length != 11)
                result.ErrorMessages.Add("CPF precisa ter 11 digitos");
            else if (!user.CPF.All(char.IsDigit))
                result.ErrorMessages.Add("CPF só pode conter números");

            if (user.Birthday == null)
                result.ErrorMessages.Add("Data de nascimento é obrigatorio");
            else if (DateTime.Today < user.Birthday.AddYears(18))
                result.ErrorMessages.Add("Usuario menor de idade");

            result.ErrorMessages.AddRange(ValidateAddress(user.Address));

            return result;
        }

        public List<String> ValidateAddress(Address address) {

            List<string> errorMensage = new List<String>();

            if (address == null)
                address = new Address();

            if (string.IsNullOrWhiteSpace(address.Street))
                errorMensage.Add("Logradouro é obrigatorio");

            if (string.IsNullOrWhiteSpace(address.Number))
                errorMensage.Add("Numero é obrigatorio");

            if (string.IsNullOrWhiteSpace(address.District))
                errorMensage.Add("Bairro é obrigatorio");

            if (string.IsNullOrWhiteSpace(address.City))
                errorMensage.Add("Cidade é obrigatorio");

            if (string.IsNullOrWhiteSpace(address.State))
                errorMensage.Add("Estado é obrigatorio");

            if (string.IsNullOrWhiteSpace(address.CEP))
                errorMensage.Add("CEP é obrigatorio");
            else if (address.CEP.Length != 8)
                errorMensage.Add( "CEP precisa ter 8 digitos");
            else if (!address.CEP.All(char.IsDigit))
                errorMensage.Add("CEP só pode conter números");

            return errorMensage;

        }
    }
}
