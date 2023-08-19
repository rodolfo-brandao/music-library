using FluentValidation;

namespace MusicLibrary.Application.Queries.Artists.ListArtists;

public class ListArtistsQueryValidator : AbstractValidator<ListArtistsQuery>
{
    private readonly string[] _allowedOrderParamValues = { "asc", "desc" };

    public ListArtistsQueryValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(query => query.OrderBy)
            .Must(orderBy => _allowedOrderParamValues.Contains(orderBy))
            .WithMessage("The value of query parameter 'orderBy' must be either 'asc' or 'desc'.");
    }
}
