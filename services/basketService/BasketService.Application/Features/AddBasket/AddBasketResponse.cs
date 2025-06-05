using Shared.Entity.Abstracts;

namespace BasketService.Application.Features.AddBasket
{
    public class AddBasketResponse : BaseResponse
    {
        public string BuyerId { get; set; }
    }
}
