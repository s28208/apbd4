using System;

namespace LegacyApp
{
    public class UserService
    {
        public readonly IClientRepository _ClientRepository;
        public readonly IUserCreditService _UserCreditService;
        public UserService()
        {
            _ClientRepository = new ClientRepository();
            _UserCreditService = new UserCreditService();
        }
        

        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (CheckIsNullOrEmpty(firstName) || CheckIsNullOrEmpty(lastName))
            {
                return false;
            }

            if (!CheckEmail(email))
            {
                return false;
            }

            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (CheckAge(age))
            {
                return false;
            }

            //_ClientRepository = new ClientRepository();
            var client = _ClientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                
                {
                    int creditLimit = _UserCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
            }
            else
            {
                user.HasCreditLimit = true;
                
                {
                    int creditLimit = _UserCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
            }

            if (CheckCredit(user.HasCreditLimit, user.CreditLimit))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        public static bool CheckIsNullOrEmpty(String data)
        {
            return string.IsNullOrEmpty(data);
        }

        public static bool CheckEmail(String data)
        {
            return (data.Contains("@") && data.Contains("."));
        }

        public static bool CheckAge(int age)
        {
            return age < 21;
        }

        public static bool CheckCredit(bool hasCreditLimit, int creditLimit)
        {
            return hasCreditLimit && creditLimit < 500;
        }
    }
}
