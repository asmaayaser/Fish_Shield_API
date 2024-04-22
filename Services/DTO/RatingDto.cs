namespace Services.DTO
{
    public record RatingDto
    {
        public decimal Rate { get; set; }
        public Guid ownerId { get; set; }
        public Guid DoctorId { get; set; }
    }

}
