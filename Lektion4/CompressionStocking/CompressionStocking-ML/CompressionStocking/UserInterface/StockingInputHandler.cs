namespace CompressionStocking.UserInterface
{
    public class StockingInputHandler : IInputHandler
    {
        ICompressionStocking stocking;

        public StockingInputHandler(ICompressionStocking theStocking)
        {
            stocking = theStocking;
        }

        public void HandleStartButtonPushed()
        {
            stocking.StartCompression();
        }

        public void HandleStopButtonPushed()
        {
            stocking.StartDecompression();
        }
    }
}
