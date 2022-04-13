using System;
using Models;

public struct ExpressionStore<TModel, TValue> : IExpressionStore where TModel : IModel
{
    public Action<TModel, TValue> Action;

    public ExpressionStore(Action<TModel, TValue> action)
    {
        Action = action;
    }

    public void Invoke<TModel2, TValue2>(TModel2 model, TValue2 value) where TModel2 : IModel
    {
        Action?.Invoke((TModel) (object) model, (TValue) (object) value);
    }
}