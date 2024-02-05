using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public abstract record UserForRegestrationDto
    {

        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; init; }
        [Required(ErrorMessage ="Email is Required")]
        public string Email { get; init; }
        [Required(ErrorMessage = "Username is Required")]
        public string UserName { get; init; }
        [Required(ErrorMessage = "Password is Required"),DataType(DataType.Password)]
        public string Password { get; init; }
        [Compare(nameof(Password),ErrorMessage ="Password and Confirm Password not Identical"), DataType(DataType.Password)]
        public string ConfirmPass {  get; init; }
        [StringLength(11)]
        public string PhoneNumber { get; init; }
        public string Role { get; init; }


    }
    public record FarmOwnerForRegistrationDto : UserForRegestrationDto
    {
        [Required(ErrorMessage ="Farm address Must Provided")]
        public string FarmAddress { get; init; }

        public string? Address { get; init; }

    }

    public record DoctorForRegistrationDto : UserForRegestrationDto
    {
        [Required(ErrorMessage = "Doctor Must Provide us With Personal Photo")]
        public IFormFile PersonalPhoto { get; init; }
        public string? MoreInfo { get; init; }

        public string Address { get; init; }
    }
    public record AdminForRegistrationDto : UserForRegestrationDto
    {
        [Required(ErrorMessage ="Admin Must Provide us With Personal Photo")]
        public IFormFile PersonalPhoto { get; init; }

        public string Address { get; init; }
    }
}

