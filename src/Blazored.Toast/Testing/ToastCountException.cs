using System;

namespace Blazored.Toast.Testing
{
    public class ToastCountException : Exception
    {
        public ToastCountException(int expected, int actual)
            : base($"The number of toasts expected does not match the number of toasts found. Expected: {expected} Actual: {actual}.")
        {
        }
    }
}
