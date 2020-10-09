using System;
using System.Collections.Generic;
using System.Text;

namespace Blazored.Toast
{
    public class CloseEventArgs : EventArgs
    {
        public BlazoredToast Toast { get; set; }
        /// <summary>
        /// Sepcifies if Closing event is triggered automatically.
        /// E.g.: From timeout
        /// </summary>
        public bool AutoClose { get; set; }

    }
}
