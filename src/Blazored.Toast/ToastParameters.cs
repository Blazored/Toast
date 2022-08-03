using System.Collections.Generic;

namespace Blazored.Toast;

public class ToastParameters
{
    internal Dictionary<string, object> _parameters;
    public ToastParameters()
    {
        _parameters = new Dictionary<string, object>();
    }
    public void Add(string parameterName, object value)
    {
        _parameters[parameterName] = value;
    }

    public T Get<T>(string parameterName)
    {
        if (_parameters.TryGetValue(parameterName, out var value))
        {
            return (T)value;
        }

        throw new KeyNotFoundException($"{parameterName} does not exist in toast parameters");
    }

    public T TryGet<T>(string parameterName)
    {
        if (_parameters.TryGetValue(parameterName, out var value))
        {
            return (T)value;
        }

        return default;
    }
}
