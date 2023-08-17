using FluentValidation;
using MusicLibrary.Application.Utils;
using MusicLibrary.Core.Contracts.Services;
using MusicLibrary.Core.Models;
using MusicLibrary.Core.Models.Nulls;

namespace MusicLibrary.Application.Commands.Users.AccessToken;

public class CreateAccessTokenValidator : AbstractValidator<CreateAccessTokenCommand>
{
    public CreateAccessTokenValidator(User user, ISecurityService securityService)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(command => command.Username)
            .NotEmpty()
            .WithMessage(command => ValidationFailureMessages.ForEmptyProperty(nameof(command.Username)))
            .Must((_, _) => user is not NullUser)
            .WithMessage(command => ValidationFailureMessages.ForRecordNotFound(command.Username));

        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage(command => ValidationFailureMessages.ForEmptyProperty(nameof(command.Password)))
            .Must(password => securityService.ValidatePassword(password, user.Password, user.PasswordSalt))
            .WithMessage("Wrong password.");
    }
}
