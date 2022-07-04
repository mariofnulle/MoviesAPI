using AutoMapper;
using MoviesAPI.Data.Dtos.Session;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<CreateSessionDto, Session>();
            CreateMap<UpdateSessionDto, Session>();
            CreateMap<Session, ReadSessionDto>()
                .ForMember(session => session.StartTime, opts => opts
                .MapFrom(session => session.EndingTime.AddMinutes(session.Movie.Duration * (-1))));
        }
    }
}
