namespace CompressionStocking.BusinessLogic
{
    public interface ICompressionCtrl
    {
        void Compress();
        void Decompress();

        void Stop();
    }
}
