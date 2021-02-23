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
        [HttpGet]
        [Route("/api/GetStudent")]
        public List<Student> GetStudents()
        {
            return bll.GetStudents();
        }
    }
}
