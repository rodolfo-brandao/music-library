using FluentValidation;

namespace MusicLibrary.Application.Queries.Genres.ListGenres;

public class ListGenreValidator : AbstractValidator<ListGenreQuery>
{
    private readonly string[] _allowedOrderParamValues = { "asc", "desc" };
    
    public ListGenreValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(query => query.OrderBy)
            .Must(orderBy => _allowedOrderParamValues.Contains(orderBy, StringComparer.OrdinalIgnoreCase))
            .WithMessage("The value of query parameter 'orderBy' must be either 'asc' or 'desc'.");
    }
}