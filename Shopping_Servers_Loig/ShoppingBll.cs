using System;
using System.Collections.Generic;
using Repository;
using ShoppingmallModel;

namespace Shopping_Servers_Loig
{
    public class ShoppingBll
    {
        private BaseRepository bll = null;
        public ShoppingBll()
        {
            bll = new BaseRepository();
        }

        public ShoppingBll(BaseRepository _bll)
        {
            bll = _bll;
        }
        public List<Student> GetStudents()
        {
            string sql = "select * from Student";
            return bll.QueryAll<Student>(sql,null,null);
        }
    }
}
