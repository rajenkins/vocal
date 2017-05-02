public interface IRecordAudio
{
	void SetupRecord();

	void Record();

	string Stop();
}