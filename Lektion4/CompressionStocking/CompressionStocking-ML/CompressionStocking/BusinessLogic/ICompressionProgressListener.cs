namespace CompressionStocking.BusinessLogic
{
    public interface ICompressionProgressListener
    {
        void CompressionStarted();
        void CompressionComplete();
        void DecompressionStarted();
        void DecompressionComplete();
    }
}
