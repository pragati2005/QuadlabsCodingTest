using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Services
{
   public  interface ILocationService
    {
    
        Task<List<LocationModel>> GetLocation();
    }
}
