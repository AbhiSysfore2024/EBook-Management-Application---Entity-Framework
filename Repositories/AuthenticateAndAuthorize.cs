using CustomExceptions;
using Ebook.Data;
using Entities;
using Repositories.Interfaces;

namespace Repositories
{
    public class AuthenticateAndAuthorize : IAuthenticateAndAuthorize
    {
        private readonly ApplicationDBContext _dbContext;

        public AuthenticateAndAuthorize(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string Signup(DTOLoginRequest loginRequest)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(loginRequest.UserName) || string.IsNullOrWhiteSpace(loginRequest.PassWord))
                {
                    throw new EmptOrNullSpaceUsrnmePsswrd("Username or password cannot be empty or whitespace");
                }

                if (string.Equals(loginRequest.UserName, loginRequest.PassWord))
                {
                    throw new EqualUserNameAndPassword("Username & password cannot be equal");
                }

                bool isUserNameTaken = _dbContext.EFCCredentials.Any(signup => signup.UserName == loginRequest.UserName);
                if (isUserNameTaken)
                {
                    throw new NotUniqueUserName("This username is already taken");
                }

                string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(loginRequest.PassWord, 13);

                var user = new LoginRequest
                {
                    UserName = loginRequest.UserName,
                    PassWord = passwordHash,
                    Role = Role.User
                };

                _dbContext.EFCCredentials.Add(user);
                _dbContext.SaveChanges();

                return "User registered successfully";
            }
            catch (Exception ex) when (ex is EmptOrNullSpaceUsrnmePsswrd ||
                               ex is EqualUserNameAndPassword ||
                               ex is NotUniqueUserName)
            {
                return ex.Message;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return e.Message;
            }
        }

        public string RoleAssigned(DTOLoginRequest loginRequest)
        {
            string role = "";
            string hashedPassword = "";
            try
            {
                hashedPassword = _dbContext.EFCCredentials.Where(user => user.UserName == loginRequest.UserName).Select(user => user.PassWord).FirstOrDefault();

                if (hashedPassword != null && BCrypt.Net.BCrypt.EnhancedVerify(loginRequest.PassWord, hashedPassword))
                {
                    role = _dbContext.EFCCredentials.Where(user => user.UserName == loginRequest.UserName).Select(user => user.UserId).FirstOrDefault().ToString(role);
                }

                return role;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
    }
}
