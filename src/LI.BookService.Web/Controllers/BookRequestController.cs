using LI.BookService.Bll.Helpers;
using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace LI.BookService.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookRequestController : ControllerBase
    {
        private IBookRequestService _bookRequestService;

        public BookRequestController(IBookRequestService bookRequestService)
        {
            _bookRequestService = bookRequestService;
        }

        /// <summary>
        /// получение всех заявок пользователя для обмена книг
        /// </summary>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<ActionResult> GetAllUserBookRequests(int userId)
        {
            var listRequestUser = await _bookRequestService.GetAllUserBookRequests(userId);
            return Ok(listRequestUser);
        }

        /// <summary>
        /// создание заявки на получение книги
        /// </summary>
        /// <param name="dtoNewRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateRequestBook([FromBody] DtoNewRequest dtoNewRequest)
        {
            if (dtoNewRequest != null)
            {
                var requestBook = await _bookRequestService.CreateRequestBook(dtoNewRequest);
                return Ok(requestBook);
            }
            else
            {
                return BadRequest();
            }

        }

        /// <summary>
        ///  редактирование заявки для получения книги
        /// </summary>
        /// <param name="requestBook"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<OfferListDto>> UpdateUserBookRequest([FromBody] OfferListDto requestBook)
        {
            try
            {
                if (requestBook != null)
                {
                    await _bookRequestService.EditRequestBookAsync(requestBook);

                    return Ok();
                }
                return BadRequest("некорректный id заявки");

            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }


        /// <summary>
        /// удаление заявки для получения книги
        /// </summary>
        /// <param name="exchangeListId"></param>
        /// <returns></returns>
        [HttpDelete("delete/{exchangeListId}")]
        public async Task<ActionResult> Delete(int exchangeListId)
        {
            try
            {
                await _bookRequestService.RemoveBookRequest(exchangeListId);

                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

    }

}
