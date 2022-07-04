using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Components
{
    public class SessionComponent : ISession
    {
        private readonly AppDbContext _context;

        public SessionComponent(AppDbContext context)
        {
            _context = context;
        }

        #region GetAllSession

        public IEnumerable<Session> GetAllSession()
        {
            try
            {
                return _context.Sessions;

            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        public IEnumerable<Session> GetAllSession(int? theatherId, int? movieId)
        {
            try
            {
                IEnumerable<Session> sessionList = _context.Sessions;

                if (theatherId != null && theatherId > 0)
                    sessionList = sessionList.Where(Session => Session.TheatherId == theatherId);

                if (movieId != null && movieId > 0)
                    sessionList = sessionList.Where(Session => Session.MovieId == movieId);

                return sessionList;

            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region GetSessionById

        public Session GetSessionById(int id)
        {
            try
            {
                return _context.Sessions.FirstOrDefault(Session => Session.Id == id);

            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region AddSession

        public void AddSession(Session Session)
        {
            try
            {
                _context.Sessions.Add(Session);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("An error ocurred when adding a new Session.");
            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region UpdateSession

        public void UpdateSession(Session Session)
        {
            try
            {
                _context.Sessions.Update(Session);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("An error ocurred when updating the Session.");
            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region DeleteSession

        public void DeleteSession(int id)
        {
            try
            {
                Session Session = GetSessionById(id);

                if (Session == null)
                    throw new DbUpdateException();

                _context.Sessions.Remove(Session);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("An error ocurred when removing the Session.");
            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

    }
}
