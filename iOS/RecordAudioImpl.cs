using vocal.iOS;
using AVFoundation;
using Foundation;
using System;
using System.IO;
using System.Net.Http;

[assembly: Xamarin.Forms.Dependency(typeof(RecordAudioImpl))]
namespace vocal.iOS
{



	public class RecordAudioImpl : IRecordAudio
	{
		AVAudioRecorder recorder; NSError error; NSUrl url; NSDictionary settings;
		string audioFilePath;
		public RecordAudioImpl() { }

		public void SetupRecord()
		{
			//initialize audio session
			var audioSession = AVAudioSession.SharedInstance();
			var err = audioSession.SetCategory(AVAudioSessionCategory.PlayAndRecord);
			if (err != null)
			{
				Console.WriteLine("audioSession: {0}", err);
				return;
			}
			err = audioSession.SetActive(true);
			if (err != null)
			{
				Console.WriteLine("audioSession: {0}", err);
				return;
			}
			//Declare string for application temp path and tack on the file extension 
			string fileName = string.Format("Myfile{0}.wav", DateTime.Now.ToString("yyyyMMddHHmmss"));
			audioFilePath = Path.Combine(Path.GetTempPath(), fileName);

			Console.WriteLine("Audio File Path: " + audioFilePath);

			url = NSUrl.FromFilename(audioFilePath); //set up the NSObject Array of values that will be combined with the keys to make the NSDictionary
			NSObject[] values = new NSObject[] { NSNumber.FromFloat (44100.0f), //Sample Rate
				NSNumber.FromInt32 ((int)AudioToolbox.AudioFormatType.LinearPCM), //AVFormat 
				NSNumber.FromInt32 (2), //Channels 
				NSNumber.FromInt32 (16), //PCMBitDepth 
				NSNumber.FromBoolean (false), //IsBigEndianKey 
				NSNumber.FromBoolean (false) //IsFloatKey 
			};

			//Set up the NSObject Array of keys that will be combined with the values to make the NSDictionary
			NSObject[] keys = new NSObject[] {
				AVAudioSettings.AVSampleRateKey,
				AVAudioSettings.AVFormatIDKey,
				AVAudioSettings.AVNumberOfChannelsKey,
				AVAudioSettings.AVLinearPCMBitDepthKey,
				AVAudioSettings.AVLinearPCMIsBigEndianKey,
				AVAudioSettings.AVLinearPCMIsFloatKey};


			//Set Settings with the Values and Keys to create the NSDictionary
			settings = NSDictionary.FromObjectsAndKeys(values, keys);

			//Set recorder parameters 
			recorder = AVAudioRecorder.Create(url, new AudioSettings(settings), out error);
		}

		public void Record()
		{
			recorder.Record();
		}

		public string Stop()
		{
			recorder.Stop();
			return audioFilePath;
		}
		public StreamContent Stop2() 
		{
			recorder.Stop();
			var content = new MultipartFormDataContent();
			var fileStream = new FileStream(audioFilePath, FileMode.Open, FileAccess.Read);
			var stream = new StreamContent(fileStream);
			return stream;
		}

	}
}