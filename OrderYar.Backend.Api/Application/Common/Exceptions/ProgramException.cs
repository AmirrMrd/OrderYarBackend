using OrderYar.Backend.Api.Domain.Constants;

namespace OrderYar.Backend.Api.Application.Common.Exceptions;

public static class ProgramException
{
    public static UserFriendlyException AppsettingNotSetException()
        => new(ErrorCode.Internal, ErrorMessage.AppConfigurationMessage, ErrorMessage.Internal);
}
