using System;
using System.IO;

namespace CrazyTones.Core
{
    public enum WaveExampleType
    {
        ExampleSineWave = 0
    }

    public class WaveGenerator
    {
        private readonly WaveHeader _header;
        private readonly WaveFormatChunk _format;
        private readonly WaveDataChunk _data;
        private FileStream _fileStream;
        private BinaryWriter _writer;

        public WaveGenerator(WaveExampleType type)
        {          
            _header = new WaveHeader();
            _format = new WaveFormatChunk();
            _data = new WaveDataChunk();            

            switch (type)
            {
                case WaveExampleType.ExampleSineWave:
                    uint numSamples = _format.SamplesPerSec * _format.NumberOfChannels;
                    _data.ShortArray = new short[numSamples];
                    int amplitude = 32760;  
                    double freq = 440.0f;   
                    double t = (Math.PI * 2 * freq) / (_format.SamplesPerSec * _format.NumberOfChannels);

                    for (uint i = 0; i < numSamples - 1; i++)
                    {
                        for (int channel = 0; channel < _format.NumberOfChannels; channel++)
                        {
                            _data.ShortArray[i + channel] = Convert.ToInt16(amplitude * Math.Sin(t * i));
                        }                        
                    }

                    _data.LenghtOfHeaderInBytes = (uint)(_data.ShortArray.Length * (_format.BitsPerSample / 8));

                    break;
            }          
        }

        public void Save(string filePath)
        {
            CreateWriter(filePath);
            WriteHeader();
            WriteFormat();
            WriteData();
            CloseWriter();
        }

        private void CloseWriter()
        {
            _writer.Close();
            _fileStream.Close();
        }

        private void CreateWriter(string filePath)
        {
            _fileStream = new FileStream(filePath, FileMode.Create);
            _writer = new BinaryWriter(_fileStream);
        }

        private void WriteData()
        {
            _writer.Write(_data.ChunkID.ToCharArray());
            _writer.Write(_data.LenghtOfHeaderInBytes);
            foreach (var dataPoint in _data.ShortArray)
            {
                _writer.Write(dataPoint);
            }

            _writer.Seek(4, SeekOrigin.Begin);
            var filesize = (uint)_writer.BaseStream.Length;
            _writer.Write(filesize - 8);
        }

        private void WriteFormat()
        {
            _writer.Write(_format.ChunkID.ToCharArray());
            _writer.Write(_format.LenghtOfHeaderInBytes);
            _writer.Write(_format.FormatTag);
            _writer.Write(_format.NumberOfChannels);
            _writer.Write(_format.SamplesPerSec);
            _writer.Write(_format.AvgBytesPerSec);
            _writer.Write(_format.SampleFrameSizeInBytes);
            _writer.Write(_format.BitsPerSample);
        }

        private void WriteHeader()
        {
            _writer.Write(_header.GroupID.ToCharArray());
            _writer.Write(_header.FileLength);
            _writer.Write(_header.RiffType.ToCharArray());
        }
    }
}
