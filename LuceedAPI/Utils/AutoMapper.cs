using AutoMapper;

namespace LuceedAPI.Utils
{
	public class AutoMapper : Profile
	{
		public AutoMapper()
		{
			CreateMap<Models.Luceed.Article, Models.Dto.ArticleDto>();
            CreateMap<Models.Luceed.ObracunPlacanja, Models.Dto.ObracunPlacanjaDto>();
            CreateMap<Models.Luceed.ObracunArtikli, Models.Dto.ObracunArtikliDto>();
        }
	}
}