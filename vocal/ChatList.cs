using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace vocal
{
	public class ChatList : ContentPage
	{
		private Controller controller = new Controller();

		public ChatList() {
            this.Title = "Matches";
			Label header = new Label
			{
				Text = "Select a Match to Message",
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			Button matchButton = new Button
			{
				Text = "Chat with Match",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 200
			};
			matchButton.Clicked += OnMatchButtonClicked;


			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			// Build the page.
			StackLayout parent = new StackLayout
			{
				Children =
								{
									header
								}
			};
			this.Content = new ScrollView { Content = parent };
				
			AddMatches(parent);
		}

		async void OnMatchButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ChatWindow());
		}
		async void AddMatches(StackLayout page)
		{
			List<String> matches = await controller.GetMatchesAsync(App.username);
			foreach (var m in matches) 
			{
				Button match = new Button
				{
					Text = m,
					Font = Font.SystemFontOfSize(NamedSize.Large),
					BorderWidth = 2,
					HorizontalOptions = LayoutOptions.Fill,
					HeightRequest = 100
				};
				match.Clicked += ShowProfile;
				page.Children.Add(match);
			}
		}
		async void ShowProfile(object sender, EventArgs e)
		{
			Button button = (Button) sender;
			String user = button.Text;
			Navigation.PushAsync(new UserProfile(user));
		}
	}
}
