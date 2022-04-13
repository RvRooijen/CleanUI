using Models;

public interface IExpressionStore
{
    void Invoke<M, T>(M model, T value) where M : IModel;
}