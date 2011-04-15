using CrazyTones.Core.Wave.Chunk;

namespace CrazyTones.Core.Wave.Types
{
    public class WaveBase : IWaveType
    {
        public WaveHeader Header { get; set; }
        public WaveFormatChunk Format { get; set; }
        public WaveDataChunk Data { get; set; }

        public WaveBase()
        {
            Header = new WaveHeader();
            Data = new WaveDataChunk();
            Format = new WaveFormatChunk();
        }

        public virtual void Initialize()
        {

        }

        public string GetHeaderGroupID()
        {
            return Header.GroupID;
        }

        public uint GetHeaderFileLength()
        {
            return Header.FileLength;
        }

        public string GetHeaderRiffType()
        {
            return Header.RiffType;
        }

        public string GetDataChunkID()
        {
            return Data.ChunkID;
        }

        public uint GetDataLenghtOfHeaderInBytes()
        {
            return Data.LenghtOfHeaderInBytes;
        }

        public short[] GetDataShortArray()
        {
            return Data.ShortArray;
        }

        public string GetFormatChunkID()
        {
            return Format.ChunkID;
        }

        public uint GetFormatLenghtOfHeaderInBytes()
        {
            return Format.LenghtOfHeaderInBytes;
        }

        public ushort GetFormatTag()
        {
            return Format.FormatTag;
        }

        public ushort GetFormatNumberOfChannels()
        {
            return Format.NumberOfChannels;
        }

        public uint GetFormatSamplesPerSec()
        {
            return Format.SamplesPerSec;
        }

        public uint GetFormatAvgBytesPerSec()
        {
            return Format.AvgBytesPerSec;
        }

        public ushort GetFormatSampleFrameSizeInBytes()
        {
            return Format.SampleFrameSizeInBytes;
        }

        public ushort GetFormatBitsPerSample()
        {
            return Format.BitsPerSample;
        }
    }
}