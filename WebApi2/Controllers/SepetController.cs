using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi2.DataConnections;
using WebApi2.Models;

namespace WebApi1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SepetController : ControllerBase
    {
        private readonly Context _context;
        public SepetController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Sepet> allSepet()
        {
            return _context.Sepets.ToList();
        }

    }
}
