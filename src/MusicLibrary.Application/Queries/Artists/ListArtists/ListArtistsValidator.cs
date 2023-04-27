using FluentValidation;

namespace MusicLibrary.Application.Queries.Artists.ListArtists;

public class ListArtistsValidator : AbstractValidator<ListArtistsQuery>
{
    private readonly IList<string> _orderByTypes = new List<string>() { "asc", "desc" };

    public ListArtistsValidator()
    {
        RuleFor(query => query.OrderBy)
            .Must(orderBy => _orderByTypes.Contains(orderBy))
            .WithMessage("The value of query parameter 'orderBy' must be either 'asc' or 'desc'.");
    }
}