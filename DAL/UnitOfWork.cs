using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.GenericRepository;
using Model.Database;
using Model.Domain;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private TpContext _context = null;

        private GenericRepository<Model.Database.Activity, Model.Domain.Activity> _activityRepository;
        private GenericRepository<Model.Database.Status, Model.Domain.Status> _statusRepository;
        private GenericRepository<Model.Database.ActivityType, Model.Domain.ActivityType> _activityTypeRepository;
        private GenericRepository<Model.Database.Comment, Model.Domain.Comment> _commentRepository;
        private GenericRepository<Model.Database.Users, Model.Domain.Users> _userRepository;




        public GenericRepository<Model.Database.ActivityType, Model.Domain.ActivityType> ActivityTypeRepository
        {
            get
            {
                if (this._activityTypeRepository == null)
                    this._activityTypeRepository = new GenericRepository<Model.Database.ActivityType, Model.Domain.ActivityType>(_context);
                return _activityTypeRepository;
            }
        }
        public GenericRepository<Model.Database.Comment, Model.Domain.Comment> CommentRepository
        {
            get
            {
                if (this._commentRepository == null)
                    this._commentRepository = new GenericRepository<Model.Database.Comment, Model.Domain.Comment>(_context);
                return _commentRepository;
            }
        }
        public GenericRepository<Model.Database.Users, Model.Domain.Users> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepository<Model.Database.Users, Model.Domain.Users>(_context);
                return _userRepository;
            }
        }
        public GenericRepository<Model.Database.Status, Model.Domain.Status> StatusRepository
        {
            get
            {
                if (this._statusRepository == null)
                    this._statusRepository = new GenericRepository<Model.Database.Status, Model.Domain.Status>(_context);
                return _statusRepository;
            }
        }
        public UnitOfWork()
        {
            _context = new TpContext();
        }

        public GenericRepository<Model.Database.Activity, Model.Domain.Activity> ActivityRepository
        {
            get
            {
                if (this._activityRepository == null)
                    this._activityRepository = new GenericRepository<Model.Database.Activity, Model.Domain.Activity> (_context);
                return _activityRepository;
            }
        }

        /// <summary>
        /// Save method.
        /// </summary>
        public virtual void Save(bool validateOnSave = true)
        {
            _context.Configuration.ValidateOnSaveEnabled = validateOnSave;

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                //System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }


        private bool disposed = false;

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
