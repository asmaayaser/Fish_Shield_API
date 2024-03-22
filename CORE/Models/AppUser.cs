
using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public abstract class AppUser:IdentityUser
    {
        [StringLength(100)]
        public string? PersonalPhoto { get; set; }
        public string? Address { get; set; }
        public DateTime BirthDate { get; set; }
        public  int Age { get; }
        [EncryptColumn]
        public string? Code { get; set; }
        public string? RefreshToken { get; set; }
        public bool Disabled { get; set; }
        public bool isDeleted {  get; set; }
        public string Discriminator { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public AppUser()
        {
            Age = DateTime.Now.Year-BirthDate.Year;
        }
    }
    public class FarmOwner:AppUser
    {
        [Required]
        public string? FarmAddress { get; set; }
    }
    public class Doctor:AppUser
    {
   
        public string? MoreInfo { get; set; }
    }
    public class Admin :AppUser
    {
       
        // public DateTime? EmploymentDate { get; set; }
    }
}
