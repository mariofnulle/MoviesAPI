﻿using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Interfaces;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesAPI.Components
{
    public class ManagerComponent : IManager
    {
        private readonly AppDbContext _context;

        public ManagerComponent(AppDbContext context)
        {
            _context = context;
        }

        #region GetAllManagers

        public IEnumerable<Manager> GetAllManagers()
        {
            try
            {
                return _context.Managers;

            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        public IEnumerable<Manager> GetAllManagers(string name)
        {
            try
            {
                IEnumerable<Manager> ManagersList = _context.Managers;

                if (!string.IsNullOrEmpty(name))
                    ManagersList = ManagersList.Where(Manager => Manager.Name.Contains(name));

                return ManagersList;

            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region GetManagerById

        public Manager GetManagerById(int id)
        {
            try
            {
                return _context.Managers.FirstOrDefault(Manager => Manager.Id == id);

            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region AddManager

        public void AddManager(Manager Manager)
        {
            try
            {
                _context.Managers.Add(Manager);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("An error ocurred when adding a new manager.");
            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region UpdateManager

        public void UpdateManager(Manager Manager)
        {
            try
            {
                _context.Managers.Update(Manager);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("An error ocurred when updating the manager.");
            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

        #region DeleteManager

        public void DeleteManager(int id)
        {
            try
            {
                Manager Manager = GetManagerById(id);

                if (Manager == null)
                    throw new DbUpdateException();

                _context.Managers.Remove(Manager);
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("An error ocurred when removing the manager.");
            }
            catch (Exception)
            {
                throw new Exception("The system encountered an error and the operation was canceled, contact your administrator.");
            }
        }

        #endregion

    }
}
