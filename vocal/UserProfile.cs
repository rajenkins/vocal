using System;
using System.Threading.Tasks;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Xamarin.Forms;

namespace vocal
{
	public class UserProfile : ContentPage
	{
		String uName;
		String uAge;
		String uUsername;
		Label name;
		Label age;
		Label username;
		private Controller controller = new Controller();
		IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;
		String url;
		public UserProfile(String user)
		{
			uUsername = user;
			PopulateInfo();
			this.Title = "Profile";
			Label usernameL = new Label
			{
				Text = "Username:",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};
			username = new Label
			{
				Text = uUsername,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
			};
			Label nameL = new Label
			{
				Text = "Name:",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};
			name = new Label
			{
				Text = uName,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
			};
			Label ageL = new Label
			{
				Text = "Age:",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};
			age = new Label
			{
				Text = uAge,
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
			};
			Button listenButton = new Button
			{
				Text = "Listen to Audio Bio",
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Fill,
				HeightRequest = 80
			};
			listenButton.Clicked += (sender, e) =>
			{
				CrossMediaManager.Current.Play(url);
			};
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			// Build the page.
			this.Content = new StackLayout
			{
				Children =
				{
					usernameL,
					username,
					nameL,
					name,
					ageL,
					age,
					listenButton
				}
			};
		}
		async Task<VocalUser> PopulateInfo()
		{
			VocalUser user = await controller.GetUserAsync(uUsername);
			uName = user.Name;
			uAge = user.Age.ToString();
			name.Text = uName;
			age.Text = uAge;
			url = await controller.GetSoundUrl(uUsername);
			return user;
		}
	}
}
