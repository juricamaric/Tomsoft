using LuceedAPI.Interfaces;
using LuceedAPI.Models.Dto;
using LuceedAPI.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LuceedAPI.Controllers
{
    [Route("api/[controller]")]
    public class ObracunController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly ILuceedApiService _luceedApiService;

        public ObracunController(IOptions<AppSettings> options, ILuceedApiService luceedApiService)
        {
            _appSettings = options.Value;
            _luceedApiService = luceedApiService;
        }

        [HttpGet("placanja")]
        public async Task<IEnumerable<ObracunPlacanjaDto>> GetObracuniPlacanja(string pjUid, DateTime odDatuma, DateTime doDatuma)
        {
            return await _luceedApiService.GetObracuniPlacanja(pjUid, odDatuma, doDatuma);
        }

        [HttpGet("artikli")]
        public async Task<IEnumerable<ObracunArtikliDto>> GetObracuniArtikli(string pjUid, DateTime odDatuma, DateTime doDatuma)
        {
            return await _luceedApiService.GetObracuniArtikli(pjUid, odDatuma, doDatuma);
        }
    }
}
