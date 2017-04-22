using System;
using Xamarin.Forms;

namespace vocal
{
	public class ChatList : ContentPage
	{
		public ChatList() {
			this.BackgroundColor = Color.Pink;
			Label header = new Label
			{
				Text = "Chat List",
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
			this.Content = new StackLayout
			{
				Children =
								{
									header,
									matchButton
								}
			};
		}

		async void OnMatchButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ChatWindow());
		}
	}
}
