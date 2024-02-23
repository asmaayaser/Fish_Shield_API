using System.ComponentModel.DataAnnotations;

namespace Services.DTO
{
    public record FeedbackForManipulationDto
    {
        [StringLength(100)]
        public string Name { get; init; }
        [StringLength(100)]
        public string Email { get; init; }
        [StringLength(450)]
        public string Message { get; init; }
    }

    public record FeedbackForCreationDto : FeedbackForManipulationDto;

    public record FeedbackForReturnDto : FeedbackForManipulationDto
    {
        public int Id { get; init; }
    }
    public record FeedbackForUpdateDto: FeedbackForReturnDto;











}
