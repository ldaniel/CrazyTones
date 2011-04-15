using System;

namespace CrazyTones.Core.Wave.Types
{
    public class WaveSine : WaveBase
    {
        private const int AMPLITUDE = 32760;
        private const double FREQUENCY = 440.0f;

        public WaveSine()
        {
            Initialize();
        } 

        public override sealed void Initialize()
        {
            uint numSamples = Format.SamplesPerSec * Format.NumberOfChannels;
            Data.ShortArray = new short[numSamples];            
            double t = (Math.PI * 2 * FREQUENCY) / (Format.SamplesPerSec * Format.NumberOfChannels);

            for (uint i = 0; i < numSamples - 1; i++)
            {
                for (int channel = 0; channel < Format.NumberOfChannels; channel++)
                {
                    Data.ShortArray[i + channel] = Convert.ToInt16(AMPLITUDE * Math.Sin(t * i));
                }
            }

            Data.LenghtOfHeaderInBytes = (uint)(Data.ShortArray.Length * (Format.BitsPerSample / 8));
        }
    }
}