using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data.Dtos.Session;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using MoviesAPI.Services.ServicesInterfaces;
using System;
using System.Collections.Generic;

namespace MoviesAPI.Services.ServicesComponents
{
    public class SessionService : ISessionService
    {
        private readonly IMapper _mapper;
        private readonly ISession _sessionInterface;

        public SessionService(IMapper mapper, ISession SessionInterface)
        {
            _mapper = mapper;
            _sessionInterface = SessionInterface;
        }

        #region GetAllSessions

        public List<Session> GetAllSessions()
        {
            try
            {
                return _sessionInterface.GetAllSessions();
            }
            catch(Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        public List<Session> GetAllSessions(int? theatherId, int? movieId)
        {
            try
            {
                return _sessionInterface.GetAllSessions(theatherId, movieId);
            }
            catch (Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        #endregion

        #region GetSessionById

        public ReadSessionDto GetSessionById(int id)
        {
            try
            {
                Session movie = _sessionInterface.GetSessionById(id);

                if (movie != null)
                    return _mapper.Map<ReadSessionDto>(movie);

                return null;
            }
            catch (Exception message)
            {
                throw new Exception(message.Message);
            }
        }

        #endregion

        #region AddSession

        public ReadSessionDto AddSession(CreateSessionDto newSession)
        {
            try
            {
                Session Session = _mapper.Map<Session>(newSession);
                _sessionInterface.AddSession(Session);
                return _mapper.Map<ReadSessionDto>(Session);
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

        #region UpdateSession

        public Result UpdateSession(int id, UpdateSessionDto updateMovie)
        {
            try
            {
                ReadSessionDto SessionDto = GetSessionById(id);

                if (SessionDto == null)
                    return Result.Fail("Session doesn't exist or wasn't found.");

                Session Session = _mapper.Map<Session>(SessionDto);

                _sessionInterface.UpdateSession(_mapper.Map(updateMovie, Session));

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

        #region DeleteSession

        public Result DeleteSession(int id)
        {
            try
            {
                return _sessionInterface.DeleteSession(id);
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
