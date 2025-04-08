using MassTransit;
using ServiceDefaults.Messaging;

namespace Basket.EventHandlers;

public class ProductPriceChangeIntegrationEventHandler(BasketService service)
    : IConsumer<ProductPriceChangeIntegrationEvent>

{
    public async Task Consume(ConsumeContext<ProductPriceChangeIntegrationEvent> context)
    {
        await service.UpdateBasketItemProductPrices(context.Message.ProductId,
            context.Message.Price);
    }
}
