namespace LuceedAPI.Models.Dto
{
	public class ArticleDto
	{
		// obzirom da je na sučelju potrebno prikazati samo Id i Naziv, dodao sam samo ta dva propertya u DTO klasu
        public int Id { get; set; }
        public required string Naziv { get; set; }
	}
}

