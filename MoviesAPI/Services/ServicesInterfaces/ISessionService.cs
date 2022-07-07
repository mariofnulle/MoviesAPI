using FluentResults;
using MoviesAPI.Data.Dtos.Session;
using MoviesAPI.Models;
using System.Collections.Generic;

namespace MoviesAPI.Services.ServicesInterfaces
{
    public interface ISessionService
    {
        public List<Session> GetAllSessions();
        public List<Session> GetAllSessions(int? theatherId, int? movieId);
        public ReadSessionDto GetSessionById(int id);
        public ReadSessionDto AddSession(CreateSessionDto newMovie);
        public Result UpdateSession(int id, UpdateSessionDto updateMovie);
        public Result DeleteSession(int id);
    }
}
