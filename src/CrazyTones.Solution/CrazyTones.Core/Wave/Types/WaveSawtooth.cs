using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrazyTones.Core
{
    public class WaveSawtooth : WaveBase
    {
        private const int AMPLITUDE = 32760;
        private const double FREQUENCY = 1000;
        private const Int16 CHANNELS = 2;

        public WaveSawtooth()
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

            int samplesPerPeriod = Convert.ToInt32(Format.SamplesPerSec / (FREQUENCY / CHANNELS));
            short sampleStep = Convert.ToInt16((AMPLITUDE * 2) / samplesPerPeriod);
            short tempSample = 0;

            int i = 0;
            int totalSamplesWritten = 0;
            while (totalSamplesWritten < numSamples)
            {
                tempSample = (short)-AMPLITUDE;
                for (i = 0; i < samplesPerPeriod && totalSamplesWritten < numSamples; i++)
                {
                    tempSample += sampleStep;
                    sampleData[totalSamplesWritten] = tempSample;

                    totalSamplesWritten++;
                }
            }


            Data.LenghtOfHeaderInBytes = (uint)(Data.ShortArray.Length * (Format.BitsPerSample / 8));
        }
    }
}
        