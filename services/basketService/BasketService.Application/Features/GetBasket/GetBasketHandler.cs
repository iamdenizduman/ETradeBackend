using BasketService.Application.Caching.Interfaces;
using BasketService.Application.Dtos;
using MediatR;

namespace BasketService.Application.Features.GetBasket
{
    public class GetBasketHandler : IRequestHandler<GetBasketRequest, GetBasketResponse>
    {
        readonly IBasketCache _basketCache;

        public GetBasketHandler(IBasketCache basketCache)
        {
            _basketCache = basketCache;
        }

        public async Task<GetBasketResponse> Handle(GetBasketRequest request, CancellationToken cancellationToken)
        {
            string errMsg = string.Empty;
            try
            {
                var basket = await _basketCache.GetByBuyerIdAsync(request.BuyerId);
                if (basket == null)
                {
                    return new GetBasketResponse
                    {
                        isSuccess = true,
                        BasketItemDtos = null,
                        BuyerId = request.BuyerId,
                        text = "Sepet boş"
                    };
                }

                return new GetBasketResponse
                {
                    isSuccess = true,
                    BasketItemDtos = basket.Items.Select(item => new BasketItemDto
                    {
                        ProductId = item.ProductId,
                        ProductName = item.ProductName,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    }).ToList(),
                    BuyerId = request.BuyerId
                };
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            return new GetBasketResponse
            {
                isSuccess = false,
                text = errMsg
            };
        }
    }
}
