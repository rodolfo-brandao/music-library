using FluentValidation;
using MusicLibrary.Application.Utils;
using MusicLibrary.Core.Contracts.Services;
using MusicLibrary.Core.Models.Nulls;

namespace MusicLibrary.Application.Commands.Users.CreateUser;

internal class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
    private const ushort UsernameMaxLength = 50;
    private const ushort PasswordMinLength = 6;

    public CreateUserValidator(ISecurityService securityService)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(command => command.Username)
            .NotEmpty()
            .WithMessage(command => ValidationFailureMessages.ForEmptyProperty(nameof(command.Username)))
            .MaximumLength(UsernameMaxLength)
            .WithMessage(command =>
                ValidationFailureMessages.ForExceededMaxLength(nameof(command.Username), UsernameMaxLength))
            .MustAsync(async (username, _) => await securityService.GetUserAsync(username) is NullUser)
            .WithMessage(command =>
                ValidationFailureMessages.ForRecordConflict("User", nameof(command.Username), command.Username));

        RuleFor(command => command.Password)
            .NotEmpty()
            .WithMessage(command => ValidationFailureMessages.ForEmptyProperty(nameof(command.Password)))
            .MinimumLength(PasswordMinLength)
            .WithMessage(command =>
                ValidationFailureMessages.ForMinimumLengthRequirement(nameof(command.Password), PasswordMinLength));
    }
}