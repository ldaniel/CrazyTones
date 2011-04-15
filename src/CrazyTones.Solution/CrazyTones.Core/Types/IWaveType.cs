using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrazyTones.Core
{
    public interface IWaveType
    {
        string GetHeaderGroupID();
        uint GetHeaderFileLength();
        string GetHeaderRiffType();
        string GetDataChunkID();
        uint GetDataLenghtOfHeaderInBytes();
        short[] GetDataShortArray();
        string GetFormatChunkID();
        uint GetFormatLenghtOfHeaderInBytes();
        ushort GetFormatTag();
        ushort GetFormatNumberOfChannels();
        uint GetFormatSamplesPerSec();
        uint GetFormatAvgBytesPerSec();
        ushort GetFormatSampleFrameSizeInBytes();
        ushort GetFormatBitsPerSample();
        void Initialize();
    }
}
