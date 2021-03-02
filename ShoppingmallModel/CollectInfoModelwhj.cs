using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingmallModel
{
    public class CollectInfoModelwhj
    {
        public int ColleID     { get; set; }
        public string ColleName   { get; set; }
        public string ColleNation { get; set; }
        public string CollenHome  { get; set; }
        public int CollePostal { get; set; }
        public string CollePhone  { get; set; }
        public int UserID { get; set; }
        public int ID { get; set; }

        public string Name { get; set; }   //地址表的地址名称

        public string UserPhone { get; set; }  //用户表的电话
    }                     
}
