using AppSettings;
using CustomExceptions;
using Ebook.Data;
using Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Repositories
{
    public class AuthenticateAndAuthorize : IAuthenticateAndAuthorize
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly JWTClaimDetails _jwtDetails;

        public AuthenticateAndAuthorize(ApplicationDBContext dbContext, IOptions<JWTClaimDetails> jwtDetails)
        {
            _dbContext = dbContext;
            _jwtDetails = jwtDetails.Value;
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
                    Role = Role.Admin
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
            string roleName = "";
            string hashedPassword = "";
            try
            {
                hashedPassword = _dbContext.EFCCredentials.Where(user => user.UserName == loginRequest.UserName).Select(user => user.PassWord).FirstOrDefault();

                if (hashedPassword != null && BCrypt.Net.BCrypt.EnhancedVerify(loginRequest.PassWord, hashedPassword))
                {
                    var role = _dbContext.EFCCredentials.Where(user => user.UserName == loginRequest.UserName).Select(user => user.Role).FirstOrDefault();

                    roleName = Enum.GetName(typeof(Role), role);
                }

                return roleName;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string GenerateJwtToken(DTOLoginRequest loginDTO, string role)
        {
            try
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtDetails.Key));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginDTO.UserName),
                    new Claim(ClaimTypes.Role, role)
                };

                var jwtSecurityToken = new JwtSecurityToken(
                    issuer: _jwtDetails.Issuer,
                    audience: _jwtDetails.Audience,
                    claims: claim,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signinCredentials
                    );

                return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            }

            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
