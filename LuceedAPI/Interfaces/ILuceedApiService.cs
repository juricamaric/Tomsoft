using LuceedAPI.Models.Dto;

namespace LuceedAPI.Interfaces
{
	public interface ILuceedApiService
	{
        Task<IEnumerable<ArticleDto>> GetArticlesByNamePart(string namePart);
        Task<IEnumerable<ObracunPlacanjaDto>> GetObracuniPlacanja(string pjUid, DateTime odDatuma, DateTime doDatuma);
        Task<IEnumerable<ObracunArtikliDto>> GetObracuniArtikli(string pjUid, DateTime odDatuma, DateTime doDatuma);
    }
}

