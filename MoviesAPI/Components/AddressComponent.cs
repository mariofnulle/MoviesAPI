using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Components
{
    public class AddressComponent : IAddress
    {
        private readonly AppDbContext _context;

        public AddressComponent(AppDbContext context)
        {
            _context = context;
        }

        #region GetAllAddress

        public IEnumerable<Address> GetAllAddress()
        {
            try
            {
                return _context.Addresses;

            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        public IEnumerable<Address> GetAllAddress(string addressName, string neighbordhood, int? number)
        {
            try
            {
                IEnumerable<Address> AddressesList = _context.Addresses;

                if (!string.IsNullOrEmpty(addressName))
                    AddressesList = AddressesList.Where(Address => Address.AddressName.Contains(addressName));

                if (!string.IsNullOrEmpty(neighbordhood))
                    AddressesList = AddressesList.Where(Address => Address.Neighborhood.Contains(neighbordhood));

                if (number != null && number > 0)
                    AddressesList = AddressesList.Where(Address => Address.Number == number);

                return AddressesList;

            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region GetAddressById

        public Address GetAddressById(int id)
        {
            try
            {
                return _context.Addresses.FirstOrDefault(Address => Address.Id == id);

            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region AddAddress

        public void AddAddress(Address Address)
        {
            try
            {
                _context.Addresses.Add(Address);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("An error ocurred when adding a new Address.");
            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region UpdateAddress

        public void UpdateAddress(Address Address)
        {
            try
            {
                _context.Addresses.Update(Address);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("An error ocurred when updating the Address.");
            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region DeleteAddress

        public void DeleteAddress(int id)
        {
            try
            {
                Address Address = GetAddressById(id);

                if (Address == null)
                    throw new DbUpdateException();

                _context.Addresses.Remove(Address);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("An error ocurred when removing the Address.");
            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

    }
}
