using Microsoft.AspNetCore.Mvc;
using portfolio_manager_api.Services;
using portfolio_manager_api_dtos;

namespace portfolio_manager_api.Controllers
{
    [ApiController]
    [Route("portfolio")]
    [Produces("application/json")]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet]
        public IActionResult ViewPortfolios()
        {
            _portfolioService.Test();
            return Ok("testing what is going to happen meme");
        }

        [HttpGet("{portfolioId}")]
        public IActionResult ViewSinglePortfolio(string portfolioId)
        {
            return Ok(portfolioId);
        }

        [HttpPost]
        public IActionResult CreateSinglePortfolio([FromBody] CreateSinglePortfolioRequest request)
        {
            return Ok(request);
        }
    }
}
