using Android.Speech.Tts;
using Xamarin.Forms;
using System.Collections.Generic;
using vocal.Droid;
using System.Net.Http;
using Android.Media;
using System.IO;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(RecordAudioImpl))]
namespace vocal.Droid
{

	public class RecordAudioImpl : Java.Lang.Object, IRecordAudio
	{
		MediaRecorder recorder;

		string audioFilePath;


		public RecordAudioImpl() { }

		public void SetupRecord()
		{
			
			string fileName = string.Format("Myfile{0}.m4a", DateTime.Now.ToString("yyyyMMddHHmmss"));
			audioFilePath = Path.Combine(Path.GetTempPath(), fileName);

			recorder = new MediaRecorder();
			recorder.SetAudioSource (AudioSource.Mic);
			recorder.SetOutputFormat (OutputFormat.Mpeg4);
			recorder.SetAudioEncoder (AudioEncoder.AmrNb);
			recorder.SetOutputFile (audioFilePath);
			recorder.Prepare ();
			//recorder.Start();

      		
		}	
		public void Record()
		{	
			recorder.Start ();
		}	

		public string Stop()
		{
			recorder.Stop ();
			recorder.Reset ();

			return "";
		}
		public StreamContent Stop2()
		{
			recorder.Stop ();
			recorder.Reset ();
			var content = new MultipartFormDataContent();
			var fileStream = new FileStream(audioFilePath, FileMode.Open, FileAccess.Read);
			var stream = new StreamContent(fileStream);
			return stream;
		}

	}
}
