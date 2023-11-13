using System.Text.Json.Serialization;

namespace LuceedAPI.Models.Luceed
{
	public class ObracunArtikli
	{
        [JsonPropertyName("artikl_uid")]
        public required string ArtiklUid { get; set; }

        [JsonPropertyName("naziv_artikla")]
        public required string NazivArtikla { get; set; }

        [JsonPropertyName("kolicina")]
        public decimal Kolicina { get; set; }

        [JsonPropertyName("iznos")]
        public decimal Iznos { get; set; }

        [JsonPropertyName("usluga")]
        public required string Usluga { get; set; }
    }
}

