using CinemaShopAdminApplication.Models;
using ClosedXML.Excel;
using GemBox.Document;
using KinoAppAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KinoAppAdmin.Controllers
{
    public class OrderController : Controller
    {
       public OrderController() {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }

        public IActionResult Index
        {
            get
            {
                HttpClient client = new HttpClient();
                string url = "https://localhost:44334/api/Admin/GetOrderes";
                HttpResponseMessage response = client.GetAsync(url).Result;
                var result = response.Content.ReadAsAsync<List<Order>>().Result;
                return View(result);
            }
        }

        public IActionResult Details(Guid id)
        {
            HttpClient client = new HttpClient();
            string url = "https://localhost:44334/api/Admin/GetDetailsForProduct";
            var model = new { Id = id };

            HttpContent content=new StringContent(JsonConvert.SerializeObject(model),Encoding.UTF8,"application/json");
            HttpRequestMessage response = client.PostAsync(url, content).Result;
            var result = response.Content.ReadAsAsync<Order>().Result;

            return View(result);

        }
    }
}
