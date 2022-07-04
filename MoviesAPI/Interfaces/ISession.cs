using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Interfaces
{
    public interface ISession
    {
        public IEnumerable<Session> GetAllSession();
        public IEnumerable<Session> GetAllSession(int? theatherId, int? movieId);
        public Session GetSessionById(int id);
        public void AddSession(Session Session);
        public void UpdateSession(Session Session);
        public void DeleteSession(int id);
    }
}
