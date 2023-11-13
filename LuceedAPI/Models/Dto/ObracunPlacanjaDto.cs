namespace LuceedAPI.Models.Dto
{
	public class ObracunPlacanjaDto
	{
        public required string VrstePlacanjaUid { get; set; }
        public required string Naziv { get; set; }
        public decimal Iznos { get; set; }
        public string? NadgrupaPlacanjaUid { get; set; }
        public string? NadgrupaPlacanjaNaziv { get; set; }
    }
}

