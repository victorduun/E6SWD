namespace LightsCommand
{
    public class doThisCmd : ICommand
    {
        private Reciever _sender;
        public doThisCmd(Reciever sender)
        {
            _sender = sender;
        }
        public void execute()
        {
            _sender.doThis();
        }
    }
}
