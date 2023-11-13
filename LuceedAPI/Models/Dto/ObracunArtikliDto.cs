namespace LuceedAPI.Models.Dto
{
	public class ObracunArtikliDto
	{
        public required string ArtiklUid { get; set; }
        public required string NazivArtikla { get; set; }
        public decimal Kolicina { get; set; }
        public decimal Iznos { get; set; }
        public required string Usluga { get; set; }
    }
}