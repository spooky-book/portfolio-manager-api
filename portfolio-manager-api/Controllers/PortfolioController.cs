using Microsoft.AspNetCore.Mvc;
using portfolio_manager_api.Services;
using portfolio_manager_api_dtos;

namespace portfolio_manager_api.Controllers
{
    [ApiController]
    [Route("portfolios")]
    [Produces("application/json")]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet]
        public async Task<IActionResult> ViewAllPortfolios()
        {
            return Ok(await _portfolioService.GetAllPortfolios());
        }

        [HttpGet("{portfolioId}")]
        public IActionResult ViewSinglePortfolio(string portfolioId)
        {
            return Ok(portfolioId);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSinglePortfolio([FromBody] CreateSinglePortfolioRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var portfolio = await _portfolioService.CreatePortfolio(request.Name, request.Description);
            return Ok(portfolio);
        }

        [HttpPost("{portfolioId}/stock")]
        public async Task<IActionResult> CreateStockTransaction(string portfolioId, [FromBody] CreateStockTransactionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockHolding = await _portfolioService.CreateStockTransaction(portfolioId, request);

            return Ok(stockHolding);
        }

        [HttpGet("{portfolioId}/stock/{stockTicker}")]
        public async Task<IActionResult> CreateStockTransaction(string portfolioId, string stockTicker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockHolding = await _portfolioService.GetStockHolding(portfolioId, stockTicker);

            return Ok(stockHolding);
        }
    }
}
