using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingmallModel;
using Shopping_Servers_Loig;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingmallAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        ShoppingBll bll = new ShoppingBll();

        //我的地址 显示
        [HttpGet]
        [Route("/api/GetCollectInfoShow")]
        public List<CollectInfoModelwhj> GetCollectInfos()
        {
            List<CollectInfoModelwhj> list = bll.GetCollectInfos();
            return list;
        }
        //我的地址 删除
        [HttpGet]
        [Route("/api/GetCollectInfoDel")]
        public int GetCollectInfosDel(int id)
        {
            var row = bll.GetCollectInfosDel(id);
            return row;
        }
        //我的地址 修改
        [HttpPost]
        [Route("/api/GetCollectInfoUpdate")]
        public int GetCollectInfosUpdate(CollectInfoModelwhj m)
        {
            var row = bll.GetCollectInfosUpdate(m);
            return row;
        }
        //我的地址 根据Id修改(反填)
        [HttpPost]
        [Route("/api/GetCollectInfoUpdateId")]
        public List<CollectInfoModelwhj> GetCollectInfosUpdateId(int id)
        {
            var row = bll.GetCollectInfosUpdateId(id);
            return row;
        }
        //我的地址 新增
        [HttpPost]
        [Route("/api/GetCollectInfoAdd")]
        public int GetCollectInfosAdd(CollectInfoModelwhj m)
        {
            var row = bll.GetCollectInfosAdd(m);
            return row;
        }



        //仓库地址  美国
        [HttpGet]
        [Route("/api/GetCollectInfoMeiguo")]
        public List<InternationalModelwhj> GetInternationalMeiguo()
        {
            List<InternationalModelwhj> list = bll.GetInternationalMeiguo();
            return list;
        }
        //仓库地址  东莞
        [HttpGet]
        [Route("/api/GetCollectInfoDongwan")]
        public List<InternationalModelwhj> GetInternationalDongwan()
        {
            List<InternationalModelwhj> list = bll.GetInternationalDongwan();
            return list;
        }
        //仓库地址  马来
        [HttpGet]
        [Route("/api/GetCollectInfoMalai")]
        public List<InternationalModelwhj> GetInternationalMalai()
        {
            List<InternationalModelwhj> list = bll.GetInternationalMalai();
            return list;
        }
        //仓库地址  日本
        [HttpGet]
        [Route("/api/GetCollectInfoRiben")]
        public List<InternationalModelwhj> GetInternationalRiben()
        {
            List<InternationalModelwhj> list = bll.GetInternationalRiben();
            return list;
        }
        //仓库地址  捷克
        [HttpGet]
        [Route("/api/GetCollectInfoJieke")]
        public List<InternationalModelwhj> GetInternationalJieke()
        {
            List<InternationalModelwhj> list = bll.GetInternationalJieke();
            return list;
        }

        //货物预报 添加预报
        [HttpPost]
        [Route("/api/GetGoodInfoAdd")]
        public int GetGoodInfo(GoodInfowhj m)
        {
            var row = bll.GetGoodInfoAdd(m);
            return row;
        }
        //货物预报 添加预报 删除
        [HttpPost]
        [Route("/api/GetGoodInfoDel")]
        public int GetGoodInfoDel(string name, string remark, int num)
        {
            var row = bll.GetGoodInfoDel(name,remark,num);
            return row;
        }

        //货物预报 添加预报 快递下拉
        [HttpGet]
        [Route("/api/GetGoodInfoAddXiala")]
        public List<GoodInfowhj> GetGoodInfoKuaidi()
        {
            List<GoodInfowhj> list = bll.GetGoodInfoKuaidi();
            return list;
        }

        //货物预报 添加预报 仓库下拉
        [HttpGet]
        [Route("/api/GetGoodInfoAddCk")]
        public List<GoodInfowhj> GetGoodInfoCangku()
        {
            List<GoodInfowhj> list = bll.GetGoodInfoCangku();
            return list;
        }

        //货物预报 添加预报 显示
        [HttpGet]
        [Route("/api/GetGoodInfoAddShow")]
        public List<GoodInfowhj> GetGoodInfosShow()
        {
            List<GoodInfowhj> list = bll.GetGoodInfosShow();
            return list;
        }

        //货物预报 添加预报 查询
        [HttpGet]
        [Route("/api/GetGoodInfoAddCX")]
        public List<GoodInfowhj> GetGoodInfosChaxun(int? id=null)
        {

            List<GoodInfowhj> list = bll.GetGoodInfosChaxun(id);
            if (id!=null)
            {
                list = list.Where(x => x.GoodID == id).ToList();
            }
            return list;
        }

        //货物预报 批量预报 添加
        [HttpPost]
        [Route("/api/GetGoodInfoPLAdd")]
        public int GetGoodInfoPLAdd(GoodInfowhj m)
        {
            var row = bll.GetGoodInfoPLAdd(m);
            return row;
        }

        //货物预报 批量预报 删除
        [HttpPost]
        [Route("/api/GetGoodInfoPLDel")]
        public int GetGoodInfoPLDel(int id, string goodname, int goodprice, int goodnum, string goodcontent)
        {
            var row = bll.GetGoodInfoPLDel(id,goodname, goodprice, goodnum,goodcontent);
            return row;
        }


        //我的收藏  显示
        [HttpGet]
        [Route("/api/GetGoodInfoSCShow")]
        public List<GoodInfowhj> GetGoodInfosSCShow()
        {
            List<GoodInfowhj> list = bll.GetGoodInfosSCShow();
            return list;
        }

        //我的收藏 删除
        [HttpGet]
        [Route("/api/GetGoodInfosSCDel")]
        public int GetGoodInfosSCDel(int id)
        {
            var row = bll.GetGoodInfosSCDel(id);
            return row;
        }

        //我的收藏 批量删除
        [HttpPost]
        [Route("/api/GetGoodInfosSCDels")]
        public int GetGoodInfosSCDels(int ids)
        {
            var row = bll.GetGoodInfosSCDels(ids);
            return row;
        }
    }
}
