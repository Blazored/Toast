using System;

namespace Blazored.Toast.Extensions
{
    public class ToastsCountException : Exception
    {
        public ToastsCountException(int expected, int actual)
            : base($"The number of toasts expected {expected}, does not match the number of toasts found {actual}.")
        {
        }
    }
}
