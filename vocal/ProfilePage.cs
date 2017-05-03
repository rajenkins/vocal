using System;
using System.Threading.Tasks;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Xamarin.Forms;

namespace vocal
{
	public class ProfilePage : ContentPage
	{
		String uName;
		String uAge;
		string url;
		IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;
		Label name;
		Label age;
		private Controller controller = new Controller();
		public ProfilePage()
		{
			PopulateInfo();
            this.Title = "Profile";
			Label header = new Label
			{
				Text = "Update Profile",
				FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};
			Label basic = new Label
			{
				Text = "Basic Info",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};
			name = new Label
			{
				Text = uName,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};
			age = new Label
			{
				Text = uAge,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			Button basicButton = new Button
			{
				Text = "Update Basic Info",
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Fill,
				HeightRequest = 100
			};
			basicButton.Clicked += showUpdateBasicPage;

			Button recordButton = new Button
			{
				Text = "Record New Bio",
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Fill,
				HeightRequest = 100
			};
			recordButton.Clicked += showRecordAudioPage;

			Button listenButton = new Button
			{
				Text = "Listen to Audio Bio",
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Fill,
				HeightRequest = 100
			};
			listenButton.Clicked += (sender, e) =>
			{
				CrossMediaManager.Current.Play(url);
			};

			BoxView boxView = new BoxView
			{
				Color = Color.Accent,
				HorizontalOptions=LayoutOptions.FillAndExpand,
				HeightRequest = 1,
			};
			Label bio = new Label
			{
				Text = "Bio",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
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
									basic,
									name,
									age,
									basicButton,
									boxView,
									bio,
									listenButton,
									recordButton
								}
				 };
		}
		async Task<VocalUser> PopulateInfo()
		{
			VocalUser user = await controller.GetUserAsync(App.username);
			uName = user.Name;
			uAge = user.Age.ToString();
			name.Text = uName;
			age.Text = uAge;
			url = await controller.GetSoundUrl(App.username);
			return user;
		}

		async void showUpdateBasicPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new UpdateBasicPage(uName, uAge, controller));
		}

		async void showRecordAudioPage(object sender, EventArgs e)
		{

			await Navigation.PushAsync(new RecordAudioPage());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			PopulateInfo();
		}
	}
}