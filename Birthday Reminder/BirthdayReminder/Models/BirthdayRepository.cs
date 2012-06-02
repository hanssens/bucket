using System;
using System.Collections.Generic;

namespace BirthdayReminder
{
	public class BirthdayRepository : IDisposable
	{
		public List<Birthday> Birthdays {
			get;
			set;
		}
		
		public BirthdayRepository ()
		{
			Birthdays = new List<Birthday>();
			
			// Create a stubbed list of Birthdays
			for (int i = 0; i < 9; i++) {
				var entry = new Birthday(){
					Id = i, DateOfBirth = DateTime.Now.AddYears(- 18 + i)
				};
				
				if (i % 2 == 0)
					entry.Name = "Mannetje no. " + i;
				else
					entry.Name = "Vrouwtje no. " + i;
				
				Birthdays.Add(entry);	
			}
			
		}

		#region IDisposable implementation
		public void Dispose ()
		{
			Birthdays.Clear();
		}
		#endregion
	}
}

