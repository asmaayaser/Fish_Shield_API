using CORE.Models;
using Microsoft.AspNetCore.Identity;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAppUserCommonService 
    {
        Task<IdentityResult> Register(UserForRegestrationDto userForRegistrationDto,Func<UserForRegestrationDto,AppUser> map);
    }


   


}
