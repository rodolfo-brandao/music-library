using FluentValidation;
using MusicLibrary.Application.Utils;
using MusicLibrary.Core.Contracts.Repositories;

namespace MusicLibrary.Application.Commands.Genres.CreateGenre;

public class CreateGenreValidator : AbstractValidator<CreateGenreCommand>
{
    private const ushort MaxNameLength = 50;

    public CreateGenreValidator(IGenreRepository genreRepository)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage(command => ValidationFailureMessages.ForEmptyProperty(nameof(command.Name)))
            .MaximumLength(MaxNameLength)
            .WithMessage(command => ValidationFailureMessages.ForExceededMaxLength(nameof(command.Name), MaxNameLength))
            .MustAsync(async (name, _) => !await genreRepository.ExistsAsync(genre => genre.Name.Equals(name)))
            .WithMessage(command =>
                ValidationFailureMessages.ForRecordConflict("Genre", nameof(command.Name), command.Name));
    }
}