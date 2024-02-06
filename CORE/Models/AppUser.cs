
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
        [Required]
        public required string Email {  get; set; }

        [Required]
        public required string Password { get; set; }

        //[Required]
        //[Compare("Password")]
        //public string Confirm_Password { get; set; }
        public string? Address { get; set; }

        public int Mobile {  get; set; }
    }
    public class FarmOwner:AppUser
    {

    }
    public class Expert : AppUser
    {
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Professional_Info { get; set; }
        public byte[]? Picture { get; set; }

        public Expert()
        {
            Age = DateTime.Now.Year - BirthDate.Year;
        }
    }
    public class Admin :AppUser
    {

        public DateTime? EmploymentDate { get; set; }


    }
}
