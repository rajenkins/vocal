using System;
using Xamarin.Forms;

namespace vocal
{
	public class RecordAudioPageBackup : ContentPage
	{
		public RecordAudioPageBackup()
		{
			var speak = new Button
			{
				Text = "Hello, Forms !",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
			speak.Clicked += (sender, e) =>
			{
				DependencyService.Get<IRecordAudio>().Record();
			};

		}
	}
}
