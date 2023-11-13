using LuceedAPI.Interfaces;
using LuceedAPI.Models.Dto;
using LuceedAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LuceedAPI.Controllers
{
    [Route("api/[controller]")]
    public class ArticleController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly ILuceedApiService _luceedApiService;

        public ArticleController(IOptions<AppSettings> options, ILuceedApiService luceedApiService)
        {
            _appSettings = options.Value;
            _luceedApiService = luceedApiService;
        }

        [HttpGet]
        public async Task<IEnumerable<ArticleDto>> Get(string namePart)
        {
            return await _luceedApiService.GetArticlesByNamePart(namePart);
        }
    }
}

