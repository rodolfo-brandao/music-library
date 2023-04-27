using AutoMapper;
using MusicLibrary.Application.Responses.Artists;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Application.MapperProfiles;

public class ModelToResponseProfile : Profile
{
    public ModelToResponseProfile()
    {
        CreateMap<Artist, DefaultArtistResponse>();
    }
}