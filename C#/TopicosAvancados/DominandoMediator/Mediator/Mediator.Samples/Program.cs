using Mediator.Abstractions;

Console.WriteLine("Hello, World!");

public class CreateAccountCommand : IRequest<string>
{
    
}

public class CreateAccountCommandHandler : IHandler<CreateAccountCommand, string>
{
    public Task<string> HandleAsync(CreateAccountCommand request, CancellationToken cancellationToken = default)
    {
        return Task.FromResult("Hello, World!");
    }
}
