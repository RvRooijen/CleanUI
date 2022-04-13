using System;
using UnityEngine;

public struct GenObserver<T> : IGenObserver
{
    public Action<T> Action;

    public GenObserver(Action<T> action)
    {
        Action = action;
    }

    public void Invoke(object value)
    {
        if (value is T castedValue) Action?.Invoke(castedValue);
        else Debug.LogError($"Value '{value}' is not typeof({typeof(T).Name})");
    }

    public bool Equals(GenObserver<T> other)
    {
        return Equals(Action, other.Action);
    }

    public override bool Equals(object obj)
    {
        return obj is GenObserver<T> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return (Action != null ? Action.GetHashCode() : 0);
    }
}