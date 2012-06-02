using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace BirthdayReminder
{
	public partial class BirthdayListViewController : UITableViewController
	{
		
		public BirthdayListViewController () : base ("BirthdayListViewController", null)
		{
			// Custom initialization
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			
			TableView.Source = new DataSource (this);
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
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
		
		class DataSource : UITableViewSource
		{
			static NSString cellIdentifier = new NSString ("CellId");
			BirthdayListViewController controller;

			public List<Birthday> _Birthdays {
				get;
				set;
			}
			
			public DataSource (BirthdayListViewController controller)
			{
				this.controller = controller;
				
				using (var repository = new BirthdayRepository())
				{
					_Birthdays = repository.Birthdays.ToList();
				}
			}
			
			// Customize the number of sections in the table view.
			public override int NumberOfSections (UITableView tableView)
			{
				return 1;
			}
			
			public override int RowsInSection (UITableView tableview, int section)
			{
				var rowCount = _Birthdays.Count();
				return rowCount;
			}
			
			// Customize the appearance of table view cells.
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (cellIdentifier);
				if (cell == null) {
					cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
					cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				}
				
				var currentBirthday = _Birthdays[indexPath.Row];
				cell.TextLabel.Text = NSBundle.MainBundle.LocalizedString(
					currentBirthday.Name,
					currentBirthday.Name
				);
				
				return cell;
			}

			/*
			// Override to support conditional editing of the table view.
			public override bool CanEditRow (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
			{
				// Return false if you do not want the specified item to be editable.
				return true;
			}
			*/
			
			/*
			// Override to support editing the table view.
			public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
			{
				if (editingStyle == UITableViewCellEditingStyle.Delete) {
					// Delete the row from the data source.
					controller.TableView.DeleteRows (new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
				} else if (editingStyle == UITableViewCellEditingStyle.Insert) {
					// Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
				}
			}
			*/
			
			/*
			// Override to support rearranging the table view.
			public override void MoveRow (UITableView tableView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
			{
			}
			*/
			
			/*
			// Override to support conditional rearranging of the table view.
			public override bool CanMoveRow (UITableView tableView, NSIndexPath indexPath)
			{
				// Return false if you do not want the item to be re-orderable.
				return true;
			}
			*/
			
			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{	
				// Fetch the selected item from the list of _Birthdays
				var model = _Birthdays[indexPath.Row];
				
				// ... and inject it into a new BirthdayDetailViewController instance
				var detailController = new BirthdayDetailViewController (model);
				
				// Pass the selected object to the new view controller.
				controller.NavigationController.PushViewController (
					detailController,
					true
				);
			}
		}
	}
}
