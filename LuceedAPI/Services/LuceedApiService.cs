using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using AutoMapper;
using LuceedAPI.Interfaces;
using LuceedAPI.Models.Dto;
using LuceedAPI.Utils;
using Microsoft.Extensions.Options;

namespace LuceedAPI.Services
{
    public class LuceedApiService : ILuceedApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _luceedRestUrl;
        private readonly string _luceedRestUser;
        private readonly string _luceedRestPassword;
        private readonly IMapper _mapper;
        private readonly ILogger<LuceedApiService> _logger;

        public LuceedApiService(HttpClient httpClient, IOptions<AppSettings> options, IMapper mapper, ILogger<LuceedApiService> logger)
        {
            _httpClient = httpClient;
            _luceedRestUrl = options.Value.LuceedRestUrl;
            _luceedRestUser = options.Value.LuceedRestUser;
            _luceedRestPassword = options.Value.LuceedRestPassword;
            _mapper = mapper;
            _logger = logger;

            InitializeHttpClient();
        }

        private void InitializeHttpClient()
        {
            _httpClient.BaseAddress = new Uri(_luceedRestUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_luceedRestUser}:{_luceedRestPassword}"))
            );
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<ArticleDto>> GetArticlesByNamePart(string namePart)
        {
            try
            {
                var response = await _httpClient.GetAsync($"artikli/naziv/{namePart}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var jsonDocument = JsonDocument.Parse(content);
                    var resultArray = jsonDocument.RootElement.GetProperty("result")[0].GetProperty("artikli");

                    var articles = JsonSerializer.Deserialize<IEnumerable<Models.Luceed.Article>>(resultArray.GetRawText(), new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    var articleDtos = _mapper.Map<IEnumerable<ArticleDto>>(articles);

                    return articleDtos;
                }

                _logger.LogError("An error occurred while fetching articles. Response status code: " + response.StatusCode);
                return Array.Empty<ArticleDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching articles.");
                return Array.Empty<ArticleDto>();
            }
        }

        public async Task<IEnumerable<ObracunPlacanjaDto>> GetObracuniPlacanja(string pjUid, DateTime odDatuma, DateTime doDatuma)
        {
            try
            {
                var formattedOdDatuma = odDatuma.ToString("dd.MM.yyyy");
                var formattedDoDatuma = doDatuma.ToString("dd.MM.yyyy");

                var response = await _httpClient.GetAsync($"mpobracun/placanja/{pjUid}/{formattedOdDatuma}/{formattedDoDatuma}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var jsonDocument = JsonDocument.Parse(content);
                    var resultArray = jsonDocument.RootElement.GetProperty("result")[0].GetProperty("obracun_placanja");

                    var obracuniPlacanja = JsonSerializer.Deserialize<IEnumerable<Models.Luceed.ObracunPlacanja>>(resultArray, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    var obracuniPlacanjaDto = _mapper.Map<IEnumerable<ObracunPlacanjaDto>>(obracuniPlacanja);

                    return obracuniPlacanjaDto;
                }

                _logger.LogError("An error occurred while fetching obracuni placanja. Response status code: " + response.StatusCode);
                return Array.Empty<ObracunPlacanjaDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching obracuni placanja.");
                return Array.Empty<ObracunPlacanjaDto>();
            }
        }

        public async Task<IEnumerable<ObracunArtikliDto>> GetObracuniArtikli(string pjUid, DateTime odDatuma, DateTime doDatuma)
        {
            try
            {
                var formattedOdDatuma = odDatuma.ToString("dd.MM.yyyy");
                var formattedDoDatuma = doDatuma.ToString("dd.MM.yyyy");

                var response = await _httpClient.GetAsync($"mpobracun/artikli/{pjUid}/{formattedOdDatuma}/{formattedDoDatuma}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var jsonDocument = JsonDocument.Parse(content);
                    var resultArray = jsonDocument.RootElement.GetProperty("result")[0].GetProperty("obracun_artikli");

                    var obracuniPlacanja = JsonSerializer.Deserialize<IEnumerable<Models.Luceed.ObracunArtikli>>(resultArray, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    var obracuniArtikliDto = _mapper.Map<IEnumerable<ObracunArtikliDto>>(obracuniPlacanja);

                    return obracuniArtikliDto;
                }

                _logger.LogError("An error occurred while fetching obracuni artikli. Response status code: " + response.StatusCode);

                return Array.Empty<ObracunArtikliDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching obracuni artikli.");
                return Array.Empty<ObracunArtikliDto>();
            }
        }
    }
}