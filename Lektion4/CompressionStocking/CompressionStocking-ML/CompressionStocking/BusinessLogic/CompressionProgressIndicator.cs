using System.Collections.Generic;

namespace CompressionStocking.BusinessLogic
{
    public class CompressionProgressIndicator : ICompressionProgressListener
    {
        List<OnOffDevice> compressionRunningIndicators = new List<OnOffDevice>();
        List<OnOffDevice> decompressionRunningIndicators = new List<OnOffDevice>();

        public void CompressionComplete()
        {
            foreach (var d in compressionRunningIndicators)
            {
                d.TurnOff();
            }
        }

        public void CompressionStarted()
        {
            foreach (var d in compressionRunningIndicators)
            {
                d.TurnOn();
            }
        }

        public void DecompressionComplete()
        {
            foreach (var d in decompressionRunningIndicators)
            {
                d.TurnOff();
            }
        }

        public void DecompressionStarted()
        {
            foreach (var d in decompressionRunningIndicators)
            {
                d.TurnOn();
            }
        }

        public void AddCompressionRunningIndicator(OnOffDevice device)
        {
            compressionRunningIndicators.Add(device);
        }

        public void AddDecompressionRunningIndicator(OnOffDevice device)
        {
            decompressionRunningIndicators.Add(device);
        }
    }
}
