using FluentResults;
using MoviesAPI.Data.Dtos.Address;
using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Services.ServicesInterfaces
{
    public interface IAddressService
    {
        public List<Address> GetAllAddress();
        public List<Address> GetAllAddress(string addressName, string neighbordhood, int? number);
        public ReadAddressDto GetAddressById(int id);
        public ReadAddressDto AddAddress(CreateAddressDto newMovie);
        public Result UpdateAddress(int id, UpdateAddressDto updateMovie);
        public Result DeleteAddress(int id);
    }
}
