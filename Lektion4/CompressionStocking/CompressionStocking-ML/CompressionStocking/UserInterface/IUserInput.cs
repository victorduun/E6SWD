namespace CompressionStocking.UserInterface
{
    public abstract class IUserInput
    {
        public void SetInputHandler(IInputHandler handler)
        {
            inputHandler = handler;
        }

        protected IInputHandler inputHandler;
    }
}
