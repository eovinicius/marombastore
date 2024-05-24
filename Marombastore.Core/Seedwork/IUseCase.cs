namespace Marombastore.Core.Seedwork;

public interface IUseCase<Input>
{
    Task Execute(Input data);
}

public interface IUseCase<Input, Output>
{
    Task<Output> Execute(Input data);
}