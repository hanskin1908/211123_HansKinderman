using _211123_HansKinderman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _211123_HansKinderman.Managers
{
   public interface IDeviceServices
    {
    
        public Task<Response<Device>> GetDetails(Device dispositivo);
    }
}
