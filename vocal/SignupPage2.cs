﻿using System;
using Xamarin.Forms;
namespace vocal
{
	public class SignupPage2 : ContentPage
	{
		Entry passwordEntry;
		Label messageLabel;
		private Controller controller = new Controller();
		UserAccount user;

		public SignupPage2(UserAccount user)
		{
			this.user = user;
			this.Title = "Password";
            this.BackgroundColor = Color.White;

			passwordEntry = new Entry { Placeholder = "Password", IsPassword=true };

			messageLabel = new Label();

			Button pwdSubmit = new Button
			{
				Text = "Create Account",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 200
			};
			pwdSubmit.Clicked += CreateAccount;
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
			this.Content = new StackLayout
				 {
					 Children =
				{
					passwordEntry,
					messageLabel,
					pwdSubmit
				}
			};
		}
		async void CreateAccount(object sender, EventArgs e)
		{
			messageLabel.Text = "Creating Account...";
			user.password = passwordEntry.Text;

			var isSuccess = await controller.AddUser(user);
			if (isSuccess)
			{
				App.IsUserLoggedIn = true;
				var nav = new NavigationPage(new Menu());
				await nav.PushAsync(new ProfilePage());
				App.Current.MainPage = nav;

			}
			else
			{
				messageLabel.Text = "Failed";
			}
		}
			
	}
}