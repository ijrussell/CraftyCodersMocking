namespace BankDemo.Infrastructure
{
    public interface ICommandHandler<in TMessage>
    {
        void Handle(TMessage message);
    }
}
