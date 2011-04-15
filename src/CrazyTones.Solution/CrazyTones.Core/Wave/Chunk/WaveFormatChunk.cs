namespace CrazyTones.Core.Wave.Chunk
{
    public class WaveFormatChunk
    {
        public string ChunkID;    
        public uint LenghtOfHeaderInBytes;        
        public ushort FormatTag;       
        public ushort NumberOfChannels;
        public uint SamplesPerSec;   
        public uint AvgBytesPerSec;   
        public ushort SampleFrameSizeInBytes;
        public ushort BitsPerSample;    

        public WaveFormatChunk()
        {
            ChunkID = "fmt ";
            LenghtOfHeaderInBytes = 16;
            FormatTag = 1;
            NumberOfChannels = 2;
            SamplesPerSec = 44100;
            BitsPerSample = 16;
            SampleFrameSizeInBytes = (ushort)(NumberOfChannels * (BitsPerSample / 8));
            AvgBytesPerSec = SamplesPerSec * SampleFrameSizeInBytes;            
        }
    }
}