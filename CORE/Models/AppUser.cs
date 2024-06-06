
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
        public  int Age { get; set; }
       
        public string? Code { get; set; }
        public string? RefreshToken { get; set; }
        public bool Disabled { get; set; }
        public bool isDeleted {  get; set; }
        public string Discriminator { get;  }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public AppUser()
        {
          
        }
    }

    public class PaymentUserAccount:AppUser
    {
        public bool isPaid { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public byte HasFreeTrialCount { get; set; } = 3;
    }
    public class FarmOwner:PaymentUserAccount
    {
        [Required]
        public string? FarmAddress { get; set; }
      
        public ICollection<Rating> Rates { get; set; }
    }
    public class Doctor:PaymentUserAccount
    {
        public int Points { get; set; }
        public string Certificate { get; set; }
        public string? MoreInfo { get; set; }

        public ICollection<Rating> Rates {  get; set; }
    }
    public class Admin :AppUser
    {
       
        // public DateTime? EmploymentDate { get; set; }
    }
}
