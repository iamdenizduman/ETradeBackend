using BasketService.Application.Caching.Interfaces;
using BasketService.Domain.Entities;
using MediatR;

namespace BasketService.Application.Features.AddBasket
{
    public class AddBasketHandler : IRequestHandler<AddBasketRequest, AddBasketResponse>
    {
        readonly IBasketCache _basketCache;

        public AddBasketHandler(IBasketCache basketCache)
        {
            _basketCache = basketCache;
        }

        public async Task<AddBasketResponse> Handle(AddBasketRequest request, CancellationToken cancellationToken)
        {
            string errMsg = string.Empty;
            try
            {
                var basket = await _basketCache.GetByBuyerIdAsync(request.BuyerId);

                if (basket == null)
                    basket = new Basket(request.BuyerId);

                basket.AddItem(request.ProductId, request.ProductName, request.UnitPrice, request.Quantity);

                await _basketCache.UpdateAsync(basket);
                
                return new AddBasketResponse
                {
                    BuyerId = request.BuyerId,
                    isSuccess = true,
                    text = errMsg
                };
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;                                
            }

            return new AddBasketResponse
            {
                BuyerId = request.BuyerId,
                isSuccess = false,
                text = errMsg
            };
        }
    }
}
