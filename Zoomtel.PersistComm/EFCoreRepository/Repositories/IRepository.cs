using EFCoreRepository.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace EFCoreRepository.Repositories
{
    /// <summary>
    /// 数据操作仓储接口
    /// </summary>
    public interface IRepository<T> where T : new()
    {
        #region public
        int GetSeq(string seqName);



        #endregion


        #region Transaction

        /// <summary>
        /// 开启事务
        /// </summary>
        /// <returns>IRepository</returns>
        IRepository<T> BeginTrans();

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <returns></returns>
        void Commit();

        /// <summary>
        /// 回滚事务
        /// </summary>
        void Rollback();

        /// <summary>
        /// 关闭连接
        /// </summary>
        void Close();


        #endregion

        #region ==Exists==

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        bool Exists(Expression<Func<T, bool>> where);
        #endregion


        #region Insert
        #region Sync
        /// <summary>
        /// 插入单个实体
        /// </summary>
        /// <param name="entity">要插入的实体</param>
        /// <returns>返回受影响行数</returns>
        int Insert(T entity);

        /// <summary>
        /// 插入多个实体
        /// </summary>
        /// <param name="entities">要插入的实体集合</param>
        /// <returns>返回受影响行数</returns>
        int Insert(IEnumerable<T> entities);
        #endregion

        #region Async
        /// <summary>
        /// 插入单个实体
        /// </summary>
        /// <param name="entity">要插入的实体</param>
        /// <returns>返回受影响行数</returns>
        Task<int> InsertAsync(T entity);

        /// <summary>
        /// 插入多个实体
        /// </summary>
        /// <param name="entities">要插入的实体集合</param>
        /// <returns>返回受影响行数</returns>
        Task<int> InsertAsync(IEnumerable<T> entities);
        #endregion
        #endregion


        #region SoftDelete

        #region Sync
        /// <summary>
        /// 删除全部
        /// </summary>
        /// <returns>返回受影响行数</returns>
        int SoftDeleteAll();

        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        /// <returns>返回受影响行数</returns>
        int SoftDelete(T entity);

        /// <summary>
        /// 删除多个实体
        /// </summary>
        /// <param name="entities">要删除的实体集合</param>
        /// <returns>返回受影响行数</returns>
        int SoftDelete(IEnumerable<T> entities);

        /// <summary>
        /// 根据条件删除实体
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>返回受影响行数</returns>
        int SoftDelete(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 根据主键删除实体
        /// </summary>
        /// <param name="KeyValues">主键值</param>
        /// <returns>返回受影响行数</returns>
        int SoftDelete(params object[] KeyValues);
        #endregion

        #region Async
        /// <summary>
        /// 删除全部
        /// </summary>
        /// <returns>返回受影响行数</returns>
        Task<int> SoftDeleteAllAsync();

        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        /// <returns>返回受影响行数</returns>
        Task<int> SoftDeleteAsync(T entity);

        /// <summary>
        /// 删除多个实体
        /// </summary>
        /// <param name="entities">要删除的实体集合</param>
        /// <returns>返回受影响行数</returns>
        Task<int> SoftDeleteAsync(IEnumerable<T> entities);

        /// <summary>
        /// 根据条件删除实体
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>返回受影响行数</returns>
        Task<int> SoftDeleteAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 根据主键删除实体
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="KeyValues">主键值</param>
        /// <returns>返回受影响行数</returns>
        Task<int> SoftDeleteAsync(params object[] KeyValues);
        #endregion


        #endregion

        #region Delete删除方法
        #region Sync
        /// <summary>
        /// 删除全部
        /// </summary>
        /// <returns>返回受影响行数</returns>
        int DeleteAll();

        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        /// <returns>返回受影响行数</returns>
        int Delete(T entity);

        /// <summary>
        /// 删除多个实体
        /// </summary>
        /// <param name="entities">要删除的实体集合</param>
        /// <returns>返回受影响行数</returns>
        int Delete(IEnumerable<T> entities);

        /// <summary>
        /// 根据条件删除实体
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>返回受影响行数</returns>
        int Delete(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 根据主键删除实体
        /// </summary>
        /// <param name="KeyValues">主键值</param>
        /// <returns>返回受影响行数</returns>
        int Delete(params object[] KeyValues);
        #endregion

        #region Async
        /// <summary>
        /// 删除全部
        /// </summary>
        /// <returns>返回受影响行数</returns>
        Task<int> DeleteAllAsync();

        /// <summary>
        /// 删除单个实体
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        /// <returns>返回受影响行数</returns>
        Task<int> DeleteAsync(T entity);

        /// <summary>
        /// 删除多个实体
        /// </summary>
        /// <param name="entities">要删除的实体集合</param>
        /// <returns>返回受影响行数</returns>
        Task<int> DeleteAsync(IEnumerable<T> entities);

        /// <summary>
        /// 根据条件删除实体
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>返回受影响行数</returns>
        Task<int> DeleteAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 根据主键删除实体
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="KeyValues">主键值</param>
        /// <returns>返回受影响行数</returns>
        Task<int> DeleteAsync(params object[] KeyValues);
        #endregion
        #endregion

        #region Update更改
        #region Sync
        /// <summary>
        /// 更新单个实体
        /// </summary>
        /// <typeparam name="T">泛型类型</typeparam>
        /// <param name="entity">要更新的实体</param>
        /// <returns>返回受影响行数</returns>
        int Update(T entity);

        /// <summary>
        /// 更新多个实体
        /// </summary>
        /// <param name="entities">要更新的实体集合</param>
        /// <returns>返回受影响行数</returns>
        int Update(IEnumerable<T> entities);

        /// <summary>
        /// 根据条件更新实体
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <param name="entity">要更新的实体</param>
        /// <returns>返回受影响行数</returns>
        int Update(Expression<Func<T, bool>> predicate, T entity);
        #endregion

        #region Async
        /// <summary>
        /// 更新单个实体
        /// </summary>
        /// <param name="entity">要更新的实体</param>
        /// <returns>返回受影响行数</returns>
        Task<int> UpdateAsync(T entity);

        /// <summary>
        /// 更新多个实体
        /// </summary>
        /// <param name="entities">要更新的实体集合</param>
        /// <returns>返回受影响行数</returns>
        Task<int> UpdateAsync(IEnumerable<T> entities);

        /// <summary>
        /// 根据条件更新实体
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <param name="entity">要更新的实体</param>
        /// <returns>返回受影响行数</returns>
        Task<int> UpdateAsync(Expression<Func<T, bool>> predicate, T entity);
        #endregion
        #endregion

        #region FindList
        #region Sync
        /// <summary>
        /// 查询全部
        /// </summary>    
        /// <returns>返回集合</returns>
        IEnumerable<T> FindList();


        /// <summary>
        /// 根据条件查询
        /// </summary>   
        /// <param name="predicate">条件</param>
        /// <returns>返回集合</returns>
        IEnumerable<T> FindList(Expression<Func<T, bool>> predicate);

        #endregion

        #region Async
        /// <summary>
        /// 查询全部
        /// </summary>     
        /// <returns>返回集合</returns>
        Task<IEnumerable<T>> FindListAsync();


        /// <summary>
        /// 根据条件查询
        /// </summary>     
        /// <param name="predicate">条件</param>
        /// <returns>返回集合</returns>
        Task<IEnumerable<T>> FindListAsync(Expression<Func<T, bool>> predicate) ;


        #endregion

        #endregion

        #region FindEntity
        /// <summary>
        /// 根据主键查询单个实体
        /// </summary>
        /// <param name="KeyValues">主键值</param>
        /// <returns>返回实体</returns>
        T FindEntity(params object[] KeyValues) ;
        /// <summary>
        /// 根据主键查询单个实体
        /// </summary>     
        /// <param name="KeyValues">主键值</param>
        /// <returns>返回实体</returns>
        Task<T> FindEntityAsync(params object[] KeyValues) ;


        T FindEntity(Expression<Func<T, bool>> predicate);

        Task<T> FindEntityAsync(Expression<Func<T, bool>> predicate);
        #endregion

    }
}