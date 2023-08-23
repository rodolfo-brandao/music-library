using MediatR;
using Microsoft.AspNetCore.Http;
using MusicLibrary.Application.Responses.Users;
using MusicLibrary.Application.Utils;
using MusicLibrary.Core.Contracts.Services;
using Serilog;

namespace MusicLibrary.Application.Commands.Users.AccessToken;

public class CreateAccessTokenHandler : IRequestHandler<CreateAccessTokenCommand, ApiResult<CreatedAccessTokenResponse>>
{
    private readonly ISecurityService _securityService;
    private readonly ILogger _logger;

    public CreateAccessTokenHandler(ISecurityService securityService, ILogger logger)
    {
        _securityService = securityService;
        _logger = logger;
    }

    public async Task<ApiResult<CreatedAccessTokenResponse>> Handle(CreateAccessTokenCommand request,
        CancellationToken cancellationToken)
    {
        _logger.Debug("Preparing to create access token for user: {Username}", request.Username);

        var apiResult = new ApiResult<CreatedAccessTokenResponse>();
        var user = await _securityService.GetUserAsync(request.Username);
        var validation =
            await new CreateAccessTokenValidator(user, _securityService).ValidateAsync(request, cancellationToken);

        if (!validation.IsValid)
        {
            var errorMessage = validation.Errors.Single().ErrorMessage;
            apiResult.StatusCode = StatusCodes.Status400BadRequest;
            apiResult.ErrorMessage = errorMessage;

            _logger.Debug("An error occurred while trying to create the access token. Reason: {ErrorMessage}",
                errorMessage);
        }
        else
        {
            const ushort oneHourInSeconds = 3600;
            apiResult.Response = new CreatedAccessTokenResponse
            {
                AccessToken = _securityService.CreateUserAccessToken(user),
                TokenType = "Bearer",
                ExpiresIn = oneHourInSeconds
            };

            _logger.Debug("Access token created successfully for user: {Username}", request.Username);
        }

        return apiResult;
    }
}