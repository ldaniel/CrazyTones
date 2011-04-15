namespace CrazyTones.Core.Wave.Chunk
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