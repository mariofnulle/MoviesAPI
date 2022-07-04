using AutoMapper;
using MoviesAPI.Data.Dtos.Manager;
using MoviesAPI.Models;
using System.Linq;

namespace MoviesAPI.Profiles
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<CreateManagerDto, Manager>();
            CreateMap<UpdateManagerDto, Manager>();
            CreateMap<Manager, ReadManagerDto>()
                .ForMember(manager => manager.MovieTheathers, opts => opts
                .MapFrom(manager => manager.MovieTheathers.Select
                (mt => new {mt.Id, mt.Name, mt.Address, mt.AddressId})));
        }
    }
}
