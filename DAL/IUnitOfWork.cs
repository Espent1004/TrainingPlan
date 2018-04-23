using DAL.GenericRepository;

namespace DAL

{
    public interface IUnitOfWork
    {
        #region Properties
        GenericRepository<Model.Database.Activity, Model.Domain.Activity> ActivityRepository { get; }
        GenericRepository<Model.Database.ActivityType, Model.Domain.ActivityType> ActivityTypeRepository { get; }
        GenericRepository<Model.Database.Comment, Model.Domain.Comment> CommentRepository { get; }
        GenericRepository<Model.Database.Users, Model.Domain.Users> UserRepository { get; }
        GenericRepository<Model.Database.Status, Model.Domain.Status> StatusRepository { get; }



        #region Public methods
        /// <summary>
        /// Save method.
        /// </summary>
        void Save(bool validateOnSave = true);


        void Dispose();

        #endregion

    }
}