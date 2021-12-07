using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LI.BookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private IExchangeService _iExchangeService;

        public ExchangeController(IExchangeService iExchangeService)
        {
            _iExchangeService = iExchangeService;
        }

        /// <summary>
        /// Подбор вариантов для обмена системой
        /// </summary>
        /// <returns></returns>
        [HttpGet("variants/{exchangeListId}")]
        public async Task<ActionResult> GetVariants(int exchangeListId)
        {
            var variantes = await _iExchangeService.GetVariantesAsync(exchangeListId);
            return Ok(variantes);

        }

        /// <summary>
        /// Все входящие предложения для обмена
        /// </summary>
        /// <returns></returns>
        [HttpGet("incoming/all/{userId}")]
        public async Task<ActionResult> GetAllUserIncomingExchangeRequests(int userId)
        {
            var res = await _iExchangeService.GetAllUserIncomingExchangeRequests(userId);

            return Ok(res);
        }

        /// <summary>
        /// Входящие предложения для обмена для определенной заявки
        /// </summary>
        /// <returns></returns>
        [HttpGet("incoming/{exchangeListId}")]
        public async Task<ActionResult> GetIncomingExchangeRequests(int exchangeListId)
        {

            var res = await _iExchangeService.GetIncomingExchangeRequests(exchangeListId);

            return Ok(res);
        }
    }
}
