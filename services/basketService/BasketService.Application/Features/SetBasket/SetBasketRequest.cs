using BasketService.Application.Features.GetBasket;
using MediatR;

namespace BasketService.Application.Features.SetBasket
{
    public class SetBasketRequest : IRequest<GetBasketResponse>
    {
        public string BuyerId { get; set; }
        public string ProductId { get; set; }
    }
}
