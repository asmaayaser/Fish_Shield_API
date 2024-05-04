namespace Services.DTO
{

    public record DetectDto
    {
        public string FishPhoto { get; set; }
        public string UserId { get; set; }
        public string NameOfDisFromAIModel { get; set; }
        public float Score { get; set; }
        public int? DiseaseId { get; set; }
        public DiseaseDto? Disease { get; set; }
        public DateTime DateTime { get; set; }
    }

}
