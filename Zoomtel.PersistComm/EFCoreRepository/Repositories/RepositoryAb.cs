using EFCoreRepository.DbContexts;
using EFCoreRepository.Enums;
using EFCoreRepository.Extensions;
using EFCoreRepository.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace EFCoreRepository.Repositories
{
    /// <summary>
    /// 仓储抽象类
    /// </summary>
    public class RepositoryAb<T> : IRepository<T> where T : class, new()
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        protected DefaultDbContext DbContext;
        protected DbSet<T> dbSet;

        public RepositoryAb(DefaultDbContext context)
        {
            DbContext = context;
            dbSet = DbContext.Set<T>();
        }


        public int GetSeq(string seqName)
        {
            return DbContext.GetSeq(seqName);
        }

        private void SetCreateBy(T entity)
        {
            //检查是否继承存在MdInfo 并且存在登陆信息
            if (entity is Zoomtel.Entity.EntityBaseWithMdInfo && DbContext.LoginInfo != null)
            {
               
                foreach (var column in entity.GetType().GetProperties())
                {
                    if (column.Name.Equals("ModifiedBy"))
                    {
                      
                        var accountId = DbContext.LoginInfo.Uid;
                    
                            column.SetValue(entity, accountId);
                    
                    }
                    if (column.Name.Equals("ModifiedTime"))
                    {
                        column.SetValue(entity, DateTime.Now);
                    }
                    if (column.Name.Equals("Modifier"))
                    {
                        var Modifier = DbContext.LoginInfo.LoginName;
                        column.SetValue(entity, Modifier);
                    }


                    if (column.Name.Equals("CreatedBy"))
                    {
                        var accountId = DbContext.LoginInfo.Uid;
                      
                            column.SetValue(entity, accountId);
                        

                    }
                

                    if (column.Name.Equals("CreatedTime"))
                    {
                        column.SetValue(entity, DateTime.Now);
                     
                    }
                    if (column.Name.Equals("Creator"))
                    {

                        var Creator = DbContext.LoginInfo.LoginName;
                        column.SetValue(entity, Creator);
              

                    }
                }
            }


        }

        /// <summary>
        /// 设置修改人
        /// </summary>
        /// <param name="entity"></param>
        private void SetModifiedBy(T entity)
        {
            int i = 0;
            //检查是否继承存在MdInfo 并且存在登陆信息
            if (entity is Zoomtel.Entity.EntityBaseWithMdInfo && DbContext.LoginInfo != null)
            {
                foreach (var column in entity.GetType().GetProperties())
                {
                    if (column.Name.Equals("ModifiedBy"))
                    {
                    
                        var accountId = DbContext.LoginInfo.Uid;
                    
                            column.SetValue(entity, accountId);
                            i++;

                    }
                    if (column.Name.Equals("ModifiedTime"))
                    {
                        column.SetValue(entity, DateTime.Now);
                        i++;
                    }
                    if (column.Name.Equals("Modifier"))
                    {

                        var Modifier = DbContext.LoginInfo.LoginName;
                        column.SetValue(entity, Modifier);


                        i++;

                    }

                    if (i > 2)
                        break;
                }

            }
        }

        private void SetDeleteInfo(T entity)
        {
            var i = 0;
            //检查是否继承存在MdInfo 并且存在登陆信息
            if (entity is Zoomtel.Entity.SoftDeleteInfo && DbContext.LoginInfo != null)
            {
                foreach (var column in entity.GetType().GetProperties())
                {
                    if (column.Name.Equals("Deleted"))
                    {
                        column.SetValue(entity, true);
                        i++;
                    }else if (column.Name.Equals("DeletedTime"))
                    {
                        column.SetValue(entity, DateTime.Now);
                        i++;
                    }
                    else if (column.Name.Equals("DeletedBy"))
                    {
                        var accountId = DbContext.LoginInfo.Uid;
                        column.SetValue(entity, accountId);
                        i++;
                    }
                    else if (column.Name.Equals("Deleter"))
                    {
                        var LoginName = DbContext.LoginInfo.LoginName;
                        column.SetValue(entity, LoginName);
                        i++;
                    }
                }


                }

        }


            #region 事务
            public IRepository<T> BeginTrans()
        {
            if (DbContext.Database.CurrentTransaction == null)
                DbContext.Database.BeginTransaction();

            return this;
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public virtual void Commit()
        {
            if (DbContext.Database.CurrentTransaction != null)
            {
                DbContext.Database.CommitTransaction();
                DbContext.Database.CurrentTransaction?.Dispose();
            }
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public virtual void Rollback()
        {
            if (DbContext.Database.CurrentTransaction!=null)
            {
                DbContext.Database.RollbackTransaction();
                DbContext.Database.CurrentTransaction?.Dispose();
            }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public virtual void Close()
        {
            DbContext.Database.CloseConnection();
            DbContext.Dispose();
        }

      

        #endregion

        #region Insert
        #region Sync
        /// <summary>
        ///  插入单个实体
        /// </summary>
        /// <param name="entity">要插入的实体</param>
        /// <returns>返回受影响行数</returns>
        public virtual int Insert(T entity) 
        {
            SetCreateBy(entity);

            dbSet.Add(entity);
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// 插入多个实体
        /// </summary>
        /// <param name="entities">要插入的实体集合</param>
        /// <returns>返回受影响行数</returns>
        public virtual int Insert(IEnumerable<T> entities) 
        {


            dbSet.AddRange(entities);
            return DbContext.SaveChanges();
        }
        #endregion

        #region Async
        /// <summary>
        ///  插入单个实体
        /// </summary>
        /// <param name="entity">要插入的实体</param>
        /// <returns>返回受影响行数</returns>
        public virtual async Task<int> InsertAsync(T entity) 
        {
            SetCreateBy(entity);

            await dbSet.AddAsync(entity);
            return await DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 插入多个实体
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="entities">要插入的实体集合</param>
        /// <returns>返回受影响行数</returns>
        public virtual async Task<int> InsertAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return await DbContext.SaveChangesAsync();
        }
        #endregion
        #endregion

        #region Delete
        #region Sync
        /// <summary>
        /// 删除全部
        /// </summary>
        /// <returns>返回受影响行数</returns>
        public virtual int DeleteAll() 
        {
            var entities = FindList();
            return Delete(entities);
        }

        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        /// <returns>返回受影响行数</returns>
        public virtual int Delete(T entity) 
        {
            DbContext.Set<T>().Remove(entity);
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// 删除多个实体
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="entities">要删除的实体集合</param>
        /// <returns>返回受影响行数</returns>
        public virtual int Delete(IEnumerable<T> entities)
        {
           dbSet.RemoveRange(entities);
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// 根据条件删除实体
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="predicate">条件</param>
        /// <returns>返回受影响行数</returns>
        public virtual int Delete(Expression<Func<T, bool>> predicate) 
        {
            var entities = FindList(predicate);
            return Delete(entities);
        }

        /// <summary>
        /// 根据主键删除实体
        /// </summary>
        /// <param name="keyValues">主键值</param>
        /// <returns>返回受影响行数</returns>
        public virtual int Delete(params object[] keyValues) 
        {
            var entity = FindEntity(keyValues);
            if (entity != null)
            {
                return Delete(entity);
            }
            return 0;
        }
        #endregion

        #region Async
        /// <summary>
        /// 删除全部
        /// </summary>
        /// <returns>返回受影响行数</returns>
        public virtual async Task<int> DeleteAllAsync() 
        {
            var entities = await FindListAsync();
            return await DeleteAsync(entities);
        }

        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="entity">要删除的实体</param>
        /// <returns>返回受影响行数</returns>
        public virtual async Task<int> DeleteAsync(T entity) 
        {
           dbSet.Remove(entity);
            return await DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 删除多个实体
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="entities">要删除的实体集合</param>
        /// <returns>返回受影响行数</returns>
        public virtual async Task<int> DeleteAsync(IEnumerable<T> entities)
        {
          dbSet.RemoveRange(entities);
            return await DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 根据条件删除实体
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="predicate">条件</param>
        /// <returns>返回受影响行数</returns>
        public virtual async Task<int> DeleteAsync(Expression<Func<T, bool>> predicate) 
        {
            var entities = await FindListAsync(predicate);
            return await DeleteAsync(entities);
        }

        /// <summary>
        /// 根据主键删除实体
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="keyValues">主键值</param>
        /// <returns>返回受影响行数</returns>
        public virtual async Task<int> DeleteAsync(params object[] keyValues) 
        {
            var entity = await FindEntityAsync(keyValues);
            if (entity != null)
            {
                return await DeleteAsync(entity);
            }
            return 0;
        }
        #endregion
        #endregion

        #region Update
        #region Sync
        /// <summary>
        /// 更新单个实体
        /// </summary>
        /// <param name="entity">要更新的实体</param>
        /// <returns>返回受影响行数</returns>
        public virtual int Update(T entity)
        {
            SetModifiedBy(entity);

            DbContext.Set<T>().Attach(entity);
            var entry = DbContext.Entry(entity);
            var props = entity.GetType().GetProperties();
            foreach (var prop in props)
            {
                //非null且非PrimaryKey
                if (prop.GetValue(entity, null) != null && !entry.Property(prop.Name).Metadata.IsPrimaryKey())
                {
                    entry.Property(prop.Name).IsModified = true;
                }
            }
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// 更新多个实体
        /// </summary>
        /// <param name="entities">要更新的实体集合</param>
        /// <returns>返回受影响行数</returns>
        public virtual int Update(IEnumerable<T> entities) 
        {
            foreach (var entity in entities)
            {
                dbSet.Attach(entity);
                var entry = DbContext.Entry(entity);
                var props = entity.GetType().GetProperties();
                foreach (var prop in props)
                {
                    //非null且非PrimaryKey
                    if (prop.GetValue(entity, null) != null && !entry.Property(prop.Name).Metadata.IsPrimaryKey())
                    {
                        entry.Property(prop.Name).IsModified = true;
                    }
                }
            }
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// 根据条件更新实体
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <param name="entity">要更新的实体</param>
        /// <returns>返回受影响行数</returns>
        public virtual int Update(Expression<Func<T, bool>> predicate, T entity) 
        {
            var entities = new List<T>();
            var instances = FindList(predicate);
            //设置所有状态为未跟踪状态
            DbContext.ChangeTracker.Entries<T>().ToList().ForEach(o => o.State = EntityState.Detached);
            foreach (var instance in instances)
            {
                var properties = typeof(T).GetProperties();
                foreach (var property in properties)
                {
                    var isKey = property.GetCustomAttributes(typeof(KeyAttribute), false).Count() > 0;
                    if (isKey)
                    {
                        var keyVal = property.GetValue(instance);
                        if (keyVal != null)
                            property.SetValue(entity, keyVal);
                    }
                }
                //深度拷贝实体，避免列表中所有实体引用地址都相同
                entities.Add(MapperHelper<T, T>.MapTo(entity));
            }
            return Update(entities);
        }
        #endregion

        #region Async
        /// <summary>
        /// 更新单个实体
        /// </summary>
        /// <param name="entity">要更新的实体</param>
        /// <returns>返回受影响行数</returns>
        public virtual async Task<int> UpdateAsync(T entity) 
        {
            SetModifiedBy(entity);

            dbSet.Attach(entity);
            var entry = DbContext.Entry(entity);
            var props = entity.GetType().GetProperties();
            foreach (var prop in props)
            {
                //非null且非PrimaryKey
                if (prop.GetValue(entity, null) != null && !entry.Property(prop.Name).Metadata.IsPrimaryKey())
                {
                    entry.Property(prop.Name).IsModified = true;
                }
            }
            return await DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 更新多个实体
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="entities">要更新的实体集合</param>
        /// <returns>返回受影响行数</returns>
        public virtual async Task<int> UpdateAsync(IEnumerable<T> entities) 
        {
            foreach (var entity in entities)
            {
                dbSet.Attach(entity);
                var entry = DbContext.Entry(entity);
                var props = entity.GetType().GetProperties();
                foreach (var prop in props)
                {
                    //非null且非PrimaryKey
                    if (prop.GetValue(entity, null) != null && !entry.Property(prop.Name).Metadata.IsPrimaryKey())
                    {
                        entry.Property(prop.Name).IsModified = true;
                    }
                }
            }
            return await DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 根据条件更新实体
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="predicate">条件</param>
        /// <param name="entity">要更新的实体</param>
        /// <returns>返回受影响行数</returns>
        public virtual async Task<int> UpdateAsync(Expression<Func<T, bool>> predicate, T entity) 
        {
            var entities = new List<T>();
            var instances = await FindListAsync(predicate);
            //设置所有状态为未跟踪状态
            DbContext.ChangeTracker.Entries<T>().ToList().ForEach(o => o.State = EntityState.Detached);
            foreach (var instance in instances)
            {
                var properties = typeof(T).GetProperties();
                foreach (var property in properties)
                {
                    var isKey = property.GetCustomAttributes(typeof(KeyAttribute), false).Count() > 0;
                    if (isKey)
                    {
                        var keyVal = property.GetValue(instance);
                        if (keyVal != null)
                            property.SetValue(entity, keyVal);
                    }
                }
                //深度拷贝实体，避免列表中所有实体引用地址都相同
                entities.Add(MapperHelper<T, T>.MapTo(entity));
            }
            return await UpdateAsync(entities);
        }

        public bool Exists(Expression<Func<T, bool>> where)
        {

            return dbSet.Any(where);

        }

        public IEnumerable<T> FindList()
        {
            return dbSet.ToList();
        }

        public IEnumerable<T> FindList(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>        
        /// <returns>返回集合</returns>
        public virtual async Task<IEnumerable<T>> FindListAsync() 
        {
            return await dbSet.ToListAsync();
        }
        /// <summary>
        /// 根据条件查询
        /// </summary>      
        /// <param name="predicate">条件</param>
        /// <returns>返回集合</returns>
        public virtual async Task<IEnumerable<T>> FindListAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }
        /// <summary>
        /// 根据主键查询单个实体
        /// </summary>
        /// <param name="keyValues">主键值</param>
        /// <returns>返回实体</returns>
        public virtual T FindEntity(params object[] keyValues)
        {
            return dbSet.Find(keyValues);
        }


       

        public virtual async  Task<T> FindEntityAsync(params object[] keyValues)
        {
            //dbSet.tol
            return await dbSet.FindAsync(keyValues);
        }




        #endregion
        #endregion


        #region 软删除
        public int SoftDeleteAll()
        {
            var entities = FindList();
        return    SoftDelete(entities);
        }

        public int SoftDelete(T entity)
        {
            SetDeleteInfo(entity);
            return DbContext.SaveChanges();
        }

        public int SoftDelete(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                SetDeleteInfo(item);

            }

            return DbContext.SaveChanges();
        }

        public int SoftDelete(Expression<Func<T, bool>> predicate)
        {
            var entities = FindList(predicate);
            return SoftDelete(entities);
        }

        public int SoftDelete(params object[] KeyValues)
        {
            var item = FindEntity(KeyValues);
            return SoftDelete(item);
        }

        public Task<int> SoftDeleteAllAsync()
        {
            var entities = FindList();
            return SoftDeleteAsync(entities);
        }

        public Task<int> SoftDeleteAsync(T entity)
        {
            SetDeleteInfo(entity);
            return DbContext.SaveChangesAsync();
        }

        public Task<int> SoftDeleteAsync(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                SetDeleteInfo(item);

            }

            return DbContext.SaveChangesAsync();
        }

        public Task<int> SoftDeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var entities = FindList(predicate);
            return SoftDeleteAsync(entities);
        }

        public  Task<int> SoftDeleteAsync(params object[] KeyValues)
        {
            var entities = FindEntity(KeyValues);
            return  SoftDeleteAsync(entities);
        }

        public T FindEntity(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).FirstOrDefault();
        }

        public Task<T> FindEntityAsync(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).FirstOrDefaultAsync();
        }
        #endregion
    }
}
