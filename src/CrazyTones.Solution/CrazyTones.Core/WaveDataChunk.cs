namespace CrazyTones.Core
{
    public class WaveDataChunk
    {
        public string ChunkID;    
        public uint LenghtOfHeaderInBytes;   
        public short[] ShortArray8Bits;  

        public WaveDataChunk()
        {
            ShortArray8Bits = new short[0];
            LenghtOfHeaderInBytes = 0;
            ChunkID = "data";
        }   
    }
}
