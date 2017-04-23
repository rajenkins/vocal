using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace vocal
{
	public class Controller
	{
		HttpClient client;

		public Controller()
		{
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
			
		}
		public async Task<VocalUser> GetUserAsync(int id)
		{
			var response = await client.GetStringAsync("http://classroom.cs.unc.edu:8000/Users/1");
			var todoItems = JsonConvert.DeserializeObject<VocalUser>(response);
			return todoItems;  
		}
	}
}
