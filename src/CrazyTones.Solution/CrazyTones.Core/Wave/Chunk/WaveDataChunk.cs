namespace CrazyTones.Core.Wave.Chunk
{
    public class WaveDataChunk
    {
        public string ChunkID;    
        public uint LenghtOfHeaderInBytes;   
        public short[] ShortArray;  

        public WaveDataChunk()
        {
            ShortArray = new short[0];
            LenghtOfHeaderInBytes = 0;
            ChunkID = "data";
        }   
    }
}
