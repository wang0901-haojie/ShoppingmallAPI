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
        public List<Shouhuowhj> GetCollectInfos()
        {
            List<Shouhuowhj> list = bll.GetCollectInfos();
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
        public int GetCollectInfosUpdate(Shouhuowhj m)
        {
            var row = bll.GetCollectInfosUpdate(m);
            return row;
        }
        //我的地址 根据Id修改(反填)
        [HttpPost]
        [Route("/api/GetCollectInfoUpdateId")]
        public List<Shouhuowhj> GetCollectInfosUpdateId(int ids)
        {
            var row = bll.GetCollectInfosUpdateId(ids);
            return row;
        }
        //我的地址 新增
        [HttpPost]
        [Route("/api/GetCollectInfoAdd")]
        public int GetCollectInfosAdd(Shouhuowhj m)
        {
            var row = bll.GetCollectInfosAdd(m);
            return row;
        }



        //仓库地址  美国
        [HttpGet]
        [Route("/api/GetCollectInfoMeiguo")]
        public List<GuojiChangkuwhj> GetInternationalMeiguo()
        {
            List<GuojiChangkuwhj> list = bll.GetInternationalMeiguo();
            return list;
        }
        //仓库地址  东莞
        [HttpGet]
        [Route("/api/GetCollectInfoDongwan")]
        public List<GuojiChangkuwhj> GetInternationalDongwan()
        {
            List<GuojiChangkuwhj> list = bll.GetInternationalDongwan();
            return list;
        }
        //仓库地址  马来
        [HttpGet]
        [Route("/api/GetCollectInfoMalai")]
        public List<GuojiChangkuwhj> GetInternationalMalai()
        {
            List<GuojiChangkuwhj> list = bll.GetInternationalMalai();
            return list;
        }
        //仓库地址  日本
        [HttpGet]
        [Route("/api/GetCollectInfoRiben")]
        public List<GuojiChangkuwhj> GetInternationalRiben()
        {
            List<GuojiChangkuwhj> list = bll.GetInternationalRiben();
            return list;
        }
        //仓库地址  捷克
        [HttpGet]
        [Route("/api/GetCollectInfoJieke")]
        public List<GuojiChangkuwhj> GetInternationalJieke()
        {
            List<GuojiChangkuwhj> list = bll.GetInternationalJieke();
            return list;
        }

        //货物预报 添加预报
        [HttpPost]
        [Route("/api/GetHuowuyubaoAdd")]
        public int GetGoodInfo(HuowuYubaowhj m)
        {
            var row = bll.GetHuowuYubaoAdd(m);
            return row;
        }

        //货物预报 添加预报 快递下拉
        [HttpGet]
        [Route("/api/GetGoodInfoAddXiala")]
        public List<Kuaidiwhj> GetGoodInfoKuaidi()
        {
            List<Kuaidiwhj> list = bll.GetGoodInfoKuaidi();
            return list;
        }

        //货物预报 添加预报 仓库下拉
        [HttpGet]
        [Route("/api/GetGoodInfoAddCk")]
        public List<Changkuwhj> GetGoodInfoCangku()
        {
            List<Changkuwhj> list = bll.GetGoodInfoCangku();
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

        //货物预报 添加预报 快递查询
        [HttpGet]
        [Route("/api/GetKuaidiInfoAddCX")]
        public List<Kuaidiwhj> GetKuaidiChaxun(string KDanhao)
        {
            List<Kuaidiwhj> list = bll.GetKuaidiChaxun(KDanhao);
            if (!string.IsNullOrEmpty(KDanhao))
            {
                list.Where(x => x.KDanhao.Contains(KDanhao)).ToList();
            }
            return list;
        }


        //货物预报 批量预报 添加
        [HttpPost]
        [Route("/api/GetGoodInfoPLAdd")]
        public int GetGoodInfoPLAdd(HuowuYubaowhj m)
        {
            var row = bll.GetGoodInfoPLAdd(m);
            return row;
        }

        //货物预报 批量预报 删除
        [HttpPost]
        [Route("/api/GetGoodInfoPLDel")]
        public int GetGoodInfoPLDel(string KudiDH, string Zhongwenpinm, string Huozhi, string Shuliang, string Beizhu)
        {
            var row = bll.GetGoodInfoPLDel(KudiDH, Zhongwenpinm, Huozhi, Shuliang, Beizhu);
            return row;
        }


        //我的收藏  显示
        [HttpGet]
        [Route("/api/GetGoodInfoSCShow")]
        public List<Dianpuwhj> GetGoodInfosSCShow()
        {
            List<Dianpuwhj> list = bll.GetGoodInfosSCShow();
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
        public int GetGoodInfosSCDels(string ids)
        {
            int row=0;
            string[] id = ids.Split(',');
            for (int i = 0; i < id.Length; i++)
            {
                bll.GetGoodInfosSCDel(Convert.ToInt32(id[i]));
                row++;
            }
            return row;
        }
    }
}
