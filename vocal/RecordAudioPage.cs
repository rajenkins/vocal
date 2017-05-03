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
			HeightRequest = 100
		};
		matchButton.Clicked += (sender, e) =>
			{
			/*	int rem;
				DivRem(i, 2, out rem);
				i++;
				if (rem == 0) 
				{
					Get<IRecordAudio>().SetupRecord();
					Get<IRecordAudio>().Record();}
				else 
				{
					SoundFileInfo audioFile = Get<IRecordAudio>().Stop2();
					controller.SaveAudio(audioFile);
				}
				*/
				Get<IRecordAudio>().SetupRecord();
		Get<IRecordAudio>().Record();
	};

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
									matchButton,
									matchButton2
								}
				 };
		}
	}
}
