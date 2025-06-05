using Shared.Entity.Abstracts;

namespace BasketService.Application.Features.ClearBasket
{
    public class ClearBasketResponse : BaseResponse
    {
        public string BuyerId { get; set; }
    }
}
