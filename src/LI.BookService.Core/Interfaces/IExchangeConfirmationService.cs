using LI.BookService.Model.DTO;
using System.Threading.Tasks;

namespace LI.BookService.Core.Interfaces
{
    public interface IExchangeConfirmationService
    {
        /// <summary>
        /// подвтерждение варианта для обмена
        /// </summary>
        /// <returns></returns>
        Task ConfirmExchangeAsync(ExchangeConfirmationDTO exchangeConfirmationDTO);
    }
}