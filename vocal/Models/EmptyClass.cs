using System;
namespace vocal
{
	public class VocalUser
	{
		public VocalUser()
		{
			[PrimaryKey, AutoIncrement]
			public int ID { get; set; }
			public string Name { get; set; }
			public string Notes { get; set; }
			public bool Done { get; set; }
		}
	}
}
