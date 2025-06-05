using BasketService.Application.Dtos;
using Shared.Entity.Abstracts;

namespace BasketService.Application.Features.GetBasket
{
    public class GetBasketResponse : BaseResponse
    {
        public string BuyerId { get; set; }
        public List<BasketItemDto> BasketItemDtos { get; set; }
    }
}
