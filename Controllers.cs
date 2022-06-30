using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefAPI.Constanto;
using ChefAPI.Client;
using ChefAPI.Model;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace ChefAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CaloriesController : ControllerBase
    {
        
        [HttpGet(Name = "Calories")]

        public Modelio Calories(string food, string Apikey)
        {
            Cliento client = new Cliento();
            return client.GetCalories(food, Apikey).Result;

        }

    }

    [ApiController]
    [Route("[controller]")]

    public class RecipesController : ControllerBase
    {

        [HttpGet(Name = "Recipes")]

        public List<Data> Recipes(string dish, string Apikey)
        {
            Cliento client = new Cliento();
            return client.GetRecipes(dish,Apikey).Result;
        }


    }

    [ApiController]
    [Route("[controller]")]

    public class AddController : ControllerBase
    {

        [HttpPost(Name = "Add")]

        public void User(long id, string types, string recipes)
        {
            AddUser(id, types, recipes);

        }
        public static async Task AddUser(long id, string types, string recipes)
        {

            await using (helloappContext db = new helloappContext())
            {
                db.Everything.Add(new Everythin
                {
                    Id = id,
                    Types = types,
                    Recipe = recipes,
                });
                db.SaveChanges();
            }
          
            
        }
    }
   
    public partial class helloappContext : DbContext
    {
        public helloappContext()
        {
        }

        public helloappContext(DbContextOptions<helloappContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Everythin> Everything { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=/Users/vlodochka1/Desktop/recipee.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

    [ApiController]
    [Route("[controller]")]

    public class ShowRecipeController : ControllerBase
    {

        [HttpGet(Name = "ShowRecipe")]

        public List<string> User()
        {
            return ShowRecipes().Result;

        }
        
        public static async Task<List<string>> ShowRecipes()
        {
            List<string> Recipes = new List<string>();

            using (helloappContext db = new helloappContext())
            {
                List<string> users = new List<string>();
                foreach(Everythin ev in db.Everything)
                {
                    users.Add(ev.Recipe);
                   
                }
                foreach (var user in users)
                Console.WriteLine($"{user}");
                return users;

            }

        }

    }

    [ApiController]
    [Route("[controller]")]

    public class ShowTypesController : ControllerBase
    {

        [HttpGet(Name = "ShowTypes")]

        public List<string> Use()
        {
            return ShowTypes().Result;

        }
        
        public static async Task<List<string>> ShowTypes()//для myfav
        {
            List<string> Typss = new List<string>();

            using (helloappContext db = new helloappContext())
            {
                List<string> use = new List<string>();
                foreach (Everythin tp in db.Everything)
                {
                    use.Add(tp.Types);

                }
                foreach (var user in use)
                    Console.WriteLine($"{user}");
                return use;


            }
        }
    }
        
        

}

  


