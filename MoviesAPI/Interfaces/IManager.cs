using FluentResults;
using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Interfaces
{
    public interface IManager
    {
        public List<Manager> GetAllManagers();
        public List<Manager> GetAllManagers(string name);
        public Manager GetManagerById(int id);
        public void AddManager(Manager movie);
        public void UpdateManager(Manager movie);
        public Result DeleteManager(int id);
    }
}
