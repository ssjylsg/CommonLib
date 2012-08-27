using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BanYuan.Framework.Domain;

namespace BanYuan.Framework.Repositories
{
    public interface IRepositories<TEntity, TKey> where TEntity : IAggregateRoot
    {
        /// <summary>
        /// Save One Entity
        /// </summary>
        /// <param name="entity"></param>
        void Save(TEntity entity);
        /// <summary>
        /// update entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);
        /// <summary>
        /// delete entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity FindByKey(TKey key);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> FindAll();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Find(IPage page);
    }
}
