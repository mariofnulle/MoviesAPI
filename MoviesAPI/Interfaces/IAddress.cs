using FluentResults;
using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Interfaces
{
    public interface IAddress
    {
        public List<Address> GetAllAddress();
        public List<Address> GetAllAddress(string addressName, string neighbordhood, int? number);
        public Address GetAddressById(int id);
        public void AddAddress(Address Address);
        public void UpdateAddress(Address Address);
        public Result DeleteAddress(int id);
    }
}
