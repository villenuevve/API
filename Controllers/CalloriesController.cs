/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefAPI.Constanto;
using ChefAPI.Client;
using ChefAPI.Model;

namespace ChefAPI.Controller
{
    [ApiController]
    [Route("[controller]")]

    public class CaloriesController : ControllerBase
    {
        [HttpGet(Name = "Dishes")]

        public List<Data> Titles(string item)
        {
            Cliento client = new Cliento();
            return client.GetTitles(item).Result;
        }
    }

}

using Microsoft.AspNetCore.Mvc;
using ChefAPI.Model;
using ChefAPI.Client;

namespace ChefAPI.Controllers
{
    //static void Main(string[] args){
    [ApiController]
    [Route("[controller]")]

    public class CalloriesController : ControllerBase
    {
        [HttpGet(Name = "Callories")]

        public Modelio Callories(string food, string Apikey)
        {
            Cliento client = new Cliento();
            return client.GetCallories(food, Apikey).Result;
        }

    }
}
*/