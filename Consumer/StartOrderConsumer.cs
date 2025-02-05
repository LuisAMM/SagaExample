namespace SagaExample.Sagas.NewDirectory1;

public class StartOrderConsumer
{
    public static void Consume(StartOrder order, ILogger<StartOrderConsumer> logger)
    {
        logger.LogInformation("Got a new order in consume with id {Id}", order.OrderId);
    }
    
    public static void Handle(StartOrder order, ILogger<StartOrderConsumer> logger)
    {
        logger.LogInformation("Got a new order in handle with id {Id}", order.OrderId);
    }
}