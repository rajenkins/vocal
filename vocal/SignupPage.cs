using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace vocal
{
	public class SignupPage : ContentPage
	{
		Entry usernameEntry;
		Label messageLabel;
		private Controller controller = new Controller();

		public SignupPage()
		{
            this.Title = "Username";
			Label usernameLabel = new Label
			{
				Text = "Username:",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
			};
			usernameEntry = new Entry { Placeholder = "Username" };

			messageLabel = new Label();

			Button nameSubmit = new Button
			{
				Text = "Submit",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 200
			};
			nameSubmit.Clicked += SubmitName;
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);
			this.Content = new StackLayout
			{
				Children =
				{
					usernameLabel,
					usernameEntry,
					messageLabel,
					nameSubmit
				}
			};
		}

		async void SubmitName(object sender, EventArgs e)
		{
			messageLabel.Text = "Checking username availability";
			var user = new UserAccount
			{
				username = usernameEntry.Text,
			};

			var isValid = await CheckNameAvail(user);
			if (isValid)
			{
				await Navigation.PushAsync(new SignupPage2(user));
			}
			else
			{
				messageLabel.Text = "Username is taken";
			}
		}

		async Task<bool> CheckNameAvail(UserAccount user)
		{
			if (user.username.Length > 0)
			{
				var doesNameExist = await controller.doesNameExist(user.username);
				return !doesNameExist;
			}
			else
			{
				return false;
			}
		}
	}
}
