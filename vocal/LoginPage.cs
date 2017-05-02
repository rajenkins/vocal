using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace vocal
{
	public class LoginPage : ContentPage
	{
		Entry usernameEntry;
		Entry passwordEntry;
		Label messageLabel;
		private Controller controller = new Controller();

		public LoginPage()
		{
            this.Title = "Login";


			Label usernameLabel = new Label
			{
				Text = "Username:",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
			};
			usernameEntry = new Entry { Placeholder = "Username" };
			Label passwordLabel = new Label
			{
				Text = "Password:",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
			};
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
					usernameLabel,
					usernameEntry,
					passwordLabel,
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
			if (usernameEntry.Text == null || usernameEntry.Text == "")
			{
				messageLabel.Text = "Please enter username";
				return;
			}
			if (passwordEntry.Text == null || passwordEntry.Text == "")
			{
				messageLabel.Text = "Please enter password";
			}
			var user = new UserAccount
			{
				username = usernameEntry.Text,
				password = passwordEntry.Text
			};

			var isValid = await AreCredentialsCorrect(user);
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

		async Task<bool> AreCredentialsCorrect(UserAccount user)
		{
			var isSuccess = await controller.Login(user);
			if (isSuccess)
			{
				return true;
			}
			else
			{
				return false;
			}
		}	
	}
}
