#region .NET Base Class Namespace Imports
using System;
#endregion

#region Compiled Technologies Assemblies
using CompiledTechnologies.Files;
#endregion

namespace CompiledTechnologies.Events
{
    #region ******************************** Public Event Handler *************************************
    public delegate void DataReceivedHandler(object sender, DataReceivedArgs e);
    public class DataReceivedArgs : EventArgs
    {
        public DLFILE DL { get; set; }
    }
    #endregion
}
