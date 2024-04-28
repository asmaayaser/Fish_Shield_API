﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

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
  
   
    public record UserForUpdateDto
    {
        public string Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; init; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; init; }
        [Required(ErrorMessage = "Username is Required")]
        public string UserName { get; init; }

        //[Required(ErrorMessage = "old Password is Required"), DataType(DataType.Password)]
        //public string oldPassword { get; init; }
        //[Required(ErrorMessage = "new Password is Required"), DataType(DataType.Password)]
        //public string newPassword { get; init; }
        //[Compare(nameof(newPassword), ErrorMessage = "Password and Confirm Password not Identical"), DataType(DataType.Password)]
        //public string ConfirmPass { get; init; }
        [StringLength(11)]
        public string PhoneNumber { get; init; }

    }


    public record FarmOwnerForUpdateDto:UserForUpdateDto
    {
        [Required(ErrorMessage = "Farm address Must Provided")]
        public string FarmAddress { get; init; }
        public string? Address { get; init; }
    }
    public record DoctorForUpdateDto : UserForUpdateDto
    {
        //[Required(ErrorMessage = "Doctor Must Provide us With Personal Photo")]
        //public IFormFile PersonalPhoto { get; init; }
        public string? MoreInfo { get; init; }
        public string Address { get; init; }
    }
    public record UpdareUserPasswordDto
    {
        public string Id { get; init; }
        [Required(ErrorMessage = "old Password is Required"), DataType(DataType.Password)]
        public string oldPassword { get; init; }
        [Required(ErrorMessage = "new Password is Required"), DataType(DataType.Password)]
        public string newPassword { get; init; }
        [Compare(nameof(newPassword), ErrorMessage = "Password and Confirm Password not Identical"), DataType(DataType.Password)]
        public string ConfirmPass { get; init; }
    }
}

