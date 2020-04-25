using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace lab10.Controllers
{
    public class Main : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public static Person people = new Person();
        public string value;
        
        [HttpPost]
        public IActionResult Index(string name, string data, string group,string ids)
        {
            
                string[] dataSplit = data.Split('.');
                string s = name + dataSplit[0] + dataSplit[1] + dataSplit[2] + group;
                value = RandomString(s);

                people.Name = name;
                people.Data = data;
                people.Group = group;
                people.id = value;
                
                ViewBag.Message = people.id;
                ViewBag.Message1 = people.Name;
                ViewBag.Message2 = people.Data;
                ViewBag.Message3 = people.Group;
                
          
            
                return View();    
        }
        
        [HttpPost]
        public IActionResult ShowMessage(string ids)
        {
           
            
            if (people.id.Equals(ids))
            {
                return Content("name: " + people.Name + "\nbirth of day: " + people.Data + "\ngroup: " + people.Group);
            }

            return View();    
        }

        private static Random random = new Random();
        public static string RandomString(string str)
        {
            return new string(Enumerable.Repeat(str, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpGet]
        [Route("anything")]
        public string anything()
        {
            return "anyting";
        }
        
        
        [HttpPost]
        [Route("resultres")]
        public ViewResult result(string id)
        {
           
            
            if (id!=null && people.id.Equals(id))
            {
                ViewBag.name = people.Name;
                ViewBag.birthDate = people.Data;
                ViewBag.group = people.Group;
            }

            return View("result"); 
        }
        

    }
}