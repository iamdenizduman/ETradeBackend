using BasketService.Application.Caching.Interfaces;
using MediatR;

namespace BasketService.Application.Features.ClearBasket
{
    public class ClearBasketHandler : IRequestHandler<ClearBasketRequest, ClearBasketResponse>
    {
        readonly IBasketCache _basketCache;

        public ClearBasketHandler(IBasketCache basketCache)
        {
            _basketCache = basketCache;
        }

        public async Task<ClearBasketResponse> Handle(ClearBasketRequest request, CancellationToken cancellationToken)
        {
            string errMsg = string.Empty;
            try
            {
                var basket = await _basketCache.GetByBuyerIdAsync(request.BuyerId);
                if (basket == null)
                {
                    return new ClearBasketResponse()
                    {
                        BuyerId = request.BuyerId,
                        isSuccess = true,
                        text = "Sepet zaten boş"
                    };
                }

                basket.Clear();

                await _basketCache.UpdateAsync(basket);

                return new ClearBasketResponse()
                {
                    BuyerId = request.BuyerId,
                    isSuccess = true,
                    text = "Sepet temizlendi"
                };
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;                
            }

            return new ClearBasketResponse()
            {
                BuyerId = request.BuyerId,
                isSuccess = false,
                text = errMsg
            };
        }
    }
}
