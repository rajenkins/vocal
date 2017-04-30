using System;
using Xamarin.Forms;

namespace vocal
{
	public class LoginPage : ContentPage
	{
		Entry usernameEntry;
		Entry passwordEntry;
		Label messageLabel;

		public LoginPage()
		{
            this.Title = "Login";
            this.BackgroundColor = Color.White;



			usernameEntry = new Entry { Placeholder = "Username" };

			passwordEntry = new Entry { Placeholder = "Password", IsPassword = true };

			messageLabel = new Label();

			Button loginButton = new Button
			{
				Text = "Log In",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 200
			};
			loginButton.Clicked += login;


			Button signupButton = new Button
			{
				Text = "Sign Up",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 200
			};
			signupButton.Clicked += signup;


			// Accomodate iPhone status bar.
			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			// Build the page.
			this.Content = new StackLayout
				 {
					 Children =
						{
							usernameEntry,
							passwordEntry,
							messageLabel,
					        loginButton,
					        signupButton
						}
				 };
		}
		async void signup(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SignupPage());
		}

		async void login(object sender, EventArgs e)
		{
			var user = new UserAccount
			{
				username = usernameEntry.Text,
				password = passwordEntry.Text
			};

			var isValid = AreCredentialsCorrect(user);
			if (isValid)
			{
				App.IsUserLoggedIn = true;
				Navigation.InsertPageBefore(new Menu(), this);
				await Navigation.PopAsync();
			}
			else
			{
				messageLabel.Text = "Login failed";
				passwordEntry.Text = string.Empty;
			}
		}

		bool AreCredentialsCorrect(UserAccount user)
		{
			return user.username == Constants.Username && user.password == Constants.Password;
		}	
	}
}
