using SagaExample.Messages;

namespace SagaExample.Consumer;

public class CompleteOrderConsumer
{
    public static void Consume(CompleteOrder order, ILogger<CompleteOrderConsumer> logger)
    {
        logger.LogInformation("Got a new order in consume with id {Id}", order.Id);
    }
    
    public static void Handle(CompleteOrder order, ILogger<CompleteOrderConsumer> logger)
    {
        logger.LogInformation("Got a new order in handle with id {Id}", order.Id);
    }
}