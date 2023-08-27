using MediatR;
using Microsoft.AspNetCore.Http;
using MusicLibrary.Application.Responses.Genres;
using MusicLibrary.Application.Utils;
using MusicLibrary.Core.Contracts.Repositories;
using MusicLibrary.Core.Contracts.Units;
using MusicLibrary.Core.Factories;
using Serilog;

namespace MusicLibrary.Application.Commands.Genres.CreateGenre;

public class CreateGenreHandler : IRequestHandler<CreateGenreCommand, ApiResult<CreatedGenreResponse>>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IModelFactory _modelFactory;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger _logger;

    public CreateGenreHandler(IGenreRepository genreRepository, IModelFactory modelFactory, IUnitOfWork unitOfWork,
        ILogger logger)
    {
        _genreRepository = genreRepository;
        _modelFactory = modelFactory;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<ApiResult<CreatedGenreResponse>> Handle(CreateGenreCommand request,
        CancellationToken cancellationToken)
    {
        var apiResult = new ApiResult<CreatedGenreResponse>(statusCode: StatusCodes.Status201Created);
        var validation = await new CreateGenreValidator(_genreRepository).ValidateAsync(request, cancellationToken);

        if (!validation.IsValid)
        {
            var errorMessage = validation.Errors.Single().ErrorMessage;
            apiResult.StatusCode = StatusCodes.Status400BadRequest;
            apiResult.ErrorMessage = errorMessage;

            _logger.Debug("An error occurred while trying to create genre. Reason: {ErrorMessage}",
                errorMessage);
        }
        else
        {
            var genre = await _genreRepository.InsertAsync(_modelFactory.CreateGenre(request.Name));
            _ = await _unitOfWork.SaveChangesAsync();
            apiResult.Response = new CreatedGenreResponse
            {
                Id = genre.Id,
                Name = genre.Name,
                CreatedOn = genre.CreatedAt
            };
        }

        return apiResult;
    }
}