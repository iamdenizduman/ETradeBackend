using MediatR;

namespace BasketService.Application.Features.GetBasket
{
    public class GetBasketRequest : IRequest<GetBasketResponse>
    {
        public string BuyerId { get; set; }
    }
}
