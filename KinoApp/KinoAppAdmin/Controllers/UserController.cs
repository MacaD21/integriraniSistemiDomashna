using ExcelDataReader;
using KinoAppAdmin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace KinoAppAdmin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ImportUsers(IFormFile file)
        {
            string path=$"{Directory.GetCurrentDirectory()}\\files\\{file.FileName}";
            using (FileStream fileStream =new FileStream(path, FileMode.Create)) { 
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            List<User> users = GetAllUsersFromFike(file.FileName);
            HttpClient client = new HttpClient();
            string url = "https://localhost:44334/api/Admin/ImportAllUsers";
            HttpContent content= new StringContent(JsonConvert.SerializeObject(users),Encoding.UTF8, "application/json");
            HttpResponseMessage response=client.PostAsync(url, content).Result;
            var result=response.Content.ReadAsAsync<bool>().Result;

            return RedirectToAction("Index", "Order");
        }

        private List<User> GetAllUsersFromFike(string fileName)
        {
            List<User> users=new List<User>();
            string path = $"{Directory.GetCurrentDirectory()}\\files\\{fileName}";

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var stream = new  FileStream(fileName, FileMode.Open))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        users.Add(new User()
                        {
                            Email = reader.GetValue(0).ToString(),
                            Password = reader.GetValue(1).ToString(),
                            ConfrimPassword = reader.GetValue(2).ToString(),
                        });
                    }
                }
            }
            return users;
        }
    }
}
