using System;

namespace CompressionStocking
{
    public interface ICompressionCtrl
    {
        void Compress();
        void Decompress();

        event EventHandler DecompressionStartedEvent;
        event EventHandler DecompressionFinishedEvent;
        event EventHandler CompressionFinishedEvent;
        event EventHandler CompressionStartedEvent;
    }
}