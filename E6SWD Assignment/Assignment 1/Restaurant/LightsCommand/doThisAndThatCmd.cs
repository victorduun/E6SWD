namespace LightsCommand
{
    public class doThisAndThatCmd : ICommand
    {
        private Reciever _sender;
        public doThisAndThatCmd(Reciever sender)
        {
            _sender = sender;
        }
        public void execute()
        {
            _sender.doThis();
            _sender.doThat();
        }
    }
}