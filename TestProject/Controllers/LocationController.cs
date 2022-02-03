using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestProject.Models;
using TestProject.Services;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        ILocationService _locationservice;
        public LocationController(ILocationService locationService)
        {
            _locationservice = locationService;
        }
        public async Task<List<LocationModel>> Index()
        {
           
            return await _locationservice.GetLocation();
            
        }

    }
}
