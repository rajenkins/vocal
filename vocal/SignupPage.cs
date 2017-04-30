using System;
using Xamarin.Forms;

namespace vocal
{
	public class SignupPage : ContentPage
	{
		Entry usernameEntry;
		Label messageLabel;

		public SignupPage()
		{
            this.Title = "Username";
            this.BackgroundColor = Color.White;

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
					usernameEntry,
					messageLabel,
					nameSubmit
				}
			};
		}

		async void SubmitName(object sender, EventArgs e)
		{
			var user = new UserAccount
			{
				username = usernameEntry.Text,
			};

			var isValid = CheckNameAvail(user);
			if (isValid)
			{
				Navigation.InsertPageBefore(new Menu(), this);
				await Navigation.PushAsync(new SignupPage2(user));
			}
			else
			{
				messageLabel.Text = "Username is taken";
			}
		}

		bool CheckNameAvail(UserAccount user)
		{
			return user.username != Constants.Username;

		}
	}
}
