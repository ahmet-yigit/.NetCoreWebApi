using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi2.DataConnections;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SepetUrunController : ControllerBase
    {
        private readonly Context _context;

        public SepetUrunController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public List<SepetUrun> allSepetUrun()
        {
            return _context.SepetUruns.ToList();
        }

    }
}
