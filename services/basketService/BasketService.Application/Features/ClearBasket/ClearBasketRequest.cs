using MediatR;

namespace BasketService.Application.Features.ClearBasket
{
    public class ClearBasketRequest : IRequest<ClearBasketResponse>
    {
        public string BuyerId { get; set; }
    }
}
