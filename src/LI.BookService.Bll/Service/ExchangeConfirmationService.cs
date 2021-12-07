using LI.BookService.Core.Interfaces;
using LI.BookService.Model.DTO;
using System;
using System.Threading.Tasks;

namespace LI.BookService.Bll.Service
{
    public class ExchangeConfirmationService : IExchangeConfirmationService
    {
        private IExchangeConfirmationRepository _exchangeConfirmationRepository;

        /// <summary>
        /// подвтерждение варианта для обмена
        /// </summary>
        /// <returns></returns>
        public async Task ConfirmExchangeAsync(ExchangeConfirmationDTO exchangeConfirmationDTO)
        {
            var exchangeConfirmation1 = await _exchangeConfirmationRepository.GetExchangeListId(exchangeConfirmationDTO.ExchangeList1Id);
            var exchangeConfirmation2 = await _exchangeConfirmationRepository.GetExchangeListId(exchangeConfirmationDTO.ExchangeList2Id);

            //второй участник уже подтвердил обмен, теперь подтверждает первый
            if (exchangeConfirmation1.OfferList1Id == exchangeConfirmation2.OfferList2Id)
            {
                exchangeConfirmation1.OfferList2Id = exchangeConfirmation2.OfferList1Id;
                exchangeConfirmation1.WishList2Id = exchangeConfirmation2.WishList1Id;
                exchangeConfirmation1.CreateAt = DateTime.Now;
                exchangeConfirmation1.IsBoth = true;
            }
            //первый участник подтверждает обмен, второй ещё нет
            else
            {
                exchangeConfirmation1.OfferList2Id = exchangeConfirmation2.OfferList1Id;
                exchangeConfirmation1.WishList2Id = exchangeConfirmation2.WishList1Id;
                exchangeConfirmation1.CreateAt = DateTime.Now;
            }

            await _exchangeConfirmationRepository.UpdateAsync(exchangeConfirmation1);
            await _exchangeConfirmationRepository.UpdateAsync(exchangeConfirmation2);
        }
    }
}
