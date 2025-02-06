using JasperFx.Core;
using Wolverine;

namespace SagaExample.Messages;

// This message will always be scheduled to be delivered after
// a one minute delay
public record OrderTimeout(string Id) : TimeoutMessage(1.Minutes());
