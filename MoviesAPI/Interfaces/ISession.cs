using FluentResults;
using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Interfaces
{
    public interface ISession
    {
        public List<Session> GetAllSessions();
        public List<Session> GetAllSessions(int? theatherId, int? movieId);
        public Session GetSessionById(int id);
        public void AddSession(Session Session);
        public void UpdateSession(Session Session);
        public Result DeleteSession(int id);
    }
}
