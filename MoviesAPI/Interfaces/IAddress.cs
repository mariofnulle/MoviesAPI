using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Interfaces
{
    public interface IAddress
    {
        public IEnumerable<Address> GetAllAddress();
        public IEnumerable<Address> GetAllAddresss(string addressName, string neighbordhood, int? number);
        public Address GetAddressById(int id);
        public void AddAddress(Address Address);
        public void UpdateAddress(Address Address);
        public void DeleteAddress(int id);
    }
}
