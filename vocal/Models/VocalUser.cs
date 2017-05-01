using Xamarin.Forms;
using SQLite;

namespace vocal
{
	public class VocalUser
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Username { get; set; }
		public string Name { get; set; }
		public string Photo { get; set; }
		public string Location { get; set; }
		public string Description { get; set;}
		public int Age { get; set; }
	}
}