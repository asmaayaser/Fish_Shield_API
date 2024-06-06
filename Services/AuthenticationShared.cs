using AutoMapper;
using CORE.Contracts;
using CORE.Exceptions;
using CORE.Models;
using CORE.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repositories.Contracts;
using Services.Contracts;
using Services.Contracts.IAuthVarianseBehaviores;
using Services.DTO;
using Services.EmailService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public partial class Authentication: IAuthentication
    {
        private readonly IRepositoryManager manager;
        private readonly UserManager<AppUser> userManager;
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IEmailSender emailSender;
        private readonly IIOService iOService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private AppUser? user;


        public Authentication(IRepositoryManager manager, UserManager<AppUser> userManager, ILoggerManager logger, IMapper mapper, IConfiguration configuration,IEmailSender emailSender,IIOService iOService, IHttpContextAccessor httpContextAccessor)
        {
            this.manager = manager;
            this.userManager = userManager;
            this.logger = logger;
            this.mapper = mapper;
            this.configuration = configuration;
            this.emailSender = emailSender;
            this.iOService = iOService;
            this.httpContextAccessor = httpContextAccessor;
        }

     

        public async Task<bool> ValidateUser(UserForLoginDto userForLogin)
        {
            user = await userManager.FindByNameAsync(userForLogin.Username);

            if (user is null)
            {
                throw new UserNotFoundException(userForLogin.Username);
            }


            var isValidUser =  await userManager.CheckPasswordAsync(user, userForLogin.Password);

            if (!isValidUser)
            {
                logger.LogWarning($" Some one try to access this User Account {user.Id} -- {user.UserName} -- {user.Email} with inValid Password");
            }

            if (user.Disabled)
                throw new UnauthorizedAccessException("your account is panned for some illegal reasons , Contact Admins for more Info in FeedBack form.");

            return isValidUser;
        }

        /// <summary>
        /// create token limited to 5 minutes as access token and 7 days as refresh token
        /// </summary>
        /// <param name="PopulateExpiration"></param>
        /// <returns></returns>
        public async Task<TokenDto> CreateToken(bool PopulateExpiration)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var RefreshToken = GenerateRefreshToken();

            user.RefreshToken = RefreshToken;
            if (PopulateExpiration)
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

            await userManager.UpdateAsync(user);

            var AccessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new TokenDto(AccessToken, RefreshToken);
        }

        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);

            var userDB = await userManager.FindByNameAsync(principal.Identity.Name);
            if (userDB == null || userDB.RefreshToken != tokenDto.RefreshToken || userDB.RefreshTokenExpiryTime <= DateTime.Now)
                throw new RefreshTokenBadRequest();
            user = userDB;
            return await CreateToken(PopulateExpiration: false);
        }

        #region helper private methods

        /// <summary>
        /// get SigningCredentials (Secret Key + Hashing Algorithm)
        /// </summary>
        /// <returns></returns>
        private SigningCredentials GetSigningCredentials()
        {
            // var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var key = Encoding.UTF8.GetBytes(configuration["JwtSettings:secretKey"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        /// <summary>
        /// Get List Of claims that Contain User name, Id and it's owned roles
        /// </summary>
        /// <returns></returns>
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName) ,
                new Claim(ClaimTypes.NameIdentifier,user.Id)
            };
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        /// <summary>
        /// generate JWTSecurityToken --> Represent Token with 5 minutes Expiration Time
        /// </summary>
        /// <param name="signingCredentials"></param>
        /// <param name="claims"></param>
        /// <returns></returns>
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

        /// <summary>
        /// generating Refresh Crypto Token using RandomNumberGenerator
        /// </summary>
        /// <returns></returns>
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["secretKey"])),// Environment.GetEnvironmentVariable("SECRET"))),
                ValidateLifetime = true,
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        } 
        #endregion

        public async Task<bool> ForgotPasswordAsync(ForgetPasswordDto forgetPasswordDto)
        {
            

            user = await userManager.FindByEmailAsync(forgetPasswordDto.Email);
            if(user is null )
                return false;
            Random random = new Random();
            var UserCode = random.Next(9999).ToString("D4");
            user.Code = UserCode;
            #region Card Email Body
            var CardEmail = @"
<body style=""font-family: Arial, sans-serif; margin: 0 ;padding: 0;background-color: #f4f4f4;"">
    <style>
        /* Media queries for responsive design */
        @media screen and (max-width: 600px) {
            .container {
                width: 100% !important;
                padding: 10px !important;
            }

            .logo {
                width: 80px !important;
                height: auto !important;
                margin-bottom: 10px !important;
            }
        }
    </style>

    <table
        style=""=width: 100%;margin: 0;padding: 20px; background-color: #fff; border-radius: 5px; box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);""
        cellpadding=""0"" cellspacing=""0"" border=""0"" align=""center"">
        <tr>
            <td style=""text-align: center;"">
                <h1>Password Reset</h1>
                
                <div style="" margin-top: 20px; text-align: left;"">
                    <p style="" text-align: center;"">Hello "+user.Email+@",</p>
                    <p style="" text-align: center;"">Someone requested that the password for your Fish Shield
                        account be reset.</p>
                    <p style="" text-align: center;""><strong>Code:</strong>"+UserCode+@"</p>
                    <p style=""padding-left: 4%;"">If you didn't request this, you can ignore this email or let us know.
                        Your
                        password won't change until you create a new password.</p>
                </div>
            </td>
        </tr>
    </table>

</body>
                ";
            #endregion

            var message = new Message(forgetPasswordDto.Email, "Reset Password Code",CardEmail);
            await  emailSender.SendAsync(message);
            await manager.SaveAsync();
            return true;
          
        }

        public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            user =await userManager.FindByEmailAsync(resetPasswordDto.Email);
            if(user is null )
                return IdentityResult.Failed(new IdentityError() {Code="",Description="No user With this Email"});
            if (!user.Code.Equals(resetPasswordDto.Code))
                throw new InvalidCodeException(resetPasswordDto.Code);
            await userManager.RemovePasswordAsync(user);
            var Result = await userManager.AddPasswordAsync(user, resetPasswordDto.Pass);
            return Result;
        }
        public async Task<bool> IsCodeEnterTrue(verifyResetPasswordDto resetPasswordDto)
        {
            var user= await  manager.AppUser.GetUserByEmail(resetPasswordDto.Email, track: false);
            
            if(user is null) throw new UserNotFoundException(resetPasswordDto.Email);

            return user.Code==resetPasswordDto.Code;
        }

        public async Task<(IEnumerable<AppuserForReturnPartial>allusers,MetaData meta)> GetAllUsers(AppUserParameters appUserParameters,bool track)
        {
            if (!appUserParameters.IsValidType)
                throw new NotValidTypeException();

          var usersInPagedList=await  manager.AppUser.GetAllUsersAsync(appUserParameters,track);

           var usersDtoList=mapper.Map<IEnumerable<AppuserForReturnPartial>>(usersInPagedList);

            return (allusers:usersDtoList,meta:usersInPagedList.MetaInfo);
        }

        public async Task DeleteUsers(List<string> UsersIds)
        {
           var deletedusersFromDB=  await manager.AppUser.DeleteUsers(UsersIds);
            bool isDeletedSuccessFully;



            foreach(var user in deletedusersFromDB)
            {
                switch (user.Discriminator)
                {
                    case "Farmowner":
                        isDeletedSuccessFully = await iOService.DeleteDirectory(user.Id);
                        if (isDeletedSuccessFully)
                            continue;
                        logger.LogError($"we are trying delete Farm owner with this id {user.Id} but something wrong accord while deleting his folder");
                        break;
                    case  "Doctor":
                        var d = await manager.Doctors.GetDoctorById(Guid.Parse(user.Id),track:false);
                        isDeletedSuccessFully = await iOService.DeleteDirectory(user.Id);
                        if (isDeletedSuccessFully)
                            isDeletedSuccessFully = await iOService.DeleteFile(user.Id, user.PersonalPhoto);
                        if (isDeletedSuccessFully)
                            isDeletedSuccessFully = await iOService.DeleteFile(user.Id, d.Certificate);
                        if (isDeletedSuccessFully)
                            continue;
                        logger.LogError($"we are trying delete Farm owner with this id {user.Id} but something wrong accord while deleting his folder");
                        break;
                    case "Admin":
                        isDeletedSuccessFully = await iOService.DeleteFile(user.Id, user.PersonalPhoto);
                        if (isDeletedSuccessFully)
                            continue;
                        logger.LogError($"we are trying delete Admin/Doctor with this id {user.Id} but something wrong accord while deleting his Personal Photo");
                        break;
                }
            }

          

           await manager.SaveAsync();

        }

        public async Task DisableOrEnableAccounts(List<string> UsersIds)
        {
           await  manager.AppUser.DisableAccounts(UsersIds);
           await  manager.SaveAsync();
        }

        public async Task MakeSubscription(Guid id)
        {
           var owner=await manager.PaymentUserRepository.GetPaymentUserAccountById(id, track: true);
            if (owner is null)
                throw new UserNotFoundException(id);
            owner.isPaid=true;
            owner.SubscriptionEndDate = DateTime.Now.AddMinutes(Double.Parse(configuration["DetectionPlan:minutes"]));
            await manager.SaveAsync();
        }

        public async Task<bool> IsThisAccountSubscriptedMember(Guid id)
        {
           var owner= await  manager.PaymentUserRepository.GetPaymentUserAccountById(id, track: false);
            if (owner is null)
                throw new UserNotFoundException(id);
            if(owner.SubscriptionEndDate<=DateTime.Now)
                owner.isPaid=false;
            await manager.SaveAsync();
            return owner.isPaid;
        }

        public async Task SetRatingForDoctor(RatingDto rating)
        {
          var owner = await   manager.farmOwner.GetFarmOwnerById(rating.ownerId,track:false);
          var doctor= await manager.Doctors.GetDoctorById(rating.DoctorId,track:true);
            if (owner is null)
                throw new UserNotFoundException(rating.ownerId);

            if (doctor is null)
                throw new UserNotFoundException(rating.DoctorId);

            var rate= mapper.Map<Rating>(rating);
            manager.ratingRepository.PostRating(rate);
            doctor.Points++;
            await manager.SaveAsync();
        }

        public async Task<decimal> GetDoctorRate(Guid doctorId)
        {
          var doctor=  await  manager.Doctors.GetDoctorById(doctorId,track:false);
            if(doctor is null)
                throw new UserNotFoundException(doctorId);
          return  await manager.ratingRepository.CalculateRating(doctorId);
        }

        public async Task<IdentityResult> ChangeUserPassword(UpdateUserPasswordDto userPassword)
        {
            user = await manager.AppUser.GetUserById(userPassword.Id,track:true);
            if (user is null)
                throw new UserNotFoundException(Guid.Parse(userPassword.Id));
           return   await  userManager.ChangePasswordAsync(user,userPassword.oldPassword,userPassword.newPassword);
        }

        public async Task updateUserImage(IFormFile photo,Guid userId)
        {
           user =  await manager.AppUser.GetUserById(userId.ToString(), track:true);
            if (user is null)
                throw new UserNotFoundException(userId);

            var relativePath=   await iOService.uploadImage("Images/Personal", photo, userId.ToString());
            var PathToStoredInDB = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{relativePath}";
            user.PersonalPhoto = PathToStoredInDB;
           await manager.SaveAsync();

        }
    }

   
}
