using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchApp.Api.Contracts;
using SearchApp.Api.Models;

namespace SearchApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchApi _searchApi;

        public SearchController(ISearchApi searchApi)
        {
            _searchApi = searchApi;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] SearchRequest request)
        {
            var response = await _searchApi.Search(request);
            return Ok(response);

        }
    }
}