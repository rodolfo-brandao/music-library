using AutoMapper;
using MusicLibrary.Application.Responses.Artists;
using MusicLibrary.Application.Responses.Users;
using MusicLibrary.Core.Models;

namespace MusicLibrary.Application.MapperProfiles;

public class ModelToResponseProfile : Profile
{
    public ModelToResponseProfile()
    {
        CreateMap<Artist, DefaultArtistResponse>();

        CreateMap<User, CreatedAccessTokenResponse>()
            .ForMember(response => response.UserId, config => config.MapFrom(model => model.Id));
    }
}