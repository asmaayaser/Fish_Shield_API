using Microsoft.AspNetCore.Identity;
using Services.Contracts.IAuthVarianseBehaviores;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
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
