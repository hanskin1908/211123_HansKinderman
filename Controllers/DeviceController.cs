using _211123_HansKinderman.Managers;
using _211123_HansKinderman.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _211123_HansKinderman.Controllers
{
    public class DeviceController : Controller
    {

        IDeviceServices _serv;
        public DeviceController(IDeviceServices service)
        {
            _serv = service;
        }




        public IActionResult Index()
        {
          //  var data = await _serv.GetDetails(10, "354330030646882");
            //if (data.Error)
            //{
            //    return RedirectToAction("Error", "Home");

            //}
            //return View(data.Lst);
            return View();
        }

        public async Task<ActionResult> Consultar(int idcompania, string imei)
        {

            Device device = new Device
            {
                CompanyId=idcompania,
                Imei = imei
            };


            var data = await _serv.GetDetails(device);
            if (data.Error)
            {
                return RedirectToAction("Error", "Home");

            }

            //List<Device> model = db.Emp_Information.ToList();
            return PartialView("Detail", data.UnitResp);
        }


        public IActionResult Consultar2()
        {
            return View();
        }
    }
}
