using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

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
		public async Task<VocalUser> GetUserAsync(String u)
		{
			var response = await client.GetStringAsync("http://wwwx.cs.unc.edu/Courses/comp580-s17/users/Vocal/rest.cgi/Users/" + u);
			var user = JsonConvert.DeserializeObject<VocalUser>(response);
			return user;  
		}

		public async Task<bool> doesNameExist(String username)
		{
			var response = await client.GetStringAsync("http://wwwx.cs.unc.edu/Courses/comp580-s17/users/Vocal/rest.cgi/Users/exists/" + username);
			JObject o = JObject.Parse(response);
			bool exists = (bool)o["exists"];
			return exists;
		}

		public async Task<bool> AddUser(UserAccount user)
		{
			if ((user.username.Length > 0) && (user.password.Length > 0))
			{
			//	var content = new StringContent(
			//		JsonConvert.SerializeObject(new { username = user.username, password = user.password }));
				var content = new FormUrlEncodedContent(new[]
				{
					new KeyValuePair<string, string>("username", user.username),
					new KeyValuePair<string, string>("password", user.password) 
				});
				var result = await client.PostAsync("http://wwwx.cs.unc.edu/Courses/comp580-s17/users/Vocal/rest.cgi/Users", content);
				if (result.IsSuccessStatusCode)
				{
					App.username = user.username;
					return true;
				}
				return false;
			}
			else
			{
				return false;
			}
		}

		public async Task<bool> UpdateNameAge(String name, String age)
		{
			var contentList = new List<KeyValuePair<string, string>>();
			if (name != null && name.Length > 0)
			{
				contentList.Add(new KeyValuePair<string, string>("name", name));
			}
			if (age != null && age.Length > 0)
			{
				contentList.Add(new KeyValuePair<string, string>("age", age));
			}
			contentList.Add(new KeyValuePair<string, string>("username", App.username));
			var content = new FormUrlEncodedContent(contentList);
			var result = await client.PostAsync("http://wwwx.cs.unc.edu/Courses/comp580-s17/users/Vocal/rest.cgi/Users/update", content);
			if (result.IsSuccessStatusCode)
			{
				return true;
			}
			return false;
		}

		public async Task<bool> Login(UserAccount user)
		{
			if ((user.username.Length > 0) && (user.password.Length > 0))
			{
				var content = new FormUrlEncodedContent(new[]
				{
					new KeyValuePair<string, string>("username", user.username),
					new KeyValuePair<string, string>("password", user.password)
				});
				var result = await client.PostAsync("http://wwwx.cs.unc.edu/Courses/comp580-s17/users/Vocal/rest.cgi/Login", content);
				if (result.IsSuccessStatusCode)
				{
					JObject o = JObject.Parse(result.Content.ReadAsStringAsync().Result);
					bool success = (bool)o["success"];
					if (success)
					{
						App.username = user.username;
						return true;
					}
					return false;
				}
				return false;
			}
			else
			{
				return false;
			}
		}
		public async Task<List<String>> GetMatchesAsync(String u)
		{
			var response = await client.GetStringAsync("http://wwwx.cs.unc.edu/Courses/comp580-s17/users/Vocal/rest.cgi/Users/matches/" + u);
			ResponseList matches = JsonConvert.DeserializeObject<ResponseList>(response);
			return matches.data;
		}
		public async Task<List<String>> GetPotentialMatches(String u)
		{
			var response = await client.GetStringAsync("http://wwwx.cs.unc.edu/Courses/comp580-s17/users/Vocal/rest.cgi/Users/queue/" + u);
			ResponseList matches = JsonConvert.DeserializeObject<ResponseList>(response);
			App.newUsers = matches.data;
			return matches.data;
		}
	}
}
