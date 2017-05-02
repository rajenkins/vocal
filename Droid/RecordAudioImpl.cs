using Android.Speech.Tts;
using Xamarin.Forms;
using System.Collections.Generic;
using vocal.Droid;
using System.Net.Http;

[assembly: Xamarin.Forms.Dependency(typeof(RecordAudioImpl))]
namespace vocal.Droid
{

	public class RecordAudioImpl : Java.Lang.Object, IRecordAudio
	{

		public RecordAudioImpl() { }

		public void SetupRecord()
		{

		}	
		public void Record()
		{	
		
		}	

		public string Stop()
		{
			return "";
		}
		public StreamContent Stop2()
		{
			return new StreamContent("");
		}

	}
}
