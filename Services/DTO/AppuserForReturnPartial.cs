namespace Services.DTO
{
    public record AppuserForReturnPartial
    {
        public string Id { get; init; }
        public string UserName { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public string Discriminator { get; init; }
        public bool Disabled { get; init; }
    }
}

