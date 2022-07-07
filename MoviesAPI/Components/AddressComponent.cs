using FluentResults;
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

        public List<Address> GetAllAddress()
        {
            try
            {
                return _context.Addresses.ToList();

            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        public List<Address> GetAllAddress(string addressName, string neighbordhood, int? number)
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

                return AddressesList.ToList();

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

        public void AddAddress(Address address)
        {
            try
            {
                _context.Addresses.Add(address);
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

        public void UpdateAddress(Address address)
        {
            try
            {
                _context.Addresses.Update(address);
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

        public Result DeleteAddress(int id)
        {
            try
            {
                Address address = GetAddressById(id);

                if (address == null)
                    return Result.Fail("Address doesn't exist or wasn't found.");

                _context.Addresses.Remove(address);
                _context.SaveChanges();

                return Result.Ok();
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
