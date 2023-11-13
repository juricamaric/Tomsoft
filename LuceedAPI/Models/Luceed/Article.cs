namespace LuceedAPI.Models.Luceed
{
	public class Article
	{
        // za potrebe demo aplikacije dodao sam samo neke od property-a koje Luceed API vraća za objekt Artikla
        public int Id { get; set; }
		public int Sid { get; set; }
		public string? ArtiklUid { get; set; }
		public string? Artikl { get; set; }
		public required string Naziv { get; set; }
        public string? Opis { get; set; }
    }
}

