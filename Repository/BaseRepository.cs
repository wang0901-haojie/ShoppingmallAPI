using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// 基础库实现
    /// </summary>
    public class BaseRepository :IRepository
    {
        /// <summary>
        /// 数据库连接字符串标识
        /// </summary>
        public string Key { get; }

        private SqlConnection connection;

        private SqlConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    //ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[Key];
                    connection = new SqlConnection("Data Source=.;Initial Catalog=Electricity_project;Integrated Security=True");
                }
                return connection;
            }
        }

        /// <summary>
        /// 增、删、改命令
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        public virtual int Command(string commandText, IDictionary<string, object> parameters = null)
        {
            Func<SqlCommand, int> excute = (commend) =>
            {
                return commend.ExecuteNonQuery();
            };
            return  CreateDbCommondAndExcute<int>(commandText, parameters, excute);
        }
        /// <summary>
        /// 查询实体（强类型）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual T Query<T>(string commandText, IDictionary<string, object> parameters = null, Func<IDataReader, T> load = null) where T : class, new()
        {
            Func<SqlCommand, T> excute = (dbCommand) =>
            {

                var result = default(T);
                using (IDataReader reader = dbCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (load == null)
                        {
                            load = (s) => { return s.GetReaderData<T>(); };
                        }
                        result = load(reader);
                    }
                    return result;
                }
            };
            return CreateDbCommondAndExcute<T>(commandText, parameters, excute);
        }
        /// <summary>
        /// 查询匿名对象集合
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="type"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual List<object> QueryAll(string commandText, Type type, IDictionary<string, object> parameters = null, Action<dynamic> setItem = null)
        {
            Func<SqlCommand, List<object>> excute = (dbCommand) =>
            {
                var result = new List<object>();

                using (IDataReader dataReader = dbCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        var item = dataReader.GetReaderData(type);
                        if (setItem != null)
                        {
                            setItem(item);
                        }
                        result.Add(item);
                    }
                }
                return result;
            };
            return CreateDbCommondAndExcute<List<object>>(commandText, parameters,
                excute);
        }
        /// <summary>
        /// 查询强类型对象集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public  List<T> QueryAll<T>(string commandText, IDictionary<string, object> parameters = null, Func<IDataReader, T> load = null) where T : class, new()
        {
            Func<SqlCommand, List<T>> excute = (dbCommand) =>
            {
                List<T> result = new List<T>();
                using (IDataReader reader = dbCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (load == null)
                        {
                            load = (s) => { return s.GetReaderData<T>(); };
                        }
                        var item = load(reader);
                        result.Add(item);
                    }
                    return result;
                }
            };
            return CreateDbCommondAndExcute(commandText, parameters, excute);
        }
        /// <summary>
        /// 查询结果数量
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public virtual object QueryCount(string commandText, IDictionary<string, object> parameters = null)
        {
            Func<SqlCommand, object> excute = (dbCommand) =>
            {
                return dbCommand.ExecuteScalar();
            };
            return CreateDbCommondAndExcute(commandText, parameters, excute);
        }

        /// <summary>
        /// 创建命令并执行
        /// </summary>
        /// <typeparam name="TValue">自定义的类型</typeparam>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <param name="excute"></param>
        /// <returns></returns>
        private TValue CreateDbCommondAndExcute<TValue>(string commandText,
            IDictionary<string, object> parameters, Func<SqlCommand, TValue> excute)
        {
            if (Connection.State == ConnectionState.Closed) { Connection.Open(); };
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandType = CommandType.Text;
                command.CommandText = commandText; 
                command.Connection = Connection;
                command.SetParameters(parameters);
                return excute(command);
            }
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Dispose()
        {
            if (connection != null)
            {
                Connection.Dispose();//非托管资源
            }
        }

        public List<T> QueryAll<T>(string commandText, IDictionary<string, object> parameters = null) where T : class, new()
        {
            throw new NotImplementedException();
        }

        public List<object> QueryAll(string commandText, Type type, IDictionary<string, object> parameters = null)
        {
            throw new NotImplementedException();
        }

        public T Query<T>(string commandText, IDictionary<string, object> parameters = null) where T : class, new()
        {
            throw new NotImplementedException();
        }
    }
}
