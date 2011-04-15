using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrazyTones.Core
{
    public class WaveSine : IWaveType
    {
        public WaveHeader Header { get; private set; }
        public WaveFormatChunk Format { get; private set; }
        public WaveDataChunk Data { get; private set; }

        public WaveSine()
        {
            Header = new WaveHeader();
            Data = new WaveDataChunk();
            Format = new WaveFormatChunk();
            Initialize();
        } 

        public void Initialize()
        {
            uint numSamples = Format.SamplesPerSec * Format.NumberOfChannels;
            Data.ShortArray = new short[numSamples];
            int amplitude = 32760;
            double freq = 440.0f;
            double t = (Math.PI * 2 * freq) / (Format.SamplesPerSec * Format.NumberOfChannels);

            for (uint i = 0; i < numSamples - 1; i++)
            {
                for (int channel = 0; channel < Format.NumberOfChannels; channel++)
                {
                    Data.ShortArray[i + channel] = Convert.ToInt16(amplitude * Math.Sin(t * i));
                }
            }

            Data.LenghtOfHeaderInBytes = (uint)(Data.ShortArray.Length * (Format.BitsPerSample / 8));
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