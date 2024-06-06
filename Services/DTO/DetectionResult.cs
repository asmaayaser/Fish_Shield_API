namespace Services.DTO
{
	public record DetectionResult
	{
		public string Detection { get; init; }
		public float Percentage { get; init; }
		public string image { get; init; }
	}
}

