using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace vocal.iOS
{
	public class AddAccessibilityEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			try
			{
				Control.AccessibilityLabel = AccessibilityEffect.GetAccessibilityLabel(Element);
				// other properties
			}
			catch (Exception ex)
			{
				Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
			}
		}

		protected override void OnDetached()
		{
		}

		protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
		{
			if (args.PropertyName == AccessibilityEffect.AccessibilityLabelProperty.PropertyName)
			{
				Control.AccessibilityLabel = AccessibilityEffect.GetAccessibilityLabel(Element);
			}
			else if (args.PropertyName == AccessibilityEffect.InAccessibleTreeProperty.PropertyName)
			{
				Control.IsAccessibilityElement = AccessibilityEffect.GetInAccessibleTree(Element);
			}
			// ... other properties
			else
			{
				base.OnElementPropertyChanged(args);
			}
		}
	}
}
