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
using System;
using Xamarin.Forms;

namespace vocal
{
	public class Menu : ContentPage
	{

		public Menu()
		{
			this.Title = "Menu";

			Button meetButton = new Button
			{
				Text = "Meet",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 200
			};
			meetButton.Clicked += OnMeetButtonClicked;
			Button chatButton = new Button
			{
				Text = "Chat",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 200
			};
			chatButton.Clicked += OnChatButtonClicked;

			Button profButton = new Button
			{
				Text = "Profile",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 200
			};
			profButton.Clicked += OnProfButtonClicked;

			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			// Build the page.
			this.Content = new StackLayout
			{
				Children =
						{
							meetButton,
							chatButton,
							profButton
						}
			};
		}

		async void OnMeetButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MainPage());
		}

		async void OnChatButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ChatList());
		}

		async void OnProfButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ProfilePage());
		}
	}
}


