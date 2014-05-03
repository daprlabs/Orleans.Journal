// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GrainExecutionHelper.cs" company="">
//   
// </copyright>
// <summary>
//   Methods surrounding the execution of requests on grains.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Orleans.Journal
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;

    using Orleans;

    /// <summary>
    /// Methods surrounding the execution of requests on grains.
    /// </summary>
    /// <remarks>
    /// WARNING:
    /// This class is the current source of sin for this project and will hopefully be replaced by a better solution.
    /// </remarks>
    public static class GrainExecutionHelper
    {
        /// <summary>
        /// Initializes static members of the <see cref="GrainExecutionHelper"/> class.
        /// </summary>
        static GrainExecutionHelper()
        {
            ResetDelegates();
        }

        /// <summary>
        /// Gets or sets the <see cref="ApplyRequest"/> delegate.
        /// </summary>
        /// <remarks>Exposed for testability.</remarks>
        public static Func<GrainBase, MethodInvocation, Task<object>> ApplyRequestDelegate { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="CurrentRequest"/> delegate.
        /// </summary>
        /// <remarks>Exposed for testability.</remarks>
        public static Func<GrainBase, MethodInvocation> CurrentRequestDelegate { get; set; }

        /// <summary>
        /// Resets all delegates to their default state.
        /// </summary>
        public static void ResetDelegates()
        {
            CurrentRequestDelegate = GetCurrentRequestViaReflection;
            ApplyRequestDelegate = ApplyRequestViaReflection;
        }

        /// <summary>
        /// Returns the request which the provided <paramref name="grainInstance"/> is currently executing.
        /// </summary>
        /// <param name="grainInstance">
        /// The grain instance.
        /// </param>
        /// <returns>
        /// The request which the provided <paramref name="grainInstance"/> is currently executing.
        /// </returns>
        public static MethodInvocation CurrentRequest(GrainBase grainInstance)
        {
            return CurrentRequestDelegate(grainInstance);
        }

        /// <summary>
        /// Applies the provided <paramref name="methodInvocation"/> on the provided <paramref name="grainInstance"/>.
        /// </summary>
        /// <param name="grainInstance">
        /// The Grain instance.
        /// </param>
        /// <param name="methodInvocation">
        /// The method invocation being applied.
        /// </param>
        /// <returns>
        /// A <see cref="Task{T}"/> containing the results of invocation.
        /// </returns>
        public static async Task<object> ApplyRequest(GrainBase grainInstance, MethodInvocation methodInvocation)
        {
            return await ApplyRequestDelegate(grainInstance, methodInvocation);
        }

        /// <summary>
        /// Returns the request which the provided <paramref name="grainInstance"/> is currently executing, obtained
        /// using reflection.
        /// </summary>
        /// <param name="grainInstance">
        /// The grain instance.
        /// </param>
        /// <returns>
        /// The request which the provided <paramref name="grainInstance"/> is currently executing.
        /// </returns>
        private static MethodInvocation GetCurrentRequestViaReflection(GrainBase grainInstance)
        {
            // Get the grain's ActivationData.
            var dataField = typeof(GrainBase).GetField("_Data", BindingFlags.NonPublic | BindingFlags.Instance);
            if (dataField == null)
            {
                return null;
            }

            var dataValue = dataField.GetValue(grainInstance);
            if (dataValue == null)
            {
                return null;
            }

            // Get the message currently being processed.
            var messageField = dataValue.GetType().GetProperty("Running");
            var messageValue = messageField.GetValue(dataValue, null);
            if (messageValue == null)
            {
                return null;
            }

            // Get the body of the message.
            var bodyObjectField = messageValue.GetType().GetProperty("BodyObject");
            var bodyObjectValue = bodyObjectField.GetValue(messageValue);
            if (bodyObjectValue == null)
            {
                return null;
            }

            // Convert the body into a method invocation.
            var invoked = (InvokeMethodRequest)bodyObjectValue;
            return new MethodInvocation { InterfaceId = invoked.InterfaceId, MethodId = invoked.MethodId, Arguments = invoked.Arguments };
        }

        /// <summary>
        /// Applies the provided <paramref name="methodInvocation"/> on the provided <paramref name="grainInstance"/>
        /// using reflection.
        /// </summary>
        /// <param name="grainInstance">
        /// The Grain instance.
        /// </param>
        /// <param name="methodInvocation">
        /// The method invocation being applied.
        /// </param>
        /// <returns>
        /// A <see cref="Task{T}"/> containing the results of invocation.
        /// </returns>
        private static async Task<object> ApplyRequestViaReflection(GrainBase grainInstance, MethodInvocation methodInvocation)
        {
            // Get grain's ActivationData.
            var dataField = typeof(GrainBase).GetField("_Data", BindingFlags.NonPublic | BindingFlags.Instance);
            if (dataField == null)
            {
                return null;
            }

            var dataValue = dataField.GetValue(grainInstance);
            if (dataValue == null)
            {
                return null;
            }

            // Get the invoker for the method's interface.
            var method = dataValue.GetType().GetMethod("GetInvoker");
            var invoker = (IGrainMethodInvoker)method.Invoke(dataValue, new object[] { methodInvocation.InterfaceId, null });
            if (invoker == null)
            {
                return null;
            }

            // Invoke the invoker.
            return await invoker.Invoke(grainInstance, methodInvocation.InterfaceId, methodInvocation.MethodId, methodInvocation.Arguments);
        }
    }
}