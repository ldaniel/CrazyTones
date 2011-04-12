namespace CrazyTones.Core
{
    public class WaveHeader
    {
        public string GroupID; 
        public uint FileLength;
        public string RiffType; 

        public WaveHeader()
        {
            FileLength = 0;
            GroupID = "RIFF";
            RiffType = "WAVE";
        }
    }
}