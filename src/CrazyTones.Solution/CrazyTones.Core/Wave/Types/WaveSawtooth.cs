using System;

namespace CrazyTones.Core.Wave.Types
{
    public class WaveSawtooth : WaveBase
    {
        private const int AMPLITUDE = 32760;
        private const double FREQUENCY = 1000;
        private const Int16 CHANNELS = 2;

        public WaveSawtooth()
        {
            Initialize();
        }

        public override sealed void Initialize()
        {
            const int bufferDurationSeconds = 1;
            var numSamples = Convert.ToInt32(bufferDurationSeconds * Format.SamplesPerSec);
            var sampleData = new short[numSamples];
            double angle = (Math.PI * 2 * FREQUENCY) / (Format.SamplesPerSec * CHANNELS);

            int samplesPerPeriod = Convert.ToInt32(Format.SamplesPerSec / (FREQUENCY / CHANNELS));
            short sampleStep = Convert.ToInt16((AMPLITUDE * 2) / samplesPerPeriod);

            int totalSamplesWritten = 0;
            while (totalSamplesWritten < numSamples)
            {
                var tempSample = (short)-AMPLITUDE;
                for (int i = 0; i < samplesPerPeriod && totalSamplesWritten < numSamples; i++)
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
        