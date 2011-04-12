namespace CrazyTones.Core
{
    public class WaveHeader
    {
        public string SGroupID; 
        public uint DwFileLength;
        public string SRiffType; 

        public WaveHeader()
        {
            DwFileLength = 0;
            SGroupID = "RIFF";
            SRiffType = "WAVE";
        }
    }
}