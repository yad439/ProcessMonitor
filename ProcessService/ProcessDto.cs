namespace ProcessService {
	internal struct ProcessDto {
		public string Name { get; set; }
		public long MemoryUsage { get; set; }
		public float CpuUsage { get; set; }
	}
}