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
			String RestUrl = "classroom.cs.unc.edu:8000/Users/1";
			var uri = new Uri(string.Format(RestUrl, string.Empty));
			  var response = await client.GetAsync(uri);
			  if (response.IsSuccessStatusCode) {
			  	var content = await response.Content.ReadAsStringAsync();
				Item = JsonConvert.DeserializeObject<VocalUser> (content);  
			  }
			return Item;
		}
	}
}
