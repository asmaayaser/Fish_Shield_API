using CORE.Models;

namespace Services.DTO
{
    public abstract record UserForReturnDto
    {

        public string Id { get; set; }
        public DateTime BirthDate { get; init; }
        public string PersonalPhoto { get; init; }

        public string Email { get; init; }

        public string UserName { get; init; }
        public int Age { get; init; }
        public string PhoneNumber { get; init; }

        public bool Disabled { get; init; }
      

    }
    public record FarmOwnerForReturnDto : UserForReturnDto
    {

        public string FarmAddress { get; init; }

        public string? Address { get; init; }

    }

    public record DoctorForReturnDto : UserForReturnDto
    {
		public int Points { get; set; }
		public string Certificate { get; init; }
        public string? MoreInfo { get; init; }

        public string Address { get; init; }
    }
    public record AdminForReturnDto : UserForReturnDto
    {

       

        public string Address { get; init; }
    }
}

