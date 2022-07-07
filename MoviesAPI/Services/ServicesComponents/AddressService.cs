using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data.Dtos.Address;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using MoviesAPI.Services.ServicesInterfaces;
using System;
using System.Collections.Generic;

namespace MoviesAPI.Services.ServicesComponents
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IAddress _AddressInterface;

        public AddressService(IMapper mapper, IAddress AddressInterface)
        {
            _mapper = mapper;
            _AddressInterface = AddressInterface;
        }

        #region GetAllAddresss

        public List<Address> GetAllAddress()
        {
            try
            {
                return _AddressInterface.GetAllAddress();
            }
            catch(Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        public List<Address> GetAllAddress(string addressName, string neighbordhood, int? number)
        {
            try
            {
                return _AddressInterface.GetAllAddress(addressName, neighbordhood, number);
            }
            catch (Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        #endregion

        #region GetAddressById

        public ReadAddressDto GetAddressById(int id)
        {
            try
            {
                Address movie = _AddressInterface.GetAddressById(id);

                if (movie != null)
                    return _mapper.Map<ReadAddressDto>(movie);

                return null;
            }
            catch (Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        #endregion

        #region AddAddress

        public ReadAddressDto AddAddress(CreateAddressDto newAddress)
        {
            try
            {
                Address Address = _mapper.Map<Address>(newAddress);
                _AddressInterface.AddAddress(Address);
                return _mapper.Map<ReadAddressDto>(Address);
            }
            catch (DbUpdateException message)
            {
                throw new DbUpdateException(message.Message);
            }
            catch (Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        #endregion

        #region UpdateAddress

        public Result UpdateAddress(int id, UpdateAddressDto updateAddress)
        {
            try
            {
                ReadAddressDto AddressDto = GetAddressById(id);

                if (AddressDto == null)
                    return Result.Fail("Movie theather doesn't exist or wasn't found.");

                Address Address = _mapper.Map<Address>(AddressDto);

                _AddressInterface.UpdateAddress(_mapper.Map(updateAddress, Address));

                return Result.Ok();
            }
            catch (DbUpdateException message)
            {
                throw new DbUpdateException(message.Message);
            }
            catch (Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        #endregion

        #region DeleteAddress

        public Result DeleteAddress(int id)
        {
            try
            {
                return _AddressInterface.DeleteAddress(id);
            }
            catch (DbUpdateException message)
            {
                throw new DbUpdateException(message.Message);
            }
            catch (Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        #endregion

    }
}
