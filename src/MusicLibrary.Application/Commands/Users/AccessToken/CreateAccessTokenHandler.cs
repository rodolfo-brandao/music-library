using AutoMapper;
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
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public CreateTokenHandler(IUserRepository userRepository, ISecurityService securityService, IMapper mapper, ILogger logger)
    {
        _userRepository = userRepository;
        _securityService = securityService;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ApiResult<CreatedAccessTokenResponse>> Handle(CreateAccessTokenCommand request, CancellationToken cancellationToken)
    {
        _logger.Debug("Preparing to create access token for user '{username}'.", request.Username);

        var apiResult = new ApiResult<CreatedAccessTokenResponse>();
        var user = await _userRepository.GetByUsername(request.Username, isReadOnly: true);
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
            var response = _mapper.Map<CreatedAccessTokenResponse>(user);
            response.AccessToken = _securityService.CreateUserAccessToken(user);
            apiResult.Response = response;
            _logger.Debug("Access token created successfully for user '{username}'.", response.Username);
        }

        return apiResult;
    }
}