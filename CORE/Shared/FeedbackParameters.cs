namespace CORE.Shared
{
    public class FeedbackParameters:RequestFeature
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.Now;

        public bool IsValidDateRange => StartDate < EndDate;

    }
    public class DetectionReportParameters : RequestFeature
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.Now;

        public bool IsValidDateRange => StartDate < EndDate;

    }
    public class AppUserParameters:RequestFeature
    {
        public string? Discriminator { get; set; }
        public bool IsValidType =>
            Discriminator == null || 
            Discriminator.Equals("doctor", StringComparison.OrdinalIgnoreCase) ||
            Discriminator.Equals("admin", StringComparison.OrdinalIgnoreCase)  || 
            Discriminator.Equals("farmowner", StringComparison.OrdinalIgnoreCase);

        public string? UsernameSearchTerm { get; set; }
    }
    public class FishDiseaseParameters : RequestFeature
    {
        public string? diseaseNameSearchTerm { get; set; }
    }
}
