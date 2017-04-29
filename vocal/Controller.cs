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
var response = await client.GetStringAsync("http://wwwx.cs.unc.edu/Courses/comp580-s17/users/Vocal/rest.cgi/Users/" + id);
			var todoItems = JsonConvert.DeserializeObject<VocalUser>(response);
			return todoItems;  
		}
	}
}
