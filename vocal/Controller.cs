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
			VocalUser Item = new VocalUser();
			String RestUrl = "https://jsonplaceholder.typicode.com/posts/1";
			var uri = new Uri(RestUrl);
			  var response = await client.GetAsync(RestUrl);
			  if (response.IsSuccessStatusCode) {
			  	var content = await response.Content.ReadAsStringAsync();
				Item = JsonConvert.DeserializeObject<VocalUser> (content);  
			  }
			return Item;
		}
	}
}
