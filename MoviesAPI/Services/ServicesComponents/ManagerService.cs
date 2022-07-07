using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data.Dtos.Manager;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using MoviesAPI.Services.ServicesInterfaces;
using System;
using System.Collections.Generic;

namespace MoviesAPI.Services.ServicesComponents
{
    public class ManagerService : IManagerService
    {
        private readonly IMapper _mapper;
        private readonly IManager _ManagerInterface;

        public ManagerService(IMapper mapper, IManager ManagerInterface)
        {
            _mapper = mapper;
            _ManagerInterface = ManagerInterface;
        }

        #region GetAllManagers

        public List<Manager> GetAllManagers()
        {
            try
            {
                return _ManagerInterface.GetAllManagers();
            }
            catch(Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        public List<Manager> GetAllManagers(string movieName)
        {
            try
            {
                return _ManagerInterface.GetAllManagers(movieName);
            }
            catch (Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        #endregion

        #region GetManagerById

        public ReadManagerDto GetManagerById(int id)
        {
            try
            {
                Manager movie = _ManagerInterface.GetManagerById(id);

                if (movie != null)
                    return _mapper.Map<ReadManagerDto>(movie);

                return null;
            }
            catch (Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        #endregion

        #region AddManager

        public ReadManagerDto AddManager(CreateManagerDto newManager)
        {
            try
            {
                Manager Manager = _mapper.Map<Manager>(newManager);
                _ManagerInterface.AddManager(Manager);
                return _mapper.Map<ReadManagerDto>(Manager);
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

        #region UpdateManager

        public Result UpdateManager(int id, UpdateManagerDto updateManager)
        {
            try
            {
                ReadManagerDto ManagerDto = GetManagerById(id);

                if (ManagerDto == null)
                    return Result.Fail("Manager doesn't exist or wasn't found.");

                Manager Manager = _mapper.Map<Manager>(ManagerDto);

                _ManagerInterface.UpdateManager(_mapper.Map(updateManager, Manager));

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

        #region DeleteManager

        public Result DeleteManager(int id)
        {
            try
            {
                return _ManagerInterface.DeleteManager(id);
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
