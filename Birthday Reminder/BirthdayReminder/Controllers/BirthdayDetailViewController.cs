using System;
using System.Drawing;
using System.Collections.Generic;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace BirthdayReminder
{
	public partial class BirthdayDetailViewController : UIViewController
	{
		Birthday birthDay;
		
		public BirthdayDetailViewController (Birthday currentBirthday) : base ("BirthdayDetailViewController", null)
		{
			// BUG: It seems detailDescriptionLabel isn't initialized at startup?
			//detailDescriptionLabel = new UILabel();
			//detailDescriptionLabel.Text = "WOOT";
			
			birthDay = currentBirthday;
			ConfigureView ();
		}
		
		void ConfigureView ()
		{
			// Update the user interface for the detail item
			//if (detailItem != null)
			//	detailDescriptionLabel.Text = detailItem.ToString ();
			
			// Custom note: Well, that doesn't work if the view hasn't been initialized yet
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			
			// Bind and update properties
			detailDescriptionLabel.Text = "Verjaardag: " + birthDay.Name;
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

