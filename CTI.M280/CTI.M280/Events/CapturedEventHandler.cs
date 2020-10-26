#region .NET Base Class Namespace Imports
using System;
using System.Drawing;
#endregion

namespace CompiledTechnologies.Events
{
    #region ******************************** Public Event Handler *************************************
    public delegate void CapturedEventHandler(object sender, CapturedEventArgs e);
    public class CapturedEventArgs : EventArgs
    {
        public Bitmap Bitmap { get; set; }
    }
    #endregion
}
