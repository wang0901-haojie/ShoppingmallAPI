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
        public List<Shouhuowhj> GetCollectInfos()
        {
            string sql = $"select * from Shouhuo";
            return bll.QueryAll<Shouhuowhj>(sql, null, null);
        }

        //我的地址 删除
        public int GetCollectInfosDel(int id)
        {
            string sql = $"delete from Shouhuo where SId='{id}'";
            return bll.Command(sql, null);
        }

        //我的地址 修改
        public int GetCollectInfosUpdate(Shouhuowhj m)
        {
            string sql = $"update Shouhuo set SName='{m.SName}',SDiqu='{m.SDiqu}' , SXiangxin='{m.SXiangxin}' , SEmile='{m.SEmile}' , SPhone='{m.SPhone}',SGDPhone='{m.SGDPhone}'  where SId='{m.SId}'";
            return bll.Command(sql, null);
        }

        //我的地址 根据Id修改
        public List<Shouhuowhj> GetCollectInfosUpdateId(int ids)
        {
            string sql = $"select * from Shouhuo where SId='{ids}'";
            return bll.QueryAll<Shouhuowhj>(sql, null, null);
        }

        //我的地址 新增
        public int GetCollectInfosAdd(Shouhuowhj m)
        {
            string sql = $"insert into Shouhuo values('{m.SName}','{m.SDiqu}','{m.SXiangxin}','{m.SEmile}','{m.SPhone}','{m.SGDPhone}')";
            return bll.Command(sql, null);
        }


        //仓库地址  美国
        public List<GuojiChangkuwhj> GetInternationalMeiguo()
        {
            string sql = $"select * from GuojiChangku where GJCity='美国'";
            return bll.QueryAll<GuojiChangkuwhj>(sql, null, null);
        }
        //仓库地址  东莞
        public List<GuojiChangkuwhj> GetInternationalDongwan()
        {
            string sql = $"select * from GuojiChangku where GJCity='东莞'";
            return bll.QueryAll<GuojiChangkuwhj>(sql, null, null);
        }
        //仓库地址  马来
        public List<GuojiChangkuwhj> GetInternationalMalai()
        {
            string sql = $"select * from GuojiChangku where GJCity='马来西亚'";
            return bll.QueryAll<GuojiChangkuwhj>(sql, null, null);
        }
        //仓库地址  日本
        public List<GuojiChangkuwhj> GetInternationalRiben()
        {
            string sql = $"select * from GuojiChangku where GJCity='日本'";
            return bll.QueryAll<GuojiChangkuwhj>(sql, null, null);
        }
        //仓库地址  捷克
        public List<GuojiChangkuwhj> GetInternationalJieke()
        {
            string sql = $"select * from GuojiChangku where GJCity='捷克'";
            return bll.QueryAll<GuojiChangkuwhj>(sql, null, null);
        }


        //货物预报 添加预报
        public int GetHuowuYubaoAdd(HuowuYubaowhj m)
        {
            string sql = $"insert into HuowuYubao values ('{m.KudiDH}','{m.Zhongwenpinm}','{m.Huozhi}','{m.Shuliang}','{m.Likezhuanyun}','{m.Beizhu}')";
            return bll.Command(sql, null);
        }

        //货物预报 添加预报 快递下拉
        public List<Kuaidiwhj> GetGoodInfoKuaidi()
        {
            string sql = $"select * from Kuaidi";
            return bll.QueryAll<Kuaidiwhj>(sql, null, null);
        }

        //货物预报 添加预报 仓库下拉
        public List<Changkuwhj> GetGoodInfoCangku()
        {
            string sql = $"select * from Changku";
            return bll.QueryAll<Changkuwhj>(sql, null, null);
        }


        //货物预报 添加预报 查询
        public List<GoodInfowhj> GetGoodInfosChaxun(int? id = null)
        {
            string sql = $"select * from GoodInfo where GoodID='{id}'";
            return bll.QueryAll<GoodInfowhj>(sql, null, null);
        }
        //货物预报 添加预报 快递查询
        public List<Kuaidiwhj> GetKuaidiChaxun(string KDanhao)
        {
            string sql = $"select * from Kuaidi where KDanhao='{KDanhao}'";
            return bll.QueryAll<Kuaidiwhj>(sql, null, null);
        }

        //货物预报 批量预报 添加
        public int GetGoodInfoPLAdd(HuowuYubaowhj m)
        {
            string sql = $"insert into HuowuYubao values ('{m.KudiDH}','{m.Zhongwenpinm}','{m.Huozhi}','{m.Shuliang}','{m.Likezhuanyun}','{m.Beizhu}'),('{m.KudiDH}','{m.Zhongwenpinm}','{m.Huozhi}','{m.Shuliang}','{m.Likezhuanyun}','{m.Beizhu}'),('{m.KudiDH}','{m.Zhongwenpinm}','{m.Huozhi}','{m.Shuliang}','{m.Likezhuanyun}','{m.Beizhu}')";
            return bll.Command(sql, null);
        }

        //货物预报 批量预报 删除
        public int GetGoodInfoPLDel(string KudiDH, string Zhongwenpinm, string Huozhi, string Shuliang, string Beizhu)
        {
            string sql = $"delete from HuowuYubao where KudiDH='{KudiDH}' and Zhongwenpinm='{Zhongwenpinm}' and Huozhi='{Huozhi}' and Shuliang='{Shuliang}' and Beizhu='{Beizhu}'";
            return bll.Command(sql, null);
        }

        //我的收藏  显示
        public List<Dianpuwhj> GetGoodInfosSCShow()
        {
            string sql = $"select top 3 * from Dianpu a join GoodInfo b on a.DId=b.GoodID";
            return bll.QueryAll<Dianpuwhj>(sql, null, null);
        }

        //我的收藏 删除
        public int GetGoodInfosSCDel(int id)
        {
            string sql = $"delete from GoodInfo where GoodID='{id}'";
            return bll.Command(sql, null);
        }

        //我的收藏 详情
        public List<Dianpuwhj> GetDianpuwhjsxiangq(int id)
        {
            string sql = $"select  * from Dianpu a join GoodInfo b on a.DId=b.GoodID where GoodID='{id}'";
            return bll.QueryAll<Dianpuwhj>(sql,null,null);
        }

        //我的钱包
        public List<Walletwhj> GetWalletwhjsshow()
        {
            string sql = $"select * from Wallet a join Jifen b  on a.JFId=b.JFId";
            return bll.QueryAll<Walletwhj>(sql, null, null);
        }
        //我的钱包 充值金额
        public int GetWalletwhjczje()
        {
            string sql = $"update Wallet set WalletBalance=WalletBalance+100";
            return bll.Command(sql, null);
        }
        //我的钱包 充值金额
        public int GetWalletwhjczjeer()
        {
            string sql = $"update Wallet set WalletBalance=WalletBalance+200";
            return bll.Command(sql, null);
        }
        //我的钱包 充值金额
        public int GetWalletwhjczjewu()
        {
            string sql = $"update Wallet set WalletBalance=WalletBalance+500";
            return bll.Command(sql, null);
        }

        //我的钱包 手动充值
        public int GetWallewhjsdcz(int balance)
        {
            string sql = $"update Wallet set WalletBalance=WalletBalance+{balance}";
            return bll.Command(sql,null);
        }

        //我的钱包 立即提现
        public int GetWallewhjljtx(int balancetx)
        {
            string sql = $"update Wallet set WalletBalance=WalletBalance-{balancetx}";
            return bll.Command(sql, null);
        }
    }
}
