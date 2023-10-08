using Microsoft.AspNetCore.Mvc;

namespace ConectionMongoClient.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class ScrapperController : Controller
    {
        private readonly HttpClient _httpClient=new HttpClient();

        [HttpGet("searchMC")]
        public async Task<string> scrapMetroCuadrado( string json_option, string ApiKey)
        {
            _httpClient.DefaultRequestHeaders.Add("X-Api-Key", ApiKey);
            string url = "https://www.metrocuadrado.com/rest-search/search";
            var response = await _httpClient.GetAsync(url+"?"+json_option);
            return await response.Content.ReadAsStringAsync();
        }    
            
    }
}
