using MediatR;

namespace BasketService.Application.Features.AddBasket
{
    public class AddBasketRequest : IRequest<AddBasketResponse>
    {
        public string BuyerId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
