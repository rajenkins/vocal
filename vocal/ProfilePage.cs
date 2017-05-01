using System;
using Xamarin.Forms;

namespace vocal
{
	public class ProfilePage : ContentPage
	{
		String uName;
		String uAge;
		Label name;
		Label age;
		private Controller controller = new Controller();
		public ProfilePage()
		{
			PopulateInfo();
            this.Title = "Profile";
			this.BackgroundColor = Color.White;
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
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = 200
			};
			basicButton.Clicked += showUpdateBasicPage;
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
			Label cat1 = new Label
			{
				Text = "Category 1",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};
			Label cat2 = new Label
			{
				Text = "Category 2",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};
			Label cat3 = new Label
			{
				Text = "Category 1",
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
									cat1,
									cat2,
									cat3
								}
				 };
		}
		async void PopulateInfo()
		{
			VocalUser user = await controller.GetUserAsync(App.username);
			uName = user.Name;
			uAge = user.Age.ToString();
			name.Text = uName;
			age.Text = uAge;
		}

		async void showUpdateBasicPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new UpdateBasicPage(uName, uAge, controller));
		}
	}
}
