using Microsoft.AspNetCore.Mvc;
using LI.BookService.Core.Interfaces;
using System.Threading.Tasks;
using LI.BookService.Model.DTO;

namespace LI.BookService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeConfirmationController : ControllerBase
    {
        private IExchangeConfirmationService _exchangeConfirmationService;

        public ExchangeConfirmationController (IExchangeConfirmationService exchangeConfirmationService)
        {
            _exchangeConfirmationService = exchangeConfirmationService;
        }

        /// <summary>
        /// подтверждение варианта для обмена
        /// </summary>
        /// <param name="exchangeConfirmationDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ConfirmExchange([FromBody] ExchangeConfirmationDTO exchangeConfirmationDTO)
        {
            await _exchangeConfirmationService.ConfirmExchangeAsync(exchangeConfirmationDTO);
            return Ok();
        }
    }
}