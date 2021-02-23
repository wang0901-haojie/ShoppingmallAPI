using System;
using System.Collections.Generic;

namespace IRepository
{
    /// <summary>
    /// Ado.Net实现的仓储
    /// </summary>
    public interface IRepositoryIbll
    {
        /// <summary>
        /// 增、删、改对象
        /// </summary>
        /// <param name="commandText">Sql语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="isCommit">是否提交</param>
        /// <returns></returns>
        void Command(string commandText, IDictionary<string, object> parameters = null);

        /// <summary>
        /// 查询对象集合
        /// </summary>
        /// <typeparam name="T">返回值的实体类型</typeparam>
        /// <param name="commandText">Sql语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="isCommit">是否提交</param>
        /// <returns>泛型实体集合</returns>
        List<T> QueryAll<T>(string commandText, IDictionary<string, object> parameters = null) where T : class, new();

        /// <summary>
        /// 查询对象集合
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="type"></param>
        /// <param name="parameters"></param>
        /// <param name="isCommit"></param>
        /// <returns></returns>
        List<object> QueryAll(string commandText, Type type, IDictionary<string, object> parameters = null);

        /// <summary>
        /// 查询对象
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="type"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        T Query<T>(string commandText, IDictionary<string, object> parameters = null) where T : class, new();

        /// <summary>
        /// 查询数量
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        object QueryCount(string commandText, IDictionary<string, object> parameters = null);
    }
}