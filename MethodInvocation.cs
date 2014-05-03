// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MethodInvocation.cs" company="">
//   
// </copyright>
// <summary>
//   Describes a method invocation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal
{
    using System;

    /// <summary>
    /// Describes a method invocation.
    /// </summary>
    [Serializable]
    public class MethodInvocation
    {
        /// <summary>
        /// Gets or sets the interface id.
        /// </summary>
        public int InterfaceId { get; set; }

        /// <summary>
        /// Gets or sets the method id.
        /// </summary>
        public int MethodId { get; set; }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        public object[] Arguments { get; set; }
    }
}