using System;
using Xamarin.Forms;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using static Xamarin.Forms.DependencyService;
using System.Net.Http;
using System.IO;

namespace vocal
{
	public class RecordAudioPage : ContentPage
	{
		public IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;
		public Controller controller = new Controller();
		public static int i = 0;

		public RecordAudioPage()
		{
			this.Title = "Record Audio";
			this.BackgroundColor = Color.Gray;
			Label header = new Label
			{
				Text = "Press the button to record",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

		Button matchButton = new Button
		{
			Text = "RECORD AUDIO",
			Font = Font.SystemFontOfSize(NamedSize.Large),
			BorderWidth = 2,
			HorizontalOptions = LayoutOptions.Fill,
			VerticalOptions = LayoutOptions.CenterAndExpand,
			HeightRequest = 80
		};
			matchButton.Clicked += ToggleRecord;

	Button matchButton2 = new Button
	{
		Text = "STOP RECORDING",
		Font = Font.SystemFontOfSize(NamedSize.Large),
		BorderWidth = 2,
		HorizontalOptions = LayoutOptions.Center,
		VerticalOptions = LayoutOptions.CenterAndExpand,
		WidthRequest = 200
	};
	matchButton2.Clicked += (sender, e) =>
			{
				SoundFileInfo audioFile = Get<IRecordAudio>().Stop2();
				controller.SaveAudio(audioFile);
				//CrossMediaManager.Current.Play(audioFile);

		};


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
		async void ToggleRecord(object sender, EventArgs e)
		{
			int rem = i % 2;
			i++;
			if (rem == 0) 
			{
				Get<IRecordAudio>().SetupRecord();
				Get<IRecordAudio>().Record();
			}
			else 
			{
				SoundFileInfo audioFile = Get<IRecordAudio>().Stop2();
				await controller.SaveAudio(audioFile);
				Navigation.PopAsync();
			}

		}
	}
}
