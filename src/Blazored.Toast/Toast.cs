using System;
using System.Collections.Generic;
using System.Text;
using Blazored.Toast.Configuration;

namespace Blazored.Toast
{
    internal class Toast
    {
        public Guid Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public ToastSettings ToastSettings { get; set; }
        public ToastOptions Options { get; internal set; }
    }
}
