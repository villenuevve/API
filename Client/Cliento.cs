using System;
using ChefAPI.Model;
using ChefAPI.Constanto;
using Newtonsoft.Json;
using RestSharp;

namespace ChefAPI.Client
{
	public class Cliento
	{ /*
		private HttpClient _client;
		private static string _address;
		private static string _key;
		
		public Cliento()
		{
			_address = Constanto.address;
			_key = Constanto.key;
			_client = new HttpClient();
			_client.BaseAddress = new Uri(_address);
		}
		*/

		public async Task<Modelio> GetCalories(string food, string Apikey)
		{
			var client = new RestClient($"https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/guessNutrition?title={food}&appid={Apikey}");
			var request = new RestRequest();
			request.AddHeader("X-RapidAPI-Key", "ed7d33507fmsh3e29771d6995771p195f9bjsn29baba04f262");
			request.AddHeader("X-RapidAPI-Host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com");
			RestResponse response = client.Execute(request);
			return JsonConvert.DeserializeObject<Modelio>(response.Content);

		}

		public async Task<List<Data>> GetRecipes(string dish, string Apikey)
		{
			var client = new RestClient($"https://recipe-by-api-ninjas.p.rapidapi.com/v1/recipe?query={dish}&appid={Apikey}");
			var request = new RestRequest();
			request.AddHeader("X-RapidAPI-Key", "3469217803mshe7515dac4541358p1c7fadjsn6809889db67b");
			request.AddHeader("X-RapidAPI-Host", "recipe-by-api-ninjas.p.rapidapi.com");
			RestResponse response = client.Execute(request);
			var result = JsonConvert.DeserializeObject<List<Data>>(response.Content);
			return result;

		}

	}
}

