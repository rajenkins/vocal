using System;
using Xamarin.Forms;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;

namespace vocal
{
	public class PlayAudioPage : ContentPage
	{
		public IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;
		public PlayAudioPage()
		{
			this.Title = "Audio";
			this.BackgroundColor = Color.Gray;
			Label header = new Label
			{
				Text = "Press the button to play",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			Button matchButton = new Button
			{
				Text = "PLAY AUDIO",
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
await CrossMediaManager.Current.Play("http://wwwx.cs.unc.edu/Courses/comp580-s17/users/Vocal/files/sounds/therecordertest.mp3");
		}
	}
}
