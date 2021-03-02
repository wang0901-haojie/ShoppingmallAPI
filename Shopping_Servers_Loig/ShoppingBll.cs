using System;
using System.Collections.Generic;
using Repository;
using ShoppingmallModel;

namespace Shopping_Servers_Loig
{
    public class ShoppingBll
    {
        //数据结构，也就相当于实例化
        private BaseRepository bll = null;
        public ShoppingBll()
        {
            bll = new BaseRepository();
        }

        public ShoppingBll(BaseRepository _bll)
        {
            bll = _bll;
        }

        //我的地址 显示
        public List<CollectInfoModelwhj> GetCollectInfos()
        {
            string sql = $"select * from CollectInfo a join UserInfo b on a.ColleID=b.UserID join Location c on a.ColleID = c.ID";
            return bll.QueryAll<CollectInfoModelwhj>(sql, null, null);
        }

        //我的地址 删除
        public int GetCollectInfosDel(int id)
        {
            string sql = $"delete from CollectInfo where ColleID='{id}'";
            return bll.Command(sql,null);
        }

        //我的地址 修改
        public int GetCollectInfosUpdate(CollectInfoModelwhj m)
        {
            string sql = $"update CollectInfo set ColleName='{m.ColleName}',ColleNation='{m.ColleNation}' , CollenHome='{m.CollenHome}' , CollePostal='{m.CollePostal}' , CollePhone='{m.CollePhone}'  where ColleID='{m.ColleID}'";
            return bll.Command(sql,null);
        }

        //我的地址 根据Id修改
        public List<CollectInfoModelwhj> GetCollectInfosUpdateId(int id)
        {
            string sql = $"select * from CollectInfo a join UserInfo b on a.ColleID=b.UserID join Location c on a.ColleID = c.ID where ColleID = '{id}'";
            return bll.QueryAll<CollectInfoModelwhj>(sql,null,null);
        }

        //我的地址 新增
        public int GetCollectInfosAdd(CollectInfoModelwhj m)
        {
            string sql = $"insert into CollectInfo values('{m.ColleName}','{m.ColleNation}','{m.CollenHome}','{m.CollePostal}','{m.CollePhone}','{m.UserID}','{m.ID}')";
            return bll.Command(sql,null);
        }


        //仓库地址  美国
        public List<InternationalModelwhj> GetInternationalMeiguo()
        {
            string sql = $"select * from International a join WareHouseInfo b on a.InternID=b.WareID where InternName='美国'";
            return bll.QueryAll<InternationalModelwhj>(sql,null,null);
        }
        //仓库地址  东莞
        public List<InternationalModelwhj> GetInternationalDongwan()
        {
            string sql = $"select * from International a join WareHouseInfo b on a.InternID=b.WareID where InternName='东莞'";
            return bll.QueryAll<InternationalModelwhj>(sql, null, null);
        }
        //仓库地址  马来
        public List<InternationalModelwhj> GetInternationalMalai()
        {
            string sql = $"select * from International a join WareHouseInfo b on a.InternID=b.WareID where InternName='马来'";
            return bll.QueryAll<InternationalModelwhj>(sql, null, null);
        }
        //仓库地址  日本
        public List<InternationalModelwhj> GetInternationalRiben()
        {
            string sql = $"select * from International a join WareHouseInfo b on a.InternID=b.WareID where InternName='日本'";
            return bll.QueryAll<InternationalModelwhj>(sql, null, null);
        }
        //仓库地址  捷克
        public List<InternationalModelwhj> GetInternationalJieke()
        {
            string sql = $"select * from International a join WareHouseInfo b on a.InternID=b.WareID where InternName='捷克'";
            return bll.QueryAll<InternationalModelwhj>(sql, null, null);
        }


        //货物预报 添加预报
        public int GetGoodInfoAdd(GoodInfowhj m)
        {
            string sql = $"insert into GoodInfo values('{m.GoodName}','{m.GoodContent}','{m.GoodSize}','{m.GoodColor}',{m.GoodPrice},{m.GoodNum},{m.GoodWeight},'{m.GoodRemark}','{m.GoodImage}',{m.GoodInland},{m.GoodClassID},{m.GoodShopID},{m.GIID},'{m.KId}','{m.WareID}')";
            return bll.Command(sql, null);
        }

        //货物预报 添加预报 删除
        public int GetGoodInfoDel(string name,string remark,int num )
        {
            string sql = $"delete  from GoodInfo where GoodName='{name}' and GoodWeight='{remark}'and GoodNum='{num}'";
            return bll.Command(sql, null);
        }

        //货物预报 添加预报 快递下拉
        public List<GoodInfowhj> GetGoodInfoKuaidi()
        {
            string sql = $"select * from Kuaidi";
            return bll.QueryAll<GoodInfowhj>(sql, null, null);
        }

        //货物预报 添加预报 仓库下拉
        public List<GoodInfowhj> GetGoodInfoCangku()
        {
            string sql = $"select* from WareHouseInfo";
            return bll.QueryAll<GoodInfowhj>(sql, null, null);
        }

        //货物预报 添加预报 显示
        public List<GoodInfowhj> GetGoodInfosShow()
        {
            string sql = $"select top 3 GoodName,GoodWeight,GoodNum from GoodInfo";
            return bll.QueryAll<GoodInfowhj>(sql, null, null);
        }

        //货物预报 添加预报 查询
        public List<GoodInfowhj> GetGoodInfosChaxun(int? id=null)
        {
            string sql = $"select * from GoodInfo where GoodID='{id}'";
            return bll.QueryAll<GoodInfowhj>(sql,null,null);
        }

        //货物预报 批量预报 添加
        public int GetGoodInfoPLAdd(GoodInfowhj m)
        {
            string sql = $"insert into GoodInfo values('{m.GoodName}','{m.GoodContent}','{m.GoodSize}','{m.GoodColor}',{m.GoodPrice},{m.GoodNum},{m.GoodWeight},'{m.GoodRemark}','{m.GoodImage}',{m.GoodInland},{m.GoodClassID},{m.GoodShopID},{m.GIID},'{m.KId}','{m.WareID}')";
            return bll.Command(sql, null);
        }

        //货物预报 批量预报 删除
        public int GetGoodInfoPLDel(int id,string goodname,int goodprice,int goodnum,string goodcontent)
        {
            string sql = $"delete  from GoodInfo where GoodID='{id}' and GoodName='{goodname}' and GoodPrice='{goodprice}' and GoodNum='{goodnum}' and GoodContent='{goodcontent}'";
            return bll.Command(sql,null);
        }

        //我的收藏  显示
        public List<GoodInfowhj> GetGoodInfosSCShow()
        {
            string sql = $"select top 3* from GoodInfo";
            return bll.QueryAll<GoodInfowhj>(sql, null, null);
        }

        //我的收藏 删除
        public int GetGoodInfosSCDel(int id)
        {
            string sql = $"delete  from GoodInfo where GoodID='{id}'";
            return bll.Command(sql,null);
        }

        //我的收藏 批量删除
        public int GetGoodInfosSCDels(int ids)
        {
            string sql = $"delete from GoodInfo where GoodID in ({ids})";
            return bll.Command(sql,null);
        }
    }
}
