using System.IO;
using CrazyTones.Core.Wave.Types;

namespace CrazyTones.Core.Wave
{
    public class WaveGenerator
    {
        private readonly IWaveType _wave;
        private FileStream _fileStream;
        private BinaryWriter _writer;

        public WaveGenerator()
        {
            _wave = new WaveSine();   
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
            _writer.Write(_wave.GetDataChunkID().ToCharArray());
            _writer.Write(_wave.GetDataLenghtOfHeaderInBytes());
            
            foreach (var dataPoint in _wave.GetDataShortArray())
            {
                _writer.Write(dataPoint);
            }

            _writer.Seek(4, SeekOrigin.Begin);
            var filesize = (uint)_writer.BaseStream.Length;
            _writer.Write(filesize - 8);
        }

        private void WriteFormat()
        {
            _writer.Write(_wave.GetFormatChunkID().ToCharArray());
            _writer.Write(_wave.GetFormatLenghtOfHeaderInBytes());
            _writer.Write(_wave.GetFormatTag());
            _writer.Write(_wave.GetFormatNumberOfChannels());
            _writer.Write(_wave.GetFormatSamplesPerSec());
            _writer.Write(_wave.GetFormatAvgBytesPerSec());
            _writer.Write(_wave.GetFormatSampleFrameSizeInBytes());
            _writer.Write(_wave.GetFormatBitsPerSample());
        }

        private void WriteHeader()
        {
            _writer.Write(_wave.GetHeaderGroupID().ToCharArray());
            _writer.Write(_wave.GetHeaderFileLength());
            _writer.Write(_wave.GetHeaderRiffType().ToCharArray());
        }
    }
}
