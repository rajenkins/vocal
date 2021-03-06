﻿//
//  Copyright (c) 2016 MatchboxMobile
//  Licensed under The MIT License (MIT)
//  http://opensource.org/licenses/MIT
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
//  TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
//  THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
//  CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
//  IN THE SOFTWARE.
//
using Xamarin.Forms;
using SQLite;
using System;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;

namespace vocal
{
	public class CardView : ContentView
	{
		public Label Name { get; set;}
		public Button PlayAudio { get; set;}
		//public Button LikeButton { get; set;}
		//public Button DislikeButton { get; set;}
		public string AudioUrl { get; set;}
		public Label Location { get; set;}
		public Label Description { get; set;}
		public string Username { get; set; }
		public IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;
		private Controller controller = new Controller();

		public CardView ()
		{
			RelativeLayout view = new RelativeLayout ();

			// box view as the background
			BoxView boxView1 = new BoxView {
				Color = Color.FromRgb (190,0,0),
				InputTransparent=true
			};
			AccessibilityEffect.SetInAccessibleTree(boxView1, true);
			view.Children.Add (boxView1,
				Constraint.Constant (0), Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {					
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				})
			);

			// items image
			PlayAudio = new Button () {				
				Text = "Play Audio",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.White,
				HeightRequest = 100,
				TextColor = Color.Black
				//WidthRequest = 200
			};
			PlayAudio.Clicked += PlayUserAudio;
			/*LikeButton = new Button()
			{
				Text = "Like",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.White,
				HeightRequest = 80,
				IsVisible = Device.OnPlatform<bool>(true, false, false)
			};
			LikeButton.Clicked += LikeLink;
			DislikeButton = new Button()
			{
				Text = "Dislike",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 2,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.White,
				HeightRequest = 80,
				IsVisible = Device.OnPlatform<bool>(true, false, false)
			};
			DislikeButton.Clicked += DislikeLink;
			*/
			view.Children.Add (PlayAudio,
				Constraint.Constant (0), 
				//Constraint.Constant (50),
				Constraint.RelativeToParent ((parent) => {
					double h = parent.Height * 0.80;
					return ((parent.Height - h)/2) + 120;
				}),
				Constraint.RelativeToParent ((parent) => {					
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Height * 0.80);
				})
			);
			/*view.Children.Add (LikeButton,
				Constraint.Constant (0), 
				//Constraint.Constant (50),
				Constraint.RelativeToParent ((parent) => {
					double h = parent.Height * 0.80;
					return ((parent.Height - h)/2) + 40;
				}),
				Constraint.RelativeToParent ((parent) => {					
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Height* 0.80);
				})
			);
			view.Children.Add (DislikeButton,
				Constraint.Constant (0), 
				//Constraint.Constant (50),
				Constraint.RelativeToParent ((parent) => {
					double h = parent.Height * 0.80;
					return ((parent.Height - h)/2) + 130;
				}),
				Constraint.RelativeToParent ((parent) => {					
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Height* 0.80);
				})
			);
*/
			// items label
			Name = new Label () {				
				TextColor = Color.White,
				FontSize = 22,
				InputTransparent=true
			};
			view.Children.Add (Name,
				Constraint.Constant (10), Constraint.Constant (10),
				Constraint.RelativeToParent ((parent) => {					
					return parent.Width;
				}),
				Constraint.Constant (28)
			);

			// location icon
			Image icon = new Image () {
				Source = "location.png",
				InputTransparent=true
			};
			view.Children.Add (icon,
				Constraint.Constant (10), Constraint.Constant (40));

			// location description
			Location = new Label () {	
				Text = "Chapel Hill, NC",
				TextColor = Color.White,
				FontSize = 14,
				InputTransparent=true
			};
			view.Children.Add (Location,
				Constraint.Constant (30), Constraint.Constant (40),
				Constraint.RelativeToParent ((parent) => {					
					return parent.Width;
				}),
				Constraint.Constant (28)
			);				


			StackLayout stack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				Spacing = 2
			};


			view.Children.Add (stack,
				Constraint.RelativeToParent ((parent) => {					
					return parent.Width - 90;
				}), 
				Constraint.Constant (40));

			// bottom label
			Description = new Label () {				
				TextColor = Color.White,
				FontSize = 20,
				FontAttributes=FontAttributes.Bold,
				HorizontalOptions=LayoutOptions.CenterAndExpand,
				HorizontalTextAlignment=TextAlignment.Center,
				InputTransparent=true
			};
			view.Children.Add (
				Description,
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {					
					return parent.Height - 30;
				}),
				Constraint.RelativeToParent ((parent) => {					
					return parent.Width;
				}),
				Constraint.Constant (40)
			);

			Content = view;
		}
		async void PlayUserAudio(object sender, EventArgs e)
		{
			await CrossMediaManager.Current.Play(AudioUrl);
		}
		async void LikeLink(object sender, EventArgs e)
		{
			await controller.Like(App.username, Username);
		}
		async void DislikeLink(object sender, EventArgs e)
		{
			await controller.Dislike(App.username, Username);
		}
	}
}

