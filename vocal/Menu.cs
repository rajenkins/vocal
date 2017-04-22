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
		Label label;
		int clickTotal = 0;

		public Menu()
		{
            this.BackgroundColor = Color.White;
			Label header = new Label
			{
				Text = "Button",
				HorizontalOptions = LayoutOptions.Center
			};

			Button button = new Button
			{
				Text = "Meet",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 200
			};
			button.Clicked += OnButtonClicked;
			Button button1 = new Button
			{
				Text = "Chat",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 200
			};
			Button button2 = new Button
			{
				Text = "Profile",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 200
			};

			label = new Label
			{
				Text = "0 button clicks",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			// Build the page.
			this.Content = new StackLayout
			{
				Children =
						{
							header,
							button,
							button1,
							button2,
							label
						}
			};
		}

		async void OnButtonClicked(object sender, EventArgs e)
		{
			clickTotal += 1;
			label.Text = String.Format("{0} button click{1}",
									   clickTotal, clickTotal == 1 ? "" : "s"); 
			await Navigation.PushAsync(new MainPage());
		}
	}
}


