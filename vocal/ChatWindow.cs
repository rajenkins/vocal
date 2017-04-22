using System;
using Xamarin.Forms;

namespace vocal
{
	public class ChatWindow : ContentPage
	{
		public ChatWindow()
		{
			this.BackgroundColor = Color.Blue;
			Label header = new Label
			{
				Text = "Chat",
				HorizontalOptions = LayoutOptions.Center
			};



			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			// Build the page.
			this.Content = new StackLayout
			{
				Children =
								{
									header,
								}
			};
		}
	}
}
