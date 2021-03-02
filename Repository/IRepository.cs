using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Ado.Net实现的仓储
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// 增、删、改对象
        /// </summary>
        /// <param name="commandText">Sql语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="isCommit">是否提交</param>
        /// <returns></returns>
        int Command(string commandText, IDictionary<string, object> parameters = null);
        /// <summary>
        /// 查询对象集合
        /// </summary>
        /// <typeparam name="T">返回值的实体类型</typeparam>
        /// <param name="commandText">Sql语句</param>
        /// <param name="parameters">参数</param>
        /// <param name="isCommit">是否提交</param>
        /// <returns>泛型实体集合</returns>
        List<T> QueryAll<T>(string commandText, IDictionary<string, object> parameters = null) where T : class, new();
        /// 查询对象集合
        List<object> QueryAll(string commandText, Type type, IDictionary<string, object> parameters = null);
        /// 查询对象
        T Query<T>(string commandText, IDictionary<string, object> parameters = null) where T : class, new();
        /// 查询数量
        object QueryCount(string commandText, IDictionary<string, object> parameters = null);
    }
}
