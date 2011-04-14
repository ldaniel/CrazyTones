using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrazyTones.Core
{
    public class WaveSquare : WaveBase
    {
        private const int AMPLITUDE = 32760;
        private const double FREQUENCY = 1000;
        private const Int16 CHANNELS = 2;

        public WaveSquare()
        {
            Header = new WaveHeader();
            Data = new WaveDataChunk();
            Format = new WaveFormatChunk();
            Initialize();
        }

        public override void Initialize()
        {
            int bufferDurationSeconds = 1;
            int numSamples = Convert.ToInt32(bufferDurationSeconds * Format.SamplesPerSec);
            short[] sampleData = new short[numSamples];
            double angle = (Math.PI * 2 * FREQUENCY) / (Format.SamplesPerSec * CHANNELS);

            for (int i = 0; i < numSamples; i++)
            {
                if (Math.Sin(angle * i) > 0)
                    sampleData[i] = Convert.ToInt16(AMPLITUDE);
                else
                    sampleData[i] = Convert.ToInt16(-AMPLITUDE);
            }

            Data.LenghtOfHeaderInBytes = (uint)(Data.ShortArray.Length * (Format.BitsPerSample / 8));
        }
    }
}