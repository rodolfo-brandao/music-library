using MediatR;
using Microsoft.AspNetCore.Http;
using MusicLibrary.Application.Responses.Users;
using MusicLibrary.Application.Utils;
using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Contracts.Services;
using Serilog;

namespace MusicLibrary.Application.Commands.Users.AccessToken;

public class CreateTokenHandler : IRequestHandler<CreateAccessTokenCommand, ApiResult<CreatedAccessTokenResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly ISecurityService _securityService;
    private readonly ILogger _logger;

    public CreateTokenHandler(IUserRepository userRepository, ISecurityService securityService, ILogger logger)
    {
        _userRepository = userRepository;
        _securityService = securityService;
        _logger = logger;
    }

    public async Task<ApiResult<CreatedAccessTokenResponse>> Handle(CreateAccessTokenCommand request, CancellationToken cancellationToken)
    {
        _logger.Debug("Preparing to create access token for user: {Username}", request.Username);

        var apiResult = new ApiResult<CreatedAccessTokenResponse>();
        var user = await _userRepository.GetByUsernameAsync(request.Username, isReadOnly: true);
        var validation = await new CreateAccessTokenValidator(user, _securityService).ValidateAsync(request, cancellationToken);

        if (!validation.IsValid)
        {
            var errorMessage = validation.Errors.First().ErrorMessage;
            _logger.Debug(errorMessage, request.Username);
            apiResult.StatusCode = StatusCodes.Status400BadRequest;
            apiResult.ErrorMessage = errorMessage;
        }
        else
        {
            apiResult.Response = new CreatedAccessTokenResponse
            {
                UserId = user.Id,
                Username = user.Username,
                AccessToken = _securityService.CreateUserAccessToken(user)
            };

            _logger.Debug("Access token created successfully for user: {Username}", request.Username);
        }

        return apiResult;
    }
}
