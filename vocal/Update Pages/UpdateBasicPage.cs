using System;
using Xamarin.Forms;
namespace vocal
{
	public class UpdateBasicPage : ContentPage
	{
		Controller controller;
		Entry nameEntry;
		Entry ageEntry;
		public UpdateBasicPage(String name, String age, Controller controller)
		{
			this.controller = controller;
			Label nameLabel = new Label
			{
				Text = "Name:",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
			};
			nameEntry = new Entry { Text = name };
			Label ageLabel = new Label
			{
				Text = "Age:",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
			};
			ageEntry = new Entry { Text = age };
			Button updateButton = new Button
			{
				Text = "Update",
				Font = Font.SystemFontOfSize(NamedSize.Medium),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = 100
			};
			updateButton.Clicked += updateNameAge;
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			// Build the page.
			this.Content = new StackLayout
			{
				Children =
				{
					nameLabel,
					nameEntry,
					ageLabel,
					ageEntry,
					updateButton
				}
			};
		}
		async void updateNameAge(object sender, EventArgs e)
		{
			await controller.UpdateNameAge(nameEntry.Text, ageEntry.Text);
			await Navigation.PopAsync();
		}
	}
}
