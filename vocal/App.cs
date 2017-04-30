//
//  Copyright (c) 2016 MatchboxMobile
//  Licensed under The MIT License (MIT)
//  http://opensource.org/licenses/MIT
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
//  TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//  THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
//  CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
//  IN THE SOFTWARE.
//
using Xamarin.Forms;

namespace vocal
{
	public class App : Application
	{

	//	static VocalDatabase database;
		public static bool IsUserLoggedIn { get; set; }

		public App ()
		{
			if (!IsUserLoggedIn) {
				MainPage = new NavigationPage(new LoginPage());
			} else {
				MainPage = new NavigationPage(new Menu());
}

		}

	/*	public static VocalDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new VocalDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
				}
				return database;
			}
		}
		*/

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

