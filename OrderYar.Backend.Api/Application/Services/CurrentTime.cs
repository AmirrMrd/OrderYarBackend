using OrderYar.Backend.Api.Application.Common.Interfaces;

namespace OrderYar.Backend.Api.Application.Services;

public class CurrentTime : ICurrentTime
{
    public DateTime GetCurrentTime() => DateTime.UtcNow;
}
