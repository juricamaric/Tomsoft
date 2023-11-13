using System.Text.Json.Serialization;

namespace LuceedAPI.Models.Luceed
{
	public class ObracunPlacanja
	{
        [JsonPropertyName("vrste_placanja_uid")]
        public required string VrstePlacanjaUid { get; set; }

        [JsonPropertyName("naziv")]
        public required string Naziv { get; set; }

        [JsonPropertyName("iznos")]
        public decimal Iznos { get; set; }

        [JsonPropertyName("nadgrupa_placanja_uid")]
        public string? NadgrupaPlacanjaUid { get; set; }

        [JsonPropertyName("nadgrupa_placanja_naziv")]
        public string? NadgrupaPlacanjaNaziv { get; set; }
    }
}

