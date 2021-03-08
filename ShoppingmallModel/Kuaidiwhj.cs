using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingmallModel
{
    public class Kuaidiwhj
    {
        public int KId             { get; set; }              //快递Id
        public string KName           { get; set; }           //快递名称
        public string KDanhao         { get; set; }           //快递单号
        public string KGuoneiFeiyong  { get; set; }           //快递国内费用
        public string KGuonwaiFeiyong { get; set; }           //快递国外费用
        public string KChangYongfei   { get; set; }           //到仓库运费 
        public DateTime KTime           { get; set; }           //时间
        public string KTimemiaoshu    { get; set; }           //时间描述
        public string KDjianshu { get; set; }                 //数量
        public int GoodID { get; set; }                       //关联商品表
    }                                               
}
