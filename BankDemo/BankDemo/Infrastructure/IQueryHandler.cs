namespace BankDemo.Infrastructure
{
    public interface IQueryHandler<in TRequest, out TResponse> where TRequest : IQuery<TResponse>
    {
        TResponse Handle(TRequest request);
    }
}
