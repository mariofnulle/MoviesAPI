using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Interfaces
{
    public interface IManager
    {
        public IEnumerable<Manager> GetAllManagers();
        public IEnumerable<Manager> GetAllManagers(string name);
        public Manager GetManagerById(int id);
        public void AddManager(Manager movie);
        public void UpdateManager(Manager movie);
        public void DeleteManager(int id);
    }
}
