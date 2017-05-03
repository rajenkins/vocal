
using System.Net.Http;

public interface IRecordAudio
{
	void SetupRecord();

	void Record();

	string Stop();

	vocal.SoundFileInfo Stop2();
}