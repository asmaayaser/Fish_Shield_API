using AutoMapper;
using CORE.Contracts;
using CORE.Exceptions;
using CORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repositories.Contracts;
using Services.Contracts;
using Services.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public interface IGetAllDerivedTypes
    {
        Task<IEnumerable<UserForReturnDto>> GetAllDreivedTypesAsync(bool track);
    }
    public class GetAllDoctors : IGetAllDerivedTypes
    {
        private readonly IRepositoryManager manager;
        private readonly IMapper mapper;

        public GetAllDoctors(IRepositoryManager manager, IMapper mapper)
        {
            this.manager = manager;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<UserForReturnDto>> GetAllDreivedTypesAsync(bool track)
        {
            var AllDoctorsEntities = await manager.Doctors.GetAllDoctors(track);

            return mapper.Map<IEnumerable<DoctorForReturnDto>>(AllDoctorsEntities);
        }
    }

    public interface IGetByIdDerivedTypes
    {
        Task<UserForReturnDto> GetById(Guid id,bool track);
    }

    public class DoctorGetByID : IGetByIdDerivedTypes
    {
        private readonly IRepositoryManager manager;
        private readonly IMapper mapper;

        public DoctorGetByID(IRepositoryManager manager,IMapper mapper)
        {
            this.manager = manager;
            this.mapper = mapper;
        }
        public async Task<UserForReturnDto> GetById(Guid id, bool track)
        {
           var DoctorEntityFromDB=  await manager.Doctors.GetDoctorById(id,track);

            if (DoctorEntityFromDB is null)
                throw new UserNotFoundException(id);

            return mapper.Map<DoctorForReturnDto>(DoctorEntityFromDB);
        }
    }

    public interface IRegistration
    {
        Task<IdentityResult> Register(UserForRegestrationDto userForRegestration);
    }

    public abstract class RegistrationBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IIOService ioService;
        private readonly IHttpContextAccessor httpContextAccessor;
        protected AppUser user;



        public RegistrationBase(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IIOService ioService, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.ioService = ioService;
            this.httpContextAccessor = httpContextAccessor;
        }



        public async Task<IdentityResult> Register(UserForRegestrationDto userForRegistrationDto, Func<UserForRegestrationDto, AppUser> map)
        {
            user = map.Invoke(userForRegistrationDto);

            var CreateResult = await userManager.CreateAsync(user, userForRegistrationDto.Password);
            var ActualTypeforUser = user.GetType();
            if (CreateResult.Succeeded)
            {
                if (ActualTypeforUser == typeof(Admin) && await roleManager.RoleExistsAsync("Admin"))
                    await userManager.AddToRoleAsync(user, "Admin");
                else if (ActualTypeforUser == typeof(Doctor) && await roleManager.RoleExistsAsync("Doctor"))
                    await userManager.AddToRoleAsync(user, "Doctor");
                else if (ActualTypeforUser == typeof(FarmOwner) && await roleManager.RoleExistsAsync("FarmOwner"))
                    await userManager.AddToRoleAsync(user, "FarmOwner");
                else
                {
                    await DeleteUser(user);
                    throw new RoleNotFoundException();
                }
            }

            return CreateResult;
        }
        protected async Task DeleteUser(AppUser user) => await userManager.DeleteAsync(user);

        protected async Task<IdentityResult> HandleUPloadedImageProcess(string FolderNamingStructureInsideWWWRoot, IFormFile image, string NewNameForImage)
        {


            var imageRelativePath = await ioService.uploadImage(FolderNamingStructureInsideWWWRoot, image, NewNameForImage);
            var HostUrl = httpContextAccessor.HttpContext.Request.Scheme + "://" + httpContextAccessor.HttpContext.Request.Host;
            user.PersonalPhoto = $"{HostUrl}/{imageRelativePath}";
            IdentityResult updated = await userManager.UpdateAsync(user);

            if (!updated.Succeeded)
            {
                await DeleteUser(user);
                return IdentityResult.Failed();
            }
            return IdentityResult.Success;


        }


    }

    public class FarmOwnerRegistration : RegistrationBase, IRegistration
    {
        private readonly IMapper mapper;
        private readonly IIOService ioService;

        public FarmOwnerRegistration(IMapper mapper, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IIOService ioService) : base(userManager, roleManager, ioService, default)
        {
            this.mapper = mapper;
            this.ioService = ioService;
        }


        public async Task<IdentityResult> Register(UserForRegestrationDto userForRegestration)
        {
            IdentityResult ResultForRegestrationProcess = IdentityResult.Failed();
            var resultOfCreatingTextualData = await base.Register(userForRegestration, user => mapper.Map<FarmOwner>(user));

            if (resultOfCreatingTextualData.Succeeded)
            {
                // create Folder
                var res = await CreateDirectory("Images/Detects", user.Id);
                if (!res)
                {
                    await base.DeleteUser(user);
                    resultOfCreatingTextualData = IdentityResult.Failed(new IdentityError() { Code = "CD Error", Description = "Some server internal error occurred while creating A Directory For this user Please try again Later " });
                }
            }
            ResultForRegestrationProcess = resultOfCreatingTextualData; // for Error equality
            return ResultForRegestrationProcess;


            async Task<bool> CreateDirectory(string FolderNameStructureInWWWROOT, string Dirname) => await ioService.CreateDirectory(FolderNameStructureInWWWROOT, Dirname);
        }

    }

    public class AdminRegistration : RegistrationBase, IRegistration
    {
        private readonly IMapper mapper;

        public AdminRegistration(IMapper mapper, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IIOService ioService, IHttpContextAccessor httpContextAccessor) : base(userManager, roleManager, ioService, httpContextAccessor)
        {
            this.mapper = mapper;
        }

        public async Task<IdentityResult> Register(UserForRegestrationDto userForRegestration)
        {
            IdentityResult ResultForRegestrationProcess = IdentityResult.Failed();

            var adminDto = userForRegestration as AdminForRegistrationDto;
            var resultOfCreatingTextualData = await base.Register(adminDto, user => mapper.Map<Admin>(user));

            if (resultOfCreatingTextualData.Succeeded)
                ResultForRegestrationProcess = await base.HandleUPloadedImageProcess("Images/Personal", adminDto.PersonalPhoto, user.Id);
            else
                ResultForRegestrationProcess = resultOfCreatingTextualData;


            return ResultForRegestrationProcess;
        }
    }

    public class DoctorRegistration : RegistrationBase, IRegistration
    {
        private readonly IMapper mapper;

        public DoctorRegistration(IMapper mapper, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IIOService ioService, IHttpContextAccessor httpContextAccessor) : base(userManager, roleManager, ioService, httpContextAccessor)
        {
            this.mapper = mapper;
        }

        public async Task<IdentityResult> Register(UserForRegestrationDto userForRegestration)
        {
            IdentityResult ResultForRegestrationProcess = IdentityResult.Failed();

            var DoctorDto = userForRegestration as DoctorForRegistrationDto;

            var resultOfCreatingTextualData = await base.Register(DoctorDto, user => mapper.Map<Doctor>(user));

            if (resultOfCreatingTextualData.Succeeded)
                ResultForRegestrationProcess = await base.HandleUPloadedImageProcess("Images/Personal", DoctorDto.PersonalPhoto, user.Id);
            else
                ResultForRegestrationProcess = resultOfCreatingTextualData;
            return ResultForRegestrationProcess;
        }
    }

 


    public interface IAuthentication
    {

        IRegistration registration { get; set; }
        Task<IdentityResult> Registration(UserForRegestrationDto userForRegestration);

        IGetAllDerivedTypes getAll { get; set; }
        Task<IEnumerable<UserForReturnDto>> GetAllDreivedTypesAsync(bool track);

        IGetByIdDerivedTypes getByIdDerivedTypes { get; set; }
        Task<UserForReturnDto> GetByIdDerivedTypeAsync(Guid id, bool track);

        Task<bool> ValidateUser(UserForLoginDto userForLogin);
        Task<TokenDto> CreateToken(bool PopulateExpiration);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        


    }

  
    public partial class Authentication: IAuthentication
    {
        private readonly IRepositoryManager manager;
        private readonly UserManager<AppUser> userManager;
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private AppUser? user;
        public Authentication(IRepositoryManager manager, UserManager<AppUser> userManager, ILoggerManager logger, IMapper mapper, IConfiguration configuration)
        {
            this.manager = manager;
            this.userManager = userManager;
            this.logger = logger;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        

        public async Task<bool> ValidateUser(UserForLoginDto userForLogin)
        {
            user = await userManager.FindByNameAsync(userForLogin.Username);
            var isValidUser = (user is not null && await userManager.CheckPasswordAsync(user, userForLogin.Password));

            if (!isValidUser)
            {
                logger.LogWarning($"there is no user with this userName :{userForLogin.Username} in Our DB Or Some one try to access this User Account {user?.Email} with inValid Password");
            }


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

        
    }

    public partial class Authentication
    {
        // what variance

        public IRegistration registration { get; set; }
        public IGetAllDerivedTypes getAll { get; set; }
        public IGetByIdDerivedTypes getByIdDerivedTypes { get; set; }


        public async Task<IdentityResult> Registration(UserForRegestrationDto userForRegestration) => await registration.Register(userForRegestration);
        public async Task<IEnumerable<UserForReturnDto>> GetAllDreivedTypesAsync(bool track) => await getAll.GetAllDreivedTypesAsync(track);
        public async Task<UserForReturnDto> GetByIdDerivedTypeAsync(Guid id, bool track) => await getByIdDerivedTypes.GetById(id, track);


    }
}
