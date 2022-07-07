using FluentResults;
using MoviesAPI.Data.Dtos.Manager;
using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Services.ServicesInterfaces
{
    public interface IManagerService
    {
        public List<Manager> GetAllManagers();
        public List<Manager> GetAllManagers(string name);
        public ReadManagerDto GetManagerById(int id);
        public ReadManagerDto AddManager(CreateManagerDto newManager);
        public Result UpdateManager(int id, UpdateManagerDto updateManager);
        public Result DeleteManager(int id);
    }
}
