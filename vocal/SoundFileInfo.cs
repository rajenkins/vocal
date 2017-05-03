using System;
using System.Net.Http;

namespace vocal
{
	public class SoundFileInfo
	{
		public StreamContent stream { get; set; }
		public String format { get; set; }
		public SoundFileInfo(StreamContent stream, String format)
		{
			this.stream = stream;
			this.format = format;
		}
		public SoundFileInfo()
		{

		}
	}
}
