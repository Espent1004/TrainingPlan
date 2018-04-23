using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace DAL.GenericRepository
{
    public class GenericRepository<TEntity, TModel>
        where TEntity : class
        where TModel : class
    {
        internal TpContext Context;
        internal DbSet<TEntity> DbSet;


        /// <summary>
        /// Public Constructor,initializes privately declared local variables.
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository(TpContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TEntity>();
        }


        /// <summary>
        /// Generic get method on the basis of id for Entities.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TModel GetByID(object id)
        {
            var dbModel = DbSet.Find(id);

            return Mapper.Map<TEntity, TModel>(dbModel);
        }


        public virtual TModel GetByID(object id, params Expression<Func<TEntity, object>>[] includes)
        {
            //Find Key property of the TEntity
            var adapter = (IObjectContextAdapter)Context;
            var objectContext = adapter.ObjectContext;
            var objectSet = objectContext.CreateObjectSet<TEntity>();
            var primaryKey = objectSet.EntitySet.ElementType
                .KeyMembers[0];


            //Create lambda expression
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var member = Expression.Property(parameter, primaryKey.Name); //x.Id

            var constant = Expression.Constant(id);
            var convertConstant =
                Expression.Convert(constant, typeof(TEntity).GetProperty(primaryKey.Name).PropertyType);

            var body = Expression.Equal(member, convertConstant);
            var finalExpression = Expression.Lambda<Func<TEntity, bool>>(body, parameter);


            //Include entities and get data.
            IQueryable<TEntity> query = this.DbSet.Where(finalExpression);
            query = includes.Aggregate(query, (current, inc) => current.Include(inc));

            var dbModel = query.FirstOrDefault();

            return Mapper.Map<TEntity, TModel>(dbModel);
        }

        /// <summary>
        /// generic get method , fetches data for the entities on the basis of condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual TModel Get(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = this.DbSet.Where(where);

            query = includes.Aggregate(query, (current, inc) => current.Include(inc));

            var dbModel = query.FirstOrDefault<TEntity>();

            return Mapper.Map<TEntity, TModel>(dbModel);
        }


        /// <summary>
        /// generic method to get many record on the basis of a condition.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual IEnumerable<TModel> GetMany(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = this.DbSet.Where(where);
            query = includes.Aggregate(query, (current, inc) => current.Include(inc));

            IEnumerable<TEntity> dbList = query.ToList();

            IEnumerable<TModel> modelList = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(dbList);

            return modelList;
        }


        /// <summary>
        /// generic method to fetch all the records from db
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TModel> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = this.DbSet;
            query = includes.Aggregate(query, (current, inc) => current.Include(inc));
            var dbList = query.ToList();

            return Mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(dbList);
        }

        /// <summary>
        /// Generic update method for the entities
        /// </summary>
        /// <param name="entityToUpdate"></param>
        public virtual void Update(object id, TModel modelToUpdate)
        {
            var entityToUpdate = DbSet.Find(id);
            Mapper.Map(modelToUpdate, entityToUpdate);

            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        /// <summary>
        /// generic Insert method for the entities
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TModel model)
        {
            var dbEntity = Mapper.Map<TModel, TEntity>(model);

            DbSet.Add(dbEntity);
        }

    }
}