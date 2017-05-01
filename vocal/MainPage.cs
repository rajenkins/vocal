//
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
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace vocal
{
	public class MainPage : ContentPage
	{				
		CardStackView cardStack;
		MainPageViewModel viewModel = new MainPageViewModel();
		private Controller controller = new Controller();
	
		public MainPage ()
		{
			this.BindingContext = viewModel;	
			this.BackgroundColor = Color.Black;

			RelativeLayout view = new RelativeLayout ();

			cardStack = new CardStackView ();
			cardStack.SetBinding(CardStackView.ItemsSourceProperty, "ItemsList");
			getData("Beth",cardStack);
			cardStack.SwipedLeft += SwipedLeft;
			cardStack.SwipedRight += SwipedRight;

			view.Children.Add (cardStack,
				Constraint.Constant (30), 
				Constraint.Constant (60),
				Constraint.RelativeToParent ((parent) => {					
					return parent.Width-60;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height-140;
				})
			);	

			this.LayoutChanged += (object sender, EventArgs e) => 
			{
				cardStack.CardMoveDistance = (int)(this.Width * 0.60f);
			};

			this.Content = view;
		}

		void SwipedLeft(int index)
		{
			// card swiped to the left
		}	
		
		void SwipedRight(int index)
		{
			// card swiped to the right
		}
		async void getData(String u, CardStackView csv)
		{
			await controller.GetPotentialMatches(App.username);
			await csv.loadNextCard();
			await csv.loadNextCard();
			await csv.loadNextCard();
			csv.Setup();
		}
	}
}