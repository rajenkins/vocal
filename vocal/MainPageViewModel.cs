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
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace vocal
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		private Controller controller = new Controller();
		public event PropertyChangedEventHandler PropertyChanged;

		List<CardStackView.Item> items = new List<CardStackView.Item>();
		public List<CardStackView.Item> ItemsList
		{
			get
			{
				return items;
			}
			set
			{
				if (items == value)
				{
					return;
				}
				items = value;
				OnPropertyChanged();
			}
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		protected virtual void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			field = value;
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public MainPageViewModel()
		{
			VocalUser addUser;
			VocalUser returnedUser;
			//VocalUser user = new VocalUser("Pizza to go","one.jpg","30 meters away","Pizza");

			//addUser = new VocalUser() { Name = "Tommy", Photo = "play.jpg", Location = "30 miles away", Description = "Hey" };
			//App.Database.SaveItemAsync(addUser);

			//addUser = new VocalUser() { Name = "Chase", Photo = "play.jpg", Location = "15 miles away", Description = "Hello" };
			//App.Database.SaveItemAsync(addUser);

			//addUser = new VocalUser() { Name = "Hassan", Photo = "play.jpg", Location = "2 miles away", Description = "Hi" };
			//App.Database.SaveItemAsync(addUser);


			//returnedUser = App.Database.GetItemAsync(1).Result;
			//items.Add(new CardStackView.Item() { Name = returnedUser.Name, Photo = returnedUser.Photo, Location = returnedUser.Location, Description = returnedUser.Description });

			//returnedUser = App.Database.GetItemAsync(2).Result;
			//items.Add(new CardStackView.Item() { Name = returnedUser.Name, Photo = returnedUser.Photo, Location = returnedUser.Location, Description = returnedUser.Description });

			//returnedUser = App.Database.GetItemAsync(3).Result;
			//items.Add(new CardStackView.Item() { Name = returnedUser.Name, Photo = returnedUser.Photo, Location = returnedUser.Location, Description = returnedUser.Description });

			//items.Add(new CardStackView.Item() { Name = "Pizza to go", Photo = "one.jpg", Location = "30 meters away", Description = "Pizza" });

			getData();

			items.Add(new CardStackView.Item() { Name = "Dragon & Peacock", Photo = "two.jpg", Location = "800 meters away", Description = "Sweet & Sour" });
			items.Add(new CardStackView.Item() { Name = "Murrays Food Palace", Photo = "three.jpg", Location = "9 miles away", Description = "Salmon Plate" });
			items.Add(new CardStackView.Item() { Name = "Food to go", Photo = "four.jpg", Location = "4 miles away", Description = "Salad Wrap" });
			//items.Add(new CardStackView.Item() { Name = "Mexican Joint", Photo = "five.jpg", Location = "2 miles away", Description = "Chilli Bites" });
			//items.Add(new CardStackView.Item() { Name = "Mr Bens", Photo = "six.jpg", Location = "1 mile away", Description = "Beef" });
			//items.Add(new CardStackView.Item() { Name = "Corner Shop", Photo = "seven.jpg", Location = "100 meters away", Description = "Burger & Chips" });
			//items.Add(new CardStackView.Item() { Name = "Sarah's Cafe", Photo = "eight.jpg", Location = "6 miles away", Description = "House Breakfast" });
			//items.Add(new CardStackView.Item() { Name = "Pata Place", Photo = "nine.jpg", Location = "2 miles away", Description = "Chicken Curry" });
			//items.Add(new CardStackView.Item() { Name = "Jerrys", Photo = "ten.jpg", Location = "8 miles away", Description = "Pasta Salad" });

		}
		async void getData()
		{
			var res = await controller.GetUserAsync(1);
			int a = 1;
			a += 2;
		}
	}
}

