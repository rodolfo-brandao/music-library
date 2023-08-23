using MediatR;
using Microsoft.AspNetCore.Http;
using MusicLibrary.Application.Responses.Users;
using MusicLibrary.Application.Utils;
using MusicLibrary.Core.Contracts.Services;
using MusicLibrary.Core.Factories;
using Serilog;

namespace MusicLibrary.Application.Commands.Users.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, ApiResult<CreatedUserResponse>>
{
    private readonly ISecurityService _securityService;
    private readonly ModelFactory _modelFactory;
    private readonly ILogger _logger;

    public CreateUserHandler(ISecurityService securityService, ILogger logger)
    {
        _securityService = securityService;
        _modelFactory = new ModelFactory();
        _logger = logger;
    }

    public async Task<ApiResult<CreatedUserResponse>> Handle(CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        _logger.Debug("Preparing to create new user with username: {Username}", request.Username);

        var apiResult = new ApiResult<CreatedUserResponse>(statusCode: StatusCodes.Status201Created);
        var validation = await new CreateUserValidator(_securityService).ValidateAsync(request, cancellationToken);

        if (!validation.IsValid)
        {
            var errorMessage = validation.Errors.Single().ErrorMessage;
            apiResult.StatusCode = StatusCodes.Status400BadRequest;
            apiResult.ErrorMessage = errorMessage;

            _logger.Debug("An error occurred while trying to create user. Reason: {ErrorMessage}",
                errorMessage);
        }
        else
        {
            var (password, passwordSalt) = _securityService.CreatePasswordHash(request.Password);
            var user = _modelFactory.CreateUser(
                username: request.Username,
                password: password,
                passwordSalt: passwordSalt,
                role: request.IsAdmin ? AuthorizationRoles.Admin : AuthorizationRoles.User);

            _ = await _securityService.CreateUserAsync(user);

            apiResult.Response = new CreatedUserResponse
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
                CreatedAt = user.CreatedAt
            };

            _logger.Debug("User '{Username}' created successfully.", user.Username);
        }

        return apiResult;
    }
}