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
        public List<Shouhuo> GetCollectInfos()
        {
            List<Shouhuo> list = bll.GetCollectInfos();
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
        public int GetCollectInfosUpdate(Shouhuo m)
        {
            var row = bll.GetCollectInfosUpdate(m);
            return row;
        }
        //我的地址 根据Id修改(反填)
        [HttpPost]
        [Route("/api/GetCollectInfoUpdateId")]
        public List<Shouhuo> GetCollectInfosUpdateId(int ids)
        {
            var row = bll.GetCollectInfosUpdateId(ids);
            return row;
        }
        //我的地址 新增
        [HttpPost]
        [Route("/api/GetCollectInfoAdd")]
        public int GetCollectInfosAdd(Shouhuo m)
        {
            var row = bll.GetCollectInfosAdd(m);
            return row;
        }



        //仓库地址  美国
        [HttpGet]
        [Route("/api/GetCollectInfoMeiguo")]
        public List<GuojiChangku> GetInternationalMeiguo()
        {
            List<GuojiChangku> list = bll.GetInternationalMeiguo();
            return list;
        }
        //仓库地址  东莞
        [HttpGet]
        [Route("/api/GetCollectInfoDongwan")]
        public List<GuojiChangku> GetInternationalDongwan()
        {
            List<GuojiChangku> list = bll.GetInternationalDongwan();
            return list;
        }
        //仓库地址  马来
        [HttpGet]
        [Route("/api/GetCollectInfoMalai")]
        public List<GuojiChangku> GetInternationalMalai()
        {
            List<GuojiChangku> list = bll.GetInternationalMalai();
            return list;
        }
        //仓库地址  日本
        [HttpGet]
        [Route("/api/GetCollectInfoRiben")]
        public List<GuojiChangku> GetInternationalRiben()
        {
            List<GuojiChangku> list = bll.GetInternationalRiben();
            return list;
        }
        //仓库地址  捷克
        [HttpGet]
        [Route("/api/GetCollectInfoJieke")]
        public List<GuojiChangku> GetInternationalJieke()
        {
            List<GuojiChangku> list = bll.GetInternationalJieke();
            return list;
        }

        //货物预报 添加预报
        [HttpPost]
        [Route("/api/GetHuowuyubaoAdd")]
        public int GetGoodInfo(HuowuYubao m)
        {
            var row = bll.GetHuowuYubaoAdd(m);
            return row;
        }

        //货物预报 添加预报 快递下拉
        [HttpGet]
        [Route("/api/GetGoodInfoAddXiala")]
        public List<Kuaidi> GetGoodInfoKuaidi()
        {
            List<Kuaidi> list = bll.GetGoodInfoKuaidi();
            return list;
        }

        //货物预报 添加预报 仓库下拉
        [HttpGet]
        [Route("/api/GetGoodInfoAddCk")]
        public List<Changku> GetGoodInfoCangku()
        {
            List<Changku> list = bll.GetGoodInfoCangku();
            return list;
        }

        //货物预报 添加预报 查询
        [HttpGet]
        [Route("/api/GetGoodInfoAddCX")]
        public List<GoodInfo> GetGoodInfosChaxun(int? id=null)
        {
            List<GoodInfo> list = bll.GetGoodInfosChaxun(id);
            if (id!=null)
            {
                list = list.Where(x => x.GoodID == id).ToList();
            }
            return list;
        }

        //货物预报 添加预报 快递查询
        [HttpGet]
        [Route("/api/GetKuaidiInfoAddCX")]
        public List<Kuaidi> GetKuaidiChaxun(string KDanhao)
        {
            List<Kuaidi> list = bll.GetKuaidiChaxun(KDanhao);
            if (!string.IsNullOrEmpty(KDanhao))
            {
                list.Where(x => x.KDanhao.Contains(KDanhao)).ToList();
            }
            return list;
        }


        //货物预报 批量预报 添加
        [HttpPost]
        [Route("/api/GetGoodInfoPLAdd")]
        public int GetGoodInfoPLAdd(HuowuYubao m)
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
        public List<Dianpu> GetGoodInfosSCShow()
        {
            List<Dianpu> list = bll.GetGoodInfosSCShow();
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
