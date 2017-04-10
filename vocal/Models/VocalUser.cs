using Xamarin.Forms;
using SQLite;

namespace vocal
{
	public class VocalUser
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public Label Name { get; set; }
		public Image Photo { get; set; }
		public Label Location { get; set; }
		public Label Description { get; set;}
	}
}