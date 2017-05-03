using System;
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

			Label passwordLabel = new Label
			{
				Text = "Password:",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
			};
			passwordEntry = new Entry { Placeholder = "Password"};

			messageLabel = new Label();

			Button pwdSubmit = new Button
			{
				Text = "Create Account",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 80
			};
			pwdSubmit.Clicked += CreateAccount;
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
			this.Content = new StackLayout
				 {
					 Children =
				{
					passwordLabel,
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
			if (user.password == null || user.password == "")
			{
				messageLabel.Text = "Please enter password";
				return;
			}

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
