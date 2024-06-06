namespace Services.DTO
{

    public record DetectDto
    {
        public string FishPhoto { get; init; }
        public string UserId { get; init; }
        public string NameOfDisFromAIModel { get; init; }
        public float Score { get; init; }
        public int? DiseaseId { get; init; }
        public DiseaseDto? Disease { get; init; }
        public DateTime DateTime { get; init; }
    }

}
