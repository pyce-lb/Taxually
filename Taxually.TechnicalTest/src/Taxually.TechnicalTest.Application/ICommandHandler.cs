namespace Taxually.TechnicalTest.Application;

public interface ICommandHandler<in T> where T : ICommand
{
    ValueTask HandleAsync(T command, CancellationToken cancellationToken = default);
}
