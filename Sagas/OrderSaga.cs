using JasperFx.Core;
using SagaExample.Messages;
using Wolverine;

namespace SagaExample.Sagas;

#region sample_Order_saga

public class Order : Saga
{
    public string? Id { get; set; }

    #region sample_starting_a_saga_inside_a_handler

    // This method would be called when a StartOrder message arrives
    // to start a new Order
    public static (Order, OrderTimeout) Start(StartOrder order, ILogger<Order> logger)
    {
        logger.LogInformation("Got a new order with id {Id}", order.OrderId);

        // creating a timeout message for the saga
        return (new Order{Id = order.OrderId}, new OrderTimeout(order.OrderId));
    }

    #endregion

    #region sample_using_saga_mark_completed

    // Apply the CompleteOrder to the saga
    public void Handle(CompleteOrder complete, ILogger<Order> logger)
    {
        logger.LogInformation("Completing order {Id}", complete.Id);

        // That's it, we're done. Delete the saga state after the message is done.
        MarkCompleted();
    }

    #endregion

    #region sample_handling_a_timeout_message

    // Delete this order if it has not already been deleted to enforce a "timeout"
    // condition
    public void Handle(OrderTimeout timeout, ILogger<Order> logger)
    {
        logger.LogInformation("Applying timeout to order {Id}", timeout.Id);

        // That's it, we're done. Delete the saga state after the message is done.
        MarkCompleted();
    }

    #endregion

    #region sample_using_not_found

    public static void NotFound(CompleteOrder complete, ILogger<Order> logger)
    {
        logger.LogInformation("Tried to complete order {Id}, but it cannot be found", complete.Id);
    }

    #endregion
}

#endregion