using API.DataStorage;
using API.HubConfig;
using API.TimerFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private IHubContext<ChartHub> _hub;
        
        public ChartController(IHubContext<ChartHub> hub)
        {
            _hub = hub;
        }

        public IActionResult Get()
        {
            var timeManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData()));
            return Ok(new { Message = "Request Completed" });
        }
    }
}
