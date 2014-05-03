<?xml version="1.0"?>
<doc>
    <assembly>
        <name>Orleans</name>
    </assembly>
    <members>
        <member name="T:Orleans.AsyncExecutorWithRetries">
            <summary>
            For internal use only.
            Utility functions.
            </summary>
        </member>
        <member name="M:Orleans.AsyncExecutorWithRetries.ExecuteWithRetries``1(System.Func{System.Int32,System.Threading.Tasks.Task{``0}},System.Int32,System.Int32,System.Func{``0,System.Int32,System.Boolean},System.Func{System.Exception,System.Int32,System.Boolean},System.TimeSpan,Orleans.IBackoffProvider,Orleans.IBackoffProvider)">
            <summary>
            Execute a given function a number of times, based on retry configuration parameters.
            </summary>
            <param name="function">Function to execute</param>
            <param name="maxNumSuccessTries">Maximal number of successful execution attempts. 
            ExecuteWithRetries will try to re-execute the given function again if directed so by retryValueFilter.
            Set to -1 for unlimited number of success retries, until retryValueFilter is satisfied.
            Set to 0 for only one success attempt, which will cause retryValueFilter to be ignored and the given function executed only once until first success.</param>
            <param name="maxNumErrorTries">Maximal number of execution attempts due to errors.
            Set to -1 for unlimited number of error retries, until retryExceptionFilter is satisfied.</param>
            <param name="retryValueFilter">Filter function to indicate if successful execution should be retied.
            Set to null to disable successful retries.</param>
            <param name="retryExceptionFilter">Filter function to indicate if error execution should be retied.
            Set to null to disable error retries.</param>
            <param name="maxExecutionTime">The maximal execution time of the ExecuteWithRetries function.</param>
            <param name="onSuccessBackOff">The backoff provider object, which determines how much to wait between success retries.</param>
            <param name="onErrorBackOff">The backoff provider object, which determines how much to wait between error retries</param>
            <returns></returns>
        </member>
        <member name="T:Orleans.AsyncLoop">
            <summary>
            This class provides useful utility functions for asynchronous programming.
            </summary>
        </member>
        <member name="M:Orleans.AsyncLoop.For(System.Int32,System.Func{System.Int32,Orleans.AsyncCompletion})">
            <summary>
            Executes a function for the specified number of times.
            Each iteration runs asynchronously as a continuation of the previous iteration.
            The first iteration is started in-line.
            </summary>
            <param name="numIterations">The number of iterations to execute.
            If this is 0 or negative, then no iterations will be executed and the resulting promise
            will be resolved when thisd method returns.</param>
            <param name="function">The function to iterate.
            This function receives the current iteration count, starting at 0, as its argument.
            It must return an <c>AsyncCompletion</c>, but need not run in a new turn itself.
            If any execution of the function throws an exception or returns a promise that is broken,
            the iteration stops and the promise returned from this method is broken.
            </param>
            <returns>A promise that is resolved when all of the iterations have completed.</returns>
        </member>
        <member name="M:Orleans.AsyncLoop.While(System.Func{System.Int32,System.Boolean},System.Func{System.Int32,Orleans.AsyncCompletion})">
            <summary>
            Executes a function while a predicate is true.
            Each iteration runs asynchronously as a continuation of the previous iteration.
            The first iteration is started in-line.
            </summary>
            <param name="predicate">A function that takes the current iteration count, starting at 0, 
            and returns a (prompt) boolean indicating whether or not iteration should continue.
            If the predicate returns <c>false</c> for 0, then no iterations will be executed and the resulting
            promise will be resolved when thisd method returns.
            If the predicate throws an exception, then the iteration stops and the promise returned from this 
            method is broken.</param>
            <param name="function">The function to iterate.
            This function receives the current iteration count, starting at 0, as its argument.
            It must return an <c>AsyncCompletion</c>, but need not run in a new turn itself.
            If any execution of the function throws an exception or returns a promise that is broken,
            the iteration stops and the promise returned from this method is broken.
            </param>
            <returns>A promise that is resolved when all of the iterations have completed.</returns>
        </member>
        <member name="T:Orleans.AsyncPipeline">
            <summary>
            A helper utility class that allows to control the rate of generation of asynchronous activities.
            Maintains a pipeline of asynchronous operations up to a given maximal capacity and blocks the calling thread if the pipeline 
            gets too deep before enqueued operations are not finished.
            Effectively adds a back-pressure to the caller.
            This is mainly usefull for stress-testing grains under controlled load and should never be used from within a grain code! 
            </summary>
        </member>
        <member name="F:Orleans.AsyncPipeline.DefaultCapacity">
            <summary>
            The Default Capacity of this AsyncPipeline. Equals to 10.
            </summary>
        </member>
        <member name="M:Orleans.AsyncPipeline.#ctor">
            <summary>
            Constructs an empty AsyncPipeline with capacity equal to the DefaultCapacity.
            </summary>
        </member>
        <member name="M:Orleans.AsyncPipeline.#ctor(System.Int32)">
            <summary>
            Constructs an empty AsyncPipeline with a given capacity.
            </summary>
            <param name="capacity">The maximal capacity of this AsyncPipeline.</param>
        </member>
        <member name="M:Orleans.AsyncPipeline.Add(System.Threading.Tasks.Task)">
            <summary>
            Adds a new task to this AsyncPipeline.
            </summary>
            <param name="task">A task to add to this AsyncPipeline.</param>
        </member>
        <member name="M:Orleans.AsyncPipeline.AddRange(System.Collections.Generic.IEnumerable{System.Threading.Tasks.Task})">
            <summary>
            Adds a collection of tasks to this AsyncPipeline.
            </summary>
            <param name="task">A collection of tasks to add to this AsyncPipeline.</param>
        </member>
        <member name="M:Orleans.AsyncPipeline.AddRange``1(System.Collections.Generic.IEnumerable{System.Threading.Tasks.Task{``0}})">
            <summary>
            Adds a collection of tasks to this AsyncPipeline.
            </summary>
            <param name="task">A collection of tasks to add to this AsyncPipeline.</param>
        </member>
        <member name="M:Orleans.AsyncPipeline.Wait">
            <summary>
            Waits until all currently queued asynchronous operations are done.
            Blocks the calling thread.
            </summary>
            <param name="task">A task to add to this AsyncPipeline.</param>
        </member>
        <member name="T:Orleans.AsyncCompletionStatus">
            <summary>
            This enumeration represents the possible states of a promise.
            </summary>
        </member>
        <member name="F:Orleans.AsyncCompletionStatus.Running">
            <summary>
            The promise is unresolved because the underlying operation has not completed.
            </summary>
        </member>
        <member name="F:Orleans.AsyncCompletionStatus.CompletedSuccessfully">
            <summary>
            The promise has been successfully resolved.
            </summary>
        </member>
        <member name="F:Orleans.AsyncCompletionStatus.Faulted">
            <summary>
            The promise has been broken.
            </summary>
        </member>
        <member name="T:Orleans.AsyncCompletion">
            <summary>
            An instance of the <c>AsyncCompletion</c> class represents a completion promise with no value associated.
            Resolution of an <c>AsyncCompletion</c> indicates that the original asynchronous request was 
            completed successfully, but returns no other data.
            Thus, an <c>AsyncCompletion</c> is effectively the asynchronous equivalent of a void function.
            <para>
            Because successful <c>AsyncCompletion</c>s have no state and so are all identical, 
            there is no public constructor for a successful <c>AsyncCompletion</c>. 
            Instead, a method that completes successfully should return <c>AsyncCompletion.Done</c>,
            which is a pre-built successful <c>AsyncCompletion</c>.
            </para>
            </summary>
        </member>
        <member name="M:Orleans.AsyncCompletion.#ctor(System.Exception)">
            <summary>
            Creates a new, broken <c>AsyncCompletion</c> with the given <c>Exception</c> as the reason.
            This constructor should be used by a grain method that wants to return an error to its caller.
            </summary>
            <param name="exception">The <c>Exception</c> that describes why the promise was broken.</param>
        </member>
        <member name="M:Orleans.AsyncCompletion.GenerateFromException(System.Exception)">
            <summary>
            Generate an <c>AsyncCompletion</c> from a given <c>Exception</c> with stack trace.
            This should be used by a code that wants to return an error to its caller with an embedded stack trace.
            </summary>
            <param name="exc">The <c>Exception</c> that describes why the promise was broken.</param>
        </member>
        <member name="M:Orleans.AsyncCompletion.StartNew(System.Action)">
            <summary>
            Queues up an action to run asynchronously and returns the promise associated with its completion.
            The returned <c>AsyncCompletion</c> is resolved when the action completes executing.
            </summary>
            <param name="action">The action to execute asynchronously.</param>
            <returns>The <c>AsyncCompletion</c> associated with the action's completion.</returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.StartNew(System.Func{Orleans.AsyncCompletion})">
            <summary>
            Queues up a function to run asynchronously and returns the promise associated with its completion.
            The returned <c>AsyncCompletion</c> is resolved when function's returned promise is resolved.
            </summary>
            <param name="function">The function to execute asynchronously.</param>
            <returns>The <c>AsyncCompletion</c> associated with the function's returned promise.</returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.ExecuteOnThreadPool(System.Action)">
            <summary>
            Execute a work item on a .NET thread pool thread, returning an AsyncCompletion promise that will be triggered when execution of the work item is completed.
            </summary>
            <param name="action">Action to be executed using .NET Thread Pool</param>
            <returns>An AsyncCompletion promise which will be </returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.ExecuteOnThreadPool(System.Action{System.Object},System.Object)">
            <summary>
            Execute a work item on a .NET thread pool thread, returning an AsyncCompletion promise that will be triggered when execution of the work item is completed.
            </summary>
            <param name="action">Action to be executed using .NET Thread Pool</param>
            <param name="state">Any state data to be passed to the Action closure when executing</param>
            <returns>An AsyncCompletion promise which will be </returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.FromAsync(System.IAsyncResult,System.Action{System.IAsyncResult})">
            <summary>
            Constructs a promise from an IAsyncResult and an end delegate that follow the .NET asynchronous programming model.
            The end delegate is guaranteed to run in a separate new turn, never inline with the begin, 
            even if IAsyncResult is already resolved (unlike the TPL implementation, which may run it inline or not).
            </summary>
            <param name="asyncResult"></param>
            <param name="endDelegate"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.FromAsync(System.Func{System.AsyncCallback,System.Object,System.IAsyncResult},System.Action{System.IAsyncResult},System.Object)">
            <summary>
            Constructs a promise from a pair of begin/end delegates that follow the .NET asynchronous programming model.
            </summary>
            <param name="beginDelegate"></param>
            <param name="endDelegate"></param>
            <param name="param"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.AsTask">
            <summary>
            Convert this AsyncCompletion to a Task
            </summary>
            <returns>Task-based async version of this AsyncCompletion</returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.FromTask(System.Threading.Tasks.Task)">
            <summary>
            Convert this Task into an AsyncCompletion
            </summary>
            <returns>AsyncCompletion wrapper for this Task</returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.Ignore">
            <summary>
            Explicitly ignores the resolution of an <c>AsyncCompletion</c>.
            This "observes" the resolution of the promise.
            <para>Every <c>AsyncCompletion</c> should have its resolution "observed" by invoking either this method,
            the <c>ContinueWith</c> method, the <c>Wait</c> method, or the <c>TryWait</c> method.
            This method is appropriate when the caller doesn't care whether the original asynchronous request
            succeeded or failed, and so whether the promise is resolved successfully or is broken has no effect
            on the caller's processing.</para>
            </summary>
        </member>
        <member name="M:Orleans.AsyncCompletion.Wait">
            <summary>
            Waits forever for the promise's original asynchronous request to complete.
            <para>While waiting, the current method execution is blocked, but other turns for the activation
            may execute. 
            See the Programmer's Guide for more information on turns and the Orleans scheduling model.</para>
            <para>This method "observes" the resolution of the promise.</para>
            </summary>
        </member>
        <member name="M:Orleans.AsyncCompletion.Wait(System.Int32)">
            <summary>
            Waits a given period of time for the promise's original asynchronous request to complete.
            If the request doesn't complete in time, a <c>TimeoutException</c> is thrown.
            <para>While waiting, the current method execution is blocked, but other turns for the activation
            may execute. 
            See the Programmer's Guide for more information on turns and the Orleans scheduling model.</para>
            <para>This method "observes" the resolution of the promise.</para>
            </summary>
            <param name="millisecondsTimeout">The period of time to wait, in milliseconds.</param>
        </member>
        <member name="M:Orleans.AsyncCompletion.Wait(System.TimeSpan)">
            <summary>
            Waits a given period of time for the promise's original asynchronous request to complete.
            If the request doesn't complete in time, a <c>TimeoutException</c> is thrown.
            <para>While waiting, the current method execution is blocked, but other turns for the activation
            may execute. 
            See the Programmer's Guide for more information on turns and the Orleans scheduling model.</para>
            <para>This method "observes" the resolution of the promise.</para>
            </summary>
            <param name="timeout">The period of time to wait.</param>
        </member>
        <member name="M:Orleans.AsyncCompletion.TryWait(System.TimeSpan)">
            <summary>
            Waits for a given period of time for the promise's original asynchronous request to complete.
            If the request doesn't complete in time, <c>false</c> is returned.
            <para>While waiting, the current method execution is blocked, but other turns for the activation
            may execute. 
            See the Programmer's Guide for more information on turns and the Orleans scheduling model.</para>
            <para>This method "observes" the resolution of the promise.</para>
            </summary>
            <param name="timeout">The period of time to wait.</param>
            <returns><c>true</c> if the request completed in time, <c>false</c> if not.</returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.ContinueWith(System.Action,System.Action{System.Exception})">
            <summary>
            Schedules an action to be executed (asynchronously) if and when this promise is resolved successfully
            and another action to be executed if this promise is broken.
            <para>This method "observes" the resolution of the promise.</para>
            </summary>
            <param name="continuationAction">The action to run if and when this promise is successfully resolved.</param>
            <param name="exceptionAction">An optional action to run when this promise is broken. 
            This action gets passed the exception related to the breaking this promise.
            This action is also executed if this promise completes successfully and the <c>continuationAction</c>
            throws an exception. If this action is not passed, then if this promise is broken, or if the continuation action throws an exception,
            then the returned promise is broken.</param>
            <returns>A promise that is resolved when the continuation or exception action completes.
            If the exception action throws an exception (or, if there is no exception action and either the promise is broken or if the continuation action throws an exception),
            then the returned promise is broken.</returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.SystemContinueWith(System.Action,System.Action{System.Exception})">
            <summary>
            This method is for use by the Orleans runtime only.
            It should not be used by user code.
            </summary>
            <param name="continuationAction"></param>
            <param name="pExceptionAction"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.SystemContinueWith``1(System.Func{``0},System.Func{System.Exception,``0})">
            <summary>
            This method is for use by the Orleans runtime only.
            It should not be used by user code.
            </summary>
            <param name="continuationAction"></param>
            <param name="pExceptionAction"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.ContinueWith(System.Func{Orleans.AsyncCompletion},System.Func{System.Exception,Orleans.AsyncCompletion})">
            <summary>
            Schedules a function to be executed (asynchronously) if and when this promise is resolved successfully.
            <para>This method "observes" the resolution of the promise.</para>
            </summary>
            <param name="continuationAction">The function to run when this promise is resolved.</param>
            <param name="exceptionAction">An optional function to run when this promise is broken. 
            This function gets passed the exception related to the breaking this promise, and must
            return <c>AsyncCompletion</c>.
            This function is also executed if this promise completes successfully and the <c>continuationAction</c>
            throws an exception. If this function is not passed, then if this promise is broken, or if the continuation function throws an exception,
            then the returned promise is broken.</param>
            <returns>The <c>AsyncCompletion</c> that is the result of the function.
            If this promise (the one that ContinueWith is invoked on) is broken 
            (or, if there is no exception function and either the promise is broken or if the continuation function throws an exception), 
            or if the function throws an exception, then a broken promise is returned.</returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.ContinueWith``1(System.Func{``0},System.Func{System.Exception,``0})">
            <summary>
            Schedules a function to be executed (asynchronously) if and when this promise is resolved successfully
            and another function to be execute if and when this promise is broken.
            This method is useful as a way to specify a default result if this promise is broken.
            <para>This method "observes" the resolution of the promise.</para>
            </summary>
            <param name="continuationAction">The function to run if and when this promise is successfully resolved.</param>
            <param name="exceptionAction">An optional function to run when this promise is broken. 
            This action gets passed the exception related to the breaking this promise, and must
            return the same data type as the <c>continuationAction</c>.
            This action is also executed if this promise completes successfully and the <c>continuationAction</c>
            throws an exception. If this function is not passed, then if this promise is broken, or if the continuation function throws an exception,
            then the returned promise is broken.</param>
            <returns>A promise for the result of the continuation or exception action.
            If the exception action throws an exception (or, if there is no exception action and either the promise is broken or if the continuation function throws an exception),
            then the returned promise is broken.</returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.ContinueWith``1(System.Func{Orleans.AsyncValue{``0}},System.Func{System.Exception,Orleans.AsyncValue{``0}})">
            <summary>
            Schedules a function to be executed (asynchronously) if and when this promise is resolved successfully
            and another function to be execute if and when this promise is broken.
            This method is useful as a way to specify a default result if this promise is broken.
            <para>This method "observes" the resolution of the promise.</para>
            </summary>
            <param name="continuationAction">The function to run if and when this promise is successfully resolved.</param>
            <param name="exceptionAction">An optional function to run when this promise is broken. 
            This action gets passed the exception related to the breaking this promise, and must
            return the same data type as that promised by the <c>continuationAction</c>.
            This action is also executed if this promise completes successfully and the <c>continuationAction</c>
            throws an exception. If this function is not passed, then if this promise is broken, or if the 
            continuation function throws an exception, then the returned promise is broken.</param>
            <returns>The promise that is the result of the continuation, or a promise for the result of the exception action.
            If the exception action throws an exception (or, if there is no exception action and either the promise is broken or if the continuation function throws an exception), 
            then the returned promise is broken.</returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.Join(Orleans.AsyncCompletion,Orleans.AsyncCompletion)">
            <summary>
            Joins two promises into a single combined promise.
            <para>This method "observes" the resolution of the joining promises.</para>
            </summary>
            <param name="ac1">The first promise to join.</param>
            <param name="ac2">The second promise to join.</param>
            <returns>A new promise that resolves when both of the two joining promises are resolved.
            The new promise is broken if either of the two combining promises break.</returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.JoinAll(Orleans.AsyncCompletion[])">
            <summary>
            Joins multiple promises into a single combined promise.
            <para>This method "observes" the resolution of the joining promises.</para>
            </summary>
            <param name="acs">An array that holds the promises to join.</param>
            <returns>A new promise that resolves when all of the joining promises are resolved.
            The new promise is broken if one or more of the combining promises break.</returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.JoinAll(System.Collections.Generic.IEnumerable{Orleans.AsyncCompletion})">
            <summary>
            Joins multiple promises into a single combined promise.
            <para>This method "observes" the resolution of the joining promises.</para>
            </summary>
            <param name="acs">A collection that holds the promises to join.</param>
            <returns>A new promise that resolves when all of the joining promises are resolved.
            The new promise is broken if one or more of the combining promises break.</returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.JoinAll(System.Collections.Generic.IEnumerable{Orleans.IAddressable})">
            <summary>
            Joins multiple grain reference promises into a single combined promise.
            See <see cref="T:Orleans.IAddressable"/> for details on waiting for unresolved grain references.
            <para>This method "observes" the resolution of the joining promises.</para>
            </summary>
            <param name="grains">A collection that holds the grain references to join.</param>
            <returns>A new promise that resolves when all of the joining references are resolved.
            The new promise is broken if one or more of the combining references break.</returns>
        </member>
        <member name="M:Orleans.AsyncCompletion.WaitAll(Orleans.AsyncCompletion[],System.TimeSpan)">
            <summary>
            Waits a given period of time for multiple promises to resolve.
            If any of the requests don't complete in time, a <c>TimeoutException</c> is thrown.
            <para>This method does not fail fast. That is, even if one of the promises gets broken, the method will wait 
            (up until timeout) until all promises complete (resolve or break) and throw an AggregateException.
            <para>While waiting, the current method execution is blocked, but other turns for the activation
            may execute. </para>
            See the Programmer's Guide for more information on turns and the Orleans scheduling model.</para>
            <para>This method "observes" the resolution of the combining promises.</para>
            </summary>
            <param name="acs">An array that holds the promises to wait for.</param>
            <param name="timeout">The period of time to wait.</param>
        </member>
        <member name="P:Orleans.AsyncCompletion.IsCompleted">
            <summary>
            Whether this AsyncCompletion is already completed - <c>true</c> if it been run to completion and has Status == CompletedSuccessfully or Faulted
            </summary>
        </member>
        <member name="P:Orleans.AsyncCompletion.IsFaulted">
            <summary>
            Whether this AsyncCompletion is faulted - <c>true</c> if it been run to completion and has Status == Faulted
            </summary>
        </member>
        <member name="P:Orleans.AsyncCompletion.Exception">
            <summary>
            The exception that describes the reason that this promise was broken.
            If the request succeeded, then this will be <c>null</c>.
            </summary>
        </member>
        <member name="P:Orleans.AsyncCompletion.Done">
            <summary>
            This static property provides a resolved <c>AsyncCompletion</c> suitable for returning from a successful method call.
            </summary>
        </member>
        <member name="P:Orleans.AsyncCompletion.TaskDone">
            <summary>
            This static property provides a resolved <c>Task</c> suitable for returning from a successful method call.
            </summary>
        </member>
        <member name="P:Orleans.AsyncCompletion.Status">
            <summary>
            This property returns the status of the promise. See <see cref="T:Orleans.AsyncCompletionStatus"/> for possible return values.
            </summary>
        </member>
        <member name="T:Orleans.AsyncResolver">
            <summary>
            The <c>AsyncResolver</c> class is the base class for <c>AsyncCompletionResolver</c> and
            <c>AsyncValueResolver</c>.
            <para>
            These classes provide a mechanism for developers to create promises whose resolution they
            control explicitly, rather than resolving when some request completes.
            There are relatively few occasions where this is necessary, but sometimes it is the only way to
            get the desired behavior.
            In general, though, if you think you need to use an explicit resolver/promise pair, you should think
            your scenario through carefully, because there's probably a better way to get the flow you want with
            a simple request-linked promise.
            </para>
            </summary>
        </member>
        <member name="M:Orleans.AsyncResolver.Break(System.Exception)">
            <summary>
            Breaks the promise associated with this resolver.
            Note that this method may throw an <c>InvalidOperationException</c> if the promise has already
            been broken or has already been resolved.
            </summary>
            <param name="exc">An exception that describes the reason for breaking the promise.</param>
        </member>
        <member name="M:Orleans.AsyncResolver.TryBreak(System.Exception)">
            <summary>
            Breaks the promise associated with this resolver if the promise is not already broken or resolved.
            </summary>
            <param name="exc">An exception that describes the reason for breaking the promise.</param>
            <returns><c>true</c> if the promise was successfully broken, or <c>false</c> if the promise was already
            broken or resolved.</returns>
        </member>
        <member name="P:Orleans.AsyncResolver.AsyncCompletion">
            <summary>
            The AsyncCompletion that is resolved by this resolver.
            </summary>
        </member>
        <member name="T:Orleans.AsyncCompletionResolver">
            <summary>
            The <c>AsyncCompletionResolver</c> class supports explicit resolver/promise pairs with void (data-less) promises.
            <para>
            This class provides a mechanism for developers to create promises whose resolution they
            control explicitly, rather than resolving when some request completes.
            There are relatively few occasions where this is necessary, but sometimes it is the only way to
            get the desired behavior.
            In general, though, if you think you need to use an explicit resolver/promise pair, you should think
            your scenario through carefully, because there's probably a better way to get the flow you want with
            a simple request-linked promise.
            </para>
            </summary>
        </member>
        <member name="M:Orleans.AsyncCompletionResolver.#ctor">
            <summary>
            Creates a new resolver/promise pair.
            </summary>
        </member>
        <member name="M:Orleans.AsyncCompletionResolver.Resolve">
            <summary>
            Successfully resolves the promise associated with this resolver.
            Note that this method may throw an <c>InvalidOperationException</c> if the promise has already
            been broken or has already been resolved.
            </summary>
        </member>
        <member name="M:Orleans.AsyncCompletionResolver.TryResolve">
            <summary>
            Successfully resolves the promise associated with this resolver if the promise has not already
            been broken or resolved.
            </summary>
            <returns><c>true</c> if the promise was successfully resolved, or <c>false</c> if the promise was already
            broken or resolved.</returns>
        </member>
        <member name="M:Orleans.AsyncCompletionResolver.Break(System.Exception)">
            <summary>
            Breaks the promise associated with this resolver.
            Note that this method may throw an <c>InvalidOperationException</c> if the promise has already
            been broken or has already been resolved.
            </summary>
            <param name="exc">An exception that describes the reason for breaking the promise.</param>
        </member>
        <member name="M:Orleans.AsyncCompletionResolver.TryBreak(System.Exception)">
            <summary>
            Breaks the promise associated with this resolver if the promise is not already broken or resolved.
            </summary>
            <param name="exc">An exception that describes the reason for breaking the promise.</param>
            <returns><c>true</c> if the promise was successfully broken, or <c>false</c> if the promise was already
            broken or resolved.</returns>
        </member>
        <member name="P:Orleans.AsyncCompletionResolver.AsyncCompletion">
            <summary>
            The promise associated with this resolver.
            </summary>
        </member>
        <member name="T:Orleans.AsyncValue`1">
            <summary>
            An instance of the <c>AsyncValue</c> class represents a promise for a value of the given type.
            When the promise is resolved, the value becomes available and is provided to any scheduled
            continuation actions.
            </summary>
            <typeparam name="TResult">The type of the promised value.</typeparam>
        </member>
        <member name="M:Orleans.AsyncValue`1.#ctor(`0)">
            <summary>
            Constructs an <c>AsyncValue</c> that is already resolved with the provided value.
            </summary>
            <param name="value">The value for the promise.</param>
        </member>
        <member name="M:Orleans.AsyncValue`1.#ctor(System.Exception)">
            <summary>
            Constructs an <c>AsyncValue</c> that is already broken.
            </summary>
            <param name="exc">An exception that describes the reason that the promise is broken.</param>
        </member>
        <member name="M:Orleans.AsyncValue`1.GenerateFromException(System.Exception)">
            <summary>
            Generate an <c>AsyncValue</c> from a given <c>Exception</c> with stack trace.
            This should be used by a code that wants to return an error to its caller with an embedded stack trace.
            </summary>
            <param name="exc">The <c>Exception</c> that describes why the promise was broken.</param>
        </member>
        <member name="M:Orleans.AsyncValue`1.StartNew(System.Func{`0})">
            <summary>
            Queues the provided function to run asynchronously and returns a promise
            for the function's result.
            </summary>
            <param name="function">The function to be executed.</param>
            <returns>A promise for the function's result. 
            This promise is resolved to the function's return value when the function's execution is complete.
            This promise is broken if the function throws an exception.</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.StartNew(System.Func{`0},Orleans.ISchedulingContext)">
            <summary>
            Queues the provided function to run asynchronously and returns a promise
            for the function's result.
            </summary>
            <param name="function">The function to be executed.</param>
            <param name="context">The scheduling context under which the function should run.</param>
            <returns>A promise for the function's result. 
            This promise is resolved to the function's return value when the function's execution is complete.
            This promise is broken if the function throws an exception.</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.StartNew(System.Func{Orleans.AsyncValue{`0}})">
            <summary>
            Queues the provided function to run asynchronously and returns a promise
            for the function's result.
            </summary>
            <param name="function">The function to be executed.</param>
            <returns>A promise for the function's result. 
            This promise is resolved when the function's return promise is resolved.
            This promise is broken if the function throws an exception.</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.StartNew(System.Func{Orleans.AsyncValue{`0}},Orleans.ISchedulingContext)">
            <summary>
            Queues the provided function to run asynchronously and returns a promise
            for the function's result.
            </summary>
            <param name="function">The function to be executed.</param>
            <param name="context">The scheduling context under which the function should run.</param>
            <returns>A promise for the function's result. 
            This promise is resolved when the function's return promise is resolved.
            This promise is broken if the function throws an exception.</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.ExecuteOnThreadPool``1(System.Func{``0})">
            <summary>
            Execute a work item on a .NET thread pool thread, returning an AsyncValue promise that will be triggered when execution of the work item is completed.
            </summary>
            <param name="func">Function to be executed using .NET Thread Pool</param>
            <returns>An AsyncValue promise which will be triggered when execution of the work item is completed.</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.ExecuteOnThreadPool``1(System.Func{System.Object,``0},System.Object)">
            <summary>
            Execute a work item on a .NET thread pool thread, returning an AsyncCompletion promise that will be triggered when execution of the work item is completed.
            </summary>
            <param name="action">Function to be executed using .NET Thread Pool</param>
            <param name="state">Any state data to be passed to the function when executing</param>
            <returns>An AsyncValue promise which will be triggered when execution of the work item is completed.</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.FromAsync(System.IAsyncResult,System.Func{System.IAsyncResult,`0})">
            <summary>
            Creates a promise from an existing IAsyncResult and an End method.
            </summary>
            <param name="asyncResult">The async result returned from a call to the Begin part of a Begin/End pair.
            The Begin method should have been called with a null async callback.</param>
            <param name="endDelegate">A delegate that calls the End part of a Begin/End pair.
            This delegate takes the IAsyncResult object returned from the Begin method and
            returns the actual result value.
            The end delegate is guaranteed to run in a separate new turn, never inline with the begin, 
            even if IAsyncResult is already resolved (unlike the TPL implementation, which may run it inline or not). </param>
            <returns>A promise for the result of the Begin/End pair.</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.FromAsync(System.Func{System.AsyncCallback,System.Object,System.IAsyncResult},System.Func{System.IAsyncResult,`0},System.Object)">
            <summary>
            Creates a promise from a Begin/End method pair.
            </summary>
            <param name="beginDelegate">A delegate that calls the Begin part of a Begin/End pair.
            This delegate takes two parameters: an async callback delegate, to be passed to the Begin async method,
            and an object that allows a parameter to be passed to the delgate.
            This object may be used as the state object for the Begin method, but does not need to be; 
            its purpose is to allow the begin delegate to be reused.
            The delegate must return the IAsyncResult that is returned by the Begin method.</param>
            <param name="endDelegate">A delegate that calls the End part of a Begin/End pair.
            This delegate takes the IAsyncResult object returned from the Begin method and
            returns the actual result value.
            The end delegate is guaranteed to run in a separate new turn, never inline with the begin, 
            even if IAsyncResult is already resolved (unlike the TPL implementation, which may run it inline or not). </param>
            <param name="param">The object parameter to be passed to the begin delegate.</param>
            <returns>A promise for the result of the Begin/End pair.</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.GetValue">
            <summary>
            Waits forever for this promise to resolve and returns its value.
            <para>While waiting, the current method execution is blocked, but other turns for the activation
            may execute. 
            See the Programmer's Guide for more information on turns and the Orleans scheduling model.</para>
            <para>This method "observes" the resolution of the promise.</para>
            </summary>
            <returns>The resolved value of this promise.</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.AsTask">
            <summary>
            Convert this AsyncValue&lt;TResult&gt; to a corresponding Task&lt;TResult&gt; "/>
            </summary>
            <returns>Task-based async version of this AsyncValue</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.FromTask(System.Threading.Tasks.Task{`0})">
            <summary>
            Convert this Task&lt;T&gt; into an AsyncValue&lt;T&gt;
            This function is primarily for use with .NET 4.0. With .NET 4.5 you can use the Task&lt;T&gt;.FromResult method to do the same thing.
            </summary>
            <returns>AsyncValue wrapper for this Task</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.GetValue(System.TimeSpan)">
            <summary>
            Waits for the given amount of time for this promise to resolve and returns its value.
            If the promise does not resolve in time, a <c>TimeoutException</c> is thrown.
            <para>While waiting, the current method execution is blocked, but other turns for the activation
            may execute. 
            See the Programmer's Guide for more information on turns and the Orleans scheduling model.</para>
            <para>This method "observes" the resolution of the promise.</para>
            </summary>
            <param name="timeout">The length of time to wait for this promise to resolve.</param>
            <returns>The resolved value of this promise.</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.ContinueWith(System.Action{`0},System.Action{System.Exception})">
            <summary>
            Schedules an action to be executed (asynchronously) if and when this promise is resolved successfully
            and another action to be executed if this promise is broken.
            <para>This method "observes" the resolution of the promise.</para>
            </summary>
            <param name="continuationAction">The action to run if and when this promise is successfully resolved.
            When invoked, the action receives the resolved value of this promise as a parameter.</param>
            <param name="exceptionAction">An optional action to run when this promise is broken. 
            This action gets passed the exception related to the breaking this promise.
            This action is also executed if this promise completes successfully and the <c>continuationAction</c>
            throws an exception. If this action is not passed, then if this promise is broken, or if the 
            continuation action throws an exception, then the returned promise is broken.</param>
            <returns>A promise that is resolved when the continuation or exception action completes.
            If the exception action throws an exception (or, if there is no exception action and either the promise is broken or if the continuation action throws an exception), 
            then the returned promise is broken.</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.ContinueWith(System.Func{`0,Orleans.AsyncCompletion},System.Func{System.Exception,Orleans.AsyncCompletion})">
            <summary>
            Schedules an action to be executed (asynchronously) if and when this promise is resolved successfully
            and another action to be executed if this promise is broken.
            <para>This method "observes" the resolution of the promise.</para>
            </summary>
            <param name="continuationAction">The function to run if and when this promise is successfully resolved.
            When invoked, the action receives the resolved value of this promise as a parameter.
            The function must return an <c>AsyncCompletion</c>.</param>
            <param name="exceptionAction">An optional function to run when this promise is broken. 
            This function gets passed the exception related to the breaking this promise.
            This function is also executed if this promise completes successfully and the <c>continuationAction</c>
            throws an exception.
            This action must return an <c>AsyncCompletion</c>. If this function is not passed, then if this promise is broken, or if the 
            continuation function throws an exception, then the returned promise is broken.</param>
            <returns>A promise that is resolved when the promise returned by the continuation or exception action completes.
            If the exception action throws an exception (or, if there is no exception function and either the promise is broken or if the continuation function throws an exception), 
            then the returned promise is broken.</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.ContinueWith``1(System.Func{`0,``0},System.Func{System.Exception,``0})">
            <summary>
            Schedules a function to be executed (asynchronously) if and when this promise is resolved successfully
            and another function to be execute if and when this promise is broken.
            This method is useful as a way to specify a default result if this promise is broken.
            <para>This method "observes" the resolution of the promise.</para>
            </summary>
            <param name="continuationAction">The function to run if and when this promise is successfully resolved.
            When invoked, the action receives the resolved value of this promise as a parameter.</param>
            <param name="exceptionAction">An optional function to run when this promise is broken. 
            This action gets passed the exception related to the breaking this promise, and must
            return the same data type as the <c>continuationAction</c>.
            This action is also executed if this promise completes successfully and the <c>continuationAction</c>
            throws an exception. If this function is not passed, then if this promise is broken, or if the 
            continuation function throws an exception, then the returned promise is broken.</param>
            <returns>A promise for the result of the continuation or exception action.
            If the exception function throws an exception (or, if there is no exception function and either the promise is broken or if the continuation function throws an exception), 
            then the returned promise is broken.</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.ContinueWith``1(System.Func{`0,Orleans.AsyncValue{``0}},System.Func{System.Exception,Orleans.AsyncValue{``0}})">
            <summary>
            Schedules an action to be executed (asynchronously) if and when this promise is resolved successfully.
            <para>This method "observes" the resolution of the promise.</para>
            </summary>
            <param name="continuationAction">The action to run when this promise is resolved.
            When invoked, the action receives the resolved value of this promise as a parameter.
            The action must return a promise for a value as its result.</param>
            <param name="exceptionAction">An optional function to run when this promise is broken. 
            This function gets passed the exception related to the breaking this promise.
            This function is also executed if this promise completes successfully and the <c>continuationAction</c>
            throws an exception.
            This action must return the same data type as the <c>continuationAction</c>. If this function is not passed, then if this promise is broken, or if the 
            continuation function throws an exception, then the returned promise is broken.</param>
            <returns>A promise that is resolved when the promise returned by the action is resolved, with the
            same value as that promise.
            If this promise (the one that ContinueWith is invoked on) is broken, or if the action throws an exception,
            or if the action's returned promise is broken, then the returned promise is broken.</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.SystemContinueWith``1(System.Func{`0,``0},System.Func{System.Exception,``0})">
            <summary>
            This method is for use by the Orleans runtime only.
            It should not be used by user code.
            </summary>
            <param name="continuationAction"></param>
            <param name="pExceptionAction"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.SystemContinueWith``1(System.Func{`0,Orleans.AsyncValue{``0}},System.Func{System.Exception,Orleans.AsyncValue{``0}})">
            <summary>
            This method is for use by the Orleans runtime only.
            It should not be used by user code.
            </summary>
            <param name="continuationAction"></param>
            <param name="pExceptionAction"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.SystemContinueWith(System.Action{`0},System.Action{System.Exception})">
            <summary>
            This method is for use by the Orleans runtime only.
            It should not be used by user code.
            </summary>
            <param name="continuationAction"></param>
            <param name="pExceptionAction"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.JoinAll(System.Collections.Generic.IEnumerable{Orleans.AsyncValue{`0}})">
            <summary>
            Joins multiple promises into a single combined promise.
            <para>This method "observes" the resolution of the joining promises.</para>
            </summary>
            <param name="acs">A collection that holds the promises to join.</param>
            <returns>A new promise that resolves when all of the joining promises are resolved.
            The new promise is broken if one or more of the combining promises break.</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.JoinAll(Orleans.AsyncValue{`0}[])">
            <summary>
            Joins multiple promises into a single combined promise.
            <para>This method "observes" the resolution of the joining promises.</para>
            </summary>
            <param name="acs">An array that holds the promises to join.</param>
            <returns>A new promise that resolves when all of the joining promises are resolved.
            The new promise is broken if one or more of the combining promises break.</returns>
        </member>
        <member name="M:Orleans.AsyncValue`1.op_Implicit(`0)~Orleans.AsyncValue{`0}">
            <summary>
            Casts a prompt value to a resolved promise for that value.
            This implicit cast is very useful for the return value of asynchronous methods; it allows the code to read
            <c>return 5;</c> instead of <c>return new AsyncValue<int>(5);</int></c>.
            </summary>
            <param name="value">The resolved value of the new promise.</param>
            <returns>A pre-resolved promise for the given value.</returns>
        </member>
        <member name="T:Orleans.AsyncValueResolver`1">
            <summary>
            The <c>AsyncValueResolver</c> class supports explicit resolver/promise pairs for data-carrying promises.
            <para>
            This class provides a mechanism for developers to create promises whose resolution they
            control explicitly, rather than resolving when some request completes.
            There are relatively few occasions where this is necessary, but sometimes it is the only way to
            get the desired behavior.
            In general, though, if you think you need to use an explicit resolver/promise pair, you should think
            your scenario through carefully, because there's probably a better way to get the flow you want with
            a simple request-linked promise.
            </para>
            </summary>
            <typeparam name="TResult">The type of the promised value.</typeparam>
        </member>
        <member name="M:Orleans.AsyncValueResolver`1.#ctor">
            <summary>
            Constructs a new, unresolved resolver/promise pair.
            </summary>
        </member>
        <member name="M:Orleans.AsyncValueResolver`1.Resolve(`0)">
            <summary>
            Resolves the associated promise to the provided value.
            This method will throw an <c>InvalidOperationException</c> if the promise has already been resolved or broken.
            </summary>
            <param name="value">The value to resolve the promise to.</param>
        </member>
        <member name="M:Orleans.AsyncValueResolver`1.TryResolve(`0)">
            <summary>
            Tries to resolve the associated promise to the provided value.
            </summary>
            <param name="value">The value to resolve the promise to.</param>
            <returns><c>true</c> if the promise was successfully resolved, or <c>false</c> if the promise has already been
            resolved or broken.</returns>
        </member>
        <member name="M:Orleans.AsyncValueResolver`1.Break(System.Exception)">
            <summary>
            Breaks the associated promise.
            Note that this method may throw an <c>InvalidOperationException</c> if the promise has already
            been broken or has already been resolved.
            </summary>
            <param name="exc">An exception that describes the reason for breaking the promise.</param>
        </member>
        <member name="M:Orleans.AsyncValueResolver`1.TryBreak(System.Exception)">
            <summary>
            Tries to break the associated promise.
            </summary>
            <param name="exc">An exception that describes the reason for breaking the promise.</param>
            <returns><c>true</c> if the promise was successfully resolved, or <c>false</c> if the promise has already been
            resolved or broken.</returns>
        </member>
        <member name="P:Orleans.AsyncValueResolver`1.AsyncValue">
            <summary>
            The promise associated with this resolver.
            </summary>
        </member>
        <member name="P:Orleans.AsyncValueResolver`1.AsyncCompletion">
            <summary>
            A "void" version of the promise associated with this resolver.
            </summary>
        </member>
        <member name="M:Orleans.AsyncCompletion_FastCWExtensions.FastContinueWith(Orleans.AsyncCompletion,System.Action,System.Action{System.Exception})">
            <summary>
            This method is for use by the Orleans runtime only.
            It should not be used by user code.
            </summary>
            <param name="continuationAction"></param>
            <param name="pExceptionAction"></param>
            <returns></returns>
        </member>
        <member name="T:Orleans.AsyncBatchExecutor">
            <summary>
            For internal use only.
            Utility functions.
            </summary>
        </member>
        <member name="T:Orleans.DelayedExecutor">
            <summary>
            For internal use only.
            Utility functions.
            </summary>
        </member>
        <member name="M:Orleans.DelayedExecutor.Execute``1(System.Func{Orleans.AsyncValue{``0}},System.TimeSpan)">
            <summary>
            Execute the provided function after the given delay.
            The provided function will run inside grain context if Execute() is called inside grain code, or outside, if called outside grain code.
            When Execute&lt;T&gt; is called from the grain code, the provided function will execute in the context of the current request.
            That means that if the grain in Non-Reentrant (default behavior), the grain will be locked and will not allow new requests, 
            until the delayed function finishes executing.
            </summary>
        </member>
        <member name="M:Orleans.DelayedExecutor.Execute(System.Func{Orleans.AsyncCompletion},System.TimeSpan)">
            <summary>
            Execute the provided function after the given delay.
            The provided function will run inside grain context if Execute() is called inside grain code, or outside, if called outside grain code.
            When Execute&lt;T&gt; is called from the grain code, the provided function will execute in the context of the current request.
            That means that if the grain in Non-Reentrant (default behavior), the grain will be locked and will not allow new requests, 
            until the delayed function finishes executing.
            </summary>
        </member>
        <member name="M:Orleans.DelayedExecutor.ExecuteDetached``1(System.Func{Orleans.AsyncValue{``0}},System.TimeSpan)">
            <summary>
            Execute the provided function after the given delay.
            The provided function will run inside grain context if Execute() is called inside grain code, or outside, if called outside grain code.
            When ExecuteDetached&lt;T&gt; is called from the grain code, the provided function might execute outside the context of the current request.
            That means that even if the grain in Reentrant, the provided function might not execute as part of this request. 
            In particular, it might execute during the execution of some future request (subject to turn-based single threaded execution).
            </summary>
        </member>
        <member name="M:Orleans.DelayedExecutor.ExecuteDetached(System.Func{Orleans.AsyncCompletion},System.TimeSpan)">
            <summary>
            Execute the provided function after the given delay.
            The provided function will run inside grain context if Execute() is called inside grain code, or outside, if called outside grain code.
            When ExecuteDetached&lt;T&gt; is called from the grain code, the provided function might execute outside the context of the current request.
            That means that even if the grain in Reentrant, the provided function might not execute as part of this request. 
            In particular, it might execute during the execution of some future request (subject to turn-based single threaded execution).
            </summary>
        </member>
        <member name="T:Orleans.LimitedConcurrencyLevelTaskScheduler">
            <summary>
            Provides a task scheduler that ensures a maximum concurrency level while
            running on top of the ThreadPool.
            </summary>
        </member>
        <member name="F:Orleans.LimitedConcurrencyLevelTaskScheduler._currentThreadIsProcessingItems">
            <summary>Whether the current thread is processing work items.</summary>
        </member>
        <member name="F:Orleans.LimitedConcurrencyLevelTaskScheduler._tasks">
            <summary>The list of tasks to be executed.</summary>
        </member>
        <member name="F:Orleans.LimitedConcurrencyLevelTaskScheduler._maxDegreeOfParallelism">
            <summary>The maximum concurrency level allowed by this scheduler.</summary>
        </member>
        <member name="F:Orleans.LimitedConcurrencyLevelTaskScheduler._delegatesQueuedOrRunning">
            <summary>Whether the scheduler is currently processing work items.</summary>
        </member>
        <member name="F:Orleans.LimitedConcurrencyLevelTaskScheduler._chooser">
            <summary>Optional function to pick a number from 0 to n-1, for choosing from queue</summary>
        </member>
        <member name="M:Orleans.LimitedConcurrencyLevelTaskScheduler.#ctor(System.Int32,System.Func{System.Int32,System.Int32})">
            <summary>
            Initializes an instance of the LimitedConcurrencyLevelTaskScheduler class with the
            specified degree of parallelism.
            </summary>
            <param name="maxDegreeOfParallelism">The maximum degree of parallelism provided by this scheduler.</param>
            <param name="chooser">Chooser function to pick a number from 0 to n-1, for choosing from queue</param>
        </member>
        <member name="M:Orleans.LimitedConcurrencyLevelTaskScheduler.QueueTask(System.Threading.Tasks.Task)">
            <summary>Queues a task to the scheduler.</summary>
            <param name="task">The task to be queued.</param>
        </member>
        <member name="M:Orleans.LimitedConcurrencyLevelTaskScheduler.NotifyThreadPoolOfPendingWork">
            <summary>
            Informs the ThreadPool that there's work to be executed for this scheduler.
            </summary>
        </member>
        <member name="M:Orleans.LimitedConcurrencyLevelTaskScheduler.TryExecuteTaskInline(System.Threading.Tasks.Task,System.Boolean)">
            <summary>Attempts to execute the specified task on the current thread.</summary>
            <param name="task">The task to be executed.</param>
            <param name="taskWasPreviouslyQueued"></param>
            <returns>Whether the task could be executed on the current thread.</returns>
        </member>
        <member name="M:Orleans.LimitedConcurrencyLevelTaskScheduler.TryDequeue(System.Threading.Tasks.Task)">
            <summary>Attempts to remove a previously scheduled task from the scheduler.</summary>
            <param name="task">The task to be removed.</param>
            <returns>Whether the task could be found and removed.</returns>
        </member>
        <member name="M:Orleans.LimitedConcurrencyLevelTaskScheduler.GetScheduledTasks">
            <summary>Gets an enumerable of the tasks currently scheduled on this scheduler.</summary>
            <returns>An enumerable of the tasks currently scheduled.</returns>
        </member>
        <member name="P:Orleans.LimitedConcurrencyLevelTaskScheduler.MaximumConcurrencyLevel">
            <summary>Gets the maximum concurrency level supported by this scheduler.</summary>
        </member>
        <member name="T:Orleans.PublicOrleansTaskExtentions">
            <summary>
            Utility functions for dealing with Task's.
            </summary>
        </member>
        <member name="M:Orleans.PublicOrleansTaskExtentions.Ignore(System.Threading.Tasks.Task)">
            <summary>
            Observes and ignores a potential exception on a given Task.
            If a Task fails and throws an exception which is never observed, it will be caught by the .NET finalizer thread.
            This function awaits the given task and if the exception is thrown, it observes this exception and simply ignores it.
            This will prevent the escalation of this exception to the .NET finalizer thread.
            </summary>
            <param name="task">The task to be ignored.</param>
        </member>
        <member name="M:Orleans.OrleansTaskExtentions.WithTimeout(System.Threading.Tasks.Task,System.TimeSpan)">
            <summary>
            This will apply a timeout delay to the task, allowing us to exit early
            </summary>
            <param name="taskToComplete">The task we will timeout after timeSpan</param>
            <param name="timeout">Amount of time to wait before timing out</param>
            <exception cref="T:System.TimeoutException">If we time out we will get this exception</exception>
            <returns>The completed task</returns>
        </member>
        <member name="M:Orleans.OrleansTaskExtentions.WithTimeout``1(System.Threading.Tasks.Task{``0},System.TimeSpan)">
            <summary>
            This will apply a timeout delay to the task, allowing us to exit early
            </summary>
            <param name="taskToComplete">The task we will timeout after timeSpan</param>
            <param name="timeout">Amount of time to wait before timing out</param>
            <exception cref="T:System.TimeoutException">If we time out we will get this exception</exception>
            <returns>The value of the completed task</returns>
        </member>
        <member name="T:Orleans.TaskDone">
            <summary>
            A special void 'Done' Task that is already in the RunToCompletion state.
            Equivalent to Task.FromResult(1).
            </summary>
        </member>
        <member name="P:Orleans.TaskDone.Done">
            <summary>
            A special 'Done' Task that is already in the RunToCompletion state
            </summary>
        </member>
        <member name="T:Orleans.AzureUtils.AzureQueueDefaultPolicies">
             <summary>
             How to use the Queue Storage Service: http://www.windowsazure.com/en-us/develop/net/how-to-guides/queue-service/
             Windows Azure Storage Abstractions and their Scalability Targets: http://blogs.msdn.com/b/windowsazurestorage/archive/2010/05/10/windows-azure-storage-abstractions-and-their-scalability-targets.aspx
             Naming Queues and Metadata: http://msdn.microsoft.com/en-us/library/windowsazure/dd179349.aspx
             Windows Azure Queues and Windows Azure Service Bus Queues - Compared and Contrasted: http://msdn.microsoft.com/en-us/library/hh767287(VS.103).aspx
             Status and Error Codes: http://msdn.microsoft.com/en-us/library/dd179382.aspx
            
             http://blogs.msdn.com/b/windowsazurestorage/archive/tags/scalability/
             http://blogs.msdn.com/b/windowsazurestorage/archive/2010/12/30/windows-azure-storage-architecture-overview.aspx
             http://blogs.msdn.com/b/windowsazurestorage/archive/2010/11/06/how-to-get-most-out-of-windows-azure-tables.aspx
             
             </summary>
             <typeparam name="T"></typeparam>
        </member>
        <member name="T:Orleans.AzureUtils.AzureStorageUtils">
            <summary>
            General utility functions related to Azure storage.
            </summary>
            <remarks>
            These functions are mostly intended for internal usage by Orleans runtime, but due to certain assembly packaging constrants this class needs to have public visibility.
            </remarks>
        </member>
        <member name="M:Orleans.AzureUtils.AzureStorageUtils.TableStorageDataNotFound(System.Exception)">
            <summary>
            Inspect an exception returned from Azure storage libraries to check whether it means that attempt was made to read some data that does not exist in storage table.
            </summary>
            <param name="exc">Exception that was returned by Azure storage library operation</param>
            <returns><c>True</c> if this exception means the data being read was not present in Azure table storage</returns>
        </member>
        <member name="M:Orleans.AzureUtils.AzureStorageUtils.ExtractRestErrorCode(System.Exception)">
            <summary>
            Extract REST error code from DataServiceClientException or DataServiceQueryException
            </summary>
            <param name="exc">Exception to be inspected.</param>
            <returns>Returns REST error code if found, otherwise <c>null</c></returns>
        </member>
        <member name="M:Orleans.AzureUtils.AzureStorageUtils.EvaluateException(System.Exception,System.Net.HttpStatusCode@,System.String@,System.Boolean)">
            <summary>
            Examine a storage exception, and if applicable extracts the HTTP status code, and REST error code if <c>getExtendedErrors=true</c>.
            </summary>
            <param name="e">Exeption to be examined.</param>
            <param name="httpStatusCode">Output HTTP status code if applicable, otherwise HttpStatusCode.Unused (306)</param>
            <param name="restStatus">When <c>getExtendedErrors=true</c>, will output REST error code if applicable, otherwise <c>null</c></param>
            <param name="getExtendedErrors">Whether REST error code should also be examined / extracted.</param>
            <returns>Returns <c>true</c> if HTTP status code and REST error were extracted.</returns>
        </member>
        <member name="M:Orleans.AzureUtils.AzureStorageUtils.IsRetriableHttpError(System.Net.HttpStatusCode,System.String)">
            <summary>
            Returns true if the specified HTTP status / error code is returned in a transient / retriable error condition
            </summary>
            <param name="httpStatusCode">HTTP error code value</param>
            <param name="restStatusCode">REST error code value</param>
            <returns><c>true</c> if this is a transient / retriable error condition</returns>
        </member>
        <member name="M:Orleans.AzureUtils.AzureStorageUtils.IsContentionError(System.Net.HttpStatusCode)">
            <summary>
            Check whether a HTTP status code returned from a REST call might be due to a (temporary) storage contention error.
            </summary>
            <param name="httpStatusCode">HTTP status code to be examined.</param>
            <returns>Returns <c>true</c> if the HTTP status code is due to storage contention.</returns>
        </member>
        <member name="T:Orleans.AzureUtils.AzureTableDefaultPolicies">
            <summary>
            Utility class for default retry / timeout settings for Azure storage.
            </summary>
            <remarks>
            These functions are mostly intended for internal usage by Orleans runtime, but due to certain assembly packaging constrants this class needs to have public visibility.
            </remarks>
        </member>
        <member name="T:Orleans.AzureUtils.AzureTableDataManager`1">
            <summary>
            Utility class to encapsulate row-based access to Azure table storage .
            </summary>
            <remarks>
            These functions are mostly intended for internal usage by Orleans runtime, but due to certain assembly packaging constrants this class needs to have public visibility.
            </remarks>
            <typeparam name="T">Table data entry used by this table / manager.</typeparam>
        </member>
        <member name="M:Orleans.AzureUtils.AzureTableDataManager`1.#ctor(System.String,System.String)">
            <summary>
            Constructor
            </summary>
            <param name="tableName">Name of the table to be connected to.</param>
            <param name="storageConnectionString">Connection string for the Azure storage account used to host this table.</param>
        </member>
        <member name="M:Orleans.AzureUtils.AzureTableDataManager`1.InitTableAsync">
            <summary>
            Connects to, or creates and initializes a new Azure table if it does not already exist.
            </summary>
            <returns>Completion promise for this operation.</returns>
        </member>
        <member name="M:Orleans.AzureUtils.AzureTableDataManager`1.DeleteTableAsync">
            <summary>
            Deletes the Azure table.
            </summary>
            <returns>Completion promise for this operation.</returns>
        </member>
        <member name="M:Orleans.AzureUtils.AzureTableDataManager`1.CreateTableEntryAsync(`0)">
            <summary>
            Create a new data entry in the Azure table.
            Fails if the data already exists.
            </summary>
            <param name="data">Data to be inserted into the table.</param>
            <returns>Value promise with new Etag for this data entry after completing this storage operation.</returns>
        </member>
        <member name="M:Orleans.AzureUtils.AzureTableDataManager`1.UpsertTableEntryAsync(`0)">
            <summary>
            Inserts a data entry in the Azure table: creates a new one if does not exists or overwrites (without eTag) an already existing version (the "update in place" semantincs).
            </summary>
            <param name="data">Data to be inserted or replaced in the table.</param>
            <returns>Value promise with new Etag for this data entry after completing this storage operation.</returns>
        </member>
        <member name="M:Orleans.AzureUtils.AzureTableDataManager`1.UpdateTableEntryAsync(`0,System.String)">
            <summary>
            Updates a data entry in the Azure table: updates an already existing data in the table, by using eTag.
            Fails if the data does not already exist or of eTag does not match.
            </summary>
            <param name="data">Data to be updated into the table.</param>
            <returns>Value promise with new Etag for this data entry after completing this storage operation.</returns>
        </member>
        <member name="M:Orleans.AzureUtils.AzureTableDataManager`1.DeleteTableEntryAsync(`0,System.String)">
            <summary>
            Deletes an already existing data in the table, by using eTag.
            Fails if the data does not already exist or if eTag does not match.
            </summary>
            <param name="data">Data entry to be deleted from the table.</param>
            <returns>Completion promise for this storage operation.</returns>
        </member>
        <member name="M:Orleans.AzureUtils.AzureTableDataManager`1.ReadSingleTableEntryAsync(System.String,System.String)">
            <summary>
            Read a single table entry from the storage table.
            </summary>
            <param name="partitionKey">The partition key for the entry.</param>
            <param name="rowKey">The row key for the entry.</param>
            <returns>Value promise for tuple containing the data entry and its corresponding etag.</returns>
        </member>
        <member name="M:Orleans.AzureUtils.AzureTableDataManager`1.ReadAllTableEntriesForPartitionAsync(System.String)">
            <summary>
            Read all entries in one partition of the storage table.
            NOTE: This could be an expensive and slow operation for large table partitions!
            </summary>
            <param name="partitionKey">The key for the partition to be searched.</param>
            <returns>Enumeration of all entries in the specified table partition.</returns>
        </member>
        <member name="M:Orleans.AzureUtils.AzureTableDataManager`1.ReadAllTableEntriesAsync">
            <summary>
            Read all entries in the table.
            NOTE: This could be a very expensive and slow operation for large tables!
            </summary>
            <returns>Enumeration of all entries in the table</returns>
        </member>
        <member name="M:Orleans.AzureUtils.AzureTableDataManager`1.DeleteTableEntriesAsync(System.Collections.Generic.IReadOnlyCollection{System.Tuple{`0,System.String}})">
            <summary>
            Deletes a set of already existing data entries in the table, by using eTag.
            Fails if the data does not already exist or if eTag does not match.
            </summary>
            <param name="list">List of data entries and their corresponding etags to be deleted from the table.</param>
            <returns>Completion promise for this storage operation.</returns>
        </member>
        <member name="M:Orleans.AzureUtils.AzureTableDataManager`1.ReadTableEntriesAndEtagsAsync(System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}})">
            <summary>
            Read data entries and their corresponding eTags from the Azure table.
            </summary>
            <param name="predicate">Predicate function to use for querying the table and filtering the results.</param>
            <returns>Enumeration of entries in the table which match the query condition.</returns>
        </member>
        <member name="P:Orleans.AzureUtils.AzureTableDataManager`1.TableName">
            <summary> Name of the table this instance is managing. </summary>
        </member>
        <member name="P:Orleans.AzureUtils.AzureTableDataManager`1.logger">
            <summary> Logger for this table manager instance. </summary>
        </member>
        <member name="P:Orleans.AzureUtils.AzureTableDataManager`1.ConnectionString">
            <summary> Connection string for the Azure storage account used to host this table. </summary>
        </member>
        <member name="M:Orleans.AzureUtils.Async_AzureTableDataManager`1.ReadTableEntriesAndEtags(System.Linq.Expressions.Expression{System.Func{`0,System.Boolean}})">
            <summary>
            Read data entries and corresponding etag values for table rows matching the specified predicate
            Used http://convective.wordpress.com/2010/02/06/queries-in-azure-tables/
            to get the API details.
            </summary>
            <param name="predicate"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.AzureUtils.OrleansSiloInstanceManager.InsertSiloEntryConditionally(Orleans.AzureUtils.SiloInstanceTableEntry,Orleans.AzureUtils.SiloInstanceTableEntry,System.String,System.Boolean)">
            <summary>
            Insert (create new) row entry
            </summary>
            <param name="siloEntry">Silo Entry to be written</param>
        </member>
        <member name="M:Orleans.AzureUtils.OrleansSiloInstanceManager.UpdateSiloEntryConditionally(Orleans.AzureUtils.SiloInstanceTableEntry,System.String,Orleans.AzureUtils.SiloInstanceTableEntry,System.String)">
            <summary>
            Conditionally update the row for this entry, but only if the eTag matches with the current record in data store
            </summary>
            <param name="siloEntry">Silo Entry to be written</param>
            <param name="eTag">ETag value for the entry being updated</param>
            <returns></returns>
        </member>
        <member name="M:Orleans.IConsistentRingProviderForGrains.GetMyRange">
            <summary>
            Get the responsbility range of the current silo
            </summary>
            <returns></returns>
        </member>
        <member name="M:Orleans.IConsistentRingProviderForGrains.SubscribeToRangeChangeEvents(Orleans.IGrainRingRangeListener)">
            <summary>
            Subscribe to receive range change notifications
            </summary>
            <param name="observer">An observer interface to receive range change notifications.</param>
            <returns>bool value indicating that subscription succeeded or not.</returns>
        </member>
        <member name="M:Orleans.IConsistentRingProviderForGrains.UnSubscribeFromRangeChangeEvents(Orleans.IGrainRingRangeListener)">
            <summary>
            Unsubscribe from receiving range change notifications
            </summary>
            <param name="observer">An observer interface to receive range change notifications.</param>
            <returns>bool value indicating that unsubscription succeeded or not</returns>
        </member>
        <member name="T:Orleans.IGrain">
            <summary>
            Marker interface for grains
            </summary>
        </member>
        <member name="T:Orleans.IAddressable">
            <summary>
            Marker interface for addressable endpoints, such as grains, observers, and other system-internal addressable endpoints
            </summary>
        </member>
        <member name="M:Orleans.IRingRange.InRange(System.UInt32)">
            <summary>
            Check if <paramref name="n"/> is our responsibility to serve
            </summary>
            <param name="id"></param>
            <returns>true if the reminder is in our responsibility range, false otherwise</returns>
        </member>
        <member name="M:Orleans.SingleRange.InRange(System.UInt32)">
            <summary>
            checks if n is element of (Begin, End], while remembering that the ranges are on a ring
            </summary>
            <param name="n"></param>
            <returns>true if n is in (Begin, End], false otherwise</returns>
        </member>
        <member name="P:Orleans.SingleRange.Begin">
            <summary>
            exclusive
            </summary>
        </member>
        <member name="P:Orleans.SingleRange.End">
            <summary>
            inclusive
            </summary>
        </member>
        <member name="M:Orleans.RangeFactory.MultiRange.InRange(System.UInt32)">
            <summary>
            Check if <paramref name="n"/> is our responsibility to serve
            </summary>
            <param name="id"></param>
            <returns>true if the reminder is in our responsibility range, false otherwise</returns>
        </member>
        <member name="T:Orleans.Providers.AssemblyLoaderCriterion">
            <summary>
            A subsystem interested in loading additional assemblies passes an instance
            of AssemblyLoadCriterion to AssemblyLoader.QualifySearch to ensure that
            assemblies that meet a given criterion are loaded into memory.
            </summary>
            <typeparam name="T">AssemblyLoader.QualifySearch accepts two parameterizations
            of T: string and Assembly. When T is a string, the criterion is used to exclude
            assemblies by path name. When T is an Assembly, the criterion is used by
            AssemblyLoader to indicate which assemblies should be loaded. See
            AssemblyLoaderCritera for examples of both.</typeparam>
        </member>
        <member name="M:Orleans.Providers.AssemblyLoaderCriterion.EvaluateCandidate(System.Object,System.String[]@)">
            <summary>
            AssemblyLoader invokes this wrapper for predicate when it needs to know whether an
            assembly is interesting to a subsystem that registered a criterion.
            </summary>
            <param name="complaint">The complaint, if the return value is *false*</param>
            <param name="candidate">The argument.</param>
            <returns>If T is a string, *false* indicates that the path name should be excluded from loading.
            If T is an assembly object, *true* indicates that the assembly should be loaded.</returns>
            <exception cref="T:System.InvalidOperationException">
            The predicate must provide a substantive complaint string if it returns *false*.</exception>
        </member>
        <member name="T:Orleans.Providers.AssemblyLoaderCriterion.Predicate">
            <summary>
            An AssemblyLoadCriterion wraps a delegate where the predicate logic is implemented.
            </summary>
            <param name="complaint">If the candidate is not interesting to the subsystem that
            registered the criterion, the predicate must supply a complaint-- i.e. a message
            describing why the assembly wasn't interesting to the subsystem.</param>
            <param name="subject">This either an absolute path name in the case of exclusion
            criteria, or an Assembly object in the case of load criterion.</param>
            <returns></returns>
        </member>
        <member name="M:Orleans.Providers.AssemblyLoader.LoadAssemblies(System.Collections.Generic.Dictionary{System.String,System.IO.SearchOption},System.Collections.Generic.IEnumerable{Orleans.Providers.AssemblyLoaderPathNameCriterion},System.Collections.Generic.IEnumerable{Orleans.Providers.AssemblyLoaderReflectionCriterion},Orleans.Logger)">
            <summary>
            Loads assemblies according to caller-defined criteria.
            </summary>
            <param name="dirEnumArgs">A list of arguments that are passed to Directory.EnumerateFiles(). 
                The sum of the DLLs found from these searches is used as a base set of assemblies for
                criteria to evaluate.</param>
            <param name="pathNameCriteria">A list of criteria that are used to disqualify
                assemblies from being loaded based on path name alone (e.g.
                AssemblyLoaderCriteria.ExcludeFileNames) </param>
            <param name="reflectionCriteria">A list of criteria that are used to identify
                assemblies to be loaded based on examination of their ReflectionOnly type
                information (e.g. AssemblyLoaderCriteria.LoadTypesAssignableFrom).</param>
            <param name="logger">A logger to provide feedback to.</param>
        </member>
        <member name="T:Orleans.Providers.IBootstrapProvider">
            <summary>
            Marker interface to be implemented by any app bootstrap classes that want to be loaded and auto-run during silo startup
            </summary>
        </member>
        <member name="T:Orleans.Providers.IOrleansProvider">
            <summary>
            Base interface for all type-specific provider interfaces in Orleans
            </summary>
            <seealso cref="T:Orleans.Providers.IBootstrapProvider"/>
            <seealso cref="T:Orleans.Storage.IStorageProvider"/>
        </member>
        <member name="M:Orleans.Providers.IOrleansProvider.Init(System.String,Orleans.Providers.IProviderRuntime,Orleans.Providers.IProviderConfiguration)">
            <summary>
            Initialization function called by Orleans Provider Manager when a new provider class instance  is created
            </summary>
            <param name="name">Name assigned for this provider</param>
            <param name="providerRuntime">Callback for accessing system functions in the Provider Runtime</param>
            <param name="config">Configuration metadata to be used for this provider instance</param>
            <returns>Completion promise Task for the inttialization work for this provider</returns>
        </member>
        <member name="P:Orleans.Providers.IOrleansProvider.Name">
            <summary>The name of this provider instance, as given to it in the config.</summary>
        </member>
        <member name="T:Orleans.Providers.BootstrapProviderConstants">
            <summary>
            Some constant values used by bootstrap provider loader
            </summary>
        </member>
        <member name="T:Orleans.Providers.IProviderRuntime">
            <summary>
            Interface to allow callbacks from providers into their assigned provider-manager.
            This allows access to runtime functionality, such as logging.
            </summary>
            <remarks>
            Passed to the provider during IOrleansProvider.Init call to that provider instance.
            </remarks>
            <seealso cref="T:Orleans.Providers.IOrleansProvider"/>
        </member>
        <member name="M:Orleans.Providers.IProviderRuntime.GetLogger(System.String,Orleans.Logger.LoggerType)">
            <summary>
            Provides a logger to be used by the provider. 
            </summary>
            <param name="loggerName">Name of the logger being requested.</param>
            <param name="logType">Type of the logger being requested.</param>
            <returns>Object reference to the requested logger.</returns>
            <seealso cref="T:Orleans.Logger.LoggerType"/>
        </member>
        <member name="T:Orleans.Providers.IStreamProviderRuntime">
            <summary>
            Provider-facing interface for manager of streaming providers
            </summary>
        </member>
        <member name="M:Orleans.Providers.IStreamProviderRuntime.ExecutingEntityIdentity">
            <summary>
            Retrieves the opaque identity of currently executing grain or client object. 
            Just for logging purposes.
            </summary>
            <param name="handler"></param>
        </member>
        <member name="M:Orleans.Providers.IStreamProviderRuntime.RegisterTimer(System.Func{System.Object,System.Threading.Tasks.Task},System.Object,System.TimeSpan,System.TimeSpan)">
            <summary>
            Register a timer to send regular callbacks to this grain.
            This timer will keep the current grain from being deactivated.
            </summary>
            <param name="callback"></param>
            <param name="state"></param>
            <param name="dueTime"></param>
            <param name="period"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.Providers.IStreamProviderRuntime.BindExtension``2(System.Func{``0})">
            <summary>
            Binds an extension to an addressable object, if not already done.
            </summary>
            <typeparam name="TExtension">The type of the extension (e.g. StreamConsumerExtension).</typeparam>
            <param name="newExtensionFunc">A factory function that constructs a new extension object.</param>
            <returns>A tuple, containing first the extension and second an addressable reference to the extension's interface.</returns>
        </member>
        <member name="M:Orleans.Providers.IStreamProviderRuntime.PubSub(Orleans.Providers.StreamPubSubType)">
            <summary>
            A Pub Sub runtime interface.
            </summary>
            <returns></returns>
        </member>
        <member name="M:Orleans.Providers.IStreamProviderRuntime.InvokeWithinSchedulingContextAsync(System.Func{System.Threading.Tasks.Task},System.Object)">
            <summary>
            Invoke the given async function from within a valid Orleans scheduler context.
            </summary>
            <param name="asyncFunc"></param>
        </member>
        <member name="P:Orleans.Providers.IStreamProviderRuntime.ConsistentRingProvider">
            <summary>
            A consistent ring interface.
            </summary>
            <param name="pubSubType"></param>
            <returns></returns>
        </member>
        <member name="P:Orleans.Providers.IStreamProviderRuntime.InSilo">
            <summary>
            Return true if this runtime executes inside silo, false otherwise (on the client).
            </summary>
            <param name="pubSubType"></param>
            <returns></returns>
        </member>
        <member name="T:Orleans.Providers.IProviderManager">
            <summary>
            Internal provider management interface for instantiating dependent providers in a hierarchical tree of dependencies
            </summary>
        </member>
        <member name="M:Orleans.Providers.IProviderManager.GetProvider(System.String)">
            <summary>
            Call into Provider Manager for instantiating dependent providers in a hierarchical tree of dependencies
            </summary>
            <param name="name">Name of the provider to be found</param>
            <returns>Provider instance with the given name</returns>
        </member>
        <member name="T:Orleans.Providers.IProviderConfiguration">
            <summary>
            Configuration information that a provider receives
            </summary>
        </member>
        <member name="P:Orleans.Providers.IProviderConfiguration.Properties">
            <summary>
            Configuration properties for this provider instance, as name-value pairs.
            </summary>
        </member>
        <member name="P:Orleans.Providers.IProviderConfiguration.Children">
            <summary>
            Nested providers in case of a hierarchical tree of dependencies
            </summary>
        </member>
        <member name="T:Orleans.Providers.IStorageProviderRuntime">
            <summary>
            Provider-facing interface for manager of storage providers
            </summary>
        </member>
        <member name="T:Orleans.TimeInterval_ThreadCycleCounterBased">
            <summary>
            Stopwatch for CPU time of a thread. 
            You must only use Start, Stop, and Restart from thread being measured!
            CANNOT call this class from a different thread that is not the currently executing thread. 
            Otherwise, QueryThreadCycleTime returns undefined (garbage) results. 
            </summary>
        </member>
        <member name="M:Orleans.TimeInterval_ThreadCycleCounterBased.#ctor">
            <summary>
            Create thread CPU timing object. You may call this from a thread outside the one you wish to measure.
            </summary>
        </member>
        <member name="M:Orleans.TimeInterval_ThreadCycleCounterBased.Start">
            <summary>
            Start measuring time thread is using CPU. Must invoke from thread to be measured!
            </summary>
        </member>
        <member name="M:Orleans.TimeInterval_ThreadCycleCounterBased.Restart">
            <summary>
            Restart measuring time thread is using CPU. Must invoke from thread to be measured!
            </summary>
        </member>
        <member name="M:Orleans.TimeInterval_ThreadCycleCounterBased.Stop">
            <summary>
            Stop measuring time thread is using CPU. Must invoke from thread to be measured!
            </summary>
        </member>
        <member name="P:Orleans.TimeInterval_ThreadCycleCounterBased.Elapsed">
            <summary>
            Obtain current time of stopwatch since last Stop method. You may call this from any thread.
            </summary>
        </member>
        <member name="T:Orleans.Streams.QueueId">
            <summary>
            </summary>
        </member>
        <member name="T:Orleans.Streams.StreamId">
            <summary>
            </summary>
        </member>
        <member name="T:Orleans.IGrainExtension">
            <summary>
            Marker interface for grain extensions, used by internal runtime extension endpoints
            </summary>
        </member>
        <member name="M:Orleans.SetExtensions.ToSet``1(System.Collections.Generic.IEnumerable{``0})">
            <summary>
            Shortcut to create HashSet from IEnumerable that supports type inference
            (which the standard constructor does not)
            </summary>
            <typeparam name="TK"></typeparam>
            <typeparam name="TV"></typeparam>
            <param name="key"></param>
            <param name="value"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.SetExtensions.Synchronize``2(System.Collections.Generic.Dictionary{``0,``1},System.Collections.Generic.Dictionary{``0,``1},System.Func{``1,``1},System.Action{``1,``1})">
            <summary>
            Synchronize contents of two dictionaries with mutable values
            </summary>
            <typeparam name="TKey">Key type</typeparam>
            <typeparam name="TValue">Value type</typeparam>
            <param name="a">Dictionary</param>
            <param name="b">Dictionary</param>
            <param name="copy">Return a copy of a value</param>
            <param name="sync">Synchronize two mutable values</param>
        </member>
        <member name="M:Orleans.SetExtensions.Synchronize``2(System.Collections.Generic.Dictionary{``0,``1},System.Collections.Generic.Dictionary{``0,``1},System.Func{``1,``1,``1})">
            <summary>
            Synchronize contents of two dictionaries with immutable values
            </summary>
            <typeparam name="TKey">Key type</typeparam>
            <typeparam name="TValue">Value type</typeparam>
            <param name="a">Dictionary</param>
            <param name="b">Dictionary</param>
            <param name="sync">Synchronize two values, return synced value</param>
        </member>
        <member name="M:Orleans.SetExtensions.Synchronize2``3(System.Collections.Generic.Dictionary{``0,System.Collections.Generic.Dictionary{``1,``2}},System.Collections.Generic.Dictionary{``0,System.Collections.Generic.Dictionary{``1,``2}},System.Func{``2,``2},System.Action{``2,``2})">
            <summary>
            Synchronize contents of two nested dictionaries with mutable values
            </summary>
            <typeparam name="TKey">Key type</typeparam>
            <typeparam name="TKey2">Nested key type</typeparam>
            <typeparam name="TValue">Value type</typeparam>
            <param name="a">Dictionary</param>
            <param name="b">Dictionary</param>
            <param name="copy">Return a copy of a value</param>
            <param name="sync">Synchronize two mutable values</param>
        </member>
        <member name="M:Orleans.SetExtensions.Synchronize2``3(System.Collections.Generic.Dictionary{``0,System.Collections.Generic.Dictionary{``1,``2}},System.Collections.Generic.Dictionary{``0,System.Collections.Generic.Dictionary{``1,``2}},System.Func{``2,``2,``2})">
            <summary>
            Synchronize contents of two nested dictionaries with immutable values
            </summary>
            <typeparam name="TKey">Key type</typeparam>
            <typeparam name="TKey2">Nested key type</typeparam>
            <typeparam name="TValue">Value type</typeparam>
            <param name="a">Dictionary</param>
            <param name="b">Dictionary</param>
            <param name="copy">Return a copy of a value</param>
            <param name="sync">Synchronize two immutable values</param>
        </member>
        <member name="M:Orleans.SetExtensions.Copy``2(System.Collections.Generic.Dictionary{``0,``1},System.Func{``1,``1})">
            <summary>
            Copy a dictionary with mutable values
            </summary>
            <typeparam name="TKey"></typeparam>
            <typeparam name="TValue"></typeparam>
            <param name="original"></param>
            <param name="copy"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.SetExtensions.ToStrings``1(System.Collections.Generic.IEnumerable{``0},System.Func{``0,System.Object},System.String)">
            <summary>
            ToString every element of an enumeration
            </summary>
            <typeparam name="T"></typeparam>
            <param name="list"></param>
            <param name="toString">Can supply null to use Object.ToString()</param>
            <param name="before">Before each element, or space if unspecified</param>
            <returns></returns>
        </member>
        <member name="T:Orleans.Counters.StatisticsLevel">
            <summary>
            The level of runtime statistics to collect and report periodically.
            The default level is Info.
            </summary>
        </member>
        <member name="M:Orleans.Counters.ThreadTrackingStatistic.#ctor(System.String,Orleans.Counters.CounterStorage)">
            <summary>
            Keep track of thread statistics, mainly timing, can be created outside the thread to be tracked.
            </summary>
            <param name="threadName">Name used for logging the collected stastistics</param>
            <param name="storage"></param>
        </member>
        <member name="M:Orleans.Counters.ThreadTrackingStatistic.OnStartExecution">
            <summary>
            Call once when the thread is started, must be called from the thread being tracked
            </summary>
        </member>
        <member name="M:Orleans.Counters.ThreadTrackingStatistic.OnStopExecution">
            <summary>
            Call once when the thread is stopped, must be called from the thread being tracked
            </summary>
        </member>
        <member name="M:Orleans.Counters.ThreadTrackingStatistic.OnStartProcessing">
            <summary>
            Call once before processing a request, must be called from the thread being tracked
            </summary>
        </member>
        <member name="M:Orleans.Counters.ThreadTrackingStatistic.OnStopProcessing">
            <summary>
            Call once after processing multiple requests as a batch or a single request, must be called from the thread being tracked
            </summary>
            <param name="num">Number of processed requests</param>
        </member>
        <member name="M:Orleans.Counters.ThreadTrackingStatistic.IncrementNumberOfProcessed(System.Int32)">
            <summary>
            Call once to just increment the stastistic of processed requests
            </summary>
            <param name="num">Number of processed requests</param>
        </member>
        <member name="T:Orleans.Messaging.GatewayClientReceiver">
            <summary>
            The Receiver class is used by the GatewayConnection to receive messages. It runs its own thread, but it performs all i/o operations synchronously.
            </summary>
        </member>
        <member name="T:Orleans.Messaging.GatewayConnection">
            <summary>
            The GatewayConnection class does double duty as both the manager of the connection itself (the socket) and the sender of messages
            to the gateway. It uses a single instance of the Receiver class to handle messages from the gateway.
            
            Note that both sends and receives are synchronous.
            </summary>
        </member>
        <member name="T:Orleans.GrainInterfaceMap">
            <summary>
            Internal data structure that holds a grain interfaces to grain classes map.
            </summary>
        </member>
        <member name="T:Orleans.GrainInterfaceData">
            <summary>
            Metadata for a grain interface
            </summary>
        </member>
        <member name="T:Orleans.GrainClassData">
            <summary>
            Metadata for a grain class
            </summary>
        </member>
        <member name="T:Orleans.Streams.IAsyncObserver`1">
            <summary>
            This interface generalizes the standard .NET IObserver interface to allow asynchronous production of items.
            <para>
            Note that this interface is implemented by item consumers and invoked (used) by item producers.
            This means that the producer endpoint of a stream implements this interface.
            </para>
            </summary>
            <typeparam name="T">The type of object consumed by the observer.</typeparam>
        </member>
        <member name="M:Orleans.Streams.IAsyncObserver`1.OnNextAsync(`0)">
            <summary>
            Passes the next item to the consumer.
            <para>
            The Task returned from this method should be completed when the item's processing has been
            sufficiently processed by the consumer to meet any behavioral guarantees.
            </para>
            <para>
            When the consumer is the (producer endpoint of) a stream, the Task is completed when the stream implementation
            has accepted responsibility for the item and is assured of meeting its delivery guarantees.
            For instance, a stream based on a durable queue would complete the Task when the item has been durably saved.
            A stream that provides best-effort at most once delivery would return a Task that is already complete.
            </para>
            <para>
            When the producer is the (consumer endpoint of) a stream, the Task should be completed by the consumer code
            when it has accepted responsibility for the item. 
            In particular, if the stream provider guarantees at-least-once delivery, then the item should not be considered
            delivered until the Task returned by the consumer has been completed.
            </para>
            </summary>
            <param name="item">The item to be passed.</param>
            <returns>A Task that is completed when the item has been accepted.</returns>
        </member>
        <member name="M:Orleans.Streams.IAsyncObserver`1.OnCompletedAsync">
            <summary>
            Notifies the consumer that the stream is closed, and no more items will be delivered.
            <para>
            The Task returned from this method should be completed when the consumer is done processing the stream closure.
            </para>
            </summary>
            <returns>A Task that is completed when the close has been accepted.</returns>
        </member>
        <member name="M:Orleans.Streams.IAsyncObserver`1.OnErrorAsync(System.Exception)">
            <summary>
            Notifies the consumer that the stream has been closed due to an error, and no more items will be delivered.
            <para>
            The Task returned from this method should be completed when the consumer is done processing the stream closure.
            </para>
            </summary>
            <param name="ex">An Exception that describes the error that forced the stream to close.</param>
            <returns>A Task that is completed when the close has been accepted.</returns>
        </member>
        <member name="T:Orleans.Streams.IAsyncBatchObserver`1">
            <summary>
            This interface generalizes the IAsyncObserver interface to allow production and consumption of batches of items.
            <para>
            Note that this interface is implemented by item consumers and invoked (used) by item producers.
            This means that the producer endpoint of a stream implements this interface.
            </para>
            TODO: Do we really need/want this interface? We can implement batch sending without it.
            </summary>
            <typeparam name="T">The type of object consumed by the observer.</typeparam>
        </member>
        <member name="M:Orleans.Streams.IAsyncBatchObserver`1.OnNextBatchAsync(System.Collections.Generic.IEnumerable{`0})">
            <summary>
            Passes the next batch of items to the consumer.
            <para>
            The Task returned from this method should be completed when all items in the batch have been
            sufficiently processed by the consumer to meet any behavioral guarantees.
            </para>
            <para>
            That is, the semantics of the returned Task is the same as for <code>OnNextAsync</code>,
            extended for all items in the batch.
            </para>
            </summary>
            <param name="batch">The items to be passed.</param>
            <returns>A Task that is completed when the batch has been accepted.</returns>
        </member>
        <member name="T:Orleans.Streams.IAsyncObservable`1">
            <summary>
            This interface generalizes the standard .NET IObserveable interface to allow asynchronous consumption of items.
            Asynchronous here means that the consumer can process items asynchronously and signal item completion to the 
            producer by completing the returned Task.
            <para>
            Note that this interface is invoked (used) by item consumers and implemented by item producers.
            This means that the producer endpoint of a stream implements this interface.
            </para>
            </summary>
            <typeparam name="T">The type of object produced by the observable.</typeparam>
        </member>
        <member name="M:Orleans.Streams.IAsyncObservable`1.SubscribeAsync(Orleans.Streams.IAsyncObserver{`0})">
            <summary>
            Subscribe a consumer to this observable.
            </summary>
            <param name="observer">The asynchronous observer to subscribe.</param>
            <returns>A promise for a StreamSubscriptionHandle that represents the subscription.
            The consumer may unsubscribe by using this handle.
            The subscription remains active for as long as it is not explicitely unsubscribed.
            </returns>
        </member>
        <member name="M:Orleans.Streams.IAsyncObservable`1.UnsubscribeAsync(Orleans.Streams.StreamSubscriptionHandle)">
            <summary>
            Unsubscribe a stream consumer from this observable.
            </summary>
            <param name="handle">The stream handle to unsubscribe.</param>
            <returns>A promise to unsubscription action.
            </returns>
        </member>
        <member name="M:Orleans.Streams.IAsyncObservable`1.UnsubscribeAllAsync">
            <summary>
            Unsubscribe all stream consumers from this observable.
            <para>
            Note that this unsubscribe call applies to all stream subscriptons done in a certain processing context, 
            and not globally all subscriptons done in a whole distributed system.
            In Orleans that means all subsriptions made by a grain.
            </para>
            </summary>
            <returns>A promise to unsubscription action.
            </returns>
        </member>
        <member name="T:Orleans.Streams.StreamSubscriptionHandle">
            <summary>
            Handle representing this subsription.
            Consumer may serialize and store the handle in order to unsubsribe later, for example
            in another activation on this grain.
            </summary>
        </member>
        <member name="T:Orleans.ITypeManager">
            <summary>
            Client gateway interface for obtaining the grain interface/type map.
            </summary>
        </member>
        <member name="T:Orleans.ISystemTarget">
            <summary>
            For internal use only.
            This is a markup interface for system target.
            System target are internal runtime objects that share some behaivior with grains, but also impose certain restrictions. In particular:
            System target are asynchronusly addressable actors, just like any IAddressable.
            Proxy class is being generated for ISystemTarget, just like for IAddressable
            System target are scheduled by the runtime scheduler and follow turn based concurrency.
                 Unlike IAddressable, ISystemTarget imposes an additional restriction on its public inteface:
                 all  methods must have as a first argument SiloAddress, which is the explicit address of the ISystemTarget which is the destination of this message.
            </summary> 
        </member>
        <member name="M:Orleans.Counters.FloatValueStatistic.GetCurrentValue">
            <summary>
            Returns the current value
            </summary>
            <returns></returns>
        </member>
        <member name="T:Orleans.IEnumerableExtensions">
            <summary>
            </summary>
        </member>
        <member name="M:Orleans.IEnumerableExtensions.AsList``1(System.Collections.Generic.IEnumerable{``0})">
            <summary>
            </summary>
        </member>
        <member name="M:Orleans.IEnumerableExtensions.AreEqual``1(System.Collections.Generic.IEnumerable{``0},System.Collections.Generic.IEnumerable{``0},System.Collections.Generic.IEqualityComparer{``0})">
            <summary>
            </summary>
        </member>
        <member name="M:Orleans.IEnumerableExtensions.BatchIEnumerable``1(System.Collections.Generic.IEnumerable{``0},System.Int32)">
            <summary>
            </summary>
        </member>
        <member name="T:Orleans.Immutable`1">
            <summary>
            Wrapper class for carrying immutable data.
            </summary>
            <remarks>
            Objects that are known to be immutable are given special fast-path handling by the Orleans serializer 
            -- which in a nutshell allows the DeepCopy step to be skipped during message sends where the sender and reveiving grain are in the same silo.
            
            One very common usage pattern for Immutable is when passing byte[] parameters to a grain. 
            If a program knows it will not alter the contents of the byte[] (for example, if it contains bytes from a static image file read from disk)
            then considerable savings in memory usage and message throughput can be obtained by marking that byte[] argument as <c>Immutable</c>.
            </remarks>
            <typeparam name="T">Type of data to be wrapped by this Immutable</typeparam>
        </member>
        <member name="M:Orleans.Immutable`1.#ctor(`0)">
            <summary>
            Constructor to wrap the specified data object in new Immutable wrapper.
            </summary>
            <param name="value">Value to be wrapped and marked as immutable.</param>
        </member>
        <member name="M:Orleans.Immutable`1.GetCopy">
            <summary>
            Create a deep copy of the original value stored in this Immutable wrapper.
            </summary>
            <returns></returns>
        </member>
        <member name="P:Orleans.Immutable`1.Value">
            <summary> Return reference to the original value stored in this Immutable wrapper. </summary>
        </member>
        <member name="T:Orleans.ImmutableExt">
            <summary>
            Utility class to add the .AsImmutable method to all objects.
            </summary>
        </member>
        <member name="M:Orleans.ImmutableExt.AsImmutable``1(``0)">
            <summary>
            Extension method to return this value wrapped in <c>Immutable</c>.
            </summary>
            <typeparam name="T"></typeparam>
            <param name="value">Value to be wrapped.</param>
            <returns>Immutable wrapper around the original object.</returns>
            <seealso cref="T:Orleans.Immutable`1"/>"/&gt;
        </member>
        <member name="T:Orleans.Providers.ProviderLoader`1">
            <summary>
            Providers configuration and loading error semantics:
            1) We will only load the providers that were specified in the config. 
            If a provider is not specified in the config, we will not attempt to load it.
            Specificaly, it means both storage and streaming providers are loaded only if configured.
            2) If a provider is specified in the config, but was not loaded (no type found, or constructor failed, or Init failed), the silo will fail to start.
            
            Loading providers workflow and error handling implementation:
            1) Load ProviderCategoryConfiguration.
                a) If CategoryConfiguration not found - it is not an error, continue.
            2) Go over all assemblies and load all found providers and instantiate them via ProviderTypeManager.
                a) If a certain found provider type failed to get instantiated, it is not an error, continue.
            3) Validate all providers were loaded: go over all provider config and check that we could indeed load and instantiate all of them.
                a) If failed to load or instantiate at least one configured provider, fail the silo start.
            4) InitProviders: call Init on all loaded providers. 
                a) Failure to init a provider wil result in silo failing to start.
            </summary>
            <typeparam name="TProvider"></typeparam>
        </member>
        <member name="M:Orleans.JenkinsHash.Factory.GetHashGenerator(System.Boolean)">
            <summary>
            Get an instance of Jenkins hash generator
            </summary>
            <param name="threadLocal">Whether instance should be ThreadLocal to provide thread safe instance</param>
            <returns>Hash generator instance</returns>
        </member>
        <member name="T:Orleans.Streams.IAsyncStream`1">
            <summary>
            This interface represents an object that serves as a distributed rendevous between producers and consumers.
            It is similar to a Reactive Framework <code>Subject</code>, but different in that it implements
            neither <code>IObserver</code> nor <code>IObservable</code> itself; rather, it provides a way to obtain
            implementations of these interfaces.
            This allows the creator of a stream to pass a single endpoint (consumer or producer) to a component, rather
            than the full (double-sided) stream itself, providing some level of usage control.
            </summary>
            <typeparam name="T">The type of object that flows through the stream.</typeparam>
        </member>
        <member name="M:Orleans.Streams.IAsyncStream`1.GetProducerInterface">
            <summary>
            Gets an interface to the stream suitable for a producer to use.
            TODO: Should this just return an IAsyncObserver, either if we don't support batching or if some providers don't?
            </summary>
            <returns>The producer-side interface.</returns>
        </member>
        <member name="M:Orleans.Streams.IAsyncStream`1.GetConsumerInterface">
            <summary>
            Gets an interface to the stream suitable for a consumer to use.
            </summary>
            <returns>The consumer-side interface.</returns>
        </member>
        <member name="M:Orleans.Streams.IAsyncStream`1.CloseAsync(System.Exception)">
            <summary>
            Closes the stream.
            </summary>
            <param name="ex">If not null, an Exception that describes the error that is forcing the stream to be closed.</param>
            <returns>A Task that completes when the stream closure has been accepted by the runtime.</returns>
        </member>
        <member name="T:Orleans.Storage.IStorageProvider">
            <summary>
            Interface to be implemented for a storage provider able to read and write Orleans grain state data.
            </summary>
        </member>
        <member name="M:Orleans.Storage.IStorageProvider.Close">
            <summary>Close function for this storage provider instance.</summary>
            <returns>Completion promise for the Close operation on this provider.</returns>
        </member>
        <member name="M:Orleans.Storage.IStorageProvider.ReadStateAsync(System.String,Orleans.GrainReference,Orleans.IGrainState)">
            <summary>Read data function for this storage provider instance.</summary>
            <param name="grainType">Type of this grain [fully qualified class name]</param>
            <param name="grainReference">Grain reference object for this grain.</param>
            <param name="grainState">State data object to be populated for this grain.</param>
            <returns>Completion promise for the Read operation on the specified grain.</returns>
        </member>
        <member name="M:Orleans.Storage.IStorageProvider.WriteStateAsync(System.String,Orleans.GrainReference,Orleans.IGrainState)">
            <summary>Write data function for this storage provider instance.</summary>
            <param name="grainType">Type of this grain [fully qualified class name]</param>
            <param name="grainReference">Grain reference object for this grain.</param>
            <param name="grainState">State data object to be written for this grain.</param>
            <returns>Completion promise for the Write operation on the specified grain.</returns>
        </member>
        <member name="M:Orleans.Storage.IStorageProvider.ClearStateAsync(System.String,Orleans.GrainReference,Orleans.GrainState)">
            <summary>Delete / Clear data function for this storage provider instance.</summary>
            <param name="grainType">Type of this grain [fully qualified class name]</param>
            <param name="grainReference">Grain reference object for this grain.</param>
            <param name="grainState">Copy of last-known state data object for this grain.</param>
            <returns>Completion promise for the Delete operation on the specified grain.</returns>
        </member>
        <member name="P:Orleans.Storage.IStorageProvider.Log">
            <summary>Logger used by this storage provider instance.</summary>
            <returns>Reference to the Logger object used by this provider.</returns>
            <seealso cref="T:Orleans.OrleansLogger"/>
        </member>
        <member name="T:Orleans.Storage.BadProviderConfigException">
            <summary>
            Exception thrown whenever a grain call is attempted with a bad / missing storage provider configuration settings for that grain.
            </summary>
        </member>
        <member name="T:Orleans.OrleansException">
            <summary>
            An exception class used by the Orleans runtime for reporting errors.
            </summary>
            <remarks>
            This is also the base class for any more specific exceptions 
            raised by the Orleans runtime.
            </remarks>
        </member>
        <member name="T:Orleans.Storage.InconsistentStateException">
            <summary>
            Exception thrown when a storage provider detects an Etag inconsistency when attemptiong to perform a WriteStateAsync operation.
            </summary>
        </member>
        <member name="P:Orleans.Storage.InconsistentStateException.StoredEtag">
            <summary>The Etag value currently held in persistent storage.</summary>
        </member>
        <member name="P:Orleans.Storage.InconsistentStateException.CurrentEtag">
            <summary>The Etag value currently help in memory, and attempting to be updated.</summary>
        </member>
        <member name="T:Orleans.ICatalog">
            <summary>
            Remote interface to grain and activation state
            </summary>
        </member>
        <member name="M:Orleans.ICatalog.CreateSystemGrain(Orleans.GrainId,System.String)">
            <summary>
            Create a new system grain
            </summary>
            <param name="silo"></param>
            <param name="grainId"></param>
            <param name="type"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ICatalog.DeleteGrainsLocal(System.Collections.Generic.List{Orleans.GrainId})">
            <summary>
            Delete grain information and activations from this silo.
            For internal use only.
            </summary>
            <param name="silo"></param>
            <param name="grainIds"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ICatalog.DeleteActivationsLocal(System.Collections.Generic.List{Orleans.ActivationAddress})">
            <summary>
            Delete activations from this silo
            </summary>
            <param name="target"></param>
            <param name="activationAddresses"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ISiloStatusOracle.Start(System.Boolean)">
            <summary>
            Start this oracle. Will register this silo in the SiloDirectory with SiloStatus.Starting status.
            </summary>
        </member>
        <member name="M:Orleans.ISiloStatusOracle.BecomeActive">
            <summary>
            Turns this oracle into an Active state. Will update this silo in the SiloDirectory with SiloStatus.Active status.
            </summary>
        </member>
        <member name="M:Orleans.ISiloStatusOracle.ShutDown">
            <summary>
            ShutDown this oracle. Will update this silo in the SiloDirectory with SiloStatus.ShuttingDown status. 
            </summary>
        </member>
        <member name="M:Orleans.ISiloStatusOracle.Stop">
            <summary>
            Stop this oracle. Will update this silo in the SiloDirectory with SiloStatus.Stopping status. 
            </summary>
        </member>
        <member name="M:Orleans.ISiloStatusOracle.KillMyself">
            <summary>
            Completely kill this oracle. Will update this silo in the SiloDirectory with SiloStatus.Dead status. 
            </summary>
        </member>
        <member name="M:Orleans.ISiloStatusOracle.GetApproximateSiloStatus(Orleans.SiloAddress)">
            <summary>
            Get the status of a given silo. 
            This method returns an approximate view on the status of a given silo. 
            In particular, this oracle may think the given silo is alive, while it may already have failed.
            If this oracle thinks the given silo is dead, it has been authoratively told so by ISiloDirectory.
            </summary>
            <param name="type">siloAddress</param>A silo whose status we are interested in.
            <returns>The status of a given silo.</returns>
        </member>
        <member name="M:Orleans.ISiloStatusOracle.GetApproximateSiloStatuses(System.Boolean)">
            <summary>
            Get the statuses of all silo. 
            This method returns an approximate view on the statuses of all silo.
            </summary>
            <param name="type">onlyActive</param>Include only silo who are currently considered to be active. If false, inlude all.
            <returns>A list of silo statuses.</returns>
        </member>
        <member name="M:Orleans.ISiloStatusOracle.IsValidSilo(Orleans.SiloAddress)">
            <summary>
            Determine if the current silo is valid for creating new activations on or for directoy lookups.
            </summary>
            <returns>The silo so ask about.</returns>
        </member>
        <member name="M:Orleans.ISiloStatusOracle.IsDeadSilo(Orleans.SiloAddress)">
            <summary>
            Determine if the current silo is dead.
            </summary>
            <returns>The silo so ask about.</returns>
        </member>
        <member name="M:Orleans.ISiloStatusOracle.SubscribeToSiloStatusEvents(Orleans.ISiloStatusListener)">
            <summary>
            Subscribe to status events about all silos. 
            </summary>
            <param name="type">observer</param>An observer async interface to receive silo status notifications.
            <returns>bool value indicating that subscription succeeded or not.</returns>
        </member>
        <member name="M:Orleans.ISiloStatusOracle.UnSubscribeFromSiloStatusEvents(Orleans.ISiloStatusListener)">
            <summary>
            UnSubscribe from status events about all silos. 
            </summary>
            <returns>bool value indicating that subscription succeeded or not.</returns>
        </member>
        <member name="P:Orleans.ISiloStatusOracle.CurrentStatus">
            <summary>
            Current status of this silo.
            </summary>
        </member>
        <member name="T:Orleans.ISiloShutdownParticipant">
            <summary>
            Implemented by runtime objects that participate in shutdown process
            </summary>
        </member>
        <member name="M:Orleans.ISiloShutdownParticipant.BeginShutdown(System.Action)">
            <summary>
            Notification that shutdown process is beginning. Should do minimal work on this thread.
            </summary>
        </member>
        <member name="M:Orleans.ISiloShutdownParticipant.CanFinishShutdown">
            <summary>
            Poll if this participant is ready to finish shutdown.
            </summary>
            <returns>True if ready to finish</returns>
        </member>
        <member name="M:Orleans.ISiloShutdownParticipant.FinishShutdown">
            <summary>
            Invoked after all participants have said they can finish shutdown,
            to actually finish the shutdown process.
            Must force a shutdown even if it is not ready.
            </summary>
        </member>
        <member name="M:Orleans.IRemoteSiloStatusOracle.SiloStatusChangeNotification(Orleans.SiloAddress,Orleans.SiloStatus)">
             <summary>
             Receive notifications about silo status events. 
             </summary>
            <param name="destination">The address of the silo this message will be sent to.</param>
             <param name="type">updatedSilo</param>A silo to update about.
             <param name="type">status</param>The status of a silo.
             <returns></returns>
        </member>
        <member name="M:Orleans.IRemoteSiloStatusOracle.Ping(System.Int32)">
            <summary>
            Ping request from another silo that probes the liveness of the recipient silo.
            </summary>
            <param name="destination">The address of the silo this message will be sent to.</param>
            <param name="pingNumber">A unique sequence number for ping message, to facilitate testijng and debugging.</param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ISiloStatusListener.SiloStatusChangeNotification(Orleans.SiloAddress,Orleans.SiloStatus)">
            <summary>
            Receive notifications about silo status events. 
            </summary>
            <param name="type">updatedSilo</param>A silo to update about.
            <param name="type">status</param>The status of a silo.
            <returns></returns>
        </member>
        <member name="M:Orleans.IMembershipTable.UpdateRow(Orleans.MembershipEntry,System.String,Orleans.TableVersion)">
            <summary>
            Writes a new entry iff the entry etag is equal to the provided etag parameter.
            </summary>
            <param name="key"></param>
            <param name="entry"></param>
            <param name="etag"></param>
            <returns>true iff the write was successful</returns>
        </member>
        <member name="M:Orleans.IMembershipNamingServiceListener.AllMembersNamingServiceNotification(Orleans.NamingServiceData)">
            <summary>
            Receive notifications about silo status events. 
            </summary>
            <param name="type">silos</param>All silos.
            <returns></returns>
        </member>
        <member name="T:Orleans.Management.IOrleansManagementGrain">
            <summary>
            Interface for system management functions for an Orleans silo, 
            exposed as a grain for receiving remote requests / commands.
            </summary>
        </member>
        <member name="M:Orleans.Management.IOrleansManagementGrain.GetHosts(System.Boolean)">
            <summary>
            Get the list of silo hosts and statuses currently known about in this cluster.
            </summary>
            <param name="onlyActive">Whether data on just current active silos should be returned, 
            or by default data for all current and previous silo instances [including those in Joining or Dead status].</param>
            <returns></returns>
        </member>
        <member name="M:Orleans.Management.IOrleansManagementGrain.SetSystemLogLevel(Orleans.SiloAddress[],System.Int32)">
            <summary>
            Set the current log level for system runtime components.
            </summary>
            <param name="hostsIds">List of silos this command is to be sent to.</param>
            <param name="traceLevel">New log level to use.</param>
            <returns>Completion promise for this operation.</returns>
        </member>
        <member name="M:Orleans.Management.IOrleansManagementGrain.SetAppLogLevel(Orleans.SiloAddress[],System.Int32)">
            <summary>
            Set the current log level for application grains.
            </summary>
            <param name="hostsIds">List of silos this command is to be sent to.</param>
            <param name="traceLevel">New log level to use.</param>
            <returns>Completion promise for this operation.</returns>
        </member>
        <member name="M:Orleans.Management.IOrleansManagementGrain.SetLogLevel(Orleans.SiloAddress[],System.String,System.Int32)">
            <summary>
            Set the current log level for a particular Logger, by name (with prefix matching).
            </summary>
            <param name="hostsIds">List of silos this command is to be sent to.</param>
            <param name="logName">Name of the Logger (with prefix matching) to change.</param>
            <param name="traceLevel">New log level to use.</param>
            <returns>Completion promise for this operation.</returns>
        </member>
        <member name="M:Orleans.Management.IOrleansManagementGrain.ForceGarbageCollection(Orleans.SiloAddress[])">
            <summary>
            Perform a run of the .NET garbage collector in the specified silos.
            </summary>
            <param name="hostsIds">List of silos this command is to be sent to.</param>
            <returns>Completion promise for this operation.</returns>
        </member>
        <member name="M:Orleans.Management.IOrleansManagementGrain.ForceActivationCollection(Orleans.SiloAddress[],System.TimeSpan)">
            <summary>
            Perform a run of the Orleans activation garbage collecter in the specified silos.
            </summary>
            <param name="hostsIds">List of silos this command is to be sent to.</param>
            <returns>Completion promise for this operation.</returns>
        </member>
        <member name="M:Orleans.Management.IOrleansManagementGrain.ForceRuntimeStatisticsCollection(Orleans.SiloAddress[])">
            <summary>
            Perform a run of the silo statistics collector in the specified silos.
            </summary>
            <param name="hostsIds">List of silos this command is to be sent to.</param>
            <returns>Completion promise for this operation.</returns>
        </member>
        <member name="M:Orleans.Management.IOrleansManagementGrain.GetRuntimeStatistics(Orleans.SiloAddress[])">
            <summary>
            Return the most recent silo runtime statistics information for the specified silos.
            </summary>
            <param name="hostsIds">List of silos this command is to be sent to.</param>
            <returns>Completion promise for this operation.</returns>
        </member>
        <member name="M:Orleans.Management.IOrleansManagementGrain.GetSimpleGrainStatistics(Orleans.SiloAddress[])">
            <summary>
            Return the most recent grain statistics information, amalgomated across silos.
            </summary>
            <param name="hostsIds">List of silos this command is to be sent to.</param>
            <returns>Completion promise for this operation.</returns>
        </member>
        <member name="M:Orleans.Management.IOrleansManagementGrain.GetSimpleGrainStatistics">
            <summary>
            Return the most recent grain statistics information, amalgomated across all silos.
            </summary>
            <returns>Completion promise for this operation.</returns>
        </member>
        <member name="M:Orleans.Management.IOrleansManagementGrain.GetGrainActivationCount(Orleans.GrainReference)">
            <summary>
            Return the most recent activation count for a specific grain across all silos.
            </summary>
            <param name="grainReference">Reference to the grain to be queried.</param>
            <returns>Completion promise for this operation.</returns>
        </member>
        <member name="M:Orleans.Management.IOrleansManagementGrain.UpdateConfiguration(Orleans.SiloAddress[],System.Collections.Generic.Dictionary{System.String,System.String},System.Collections.Generic.Dictionary{System.String,System.String})">
            <summary>
            Update the configuration information dynamically. Only a subset of configuration information
            can be updated - will throw an error (and make no config changes) if you specify attributes
            or elements that cannot be changed. The configuration format is XML, in the same format
            as the OrleansConfiguration.xml file. The allowed elements and attributes are:
            <pre>
            &lt;OrleansConfiguration&gt;
                &lt;Globals&gt;
                    &lt;Messaging ResponseTimeout=&quot;?&quot;/&gt;
                    &lt;Caching CacheSize=&quot;?&quot;/&gt;
                    &lt;Activation CollectionInterval=&quot;?&quot; CollectionAmount=&quot;?&quot; CollectionTotalMemoryLimit=&quot;?&quot; CollectionActivationLimit=&quot;?&quot;/&gt;
                    &lt;Liveness ProbeTimeout=&quot;?&quot; TableRefreshTimeout=&quot;?&quot; NumMissedProbesLimit=&quot;?&quot;/&gt;
                &lt;/Globals&gt;
                &lt;Defaults&gt;
                    &lt;LoadShedding Enabled=&quot;?&quot; LoadLimit=&quot;?&quot;/&gt;
                    &lt;Tracing DefaultTraceLevel=&quot;?&quot; PropagateActivityId=&quot;?&quot;&gt;
                        &lt;TraceLevelOverride LogPrefix=&quot;?&quot; TraceLevel=&quot;?&quot;/&gt;
                    &lt;/Tracing&gt;
                &lt;/Defaults&gt;
            &lt;/OrleansConfiguration&gt;
            </pre>
            </summary>
            <param name="hostIds">Silos to update, or null for all silos</param>
            <param name="configuration">XML elements and attributes to update</param>
            <returns></returns>
        </member>
        <member name="M:Orleans.Management.IOrleansManagementGrain.GetGlobalConfiguration(Orleans.SiloAddress[])">
            <summary>
            Retrieve the current global configuration settings for each specified silo.
            </summary>
            <param name="hostsIds">Silos to query, or null for all silos</param>
            <returns><c>GlobalConfiguration</c> from each requested silo</returns>
        </member>
        <member name="M:Orleans.Management.IOrleansManagementGrain.GetNodeConfiguration(Orleans.SiloAddress[])">
            <summary>
            Retrieve the current configuration settings for each specified silo.
            </summary>
            <param name="hostsIds">Silos to query, or null for all silos</param>
            <returns><c>NodeConfiguration</c> from each requested silo</returns>
        </member>
        <member name="M:Orleans.Management.IOrleansManagementGrain.GetTotalActivationCount">
            <summary>
            Retrieve the total number of activations in the cluster.
            </summary>
            <returns>A quantity of activations.</returns>
        </member>
        <member name="M:Orleans.IReminderService.RegisterOrUpdateReminder(Orleans.GrainId,System.String,System.TimeSpan,System.TimeSpan)">
            <summary>
            Register a persistent reminder
            </summary>
            <param name="destination"></param>
            <param name="grainId"></param>
            <param name="reminderName"></param>
            <param name="dueTime"></param>
            <param name="period"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.IReminderTable.ReadRows(Orleans.IRingRange)">
            <summary>
            Return all rows that have their GrainId's.GetUniformHashCode() in the range (start, end]
            </summary>
            <param name="start"></param>
            <param name="end"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.IReminderTable.RemoveRow(Orleans.GrainId,System.String,System.String)">
            <summary>
            Remove a row from the table
            </summary>
            <param name="grainId"></param>
            <param name="reminderName"></param>
            /// <param name="eTag"></param>
            <returns>true if a row with <paramref name="grainId"/> and <paramref name="reminderName"/> existed and was removed successfully, false otherwise</returns>
        </member>
        <member name="T:Orleans.IOrleansReminder">
            <summary>
            Handle for a persistent Reminder.
            </summary>
        </member>
        <member name="P:Orleans.IOrleansReminder.ReminderName">
            <summary> Name of this Reminder. </summary>
        </member>
        <member name="T:Orleans.IGrainInfo">
            <summary>
            For internal use only.
            </summary>
        </member>
        <member name="T:Orleans.IRemoteGrainDirectory">
            <summary>
            Per-silo system interface for managing the distributed, partitioned grain-silo-activation directory.
            </summary>
        </member>
        <member name="M:Orleans.IRemoteGrainDirectory.Register(Orleans.ActivationAddress,System.Int32)">
            <summary>
            Record a new grain activation by adding it to the directory.
            </summary>
            <param name="destination">The address of the silo this message will be sent to.</param>
            <param name="address">The address of the new activation.</param>
            <param name="retries">Number of retries to execute the method in case the virtual ring (servers) changes.</param>
            <returns></returns>
        </member>
        <member name="M:Orleans.IRemoteGrainDirectory.RegisterMany(System.Collections.Generic.List{Orleans.ActivationAddress},System.Int32)">
            <summary>
            Records a bunch of new grain activations.
            </summary>
            <param name="silo"></param>
            <param name="addresses"></param>
            <param name="retries">Number of retries to execute the method in case the virtual ring (servers) changes.</param>
            <returns></returns>
        </member>
        <member name="M:Orleans.IRemoteGrainDirectory.RegisterSingleActivation(Orleans.ActivationAddress,System.Int32)">
            <summary>
            Registers a new activation, in single activation mode, with the directory service.
            If there is already an activation registered for this grain, then the new activation will
            not be registered and the address of the existing activation will be returned.
            Otherwise, the passed-in address will be returned.
            <para>This method must be called from a scheduler thread.</para>
            </summary>
            <param name="silo"></param>
            <param name="address">The address of the potential new activation.</param>
            <param name="retries">Number of retries to execute the method in case the virtual ring (servers) changes.</param>
            <returns>The address registered for the grain's single activation.</returns>
        </member>
        <member name="M:Orleans.IRemoteGrainDirectory.RegisterManySingleActivation(System.Collections.Generic.List{Orleans.ActivationAddress},System.Int32)">
            <summary>
            Registers multiple new activations, in single activation mode, with the directory service.
            If there is already an activation registered for any of the grains, then the corresponding new activation will
            not be registered.
            <para>This method must be called from a scheduler thread.</para>
            </summary>
            <param name="silo"></param>
            <param name="addresses"></param>
            <param name="retries">Number of retries to execute the method in case the virtual ring (servers) changes.</param>
            <returns></returns>
        </member>
        <member name="M:Orleans.IRemoteGrainDirectory.Unregister(Orleans.ActivationAddress,System.Boolean,System.Int32)">
            <summary>
            Remove an activation from the directory.
            </summary>
            <param name="destination">The address of the silo this message will be sent to.</param>
            <param name="address">The address of the activation to unregister.</param>
            <param name="force">If true, then the entry is removed; if false, then the entry is removed only if it is
            sufficiently old.</param>
            <param name="retries">Number of retries to execute the method in case the virtual ring (servers) changes.</param>
            <returns>Success</returns>
        </member>
        <member name="M:Orleans.IRemoteGrainDirectory.DeleteGrain(Orleans.GrainId,System.Int32)">
            <summary>
            Removes all directory information about a grain.
            </summary>
            <param name="destination">The address of the silo this message will be sent to.</param>
            <param name="grain">The ID of the grain to look up.</param>
            <param name="retries">Number of retries to execute the method in case the virtual ring (servers) changes.</param>
            <returns></returns>
        </member>
        <member name="M:Orleans.IRemoteGrainDirectory.LookUp(Orleans.GrainId,System.Int32)">
            <summary>
            Fetch the list of the current activations for a grain along with the version number of the list.
            </summary>
            <param name="destination">The address of the silo this message will be sent to.</param>
            <param name="grain">The ID of the grain.</param>
            <param name="retries">Number of retries to execute the method in case the virtual ring (servers) changes.</param>
            <returns></returns>
        </member>
        <member name="M:Orleans.IRemoteGrainDirectory.LookUpMany(System.Collections.Generic.List{System.Tuple{Orleans.GrainId,System.Int32}},System.Int32)">
            <summary>
            Fetch the updated information on the given list of grains.
            This method should be called only remotely to refresh directory caches.
            </summary>
            <param name="destination">The address of the silo this message will be sent to.</param>
            <param name="grainAndETagList">list of grains and generation (version) numbers. The latter denote the versions of 
            the lists of activations currently held by the invoker of this method.</param>
            <param name="retries">Number of retries to execute the method in case the virtual ring (servers) changes.</param>
            <returns>list of tuples holding a grain, generation number of the list of activations, and the list of activations. 
            If the generation number of the invoker matches the number of the destination, the list is null. If the destination does not
            hold the information on the grain, generation counter -1 is returned (and the list of activations is null)</returns>
        </member>
        <member name="M:Orleans.IRemoteGrainDirectory.RegisterReplica(Orleans.SiloAddress,Orleans.GrainId,Orleans.GrainId,System.Collections.Generic.Dictionary{Orleans.GrainId,Orleans.IGrainInfo},System.Boolean)">
            <summary>
            Registers replica of the directory partition from source silo on the destination silo.
            </summary>
            <param name="destination">The address of the silo this message will be sent to.</param>
            <param name="source">The address of the owner of the replica.</param>
            <param name="start">The first GrainId covered by this chunk; null if this is the first chunk</param>
            <param name="end">The last GrainId covered by this chunk; null if this is the last chunk</param>
            <param name="partition">The (full or partial) replica of the directory partition to be registered.
            TODO: this probably should be just a simple List&lt;KeyValuePair&lt;GrainId, IGrainInfo&gt;&gt;, or List&lt;Tuple...&gt;</param>
            <param name="isFullCopy">Flag specifying whether it is a full replica (and thus any old replica should be just replaced) or the
            a delta replica (and thus the old replica should be updated by delta changes) </param>
            <returns></returns>
        </member>
        <member name="M:Orleans.IRemoteGrainDirectory.UnregisterReplica(Orleans.SiloAddress)">
            <summary>
            Unregisters replica of the directory partition from source silo on the destination silo.
            </summary>
            <param name="destination">The address of the silo this message will be sent to.</param>
            <param name="source">The address of the owner of the replica.</param>
            <returns></returns>
        </member>
        <member name="M:Orleans.IRemoteGrainDirectory.UnregisterMany(System.Collections.Generic.List{Orleans.ActivationAddress},System.Int32)">
            <summary>
            Unregister a block of addresses at once
            </summary>
            <param name="destination"></param>
            <param name="activationAddresses"></param>
            <param name="retries"></param>
            <returns></returns>
        </member>
        <member name="T:Orleans.ReasonDetail">
            <summary>
            Reason for aborting a task
            </summary>
        </member>
        <member name="P:Orleans.ReasonDetail.IsRetriable">
            <summary>
            Whether it can be retried
            </summary>
        </member>
        <member name="T:Orleans.IRemindable">
            <summary>
            Callback interface that grains must implement inorder to be able to register and receive Reminders.
            </summary>
        </member>
        <member name="M:Orleans.IRemindable.ReceiveReminder(System.String,Orleans.TickStatus)">
            <summary>
            Receieve a new Reminder.
            </summary>
            <param name="reminderName">Name of this Reminder</param>
            <param name="status">Status of this Reminder tick</param>
            <returns>Completion promise which the grain will resolve when it has finished processing this Reminder tick.</returns>
        </member>
        <member name="T:Orleans.TickStatus">
            <summary>
            The status of a tick when the tick is delivered to the registrar grain.
            In case of failures, it may happen that a tick is not delievered on time. The app can notice such missed missed ticks as follows.
            Upon receiving a tick, the app can calculate the theoretical number of ticks since start of the reminder as: 
            curCount = (Now - FirstTickTime) / Period
            The app can keep track of it as 'count'. Upon receiving a tick, the number of missed ticks = curCount - count - 1
            Thereafter, the app can set count = curCount
            </summary>
        </member>
        <member name="P:Orleans.TickStatus.FirstTickTime">
            <summary>
            The time at which the first tick of this reminder is due, or was triggered
            </summary>
        </member>
        <member name="P:Orleans.TickStatus.Period">
            <summary>
            The period of the reminder
            </summary>
        </member>
        <member name="P:Orleans.TickStatus.CurrentTickTime">
            <summary>
            The time on the runtime silo when the silo initiated the delivery of this tick.
            </summary>
        </member>
        <member name="T:Orleans.ReminderException">
            <summary>
            Exception related to Orleans Reminder functions or Reminder service.
            </summary>
        </member>
        <member name="M:Orleans.Counters.StringValueStatistic.GetCurrentValue">
            <summary>
            Returns the current value
            </summary>
            <returns></returns>
        </member>
        <member name="M:Orleans.BufferPool.#ctor(System.Int32,System.Int32,System.Int32,System.String)">
            <summary>
            Creates a buffer pool.
            </summary>
            <param name="bufferSize">The size, in bytes, of each buffer.</param>
            <param name="maxBuffers">The maximum number of buffers to keep around, unused; by default, the number of unused buffers is unbounded.</param>
        </member>
        <member name="T:Orleans.Counters.SiloRuntimeStatistics">
            <summary>
            Snapshot of current runtime statistics for a silo
            </summary>
        </member>
        <member name="P:Orleans.Counters.SiloRuntimeStatistics.ActivationCount">
            <summary>
            Number of activations in a silo.
            </summary>
        </member>
        <member name="P:Orleans.Counters.SiloRuntimeStatistics.RequestQueueLength">
            <summary>
            The size of the request queue.
            </summary>
        </member>
        <member name="P:Orleans.Counters.SiloRuntimeStatistics.SendQueueLength">
            <summary>
            The size of the sending queue.
            </summary>
        </member>
        <member name="P:Orleans.Counters.SiloRuntimeStatistics.ReceiveQueueLength">
            <summary>
            The size of the receiving queue.
            </summary>
        </member>
        <member name="P:Orleans.Counters.SiloRuntimeStatistics.CpuUsage">
            <summary>
            The CPU utilization.
            </summary>
        </member>
        <member name="P:Orleans.Counters.SiloRuntimeStatistics.MemoryUsage">
            <summary>
            The used memory size.
            </summary>
        </member>
        <member name="P:Orleans.Counters.SiloRuntimeStatistics.IsOverloaded">
            <summary>
            Is this silo overloaded.
            </summary>
        </member>
        <member name="P:Orleans.Counters.SiloRuntimeStatistics.ClientCount">
            <summary>
            The number of clients currently connected to that silo.
            </summary>
        </member>
        <member name="T:Orleans.Counters.GrainStatistic">
            <summary>
            Snapshot of current statistics for a given grain type.
            </summary>
        </member>
        <member name="M:Orleans.Counters.GrainStatistic.ToString">
            <summary>
            Returns the string representatio of this GrainStatistic.
            </summary>
        </member>
        <member name="P:Orleans.Counters.GrainStatistic.GrainType">
            <summary>
            The type of the grain for this GrainStatistic.
            </summary>
        </member>
        <member name="P:Orleans.Counters.GrainStatistic.GrainCount">
            <summary>
            Number of grains of a this type.
            </summary>
        </member>
        <member name="P:Orleans.Counters.GrainStatistic.ActivationCount">
            <summary>
            Number of activation of a agrain of this type.
            </summary>
        </member>
        <member name="P:Orleans.Counters.GrainStatistic.SiloCount">
            <summary>
            Number of silos that have activations of this grain type.
            </summary>
        </member>
        <member name="T:Orleans.Counters.SimpleGrainStatistic">
            <summary>
            Simple snapshot of current statistics for a given grain type on a given silo.
            </summary>
        </member>
        <member name="M:Orleans.Counters.SimpleGrainStatistic.ToString">
            <summary>
            Returns the string representatio of this SimpleGrainStatistic.
            </summary>
        </member>
        <member name="P:Orleans.Counters.SimpleGrainStatistic.GrainType">
            <summary>
            The type of the grain for this SimpleGrainStatistic.
            </summary>
        </member>
        <member name="P:Orleans.Counters.SimpleGrainStatistic.SiloAddress">
            <summary>
            The silo address for this SimpleGrainStatistic.
            </summary>
        </member>
        <member name="P:Orleans.Counters.SimpleGrainStatistic.ActivationCount">
            <summary>
            The number of activations of this grain type on this given silo.
            </summary>
        </member>
        <member name="T:Orleans.AsyncSafeTimer">
            <summary>
            SafeTimer - A wrapper class around .NET Timer objects, with some additional built-in safeguards against edge-case errors.
            
            SafeTimer is a replacement for .NET Timer objects, and removes some of the more infrequently used method overloads for simplification.
            SafeTimer provides centralization of various "guard code" previously added in various places for handling edge-case fault conditions.
            
            Log levels used: Recovered faults => Warning, Per-Timer operations => Verbose, Per-tick operations => Verbose3
            </summary>
        </member>
        <member name="T:Orleans.LimitNames">
            <summary>
            Class containing key names for the configurable LimitValues used by Orleans runtime.
            </summary>
        </member>
        <member name="T:Orleans.LimitManager">
            <summary>
            Limits Manager
            </summary>
        </member>
        <member name="T:Orleans.SafeTimerBase">
            <summary>
            SafeTimerBase - an internal base class for implementing sync and async timers in Orleans.
            
            </summary>
        </member>
        <member name="M:Orleans.SafeTimerBase.Change(System.TimeSpan,System.TimeSpan)">
            <summary>
            Changes the start time and the interval between method invocations for a timer, using TimeSpan values to measure time intervals.
            </summary>
            <param name="dueTime">A TimeSpan representing the amount of time to delay before invoking the callback method specified when the Timer was constructed. Specify negative one (-1) milliseconds to prevent the timer from restarting. Specify zero (0) to restart the timer immediately.</param>
            <param name="period">The time interval between invocations of the callback method specified when the Timer was constructed. Specify negative one (-1) milliseconds to disable periodic signaling.</param>
            <returns><c>true</c> if the timer was successfully updated; otherwise, <c>false</c>.</returns>
        </member>
        <member name="T:Orleans.OneTimeSafeTimer">
            <summary>
            OneTimeSafeTimer is just a convenience class for creating one time safe timers.
            No need to manually dispose it. It will self dispose after the first tick.
            </summary>
        </member>
        <member name="T:Orleans.SafeTimer">
            <summary>
            SafeTimer - A wrapper class around .NET Timer objects, with some additional built-in safeguards against edge-case errors.
            
            SafeTimer is a replacement for .NET Timer objects, and removes some of the more infrequently used method overloads for simplification.
            SafeTimer provides centralization of various "guard code" previously added in various places for handling edge-case fault conditions.
            
            Log levels used: Recovered faults => Warning, Per-Timer operations => Verbose, Per-tick operations => Verbose3
            </summary>
        </member>
        <member name="T:Orleans.StandardExtensions">
            <summary>
            The Utils class contains a variety of utility methods for use in application and grain code.
            </summary>
        </member>
        <member name="T:Orleans.GrainReferenceCache`2">
            <summary>
            This class implements an LRU (Least-Recently Used) cache of grain references. It keeps a bounded set of values and will age-out "old" values 
            </summary>
            <typeparam name="TKey"></typeparam>
            <typeparam name="TValue"></typeparam>
        </member>
        <member name="M:Orleans.GrainReferenceCache`2.#ctor(System.Int32,System.TimeSpan,Orleans.GrainReferenceCache{`0,`1}.FetchValueDelegate,Orleans.GrainReferenceCache{`0,`1}.CastDelegate)">
            <summary>
            Creates a new LRU (Least-Recently Used) cache of GrainReferences.
            </summary>
            <param name="maxSize">Maximum number of entries to allow.</param>
            <param name="maxAge">Maximum age of an entry.</param>
            <param name="f"> Delegate for fetching the value associated with a given key</param>
            <param name="c"> Delegate for casting IAddressable to TValue</param>
        </member>
        <member name="M:Orleans.GrainReferenceCache`2.Get(`0)">
            <summary>
            Get a grain reference for the specified cache-key.
            The grain reference will either be taken from cahce, or a new one will be created by calling the <c>FetchValueDelegate</c>
            </summary>
            <param name="key"></param>
            <returns></returns>
        </member>
        <member name="P:Orleans.GrainReferenceCache`2.Count">
            <summary>
            Return the number of entries currently in the cache
            </summary>
        </member>
        <member name="T:Orleans.RequestContext">
            <summary>
            This class holds information regarding the request currently being processed.
            It is explicitly intended to be available to application code.
            </summary>
            <remarks>
            <para>
            The request context is represented as a property bag.
            Some values are provided by default; others are derived from messages headers in the
            request that led to the current processing.
            </para>
            <para>
            Information stored in RequestContext is propagated from 
            Orleans clients to Orleans grains automatically 
            by the Orleans runtime.
            RequestContext data is not automatically propagated across 
            TPL thread-switch boundaries -- <see cref="T:System.Runtime.Remoting.Messaging.CallContext"/> 
            for that type of functionality.
            </para>
            </remarks>
        </member>
        <member name="M:Orleans.RequestContext.Get(System.String)">
            <summary>
            Retrieve a value from the RequestContext key-value bag.
            </summary>
            <param name="key">The key for the value to be retrieved.</param>
            <returns>The value currently in the RequestContext for the specified key, 
            otherwise returns <c>null</c> if no data is present for that key.</returns>
        </member>
        <member name="M:Orleans.RequestContext.Set(System.String,System.Object)">
            <summary>
            Sets a value into the RequestContext key-value bag.
            </summary>
            <param name="key">The key for the value to be updated / added.</param>
            <param name="value">The value to be stored into RequestContext.</param>
        </member>
        <member name="M:Orleans.RequestContext.Remove(System.String)">
            <summary>
            Remove a value from the RequestContext key-value bag.
            </summary>
            <param name="key">The key for the value to be removed.</param>
            <returns>Boolean <c>True</c> if the value was previously in the RequestContext key-value bag and has now been removed, otherwise returns <c>False</c>.</returns>
        </member>
        <member name="P:Orleans.RequestContext.PropagateActivityId">
            <summary>
            Whether Trace.CorrelationManager.ActivityId settings should be propagated into grain calls.
            </summary>
        </member>
        <member name="T:Orleans.ErrorCode">
            <summary>
            The set of error types used by the Orleans runtime libraries for logging errors.
            </summary>
        </member>
        <member name="M:Orleans.Counters.CounterStatistic.GetCurrentValue">
            <summary>
            Returns the current value
            </summary>
            <returns></returns>
        </member>
        <member name="M:Orleans.Counters.CounterStatistic.GetCurrentValueAndDeltaAndResetDelta(System.Int64@)">
            <summary>
            Returns the current value and the delta since the last call to this method.
            Note: This call also resets the delta by remembering the 'current' value as the new 'last' value.
            </summary>
            <returns></returns>
        </member>
        <member name="M:Orleans.Counters.IntValueStatistic.GetCurrentValue">
            <summary>
            Returns the current value
            </summary>
            <returns></returns>
        </member>
        <member name="M:Orleans.Version.ProgamIdent">
            <summary>
            Writes the Orleans program ident info to the Console, eg: 'OrleansHost v2012.5.9.51607 Build:12345 Timestamp: 20120509-185359'
            </summary>
        </member>
        <member name="P:Orleans.Version.Current">
            <summary>
            The full version string of the Orleans runtime, eg: '2012.5.9.51607 Build:12345 Timestamp: 20120509-185359'
            </summary>
        </member>
        <member name="P:Orleans.Version.ApiVersion">
            <summary>
            The ApiVersion of the Orleans runtime, eg: '1.0.0.0'
            </summary>
        </member>
        <member name="P:Orleans.Version.FileVersion">
            <summary>
            The FileVersion of the Orleans runtime, eg: '2012.5.9.51607'
            </summary>
        </member>
        <member name="P:Orleans.Version.ProgramName">
            <summary>
            The program name string for the Orleans runtime, eg: 'OrleansHost'
            </summary>
        </member>
        <member name="T:Orleans.SafeRandom">
            <summary>
            Thread-safe random number generator.
            Has same API as System.Random but takes a lock.
            </summary>
        </member>
        <member name="T:Orleans.Serialization.BinaryTokenStreamReader">
            <summary>
            Reader for Orleans binary token streams
            </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.#ctor(System.Byte[])">
            <summary>
            Create a new BinaryTokenStreamReader to read from the specified input byte array.
            </summary>
            <param name="input">Input binary data to be tokenized.</param>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.#ctor(System.Collections.Generic.List{System.ArraySegment{System.Byte}})">
            <summary>
            Create a new BinaryTokenStreamReader to read from the specified input buffers.
            </summary>
            <param name="buffs">The list of ArraySegments to use for the data.</param>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadInt">
            <summary> Read an <c>Int32</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadUInt">
            <summary> Read an <c>UInt32</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadShort">
            <summary> Read an <c>Int16</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadUShort">
            <summary> Read an <c>UInt16</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadLong">
            <summary> Read an <c>Int64</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadULong">
            <summary> Read an <c>UInt64</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadFloat">
            <summary> Read an <c>float</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadDouble">
            <summary> Read an <c>double</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadDecimal">
            <summary> Read an <c>decimal</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadString">
            <summary> Read an <c>string</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadBytes(System.Int32)">
            <summary> Read the next bytes from the stream. </summary>
            <param name="count">Number of bytes to read.</param>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadByteArray(System.Byte[],System.Int32,System.Int32)">
            <summary> Read the next bytes from the stream. </summary>
            <param name="destination">Output array to store the returned data in.</param>
            <param name="offset">Offset into the destination array to write to.</param>
            <param name="count">Number of bytes to read.</param>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadChar">
            <summary> Read an <c>char</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadByte">
            <summary> Read an <c>byte</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadSByte">
            <summary> Read an <c>sbyte</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadIPAddress">
            <summary> Read an <c>IPAddress</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadIPEndPoint">
            <summary> Read an <c>IPEndPoint</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadSiloAddress">
            <summary> Read an <c>SiloAddress</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadGrainId">
            <summary> Read an <c>GrainId</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadActivationId">
            <summary> Read an <c>ActivationId</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadActivationAddress">
            <summary> Read an <c>ActivationAddress</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadBlockInto(System.Array,System.Int32)">
            <summary>
            Read a block of data into the specified output <c>Array</c>.
            </summary>
            <param name="array">Array to output the data to.</param>
            <param name="n">Number of bytes to read.</param>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.PeekToken">
            <summary>
            Peek at the next token in this input stream.
            </summary>
            <returns>Next token thatr will be read from the stream.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadToken">
            <summary> Read a <c>SerializationTokenType</c> value from the stream. </summary>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadFullTypeHeader(System.Type)">
            <summary> Read a <c>Type</c> value from the stream. </summary>
            <param name="expected">Expected Type, if known.</param>
            <returns>Data from current position in stream, converted to the appropriate output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamReader.ReadSpecifiedTypeHeader">
            <summary> Read a <c>Type</c> value from the stream. </summary>
        </member>
        <member name="P:Orleans.Serialization.BinaryTokenStreamReader.CurrentPosition">
            <summary> Current read position in the stream. </summary>
        </member>
        <member name="T:Orleans.Serialization.BinaryTokenStreamWriter">
            <summary>
            Writer for Orleans binary token streams
            </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.#ctor">
            <summary> Default constructor. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.ToBytes">
            <summary> Return the output stream as a set of <c>ArraySegment</c>. </summary>
            <returns>Data from this stream, converted to output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.ToByteArray">
            <summary> Return the output stream as a <c>byte[]</c>. </summary>
            <returns>Data from this stream, converted to output type.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.ReleaseBuffers">
            <summary> Release any serialization buffers being used by this stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Int32)">
            <summary> Write an <c>Int32</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Int16)">
            <summary> Write an <c>Int16</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Int64)">
            <summary> Write an <c>Int64</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.SByte)">
            <summary> Write a <c>sbyte</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.UInt32)">
            <summary> Write a <c>UInt32</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.UInt16)">
            <summary> Write a <c>UInt16</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.UInt64)">
            <summary> Write a <c>UInt64</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Byte)">
            <summary> Write a <c>byte</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Single)">
            <summary> Write a <c>float</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Double)">
            <summary> Write a <c>double</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Decimal)">
            <summary> Write a <c>decimal</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.String)">
            <summary> Write a <c>string</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Char)">
            <summary> Write a <c>char</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Boolean)">
            <summary> Write a <c>bool</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.WriteNull">
            <summary> Write a <c>null</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.WriteTypeHeader(System.Type,System.Type)">
            <summary> Write a type header for the specified Type to the stream. </summary>
            <param name="t">Type to write header for.</param>
            <param name="expected">Currently expected Type for this stream.</param>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Byte[])">
            <summary> Write a <c>byte[]</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Byte[],System.Int32,System.Int32)">
            <summary> Write the specified number of bytes to the stream, starting at the specified offset in the input <c>byte[]</c>. </summary>
            <param name="b">The input data to be written.</param>
            <param name="offset">The offset into the inout byte[] to start writing bytes from.</param>
            <param name="count">The number of bytes to be written.</param>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Int16[])">
            <summary> Write a <c>Int16[]</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Int32[])">
            <summary> Write a <c>Int32[]</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Int64[])">
            <summary> Write a <c>Int64[]</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.UInt16[])">
            <summary> Write a <c>UInt16[]</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.UInt32[])">
            <summary> Write a <c>UInt32[]</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.UInt64[])">
            <summary> Write a <c>UInt64[]</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.SByte[])">
            <summary> Write a <c>sbyte[]</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Char[])">
            <summary> Write a <c>char[]</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Boolean[])">
            <summary> Write a <c>bool[]</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Double[])">
            <summary> Write a <c>double[]</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Single[])">
            <summary> Write a <c>float[]</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(Orleans.CorrelationId)">
            <summary> Write a <c>CorrelationId</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Net.IPEndPoint)">
            <summary> Write a <c>IPEndPoint</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Net.IPAddress)">
            <summary> Write a <c>IPAddress</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(Orleans.ActivationAddress)">
            <summary> Write a <c>ActivationAddress</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(Orleans.SiloAddress)">
            <summary> Write a <c>SiloAddress</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(Orleans.ActivationId)">
            <summary> Write a <c>ActivationId</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(Orleans.GrainId)">
            <summary> Write a <c>GrainId</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.TimeSpan)">
            <summary> Write a <c>TimeSpan</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.DateTime)">
            <summary> Write a <c>DataTime</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.Write(System.Guid)">
            <summary> Write a <c>Guid</c> value to the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.TryWriteSimpleObject(System.Object)">
            <summary>
            Try to write a simple type (non-array) value to the stream.
            </summary>
            <param name="obj">Input object to be written to the output stream.</param>
            <returns>Returns <c>true</c> if the value was successfully written to the output stream.</returns>
        </member>
        <member name="M:Orleans.Serialization.BinaryTokenStreamWriter.WriteArrayHeader(System.Array,System.Type)">
            <summary>
            Write header for an <c>Array</c> to the output stream.
            </summary>
            <param name="a">Data object for which header should be written.</param>
            <param name="expected">The most recent Expected Type currently active for this stream.</param>
        </member>
        <member name="P:Orleans.Serialization.BinaryTokenStreamWriter.CurrentOffset">
            <summary> Current write position in the stream. </summary>
        </member>
        <member name="M:Orleans.Serialization.TypeUtilities.OrleansTypeName(System.Type)">
            <summary>
            For internal use only.
            Public for testing purposes.
            </summary>
            <param name="t"></param>
            <returns></returns>
        </member>
        <member name="T:Orleans.SiloStatus">
            <summary>
            This enumeration is for internal use only.
            </summary>
        </member>
        <member name="F:Orleans.SiloStatus.None">
            <summary>
            For internal use only.
            </summary>
        </member>
        <member name="F:Orleans.SiloStatus.Created">
            <summary>
            For internal use only.
            This silo was just created, but not started yet.
            </summary>
        </member>
        <member name="F:Orleans.SiloStatus.Joining">
            <summary>
            For internal use only.
            This silo has just started, but not ready yet. It is attempting to join the cluster.
            </summary>
        </member>
        <member name="F:Orleans.SiloStatus.Active">
            <summary>
            For internal use only.
            This silo is alive and functional.
            </summary>
        </member>
        <member name="F:Orleans.SiloStatus.ShuttingDown">
            <summary>
            For internal use only.
            This silo is shutting itself down.
            </summary>
        </member>
        <member name="F:Orleans.SiloStatus.Stopping">
            <summary>
            For internal use only.
            This silo is stopping itself down.
            </summary>
        </member>
        <member name="F:Orleans.SiloStatus.Dead">
            <summary>
            For internal use only.
            This silo is de-activated/considered to be dead.
            </summary>
        </member>
        <member name="T:Orleans.IOrleansTimer">
            <summary>
            OrleansTimer instances represent a pending timer.
            The only operation that is available is Dispose, which will cancel the pending timer message.
            </summary>
        </member>
        <member name="T:Orleans.OrleansClient">
            <summary>
            Configures client runtime for connecting to Orleans system
            </summary>
        </member>
        <member name="M:Orleans.OrleansClient.Initialize">
            <summary>
            Initializes the client runtime from the standard client configuration file.
            </summary>
        </member>
        <member name="M:Orleans.OrleansClient.Initialize(System.String)">
            <summary>
            Initializes the client runtime from the provided client configuration file.
            If an error occurs reading the specified configuration file, the initialization fails.
            </summary>
            <param name="configFilePath">A relative or absolute pathname for the client configuration file.</param>
        </member>
        <member name="M:Orleans.OrleansClient.Initialize(System.IO.FileInfo)">
            <summary>
            Initializes the client runtime from the provided client configuration file.
            If an error occurs reading the specified configuration file, the initialization fails.
            </summary>
            <param name="configFile">The client configuration file.</param>
        </member>
        <member name="M:Orleans.OrleansClient.Initialize(Orleans.ClientConfiguration)">
            <summary>
            Initializes the client runtime from the provided client configuration object. 
            If the configuration object is null, the initialization fails. 
            </summary>
            <param name="config">A ClientConfiguration object.</param>
        </member>
        <member name="M:Orleans.OrleansClient.Initialize(System.Net.IPEndPoint,System.Boolean)">
            <summary>
            Initializes the client runtime from the standard client configuration file using the provided gateway address.
            Any gateway addresses specified in the config file will be ignored and the provided gateway address wil be used instead. 
            </summary>
            <param name="gatewayAddress">IP address and port of the gateway silo</param>
            <param name="overrideConfig">Whether the specified gateway endpoint should override / replace the values from config file, or be additive</param>
        </member>
        <member name="M:Orleans.OrleansClient.DoInternalInitialize(Orleans.ClientConfiguration,Orleans.OutsideGrainClient)">
            <summary>
            Initializes client runtime from client configuration object.
            </summary>
        </member>
        <member name="M:Orleans.OrleansClient.Uninitialize">
            <summary>
            Uninitializes client runtime.
            </summary>
        </member>
        <member name="M:Orleans.OrleansClient.InternalUninitialize">
            <summary>
            This is the lock free version of uninitilize so we can share 
            it between the public method and error paths inside initialize.
            This should only be called inside a lock(initLock) block.
            </summary>
        </member>
        <member name="M:Orleans.OrleansClient.CheckInitialized">
            <summary>
            Check that the runtime is intialized correctly, and throw InvalidOperationException if not
            </summary>
            <exception cref="T:System.InvalidOperationException">Thrown if Orleans runtime is not correctly initialized before this call.</exception>
        </member>
        <member name="M:Orleans.OrleansClient.SetResponseTimeout(System.TimeSpan)">
            <summary>
            Set a timeout for responses on this Orleans client.
            </summary>
            <param name="timeout"></param>
            <exception cref="T:System.InvalidOperationException">Thrown if Orleans runtime is not correctly initialized before this call.</exception>
        </member>
        <member name="M:Orleans.OrleansClient.GetResponseTimeout">
            <summary>
            Get a timeout of responses on this Orleans client.
            </summary>
            <returns>The response timeout.</returns>
            <exception cref="T:System.InvalidOperationException">Thrown if Orleans runtime is not correctly initialized before this call.</exception>
        </member>
        <member name="P:Orleans.OrleansClient.IsInitialized">
            <summary>
            Whether the client runtime has already been initialized
            </summary>
            <returns><c>true</c> if client runtime is already initialized</returns>
        </member>
        <member name="P:Orleans.OrleansClient.Logger">
            <summary>
            Provides logging facility for applications.
            </summary>
            <exception cref="T:System.InvalidOperationException">Thrown if Orleans runtime is not correctly initialized before this call.</exception>
        </member>
        <member name="T:Orleans.IGrainClient">
            <summary>
            The IGrainClient interface defines the API exposed to non-Orleans code for interacting with Orleans.
            </summary>
        </member>
        <member name="M:Orleans.IGrainClient.GetResponseTimeout">
            <summary>
            Get the current response timeout setting for this client.
            </summary>
            <returns>Response timeout value</returns>
        </member>
        <member name="M:Orleans.IGrainClient.SetResponseTimeout(System.TimeSpan)">
            <summary>
            Sets the current response timeout setting for this client.
            </summary>
            <param name="timeout">New response timeout value</param>
        </member>
        <member name="P:Orleans.IGrainClient.AppLogger">
            <summary>
            Provides client application code with access to an Orleans logger.
            </summary>
        </member>
        <member name="P:Orleans.IGrainClient.Identity">
            <summary>
            A unique identifier for the current client.
            There is no semantic content to this string, but it may be useful for logging.
            </summary>
        </member>
        <member name="P:Orleans.IGrainClient.CurrentGrain">
            <summary>
            Return the currently running grain if in a grain, or null if running in a client
            </summary>
        </member>
        <member name="T:Orleans.IGrainClientInternal">
            <summary>
            The IGrainClientInternal interface defines the internal client API exposed to Orleans runtime code.
            For internal use only.
            </summary>
        </member>
        <member name="P:Orleans.IGrainClientInternal.CurrentStorageProvider">
            <summary>
            Return the currently storage provider configured for this grain, or null if no storage provider configured for this grain.
            </summary>
            <exception cref="T:System.InvalidOperationException">If called from outside grain class</exception>
        </member>
        <member name="F:Orleans.OutsideGrainClient.responseTimeout">
            <summary>
            Response timeout.
            </summary>
        </member>
        <member name="M:Orleans.OutsideGrainClient.Disconnect">
            <summary>
            For internal testing only.
            </summary>
        </member>
        <member name="M:Orleans.OutsideGrainClient.Reconnect">
            <summary>
            For internal testing only.
            </summary>
        </member>
        <member name="T:Orleans.Strategy">
            <summary>
            Abstract marker class for configuration information associated with a cell
            </summary>
        </member>
        <member name="M:Orleans.Strategy.ToString">
            <summary>
            Generates a human-readable string description of this strategy.
            </summary>
            <returns>A string containing the description. By default, this is the short name of the implementing type.</returns>
        </member>
        <member name="T:Orleans.GrainStrategy">
            <summary>
            Strategy that applies to an individual grain
            </summary>
        </member>
        <member name="F:Orleans.GrainStrategy.RandomPlacement">
            <summary>
            Placement strategy that indicates that new activations of this grain type should be placed randomly,
            subject to the overall placement policy.
            </summary>
        </member>
        <member name="F:Orleans.GrainStrategy.PreferLocalPlacement">
            <summary>
            Placement strategy that indicates that new activations of this grain type should be placed on a local silo.
            </summary>
        </member>
        <member name="F:Orleans.GrainStrategy.LoadAwarePlacement">
            <summary>
            Placement strategy that indicates that new activations of this grain type should be placed randomly,
            subject to the current load distribution across the deployment.
            </summary>
        </member>
        <member name="F:Orleans.GrainStrategy.LocalPlacement">
            <summary>
            Use a local activation, create if not present
            </summary>
        </member>
        <member name="F:Orleans.GrainStrategy.LocalPlacementAvailable">
            <summary>
            Use a local activation, create if not present or all busy
            </summary>
        </member>
        <member name="F:Orleans.GrainStrategy.LocalPlacementAvailableSpare">
            <summary>
            Use a local activation, ensure there is always at least one inactive to copy state
            </summary>
        </member>
        <member name="T:Orleans.Timeoutable">
            <summary>
            This interface is for use with the Orleans timers.
            See <see cref="T:Orleans.CoarseGrainTimerWheel"/>.
            </summary>
        </member>
        <member name="M:Orleans.Timeoutable.OnTimeout">
            <summary>
            This method is called by the timer when the time out is reached.
            </summary>
        </member>
        <member name="M:Orleans.Timeoutable.RequestedTimeout">
            <summary>
            This method is not used.
            </summary>
            <returns>Not used.</returns>
        </member>
        <member name="M:Orleans.CallbackData.StartTimer(System.TimeSpan)">
            <summary>
            Start this callback timer
            </summary>
            <param name="time">Timeout time</param>
        </member>
        <member name="T:Orleans.CoarseGrainTimerWheel">
            <summary>
            This class is for internal use by the Orleans run-time.
            </summary>
        </member>
        <member name="M:Orleans.CoarseGrainTimerWheel.#ctor(System.Int32,System.TimeSpan)">
            <summary>
            For internal use by the Orleans run-time.
            </summary>
            <param name="numPeriods"></param>
            <param name="maxTimeout"></param>
        </member>
        <member name="M:Orleans.CoarseGrainTimerWheel.ScheduleForTimeout(Orleans.Timeoutable,System.TimeSpan)">
            <summary>
            For internal use by the Orleans run-time.
            </summary>
            <param name="target"></param>
            <param name="timeout"></param>
        </member>
        <member name="T:Orleans.ReadOnlyAttribute">
            <summary>
            The ReadOnly attribute is used to mark methods that do not modify the state of a grain.
            <para>
            Marking methods as ReadOnly allows the run-time system to perform a number of optimizations
            that may significantly improve the performance of your application.
            </para>
            </summary>
        </member>
        <member name="T:Orleans.ReentrantAttribute">
            <summary>
            The Reentrant attribute is used to mark grain implementation classes that allow request interleaving within a task.
            <para>
            This is an advanced feature and should not be used unless the implications are fully understood.
            That said, allowing request interleaving allows the run-time system to perform a number of optimizations
            that may significantly improve the performance of your application. 
            </para>
            </summary>
        </member>
        <member name="T:Orleans.UnorderedAttribute">
            <summary>
            The Unordered attribute is used to mark grain interface in which the delivery order of
            messages is not significant.
            </summary>
        </member>
        <member name="T:Orleans.StatelessWorkerAttribute">
            <summary>
            The StatelessWorker attribute is used to mark grain interface in which there is no expectation
            of preservation of grain state between requests. 
            </summary>
        </member>
        <member name="T:Orleans.AlwaysInterleaveAttribute">
            <summary>
            The AlwaysInterleaveAttribute attribute is used to mark methods that can interleave with any other method type, including write (non ReadOnly) requests.
            </summary>
        </member>
        <member name="T:Orleans.TypeCodeOverrideAttribute">
            <summary>
            The TypeCodeOverrideAttribute attribute allows to specify the grain interface ID or the grain class type code
            to override the default ones to avoid hash collisions
            </summary>
        </member>
        <member name="P:Orleans.TypeCodeOverrideAttribute.TypeCode">
            <summary>
            Use a specific grain interface ID or grain class type code (e.g. to avoid hash collisions)
            </summary>
        </member>
        <member name="T:Orleans.PlacementAttribute">
            <summary>
            Base for all placement policy marker attributes.
            </summary>
        </member>
        <member name="T:Orleans.RandomPlacementAttribute">
            <summary>
            Marks a grain interface as using the <c>RandomPlacement</c> policy.
            </summary>
            <remarks>
            This is the default placement policy, so this attribute does not need to be used for normal grains.
            </remarks>
        </member>
        <member name="T:Orleans.PreferLocalPlacementAttribute">
            <summary>
            Marks a grain interface as using the <c>PreferLocalPlacement</c> policy.
            </summary>
        </member>
        <member name="T:Orleans.LoadAwarePlacementAttribute">
            <summary>
            Marks a grain interface as using the <c>LoadAwarePlacement</c> policy.
            </summary>
        </member>
        <member name="T:Orleans.LocalPlacementAttribute">
            <summary>
            Marks a grain interface as using the <c>LocalPlacement</c> policy.
            </summary>
        </member>
        <member name="T:Orleans.ExplicitPlacementAttribute">
            <summary>
            Marks a grain interface as using the <c>ExplicitPlacement</c> policy.
            </summary>
        </member>
        <member name="T:Orleans.CacheableAttribute">
            <summary>
            The Cacheable attribute is used to mark properties whose values may be cached by clients for a maximum of the specified amount of time.
            </summary>
        </member>
        <member name="T:Orleans.ImmutableAttribute">
            <summary>
            The Immutable attribute indicates that instances of the marked class or struct are never modified
            after they are created.
            </summary>
            <remarks>
            Note that this implies that sub-objects are also not modified after the instance is created.
            </remarks>
        </member>
        <member name="T:Orleans.ActivationIncludedAttribute">
            <summary>
            The ActivationIncluded attribute is used to mark assemblies generated by the ClientGenerator tool.
            It is for internal use only.
            </summary>
        </member>
        <member name="T:Orleans.CopierMethodAttribute">
            <summary>
            Used to mark a method as providing a copier function for that type.
            </summary>
        </member>
        <member name="T:Orleans.SerializerMethodAttribute">
            <summary>
            Used to mark a method as providinga serializer function for that type.
            </summary>
        </member>
        <member name="T:Orleans.DeserializerMethodAttribute">
            <summary>
            Used to mark a method as providing a deserializer function for that type.
            </summary>
        </member>
        <member name="T:Orleans.RegisterSerializerAttribute">
            <summary>
            Used to make a class for auto-registration as a serialization helper.
            </summary>
        </member>
        <member name="T:Orleans.StorageProviderAttribute">
            <summary>
            The [StorageProvider] attribute is used to define which storage provider to use for persistence of grain state.
            <para>
            Specifying [StorageProvider] property is recommended for all grains which extend GrainBase&lt;T&gt;.
            If no [StorageProvider] attribute is  specified, then a "Default" strorage provider will be used.
            If a suitable storage provider cannot be located for this grain, then the grain will fail to load into the Silo.
            </para>
            </summary>
        </member>
        <member name="P:Orleans.StorageProviderAttribute.ProviderName">
            <summary>
            The name of the storage provider to ne used for persisting state for this grain.
            </summary>
        </member>
        <member name="T:Orleans.ExtendedPrimaryKeyAttribute">
            <summary>
            Used to make a grain interface as using extended keys.
            </summary>
            <remarks>
            If a grain interface uses extended keys, then an additional set of grain reference 
            factory methods will be generated which accept both primary and extended key parts.
            </remarks>
        </member>
        <member name="T:Orleans.GrainFactoryBase">
            <summary>
            Abstract base class for all grain proxy factory classes.
            </summary>
            <remarks>
            These methods are used from Orleans generated code.
            </remarks>
        </member>
        <member name="M:Orleans.GrainFactoryBase.MakeGrainReferenceInternal(System.Type,System.Int32,System.Int64,System.String)">
            <summary>
            Fabricate a grain reference for a grain with the specified Int64 primary key
            </summary>
            <param name="grainInterfaceType">Grain type</param>
            <param name="interfaceId">Type code value for this grain type</param>
            <param name="primaryKey">Primary key for the grain</param>
            <param name="grainClassNamePrefix">Prefix or full name of the grain class to disambiguate multiple implementations.</param>
            <returns><c>GrainReference</c> for connecting to the grain with the specified primary key</returns>
            <exception cref="T:System.ArgumentException">If called for a grain type that is not a valid grain type.</exception>
        </member>
        <member name="M:Orleans.GrainFactoryBase.MakeGrainReferenceInternal(System.Type,System.Int32,System.Guid,System.String)">
            <summary>
            Fabricate a grain reference for a grain with the specified Guid primary key
            </summary>
            <param name="grainInterfaceType">Grain type</param>
            <param name="interfaceId">Type code value for this self-managed grain type</param>
            <param name="primaryKey">Primary key for the grain</param>
            <param name="grainClassNamePrefix">Prefix or full name of the grain class to disambiguate multiple implementations.</param>
            <returns><c>GrainReference</c> for connecting to the self-managed grain with the specified primary key</returns>
            <exception cref="T:System.ArgumentException">If called for a grain type that is not a valid grain type.</exception>
        </member>
        <member name="M:Orleans.GrainFactoryBase.MakeExplicitlyPlacedGrainReferenceInternal(System.Type,System.Int32,System.Guid,System.Net.IPEndPoint,System.String)">
            <summary>
            Fabricate a grain reference for an explicitly-placed grain with the specified Guid primary key
            </summary>
            <param name="grainInterfaceType">Grain type</param>
            <param name="interfaceId">Type code value for this grain type</param>
            <param name="primaryKey">Primary key for the grain</param>
            <param name="grainClassNamePrefix">Prefix or full name of the grain class to disambiguate multiple implementations.</param>
            <returns><c>GrainReference</c> for connecting to the grain with the specified primary key</returns>
            <exception cref="T:System.ArgumentException">If called for a grain type that is not a valid grain type.</exception>
        </member>
        <member name="M:Orleans.GrainFactoryBase.MakeExplicitlyPlacedGrainReferenceInternal(System.Type,System.Int32,System.Int64,System.Net.IPEndPoint,System.String)">
            <summary>
            Fabricate a grain reference for an explicitly-placed grain with the specified Int64 primary key
            </summary>
            <param name="grainInterfaceType">Grain type</param>
            <param name="interfaceId">Type code value for this grain type</param>
            <param name="primaryKey">Primary key for the grain</param>
            <param name="grainClassNamePrefix">Prefix or full name of the grain class to disambiguate multiple implementations.</param>
            <returns><c>GrainReference</c> for connecting to the grain with the specified primary key</returns>
            <exception cref="T:System.ArgumentException">If called for a grain type that is not a valid grain type.</exception>
        </member>
        <member name="M:Orleans.GrainFactoryBase.MakeKeyExtendedGrainReferenceInternal(System.Type,System.Int32,System.Guid,System.String,System.String)">
            <summary>
            Fabricate a grain reference for an extended-key grain with the specified Guid primary key
            </summary>
            <param name="grainInterfaceType">Grain type</param>
            <param name="interfaceId">Type code value for this grain type</param>
            <param name="primaryKey">Primary key for the grain</param>
            <param name="keyExt">Extended key for the grain</param>
            <param name="grainClassNamePrefix">Prefix or full name of the grain class to disambiguate multiple implementations.</param>
            <returns><c>GrainReference</c> for connecting to the grain with the specified primary key</returns>
            <exception cref="T:System.ArgumentException">If called for a grain type that is not a valid grain type.</exception>
        </member>
        <member name="M:Orleans.GrainFactoryBase.MakeKeyExtendedGrainReferenceInternal(System.Type,System.Int32,System.Int64,System.String,System.String)">
            <summary>
            Fabricate a grain reference for an extended-key grain with the specified Int64 primary key
            </summary>
            <param name="grainInterfaceType">Grain type</param>
            <param name="interfaceId">Type code value for this grain type</param>
            <param name="primaryKey">Primary key for the grain</param>
            <param name="keyExt">Extended key for the grain</param>
            <param name="grainClassNamePrefix">Prefix or full name of the grain class to disambiguate multiple implementations.</param>
            <returns><c>GrainReference</c> for connecting to the grain with the specified primary key</returns>
            <exception cref="T:System.ArgumentException">If called for a grain type that is not a valid grain type.</exception>
        </member>
        <member name="M:Orleans.GrainFactoryBase.CheckGrainObserverParamInternal(Orleans.IGrainObserver)">
            <summary>
            Check that a grain observer parameter is of the correct underlying concrent type -- either extending from <c>GrainRefereence</c> or <c>GrainBase</c>
            </summary>
            <param name="grainObserver">Grain observer parameter to be checked.</param>
            <exception cref="T:System.ArgumentNullException">If grainObserver is <c>null</c></exception>
            <exception cref="T:System.NotSupportedException">If grainObserver class is not an appropriate underlying concrete type.</exception>
        </member>
        <member name="M:Orleans.GrainFactoryBase.CheckRuntimeEnvironmentSetup">
            <summary>
            Check the current runtime environment has been setup and initialized correctly.
            Throws InvalidOperationException if current runtime environment is not initialized.
            </summary>
        </member>
        <member name="T:Orleans.IClientObserverRegistrar">
            <summary>
            Client gateway interface for forwarding client requests to silos.
            </summary>
        </member>
        <member name="M:Orleans.IClientObserverRegistrar.RegisterClientObserver(Orleans.GrainId,System.Guid)">
            <summary>
            Registers a client observer object on this gateway.
            </summary>
        </member>
        <member name="M:Orleans.IClientObserverRegistrar.UnregisterClientObserver(Orleans.ActivationAddress)">
            <summary>
            Unregisters client observer object.
            </summary>
        </member>
        <member name="M:Orleans.IClientObserverRegistrar.UnregisterClientObserver(Orleans.GrainId)">
            <summary>
            Unregisters client observer object from all gateways.
            </summary>
        </member>
        <member name="T:Orleans.LogWriterBase">
            <summary>
            The Log Writer base class provides default partial implementation suitable for most specific log writer.
            </summary>
        </member>
        <member name="T:Orleans.ILogConsumer">
            <summary>
            An interface used to consume log entries. 
            Instaces of a class implementing this should be added to <see cref="P:Orleans.Logger.LogConsumers"/> collection in order to retrieve events.
            </summary>
        </member>
        <member name="M:Orleans.ILogConsumer.Log(Orleans.OrleansLogger.Severity,Orleans.Logger.LoggerType,System.String,System.String,System.Net.IPEndPoint,System.Exception,System.Int32)">
            <summary>
            The method to call during logging.
            This method should be very fast, since it is called synchronously during Orleans logging.
            </summary>
            <param name="severity">The severity of the message being traced.</param>
            <param name="loggerType">The type of logger the message is being traced through.</param>
            <param name="caller">The name of the logger tracing the message.</param>
            <param name="myIPEndPoint">The <see cref="T:System.Net.IPEndPoint"/> of the Orleans client/server if known. May be null.</param>
            <param name="message">The message to log.</param>
            <param name="exception">The exception to log. May be null.</param>
            <param name="eventCode">Numeric event code for this log entry. May be zero, meaning 'Unspecified'. 
            In general, all log entries at severity=Error or greater should specify an explicit error code value.</param>
        </member>
        <member name="M:Orleans.LogWriterBase.Log(Orleans.OrleansLogger.Severity,Orleans.Logger.LoggerType,System.String,System.String,System.Net.IPEndPoint,System.Exception,System.Int32)">
            <summary>
            The method to call during logging.
            This method should be very fast, since it is called synchronously during Orleans logging.
            </summary>
            <remarks>
            To customize functionality in a log writter derived from this base class, 
            you should override the <c>FormatLogMessage</c> and/or <c>WriteLogMessage</c> 
            methods rather than overriding this method directly.
            </remarks>
            <seealso cref="M:Orleans.LogWriterBase.FormatLogMessage(System.DateTime,Orleans.OrleansLogger.Severity,Orleans.Logger.LoggerType,System.String,System.String,System.Net.IPEndPoint,System.Exception,System.Int32)"/>
            <seealso cref="M:Orleans.LogWriterBase.WriteLogMessage(System.String,Orleans.OrleansLogger.Severity)"/>
            <param name="severity">The severity of the message being traced.</param>
            <param name="loggerType">The type of logger the message is being traced through.</param>
            <param name="caller">The name of the logger tracing the message.</param>
            <param name="myIPEndPoint">The <see cref="T:System.Net.IPEndPoint"/> of the Orleans client/server if known. May be null.</param>
            <param name="message">The message to log.</param>
            <param name="exception">The exception to log. May be null.</param>
            <param name="eventCode">Numeric event code for this log entry. May be zero, meaning 'Unspecified'.</param>
        </member>
        <member name="M:Orleans.LogWriterBase.FormatLogMessage(System.DateTime,Orleans.OrleansLogger.Severity,Orleans.Logger.LoggerType,System.String,System.String,System.Net.IPEndPoint,System.Exception,System.Int32)">
            <summary>
            The method to call during logging to format the log info into a string ready for output.
            </summary>
            <param name="severity">The severity of the message being traced.</param>
            <param name="loggerType">The type of logger the message is being traced through.</param>
            <param name="caller">The name of the logger tracing the message.</param>
            <param name="myIPEndPoint">The <see cref="T:System.Net.IPEndPoint"/> of the Orleans client/server if known. May be null.</param>
            <param name="message">The message to log.</param>
            <param name="exception">The exception to log. May be null.</param>
            <param name="eventCode">Numeric event code for this log entry. May be zero, meaning 'Unspecified'.</param>
        </member>
        <member name="M:Orleans.LogWriterBase.WriteLogMessage(System.String,Orleans.OrleansLogger.Severity)">
            <summary>
            The method to call during logging to write the log message by this log.
            </summary>
            <param name="msg">Message string to be writter</param>
            <param name="severity">The severity level of this message</param>
        </member>
        <member name="T:Orleans.LogWriterToTrace">
            <summary>
            The Log Writer class is a convenient wrapper around the .Net Trace class.
            </summary>
        </member>
        <member name="T:Orleans.IFlushableLogConsumer">
            <summary>
            An interface used to consume log entries, when a Flush function is also supported. 
            Instances of a class implementing this should be added to <see cref="P:Orleans.Logger.LogConsumers"/> collection in order to retrieve events.
            </summary>
        </member>
        <member name="M:Orleans.IFlushableLogConsumer.Flush">
            <summary>Flush any pending log writes.</summary>
        </member>
        <member name="M:Orleans.LogWriterToTrace.WriteLogMessage(System.String,Orleans.OrleansLogger.Severity)">
            <summary>Write the log message for this log.</summary>
        </member>
        <member name="M:Orleans.LogWriterToTrace.Flush">
            <summary>Flush any pending output for this log.</summary>
        </member>
        <member name="T:Orleans.LogWriterToConsole">
            <summary>
            The Log Writer class is a wrapper around the .Net Console class.
            </summary>
        </member>
        <member name="M:Orleans.LogWriterToConsole.#ctor">
            <summary>
            Default constructor
            </summary>
        </member>
        <member name="M:Orleans.LogWriterToConsole.#ctor(System.Boolean,System.Boolean)">
            <summary>
            Constructor which allow some limited overides to the format of log message output,
            primarily intended for allow simpler Console screen output.
            </summary>
            <param name="useCompactConsoleOutput"></param>
            <param name="showMessageOnly"></param>
        </member>
        <member name="M:Orleans.LogWriterToConsole.FormatLogMessage(System.DateTime,Orleans.OrleansLogger.Severity,Orleans.Logger.LoggerType,System.String,System.String,System.Net.IPEndPoint,System.Exception,System.Int32)">
            <summary>Format the log message into the format used by this log.</summary>
        </member>
        <member name="M:Orleans.LogWriterToConsole.WriteLogMessage(System.String,Orleans.OrleansLogger.Severity)">
            <summary>Write the log message for this log.</summary>
        </member>
        <member name="T:Orleans.LogWriterToFile">
            <summary>
            This Log Writer class is an Orleans Log Consumer wrapper class which writes to a specified log file.
            </summary>
        </member>
        <member name="T:Orleans.ICloseableLogConsumer">
            <summary>
            An interface used to consume log entries, when a Close function is also supported. 
            Instances of a class implementing this should be added to <see cref="P:Orleans.Logger.LogConsumers"/> collection in order to retrieve events.
            </summary>
        </member>
        <member name="M:Orleans.ICloseableLogConsumer.Close">
            <summary>Close this log.</summary>
        </member>
        <member name="M:Orleans.LogWriterToFile.#ctor(System.IO.FileInfo)">
            <summary>
            Constructor, specifying the file to send output to.
            </summary>
            <param name="logFile">The log file to be written to.</param>
        </member>
        <member name="M:Orleans.LogWriterToFile.Close">
            <summary>Close this log file, after flushing any pending output.</summary>
        </member>
        <member name="M:Orleans.LogWriterToFile.WriteLogMessage(System.String,Orleans.OrleansLogger.Severity)">
            <summary>Write the log message for this log.</summary>
        </member>
        <member name="M:Orleans.LogWriterToFile.Flush">
            <summary>Flush any pending output for this log.</summary>
        </member>
        <member name="T:Orleans.SimpleLogWriterToFile">
            <summary>
            Just a simple log writer wrapper class with public WriteToLog method directly, without formatting.
            Mainly to be used from tests and external utilities.
            </summary>
        </member>
        <member name="M:Orleans.SimpleLogWriterToFile.#ctor(System.IO.FileInfo)">
            <summary>
            Constructor, specifying the file to send output to.
            </summary>
            <param name="logFile">The log file to be written to.</param>
        </member>
        <member name="M:Orleans.SimpleLogWriterToFile.WriteToLog(System.String,Orleans.OrleansLogger.Severity)">
            <summary>
            Output message directly to log file -- no formatting is performed.
            </summary>
            <param name="msg">Message text to be logged.</param>
            <param name="severity">Severity of this log message -- ignored.</param>
        </member>
        <member name="T:Orleans.GeneratedAttribute">
            <summary>
            For internal (run-time) use only.
            Base class of all the activation attributes 
            </summary>
        </member>
        <member name="M:Orleans.GeneratedAttribute.#ctor(System.String)">
            <summary>
            For internal (run-time) use only.
            </summary>
            <param name="forGrainType">type argument</param>
        </member>
        <member name="M:Orleans.GeneratedAttribute.#ctor">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="P:Orleans.GeneratedAttribute.ForGrainType">
            <summary>
            For internal (run-time) use only.
            Type for which this activation is implemented
            </summary>
        </member>
        <member name="T:Orleans.GrainStateAttribute">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="M:Orleans.GrainStateAttribute.#ctor(System.String)">
            <summary>
            For internal (run-time) use only.
            </summary>
            <param name="forGrainType">type argument</param>
        </member>
        <member name="T:Orleans.MethodInvokerAttribute">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="M:Orleans.MethodInvokerAttribute.#ctor(System.String,System.Int32)">
            <summary>
            For internal (run-time) use only.
            </summary>
            <param name="forGrainType">type argument</param>
        </member>
        <member name="T:Orleans.GrainReferenceAttribute">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="M:Orleans.GrainReferenceAttribute.#ctor(System.String)">
            <summary>
            For internal (run-time) use only.
            </summary>
            <param name="forGrainType">type argument</param>
        </member>
        <member name="T:Orleans.ActivationData">
            <summary>
            Maintains additional per-activation state that is required for Orleans internal operations.
            MUST lock this object for any concurrent access
            todo: compartmentalize by usage? e.g. using separate interfaces for data for catalog, journal, etc.
            </summary>
        </member>
        <member name="F:Orleans.ActivationData.Bucket">
            <summary>
            For internal (run-time) use only.
            Needs to be field for CompareExchange.
            </summary>
        </member>
        <member name="M:Orleans.ActivationData.IncrementInFlightCount">
            <summary>Increment the number of in-flight messages currently being processed.</summary>
        </member>
        <member name="M:Orleans.ActivationData.DecrementInFlightCount">
            <summary>Decrement the number of in-flight messages currently being processed.</summary>
        </member>
        <member name="M:Orleans.ActivationData.IncrementReceivingCount">
            <summary>Increment the number of messages currently in the prcess of being received.</summary>
        </member>
        <member name="M:Orleans.ActivationData.DecrementReceivingCount">
            <summary>Decrement the number of messages currently in the prcess of being received.</summary>
        </member>
        <member name="F:Orleans.ActivationData.waiting">
            <summary>
            For internal (run-time) use only.
            grouped by sending activation: responses first, then sorted by id
            </summary>
        </member>
        <member name="M:Orleans.ActivationData.EnqueueMessage(Orleans.Message)">
            <summary>
            Insert in a FIFO order
            </summary>
            <param name="message"></param>
        </member>
        <member name="M:Orleans.ActivationData.CheckOverloaded(Orleans.Logger)">
            <summary>
            Check whether this activation is overloaded. 
            Returns OrleansLimitExceededException if overloaded, otherwise <c>null</c>c>
            </summary>
            <param name="log">Logger to use for reporting any overflow condition</param>
            <returns>Returns OrleansLimitExceededException if overloaded, otherwise <c>null</c>c></returns>
        </member>
        <member name="M:Orleans.ActivationData.AddOnInactive(System.Action)">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="M:Orleans.ActivationData.ToString">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="M:Orleans.ActivationData.PrintWaitingQueue">
            <summary>
            Return string containing dump of the queue of waiting work items
            </summary>
            <returns></returns>
            <remarks>Note: Caller must be holding lock on this activation while calling this method.</remarks>
        </member>
        <member name="P:Orleans.ActivationData.GrainInstance">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="P:Orleans.ActivationData.StorageProvider">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="P:Orleans.ActivationData.Silo">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="P:Orleans.ActivationData.Grain">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="P:Orleans.ActivationData.State">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="P:Orleans.ActivationData.ForwardingAddress">
            <summary>
            If State == Invalid, this may contain a forwarding address for incoming messages
            </summary>
        </member>
        <member name="P:Orleans.ActivationData.Running">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="P:Orleans.ActivationData.InFlightCount">
            <summary>
            Number of messages that are actively being processed [as opposed to being in the Waiting queue].
            In most cases this will be 0 or 1, but for Reentrant grains can be >1.
            </summary>
        </member>
        <member name="P:Orleans.ActivationData.ReceivingCount">
            <summary>
            Number of messages that are being received [as opposed to being in the scheduler queue or actively processed].
            </summary>
        </member>
        <member name="P:Orleans.ActivationData.OnInactive">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="P:Orleans.ActivationData.IsGcCandidate">
            <summary>
            Whether this activation is eligable for garbage collection.
            </summary>
        </member>
        <member name="P:Orleans.ActivationData.Shutdown">
            <summary>
            If non-null, this activation is in a shutdown state and should
            not accept new transactions. Resolve when all transactions
            are committed or aborted.
            </summary>
        </member>
        <member name="P:Orleans.ActivationData.Name">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="T:Orleans.IGrainMethodInvoker">
            <summary>
            This interface is for internal use only.
            An implementation of this interface is generated for every grain interface as part of the client-side code generation.
            </summary>
        </member>
        <member name="M:Orleans.IGrainMethodInvoker.Invoke(Orleans.IAddressable,System.Int32,System.Int32,System.Object[])">
            <summary>
            This method is for internal use only.
            Invoke a grain method.
            Invoker classes in generated code implement this method to provide a method call jump-table to map invoke data to a strongly typed call to the correct method on the correct interface.
            </summary>
            <param name="grain">Reference to the grain to be invoked.</param>
            <param name="interfaceId">Interface id of the method to be called.</param>
            <param name="methodId">Method id of the method to be called.</param>
            <param name="arguments">Arguments to be passed to the method being invoked.</param>
            <returns>Value promise for the result of the method invoke.</returns>
        </member>
        <member name="P:Orleans.IGrainMethodInvoker.InterfaceId">
            <summary> The interface id that this invoker supports. </summary>
        </member>
        <member name="M:Orleans.ActivationData.ExtensionInvoker.TryAddExtension(Orleans.IGrainExtensionMethodInvoker,Orleans.IGrainExtension)">
            <summary>
            Try to add an extension for the specific interface ID.
            Fail and return false if there is already an extension for that interface ID.
            Note that if an extension invoker handles multiple interface IDs, it can only be associated
            with one of those IDs when added, and so only conflicts on that one ID will be detected and prevented.
            </summary>
            <param name="interfaceId"></param>
            <param name="invoker"></param>
            <param name="handler"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ActivationData.ExtensionInvoker.Remove(Orleans.IGrainExtension)">
            <summary>
            Removes all extensions for the specified interface id.
            Returns true if the chained invoker no longer has any extensions and may be safely retired.
            </summary>
            <param name="interfaceId"></param>
            <returns>true if the chained invoker is now empty, false otherwise</returns>
        </member>
        <member name="M:Orleans.ActivationData.ExtensionInvoker.Invoke(Orleans.IAddressable,System.Int32,System.Int32,System.Object[])">
            <summary>
            Invokes the appropriate grain or extension method for the request interface ID and method ID.
            First each extension invoker is tried; if no extension handles the request, then the base
            invoker is used to handle the request.
            The base invoker will throw an appropriate exception if the request is not recognized.
            </summary>
            <param name="grain"></param>
            <param name="interfaceId"></param>
            <param name="methodId"></param>
            <param name="arguments"></param>
            <returns></returns>
        </member>
        <member name="T:Orleans.ActivationState">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="F:Orleans.ActivationState.Create">
            <summary>
            For internal (run-time) use only.
            being created
            </summary>
        </member>
        <member name="F:Orleans.ActivationState.Inactive">
            <summary>
            For internal (run-time) use only.
            not in an active task
            </summary>
        </member>
        <member name="F:Orleans.ActivationState.Invalid">
            <summary>
            Tombstone for activation that was unable to be properly created
            </summary>
        </member>
        <member name="T:Orleans.IGrainExtensionMethodInvoker">
            <summary>
            This interface is for internal use only.
            An implementation of this interface is generated for every grain extension as part of the client-side code generation.
            </summary>
        </member>
        <member name="M:Orleans.IGrainExtensionMethodInvoker.Invoke(Orleans.IGrainExtension,System.Int32,System.Int32,System.Object[])">
            <summary>
            This method is for internal use only.
            Invoke a grain extension method.
            </summary>
            <param name="extension">Reference to the extension to be invoked.</param>
            <param name="interfaceId">Interface id of the method to be called.</param>
            <param name="methodId">Method id of the method to be called.</param>
            <param name="arguments">Arguments to be passed to the method being invoked.</param>
            <returns>Value promise for the result of the method invoke.</returns>
        </member>
        <member name="T:Orleans.IGrainObserver">
            <summary>
            The IGrainObserver interface is a marker interface for observers.
            Observers are used to receive notifications from grains; that is, they represent the subscriber side of a 
            publisher/subscriber interface.
            Note that all observer methods should be void, since they do not return a value to the observed grain.
            </summary>
        </member>
        <member name="T:Orleans.GrainExtensions">
            <summary>
            Extension methods for grains.
            </summary>
        </member>
        <member name="M:Orleans.GrainExtensions.AsReference(Orleans.IAddressable)">
            <summary>
            Converts this grain to a <c>GrainReference</c>
            </summary>
            <param name="grain">The grain to convert.</param>
            <returns>A <c>GrainReference</c> for this grain.</returns>
        </member>
        <member name="M:Orleans.GrainExtensions.GetPrimaryKeyLong(Orleans.IGrain,System.String@)">
            <summary>
            Returns the long representation of a grain primary key.
            </summary>
            <param name="grain">The grain to find the primary key for.</param>
            <param name="keyExt">The output paramater to return the extended key part of the grain primary key, if extened primary key was provided for that grain.</param>
            <returns>A long representing the primary key for this grain.</returns>
        </member>
        <member name="M:Orleans.GrainExtensions.GetPrimaryKeyLong(Orleans.IGrain)">
            <summary>
            Returns the long representation of a grain primary key.
            </summary>
            <param name="grain">The grain to find the primary key for.</param>
            <returns>A long representing the primary key for this grain.</returns>
        </member>
        <member name="M:Orleans.GrainExtensions.GetPrimaryKey(Orleans.IGrain,System.String@)">
            <summary>
            Returns the Guid representation of a grain primary key.
            </summary>
            <param name="grain">The grain to find the primary key for.</param>
            <param name="keyExt">The output paramater to return the extended key part of the grain primary key, if extened primary key was provided for that grain.</param>
            <returns>A Guid representing the primary key for this grain.</returns>
        </member>
        <member name="M:Orleans.GrainExtensions.GetPrimaryKey(Orleans.IGrain)">
            <summary>
            Returns the Guid representation of a grain primary key.
            </summary>
            <param name="grain">The grain to find the primary key for.</param>
            <returns>A Guid representing the primary key for this grain.</returns>
        </member>
        <member name="T:Orleans.Messaging.GatewayManager">
            <summary>
            The GatewayManager class holds the list of known gateways, as well as maintaining the list of "dead" gateways.
            
            The known list can come from one of two places: the full list may appear in the client configuration object, or 
            the config object may contain an IGatewayListProvider delegate. If both appear, then the delegate takes priority.
            </summary>
        </member>
        <member name="M:Orleans.Messaging.GatewayManager.GetLiveGateway">
            <summary>
            Selects a gateway to use for a new bucket. 
            
            Note that if a list provider delegate was given, the delegate is invoked every time this method is called. 
            This method performs caching to avoid hammering the ultimate data source.
            
            This implementation does a simple round robin selection. It assumes that the gateway list from the provider
            is in the same order every time.
            </summary>
            <returns></returns>
        </member>
        <member name="M:Orleans.Messaging.ProxiedMessageCenter.#ctor(Orleans.ClientConfiguration,System.Net.IPAddress,System.Int32,System.Guid,Orleans.Messaging.IGatewayListProvider)">
             <summary>
             For internal use only.
             </summary>
             <param name="config"></param>
            
        </member>
        <member name="M:Orleans.Messaging.ProxiedMessageCenter.Start">
            <summary>
            For internal use only.
            </summary>
        </member>
        <member name="M:Orleans.Messaging.ProxiedMessageCenter.PrepareToStop">
            <summary>
            For internal use only.
            </summary>
        </member>
        <member name="M:Orleans.Messaging.ProxiedMessageCenter.Stop">
            <summary>
            For internal use only.
            </summary>
        </member>
        <member name="M:Orleans.Messaging.ProxiedMessageCenter.SendMessage(Orleans.Message)">
            <summary>
            For internal use only.
            </summary>
            <param name="msg"></param>
        </member>
        <member name="M:Orleans.Messaging.ProxiedMessageCenter.WaitMessage(Orleans.Message.Categories,System.Threading.CancellationToken)">
            <summary>
            For internal use only.
            </summary>
            <param name="type"></param>
            <param name="ct"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.Messaging.ProxiedMessageCenter.Disconnect">
            <summary>
            For testing use only
            </summary>
        </member>
        <member name="M:Orleans.Messaging.ProxiedMessageCenter.Reconnect">
            <summary>
            For testing use only.
            </summary>
        </member>
        <member name="P:Orleans.Messaging.ProxiedMessageCenter.IsProxying">
            <summary>
            For internal use only.
            </summary>
        </member>
        <member name="P:Orleans.Messaging.ProxiedMessageCenter.SendQueueLength">
            <summary>
            For internal use only.
            </summary>
        </member>
        <member name="P:Orleans.Messaging.ProxiedMessageCenter.ReceiveQueueLength">
            <summary>
            For internal use only.
            </summary>
        </member>
        <member name="M:Orleans.SocketManager.GetAcceptingSocketForEndpoint(System.Net.IPEndPoint)">
            <summary>
            Creates a socket bound to an address for use accepting connections.
            This is for use by client gateways and other acceptors.
            </summary>
            <param name="address">The address to bind to.</param>
            <returns>The new socket, appropriately bound.</returns>
        </member>
        <member name="T:Orleans.ObserverSubscriptionManager`1">
            <summary>
            The ObserverSubscriptionManager class is a helper class for grains that support observers.
            It provides methods for tracking subscribing observers and for sending notifications.
            </summary>
            <typeparam name="T">The observer interface type to be managed.</typeparam>
        </member>
        <member name="F:Orleans.ObserverSubscriptionManager`1._observers">
            <summary>
            The set of currently-subscribed observers.
            This is implemented as a dictionary keyed by GrainID so that if the same obsever subscribes multiple times,
            it will still only get invoked once per notification.
            </summary>
        </member>
        <member name="M:Orleans.ObserverSubscriptionManager`1.#ctor">
            <summary>
            Constructs an empty subscription manager.
            </summary>
        </member>
        <member name="M:Orleans.ObserverSubscriptionManager`1.Subscribe(`0)">
            <summary>
            Records a new subscribing observer.
            </summary>
            <param name="observer">The new subscriber.</param>
            <returns>A promise that resolves when the subscriber is added.
            <para>This promise will be broken if the observer is already a subscriber.
            In this case, the existing subscription is unaffected.</para></returns>
        </member>
        <member name="M:Orleans.ObserverSubscriptionManager`1.Unsubscribe(`0)">
            <summary>
            Removes a (former) subscriber.
            </summary>
            <param name="observer">The unsubscribing observer.</param>
            <returns>A promise that resolves when the subscriber is removed.
            This promise will be broken if the observer is not a subscriber.</returns>
        </member>
        <member name="M:Orleans.ObserverSubscriptionManager`1.Clear">
            <summary>
            Removes all subscriptions.
            </summary>
        </member>
        <member name="M:Orleans.ObserverSubscriptionManager`1.Notify(System.Action{`0})">
            <summary>
            Sends a notification to all subscribers.
            </summary>
            <param name="notification">An action that sends the notification by invoking the proper method on the provided subscriber.
            This action is called once for each current subscriber.</param>
        </member>
        <member name="P:Orleans.ObserverSubscriptionManager`1.Count">
            <summary>
            Number of subscribers currently registered
            </summary>
        </member>
        <member name="M:GrainClientGenerator.GrainInterfaceData.GetServiceIntefaceMethodsImpl(System.Type,System.Type,System.Collections.Generic.List{System.Reflection.MethodInfo})">
            <summary>
            Recurses through interface graph accumulating methods
            </summary>
            <param name="grainType">Grain type</param>
            <param name="serviceType">Service interface type</param>
            <param name="methodInfos">Accumulated </param>
        </member>
        <member name="M:GrainClientGenerator.GrainInterfaceData.IsReadOnly(System.Reflection.MethodInfo)">
            <summary>
            Whether method is read-only, i.e. does not modify grain state.
            Either a property getter, or a method marked with [ReadOnly].
            </summary>
            <param name="info"></param>
            <returns></returns>
        </member>
        <member name="M:GrainClientGenerator.GrainInterfaceData.GetStaticPlacementPropertyByName``1(System.Object)">
            <summary>
            Evaluate a static property/method invocation
            </summary>
            <typeparam name="T">Type which has static factory properties/methods returning type T</typeparam>
            <param name="param">"property name" for static field/property, or new object[] {"method name", ..params..} for static method</param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ActivationId.#ctor">
            <summary>
            For internal use only
            Only used in Json serialization
            DO NOT USE TO CREATE A RANDOM ACTIVATION ID
            Use ActivationId.NewId to create new activation IDs.
            </summary>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.#ctor">
            <summary>
            
            </summary>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.#ctor(Orleans.BufferPool)">
            <summary>
            
            </summary>
            <param Name="size"></param>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.Append(System.Byte[])">
            <summary>
            Append a byte array to the byte array.
            Note that this assumes that the array passed in is now owned by the ByteArrayBuilder, and will not be modified.
            </summary>
            <param Name="array"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.Append(Orleans.ByteArrayBuilder)">
            <summary>
            
            </summary>
            <param name="b"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.Append(System.Collections.Generic.List{System.ArraySegment{System.Byte}})">
            <summary>
            Append a list of byte array segments to the byte array.
            Note that this assumes that the data passed in is now owned by the ByteArrayBuilder, and will not be modified.
            </summary>
            <param name="b"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.Append(System.Int16[])">
            <summary>
            
            </summary>
            <param name="array"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.Append(System.Int32[])">
            <summary>
            
            </summary>
            <param name="array"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.Append(System.Int64[])">
            <summary>
            
            </summary>
            <param name="array"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.Append(System.UInt16[])">
            <summary>
            
            </summary>
            <param name="array"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.Append(System.UInt32[])">
            <summary>
            
            </summary>
            <param name="array"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.Append(System.UInt64[])">
            <summary>
            
            </summary>
            <param name="array"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.Append(System.SByte[])">
            <summary>
            
            </summary>
            <param name="array"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.Append(System.Char[])">
            <summary>
            
            </summary>
            <param name="array"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.Append(System.Boolean[])">
            <summary>
            
            </summary>
            <param name="array"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.Append(System.Single[])">
            <summary>
            
            </summary>
            <param name="array"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.Append(System.Double[])">
            <summary>
            
            </summary>
            <param name="array"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.Append(System.Char)">
            <summary>
            Appends an ASCII character to the byte array.
            This method will throw an exception if called with a non-ASCII character.
            </summary>
            <param Name="c"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.ByteArrayBuilder.Append(System.String)">
            <summary>
            
            </summary>
            <param Name="s"></param>
            <returns></returns>
        </member>
        <member name="T:Orleans.ClientConfiguration">
            <summary>
            Orleans client configuration parameters.
            </summary>
        </member>
        <member name="T:Orleans.MessagingConfiguration">
            <summary>
            Messaging configuration that are common to client and silo.
            </summary>
        </member>
        <member name="T:Orleans.IMessagingConfiguration">
            <summary>
            Specifies global messaging configuration that are common to client and silo.
            </summary>
        </member>
        <member name="P:Orleans.IMessagingConfiguration.ResponseTimeout">
            <summary>
            The ResponseTimeout attribute specifies the default timeout before a request is assumed to have failed.
            </summary>
        </member>
        <member name="P:Orleans.IMessagingConfiguration.MaxResendCount">
            <summary>
            The MaxResendCount attribute specifies the maximal number of resends of the same message.
            </summary>
        </member>
        <member name="P:Orleans.IMessagingConfiguration.ResendOnTimeout">
            <summary>
            The ResendOnTimeout attribute specifies whether the message should be automaticaly resend by the runtime when it times out on the sender.
            Default is false.
            </summary>
        </member>
        <member name="P:Orleans.IMessagingConfiguration.MaxSocketAge">
            <summary>
            The MaxSocketAge attribute specifies how long to keep an open socket before it is closed.
            Default is TimeSpan.MaxValue (never close sockets automatically, unles they were broken).
            </summary>
        </member>
        <member name="P:Orleans.IMessagingConfiguration.DropExpiredMessages">
            <summary>
            The DropExpiredMessages attribute specifies whether the message should be dropped if it has expired, that is if it was not delivered 
            to the destination before it has timed out on the sender.
            Default is true.
            </summary>
        </member>
        <member name="P:Orleans.IMessagingConfiguration.SiloSenderQueues">
            <summary>
            The SiloSenderQueues attribute specifies the number of parallel queues and attendant threads used by the silo to send outbound
            messages (requests, responses, and notifications) to other silos.
            If this attribute is not specified, then System.Environment.ProcessorCount is used.
            </summary>
        </member>
        <member name="P:Orleans.IMessagingConfiguration.GatewaySenderQueues">
            <summary>
            The GatewaySenderQueues attribute specifies the number of parallel queues and attendant threads used by the silo Gateway to send outbound
             messages (requests, responses, and notifications) to clients that are connected to it.
             If this attribute is not specified, then System.Environment.ProcessorCount is used.
            </summary>
        </member>
        <member name="P:Orleans.IMessagingConfiguration.ClientSenderBuckets">
            <summary>
             The ClientSenderBuckets attribute specifies the total number of grain buckets used by the client in client-to-gateway communication
             protocol. In this protocol, grains are mapped to buckets and buckets are mapped to gateway connections, in order to enable stickiness
             of grain to gateway (messages to the same grain go to the same gateway, while evenly spreading grains across gateways).
             This number should be about 10 to 100 times larger than the expected number of gateway connections.
             If this attribute is not specified, then Math.Pow(2, 13) is used.
            </summary>
        </member>
        <member name="P:Orleans.IMessagingConfiguration.UseStandardSerializer">
            <summary>
            The UseStandardSerializer attribute, if provided and set to "true", forces the use of the standard .NET serializer instead
            of the custom Orleans serializer.
            This parameter is intended for use only for testing and troubleshooting.
            In production, the custom Orleans serializer should always be used because it performs significantly better.
            </summary>
        </member>
        <member name="P:Orleans.IMessagingConfiguration.BufferPoolBufferSize">
            <summary>
            The size of a buffer in the messaging buffer pool.
            </summary>
        </member>
        <member name="P:Orleans.IMessagingConfiguration.BufferPoolMaxSize">
            <summary>
            The maximum size of the messaging buffer pool.
            </summary>
        </member>
        <member name="P:Orleans.IMessagingConfiguration.BufferPoolPreallocationSize">
            <summary>
            The initial size of the messaging buffer pool that is pre-allocated.
            </summary>
        </member>
        <member name="P:Orleans.IMessagingConfiguration.UseMessageBatching">
            <summary>
            Whether to use automatic batching of messages. Default is false.
            </summary>
        </member>
        <member name="P:Orleans.IMessagingConfiguration.MaxMessageBatchingSize">
            <summary>
            The maximum batch size for automatic batching of messages, when message batching is used.
            </summary>
        </member>
        <member name="P:Orleans.MessagingConfiguration.MaxForwardCount">
            <summary>
            The MaxForwardCount attribute specifies the maximal number of times a message is being forwared from one silo to another.
            Forwarding is used internally by the tuntime as a recovery mechanism when silos fail and the membership is unstable.
            In such times the messages might not be routed correctly to destination, and runtime attempts to forward such messages a number of times before rejecting them.
            </summary>
        </member>
        <member name="T:Orleans.ITraceConfiguration">
            <summary>
            The TracingConfiguration type contains various tracing-related configuration parameters.
            For production use, the default value of these parameters should be fine.
            </summary>
        </member>
        <member name="P:Orleans.ITraceConfiguration.DefaultTraceLevel">
            <summary>
            The DefaultTraceLevel attribute specifies the default tracing level for all Orleans loggers, unless overridden by
            a specific TraceLevelOverride element.
            The default level is Info if this attribute does not appear.
            </summary>
        </member>
        <member name="P:Orleans.ITraceConfiguration.TraceFileName">
            <summary>
            The TraceFileName attribute specifies the name of a file that trace output should be written to.
            </summary>
        </member>
        <member name="P:Orleans.ITraceConfiguration.TraceFilePattern">
            <summary>
            The TraceFilePattern attribute specifies the pattern name of a file that trace output should be written to.
            </summary>
        </member>
        <member name="P:Orleans.ITraceConfiguration.TraceLevelOverrides">
            <summary>
            The TraceLevelOverride element provides a mechanism to allow the tracing level to be set differently for different
            parts of the Orleans system.
            The tracing level for a logger is set based on a prefix match on the logger's name.
            TraceLevelOverrides are applied in length order; that is, the override with the longest matching
            LogPrefix takes precedence and specifies the tracing level for all matching loggers.
            </summary>
        </member>
        <member name="P:Orleans.ITraceConfiguration.TraceToConsole">
            <summary>
            The TraceToConsole attribute specifies whether trace output should be written to the console.
            The default is not to write trace data to the console.
            </summary>
        </member>
        <member name="P:Orleans.ITraceConfiguration.WriteMessagingTraces">
            <summary>
            The WriteMessagingTraces attribute specifies whether to write details message traces.
            This should be used only in development mode and never in production.
            </summary>
        </member>
        <member name="P:Orleans.ITraceConfiguration.LargeMessageWarningThreshold">
            <summary>
            The LargeMessageWarningThreshold attribute specifies when to generate a warning trace message for large messages.
            </summary>
        </member>
        <member name="P:Orleans.ITraceConfiguration.PropagateActivityId">
            <summary>
            The PropagateActivityId attribute specifies whether the value of Tracing.CorrelationManager.ActivityId should be propagated into grain calls, to support E2E tracing.
            The default is not to propagate ActivityId.
            </summary>
        </member>
        <member name="P:Orleans.ITraceConfiguration.BulkMessageLimit">
            <summary>
            The BulkMessageLimit attribute specifies how to bulk (aggregate) trace messages with identical erro code.
            </summary>
        </member>
        <member name="T:Orleans.IStatisticsConfiguration">
            <summary>
            Statistics Configuration that are common to client and silo.
            </summary>
        </member>
        <member name="T:Orleans.ILimitsConfiguration">
            <summary>
            Configuration for system Limits values
            </summary>
        </member>
        <member name="M:Orleans.ILimitsConfiguration.GetLimit(System.String)">
            <summary> Get a specified Limits value. </summary>
            <param name="name">Name of the Limit valeu to find.</param>
            <returns>Details of the Limit value.</returns>
        </member>
        <member name="P:Orleans.ILimitsConfiguration.LimitValues">
            <summary>
            Currently set Limits values.
            </summary>
        </member>
        <member name="F:Orleans.ClientConfiguration.ClientName">
            <summary>
            The name of this client.
            </summary>
        </member>
        <member name="M:Orleans.ClientConfiguration.#ctor">
            <summary>
            </summary>
        </member>
        <member name="M:Orleans.ClientConfiguration.GetLimit(System.String)">
            <summary>
            </summary>
        </member>
        <member name="M:Orleans.ClientConfiguration.LoadFromFile(System.String)">
            <summary>
            </summary>
        </member>
        <member name="M:Orleans.ClientConfiguration.StandardLoad">
            <summary>
            Loads the configuration from the standard paths, looking up the directory hierarchy
            </summary>
            <returns>Client configuration data if a configuration file was found.</returns>
            <exception cref="T:System.IO.FileNotFoundException">Thrown if no configuration file could be found in any of the standard locations</exception>
        </member>
        <member name="P:Orleans.ClientConfiguration.Gateways">
            <summary>
            The list fo the gateways to use.
            Each GatewayNode element specifies an outside grain client gateway node.
            If outside (non-Orleans) clients are to connect to the Orleans system, then at least one gateway node must be specified.
            Additional gateway nodes may be specified if desired, and will add some failure resilience and scalability.
            If multiple gateways are specified, then each client will select one from the list at random.
            </summary>
        </member>
        <member name="P:Orleans.ClientConfiguration.PreferedGatewayIndex">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.ClientConfiguration.GatewayProvider">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.ClientConfiguration.DeploymentId">
            <summary>
            Specifies a unique identifier of this deployment.
            If the silos are deployed on Azure (run as workers roles), deployment id is set automatically by Azure runtime, 
            accessible to the role via RoleEnvironment.DeploymentId static variable and is passed to the silo automatically by the role via config. 
            So if the silos are run as Azure roles this variable should not be specified in the OrleansConmfiguration.xml (it will be overwritten if specified).
            If the silos are deployed on the cluster and not as Azure roles, this variable should be set by a deployment script in the OrleansConmfiguration.xml file.
            </summary>
        </member>
        <member name="P:Orleans.ClientConfiguration.DataConnectionString">
            <summary>
            Specifies the connection string for azure storage account.
            If the silos are deployed on Azure (run as workers roles), DataConnectionString may be specified via RoleEnvironment.GetConfigurationSettingValue("DataConnectionString");
            In such a case it is taken from there and passed to the silo automatically by the role via config.
            So if the silos are run as Azure roles and this config is specified via RoleEnvironment, 
            this variable should not be specified in the OrleansConmfiguration.xml (it will be overwritten if specified).
            If the silos are deployed on the cluster and not as Azure roles,  this variable should be set in the OrleansConmfiguration.xml file.
            If not set at all, DevelopmentStorageAccount will be used.
            </summary>
        </member>
        <member name="P:Orleans.ClientConfiguration.PreferredFamily">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.ClientConfiguration.NetInterface">
            <summary>
            The Interface attribute specifies the name of the network interface to use to work out an IP address for this machine.
            </summary>
        </member>
        <member name="P:Orleans.ClientConfiguration.Port">
            <summary>
            The Port attribute specifies the specific listen port for this client machine.
            If value is zero, then a random machine-assigned port number will be used.
            </summary>
        </member>
        <member name="P:Orleans.ClientConfiguration.DNSHostName">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.ClientConfiguration.GatewayListRefreshPeriod">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.ClientConfiguration.UseAzureStorage">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.ClientConfiguration.ProviderConfigurations">
            <summary>
            </summary>
        </member>
        <member name="T:Orleans.ClientConfiguration.GatewayProviderType">
            <summary>
            Specifies the type of the gateway provider.
            </summary>
        </member>
        <member name="T:Orleans.ConfigUtilities">
            <summary>
            Utilities class for handling configuration.
            </summary>
        </member>
        <member name="M:Orleans.ConfigUtilities.PrintDataConnectionInfo(System.String)">
            <summary>
            Prints the the Azure storage DataConnection string, without disclosing the AccountKey.
            </summary>
            <param name="dataConnectionString">The DataConnection string to print.</param>
            <returns>The string representation of the Azure storage DataConnection string.</returns>
        </member>
        <member name="T:Orleans.GlobalConfiguration">
            <summary>
            Data object holding Silo global configuration parameters.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.SeedNodes">
            <summary>
            SeedNodes are only used in local development setting with LivenessProviderType.MembershipTableGrain
            SeedNodes are never used in production.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.Subnet">
            <summary>
            The subnet on which the silos run. 
            This option should only be used when running on multi-homed cluster. It should not be used when running in Azure.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.PrimaryNodeIsRequired">
            <summary>
            Determines if primary node is required to be configured as a seed node.
            True if LivenessType is set to LivenessProviderType.MembershipTableGrain, faklse otherwise.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.LivenessType">
            <summary>
            The LivenessType attribute controls the liveness method used for silo reliability.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.LivenessEnabled">
            <summary>
            Global switch to disbale silo liveness protocol (should be used only for testing).
            The LivenessEnabled attribute, if provided and set to "false", suppresses liveness enforcement.
            If a silo is suspected to be dead, but this attribute is set to "false", the suspicions will not propagated to the system and enforced,
            This parameter is intended for use only for testing and troubleshooting.
            In production, liveness should always be enabled.
            Default is true (eanabled)
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.ProbeTimeout">
            <summary>
            The number of seconds to periodically probe other silos for their liveness or for the silo to send "I am alive" heartbeat  messages about itself.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.TableRefreshTimeout">
            <summary>
            The number of seconds to periodically fetch updates from the membership table.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.DeathVoteExpirationTimeout">
            <summary>
            Expiration time in seconds for death vote in the membership table.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.IAmAliveTablePublishTimeout">
            <summary>
            The number of seconds to periodically write in the membership table that this silo is alive. Used ony for diagnostics.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.MaxJoinAttemptTime">
            <summary>
            The number of seconds to attempt to join a cluster of silos before giving up.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.ExpectedClusterSize">
            <summary>
            The expected size of a cluster. Need not be very accurate, can be an overestimate.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.NumMissedProbesLimit">
            <summary>
            The number of missed "I am alive" heartbeat messages from a silo or number of un-replied probes that lead to suspecting this silo as dead.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.NumProbedSilos">
            <summary>
            The number of silos each silo probes for liveness.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.NumVotesForDeathDeclaration">
            <summary>
            The number of non-expired votes that are needed to declare some silo as dead (should be at most NumMissedProbesLimit)
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.NumMissedTableIAmAliveLimit">
            <summary>
            The number of missed "I am alive" updates  in the table from a silo that causes warning to be logged. Does not impact the liveness protocol.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.UseLivenessGossip">
            <summary>
            Whether to use the gossip optimization to speed up spreading liveness information.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.DeploymentId">
            <summary>
            Azure DeploymentId.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.DataConnectionString">
            <summary>
            Azure DataConnectionString for storage connection.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.CollectionAgeLimit">
            <summary>
            The minimal idleness period (idle grain activation age) that makes activations eligiable for activation garbage collection.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.CacheSize">
            <summary>
            The CacheSize attribute specifies the maximum number of grains to cache directory information for.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.InitialCacheTTL">
            <summary>
            The InitialTTL attribute specifies the initial (minimum) time, in seconds, to keep a cache entry before revalidating.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.MaximumCacheTTL">
            <summary>
            The MaximumTTL attribute specifies the maximum time, in seconds, to keep a cache entry before revalidating.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.CacheTTLExtensionFactor">
            <summary>
            The TTLExtensionFactor attribute specifies the factor by which cache entry TTLs should be extended when they are found to be stable.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.DirectoryCachingStrategy">
            <summary>
            The DirectoryCachingStrategy attribute specifies the caching strategy to use.
            The options are None, which means don't cache directory entries locally;
            LRU, which indicates that a standard fixed-size least recently used strategy should be used; and
            Adaptive, which indicates that an adaptive strategy with a fixed maximum size should be used.
            The Adaptive strategy is used by default.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.ReminderServiceType">
            <summary>
            The ReminderServiceType attribute controls the type of the reminder service implementation used by silos.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.ProviderConfigurations">
            <summary>
            Configuration for various runtime providers.
            </summary>
        </member>
        <member name="P:Orleans.GlobalConfiguration.DirectoryLazyDeregistrationDelay">
            <summary>
            The time span between when we have added an entry for an activation to the grain directory and when we are allowed
            to conditionally remove that entry. 
            Conditional deregistration is used for lazy clean-up of activations whose prompt deregistration failed for some reason (e.g., message failure).
            This should always be at least one minute, since we compare the times on the directory partition, so message delays and clcks skues have
            to be allowed.
            </summary>
        </member>
        <member name="T:Orleans.GlobalConfiguration.LivenessProviderType">
            <summary>
            Liveness configuration that controls the type of the liveness protocol that silo use for membership.
            </summary>
        </member>
        <member name="F:Orleans.GlobalConfiguration.LivenessProviderType.MembershipTableGrain">
            <summary>Grain is used to store membership information. 
            This option is not reliable and thus should only be used in local development setting.</summary>
        </member>
        <member name="F:Orleans.GlobalConfiguration.LivenessProviderType.AzureTable">
            <summary>AzureTable is used to store membership information. 
            This option should be used in production.</summary>
        </member>
        <member name="T:Orleans.GlobalConfiguration.ReminderServiceProviderType">
            <summary>
            Reminders configuration that controls the type of the protocol that silo use to implement Reminders.
            </summary>
        </member>
        <member name="F:Orleans.GlobalConfiguration.ReminderServiceProviderType.None">
            <summary>No reminders.</summary>
        </member>
        <member name="F:Orleans.GlobalConfiguration.ReminderServiceProviderType.ReminderTableGrain">
            <summary>Grain is used to store reminders information. 
            This option is not reliable and thus should only be used in local development setting.</summary>
        </member>
        <member name="F:Orleans.GlobalConfiguration.ReminderServiceProviderType.AzureTable">
            <summary>AzureTable is used to store reminders information. 
            This option should be used in production.</summary>
        </member>
        <member name="T:Orleans.GlobalConfiguration.DirectoryCachingStrategyType">
            <summary>
            Configuration type that controls the type of the grain directory caching algorithm that silo use.
            </summary>
        </member>
        <member name="F:Orleans.GlobalConfiguration.DirectoryCachingStrategyType.None">
            <summary>Don't cache.</summary>
        </member>
        <member name="F:Orleans.GlobalConfiguration.DirectoryCachingStrategyType.LRU">
            <summary>Standard fixed-size LRU.</summary>
        </member>
        <member name="F:Orleans.GlobalConfiguration.DirectoryCachingStrategyType.Adaptive">
            <summary>Adaptive caching with fixed maximum size and refresh. This option should be used in production.</summary>
        </member>
        <member name="T:Orleans.LimitValue">
            <summary>
            Data class encapsulating details of a particular system limit.
            </summary>
        </member>
        <member name="P:Orleans.LimitValue.Name">
            <summary>
            Name of this Limit value
            </summary>
        </member>
        <member name="P:Orleans.LimitValue.SoftLimitThreshold">
            <summary>
            'Soft" limit threshold value for this Limit, after which Warnings will start to be generated
            </summary>
        </member>
        <member name="P:Orleans.LimitValue.HardLimitThreshold">
            <summary>
            'Hard' limit threshold value, after which Errors will start to be generated and action take (for example, rejecting new request messages, etc) 
            to actively reduce the limit value back to within thresholds.
            </summary>
        </member>
        <member name="T:Orleans.ProviderCategoryConfiguration">
            <summary>
            Provider categoty configuration.
            </summary>
        </member>
        <member name="T:Orleans.ProviderConfiguration">
            <summary>
            Configuration for a particular provider instance.
            </summary>
        </member>
        <member name="P:Orleans.ProviderConfiguration.Properties">
            <summary>
            Properties of this provider.
            </summary>
        </member>
        <member name="P:Orleans.ProviderConfiguration.Children">
            <summary>
            Children providers of this provider. Used by hierarchical providers.
            </summary>
        </member>
        <member name="T:Orleans.NodeConfiguration">
            <summary>
            Individual node-specific silo configuration parameters.
            </summary>
        </member>
        <member name="M:Orleans.NodeConfiguration.GetLimit(System.String)">
            <summary>
            Returns the value of silo limit.
            </summary>
            <param name="limitName">The name of the limit return.</param>
            <returns>Limit value</returns>
        </member>
        <member name="P:Orleans.NodeConfiguration.SiloName">
            <summary>
            The name of this silo.
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.DNSHostName">
            <summary>
            The DNS host name of this silo.
            This is a true host name, no IP address. It is NOT settable, equals Dns.GetHostName().
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.HostNameOrIPAddress">
            <summary>
            The host name or IP address of this silo.
            This is a configurable IP address or Hostname.
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.Port">
            <summary>
            The port this silo uses for silo-to-silo communication.
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.Generation">
            <summary>
            The epoch generation number for this silo.
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.Endpoint">
            <summary>
            The IPEndPoint this silo uses for silo-to-silo communication.
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.AddressType">
            <summary>
            The AddressFamilyof the IP address of this silo.
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.ProxyGatewayEndpoint">
            <summary>
            The IPEndPoint this silo uses for (gateway) silo-to-client communication.
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.IsPrimaryNode">
            <summary>
            Whether this is a primary silo (applies for dev settings only).
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.IsSeedNode">
            <summary>
            Whether this is one of the seed silos (applies for dev settings only).
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.IsGatewayNode">
            <summary>
            Whether this is silo is a proxying gateway silo.
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.MaxActiveThreads">
            <summary>
            The MaxActiveThreads attribute specifies the maximum number of simultaneous active threads the scheduler will allow.
            Generally this number should be roughly equal to the number of cores on the node.
            Using a value of 0 will look at System.Environment.ProcessorCount to decide the number instead.
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.DelayWarningThreshold">
            <summary>
            The DelayWarningThreshold attribute specifies the work item queuing delay threshold, at which a warning log message is written.
            That is, if the delay between enqueuing the work item and executing the work item is greater than DelayWarningThreshold, a warning log is written.
            The default value is 10 seconds.
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.ActivationSchedulingQuantum">
            <summary>
            ActivationSchedulingQuantum is a soft time limit on the duration of activation macro-turn (a number of micro-turns). 
            If a activation was running its micro-turns longer than this, we will give up the thread.
            If this is set to zero or a negative number, then the full work queue is drained (MaxWorkItemsPerTurn allowing).
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.TurnWarningLengthThreshold">
            <summary>
            TurnWarningLengthThreshold is a soft time limit to generate trace warning when the micro-turn executes longer then this period in CPU. 
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.LoadSheddingEnabled">
            <summary>
            The LoadShedding element specifies the gateway load shedding configuration for the node.
            If it does not appear, gateway load shedding is disabled.
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.LoadSheddingLimit">
            <summary>
            The LoadLimit attribute specifies the system load, in CPU%, at which load begins to be shed.
            Note that this value is in %, so valid values range from 1 to 100, and a reasonable value is
            typically between 80 and 95.
            This value is ignored if load shedding is disabled, which is the default.
            If load shedding is enabled and this attribute does not appear, then the default limit is 95%.
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.LimitValues">
            <summary>
            The values for various silo limits.
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.DefaultTraceLevel">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.TraceLevelOverrides">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.WriteMessagingTraces">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.TraceToConsole">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.TraceFilePattern">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.TraceFileName">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.LargeMessageWarningThreshold">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.PropagateActivityId">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.BulkMessageLimit">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.StatisticsMetricsTableWriteInterval">
            <summary>
            The MetricsTableWriteInterval attribute specifies the frequency of updating the metrics in Azure table.
             The default is 30 seconds.
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.StatisticsPerfCountersWriteInterval">
            <summary>
            The PerfCounterWriteInterval attribute specifies the frequency of updating the windows performance counters.
            The default is 30 seconds.
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.StatisticsLogWriteInterval">
            <summary>
            The LogWriteInterval attribute specifies the frequency of updating the statistics in the log file.
            The default is 5 minutes.
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.StatisticsWriteLogStatisticsToTable">
            <summary>
            The WriteLogStatisticsToTable attribute specifies whether log statistics should also be written into a separate, special Azure table.
             The default is yes.
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.StatisticsCollectionLevel">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.WorkingStorageDirectory">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.MinDotNetThreadPoolSize">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.Expect100Continue">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.DefaultConnectionLimit">
            <summary>
            </summary>
        </member>
        <member name="P:Orleans.NodeConfiguration.UseNagleAlgorithm">
            <summary>
            </summary>
        </member>
        <member name="T:Orleans.OrleansConfiguration">
            <summary>
            Data object holding Silo configuration parameters.
            </summary>
        </member>
        <member name="M:Orleans.OrleansConfiguration.#ctor">
            <summary>
            OrleansConfiguration constructor.
            </summary>
        </member>
        <member name="M:Orleans.OrleansConfiguration.#ctor(System.IO.TextReader)">
            <summary>
            OrleansConfiguration constructor.
            </summary>
        </member>
        <member name="M:Orleans.OrleansConfiguration.Load(System.IO.TextReader)">
            <summary>
            Loads configuration from a given input text reader.
            </summary>
            <param name="input">The TextReader to use.</param>
        </member>
        <member name="M:Orleans.OrleansConfiguration.GetConfigurationForNode(System.String)">
            <summary>
            Returns the configuration for a given silo.
            </summary>
            <param name="name">Silo name.</param>
            <returns>NodeConfiguration associated with the specified silo.</returns>
        </member>
        <member name="M:Orleans.OrleansConfiguration.StandardLoad">
            <summary>
            Loads the configuration from the standard paths
            </summary>
            <returns></returns>
        </member>
        <member name="F:Orleans.OrleansConfiguration.UpdatableXml">
            <summary>
            Subset of XML configuration file that is updatable at runtime
            </summary>
        </member>
        <member name="M:Orleans.OrleansConfiguration.Update(System.String)">
            <summary>
            Updates existing configuration.
            </summary>
            <param name="input">The input string in XML format to use to update the existing configuration.</param>
            <returns></returns>
        </member>
        <member name="M:Orleans.OrleansConfiguration.ToString(System.String)">
            <summary>
            Prints the current config for a given silo.
            </summary>
            <param name="siloName">The name of the silo to print its configuration.</param>
            <returns></returns>
        </member>
        <member name="M:Orleans.OrleansConfiguration.RuntimeVersionInfo">
            <summary>
            Returns the Runtime Version information.
            </summary>
            <returns>the Runtime Version information</returns>
        </member>
        <member name="M:Orleans.OrleansConfiguration.GetLocalIPAddress(System.Net.Sockets.AddressFamily,System.String)">
            <summary>
            Gets the address of the local server.
            If there are multiple addresses in the correct family in the server's DNS record, the first will be returned.
            </summary>
            <returns>The server's IPv4 address.</returns>
        </member>
        <member name="P:Orleans.OrleansConfiguration.Globals">
            <summary>
            The global configuration parameters that apply uniformly to all silos.
            </summary>
        </member>
        <member name="P:Orleans.OrleansConfiguration.Defaults">
            <summary>
            The default configuration parameters that apply to each and every silo. 
            These can be over-written on a per silo basis.
            </summary>
        </member>
        <member name="P:Orleans.OrleansConfiguration.SourceFile">
            <summary>
            The configuration file.
            </summary>
        </member>
        <member name="P:Orleans.OrleansConfiguration.PrimaryNode">
            <summary>
            The Primary Node IP and port (in dev setting).
            </summary>
        </member>
        <member name="P:Orleans.OrleansConfiguration.Overrides">
            <summary>
            Per silo configuration parameters overrides.
            </summary>
        </member>
        <member name="F:Orleans.Constants.DEFAULT_RESPONSE_TIMEOUT">
            <summary>
            The default timeout before a request is assumed to have failed.
            </summary>
        </member>
        <member name="F:Orleans.Constants.MIN_REMINDER_PERIOD">
            <summary>
            Minimum period for registering a reminder ... we want to enforce a lower bound
            </summary>
        </member>
        <member name="F:Orleans.Constants.REFRESH_REMINDER_LIST">
            <summary>
            Refresh local reminder list to reflect the global reminder table every 'REFRESH_REMINDER_LIST' period
            </summary>
        </member>
        <member name="M:Orleans.GrainId.GetUniformHashCode">
            <summary>
            Get a uniformly distributed hash code value for this grain, based on Jenkins Hash function.
            NOTE: Hash code value may be positive or NEGATIVE.
            </summary>
            <returns>Hash code for this GrainId</returns>
        </member>
        <member name="M:Orleans.GrainId.ToParsableString">
            <summary>
            Return this GrainId in a standard string form, suitable for later use with the <c>FromParsableString</c> method.
            </summary>
            <returns>GrainId in a standard string format.</returns>
        </member>
        <member name="M:Orleans.GrainId.FromParsableString(System.String)">
            <summary>
            Create a new GrainId object by parsing string in a standard form returned from <c>ToParsableString</c> method.
            </summary>
            <param name="addr">String containing the GrainId info to be parsed.</param>
            <returns>New GrainId object created from the input data.</returns>
        </member>
        <member name="M:Orleans.GrainId.ToKeyString">
            <summary> This is intended to be a human-readable version of the key for this GrainId. </summary>
        </member>
        <member name="T:Orleans.Interner`2">
            <summary>
            Provide a weakly-referenced cache of interned objects
            </summary>
            <typeparam name="K">Type of objects to be used for intern keys</typeparam>
            <typeparam name="T">Type of objects to be interned / cached</typeparam>
        </member>
        <member name="M:Orleans.Interner`2.FindOrCreate(`0,System.Func{`1})">
            <summary>
            Find cached copy of object with specified key, otherwise create new one using the supplied creator-function.
            </summary>
            <param name="key">key to find</param>
            <param name="creatorFunc">function to create new object and store for this key if no cached copy exists</param>
            <returns>Object with specified key - either previous cached copy or newly created</returns>
        </member>
        <member name="M:Orleans.Interner`2.TryFind(`0,`1@)">
            <summary>
            Find cached copy of object with specified key, otherwise create new one using the supplied creator-function.
            </summary>
            <param name="key">key to find</param>
            <param name="creatorFunc">function to create new object and store for this key if no cached copy exists</param>
            <returns>Object with specified key - either previous cached copy or newly created</returns>
        </member>
        <member name="M:Orleans.Interner`2.Intern(`0,`1)">
            <summary>
            Find cached copy of object with specified key, otherwise store the supplied one. 
            </summary>
            <param name="key">key to find</param>
            <param name="obj">The new object to store for this key if no cached copy exists</param>
            <returns>Object with specified key - either previous cached copy or justed passed in</returns>
        </member>
        <member name="M:Orleans.Interner`2.InternAndUpdateWithMoreDerived(`0,`1)">
            <summary>
            Intern the specified object, replacing any previous cached copy of object with specified key if the new object has a more derived type than the cached object
            </summary>
            <param name="key">object key</param>
            <param name="obj">object to be interned</param>
            <returns>Interned copy of the object with specified key</returns>
        </member>
        <member name="P:Orleans.PlacementResult.GrainType">
            <summary>
            Some storage providers need to know the grain type in order to read the state.
            The PlacementResult is generated based on the target grain type's policy, so the type
            is known and will be passed in the message NewGrainType header.
            </summary>
        </member>
        <member name="T:Orleans.Logger">
            <summary>
            The Logger class is a convenient wrapper around the .Net Trace class.
            It provides more flexible configuration than the Trace class.
            </summary>
        </member>
        <member name="T:Orleans.OrleansLogger">
            <summary>
            Interface of Orleans RunTime for logging services. 
            </summary>
        </member>
        <member name="M:Orleans.OrleansLogger.Verbose(System.String,System.Object[])">
            <summary> Output the specified message at <c>Verbose</c> log level. </summary>
        </member>
        <member name="M:Orleans.OrleansLogger.Verbose2(System.String,System.Object[])">
            <summary> Output the specified message at <c>Verbose2</c> log level. </summary>
        </member>
        <member name="M:Orleans.OrleansLogger.Verbose3(System.String,System.Object[])">
            <summary> Output the specified message at <c>Verbose3</c> log level. </summary>
        </member>
        <member name="M:Orleans.OrleansLogger.Info(System.String,System.Object[])">
            <summary> Output the specified message at <c>Info</c> log level. </summary>
        </member>
        <member name="M:Orleans.OrleansLogger.Error(System.Int32,System.String,System.Exception)">
            <summary> Output the specified message and Exception at <c>Error</c> log level with the specified log id value. </summary>
        </member>
        <member name="M:Orleans.OrleansLogger.Warn(System.Int32,System.String,System.Object[])">
            <summary> Output the specified message at <c>Warning</c> log level with the specified log id value. </summary>
        </member>
        <member name="M:Orleans.OrleansLogger.Warn(System.Int32,System.String,System.Exception)">
            <summary> Output the specified message and Exception at <c>Warning</c> log level with the specified log id value. </summary>
        </member>
        <member name="M:Orleans.OrleansLogger.Info(System.Int32,System.String,System.Object[])">
            <summary> Output the specified message at <c>Info</c> log level with the specified log id value. </summary>
        </member>
        <member name="M:Orleans.OrleansLogger.Verbose(System.Int32,System.String,System.Object[])">
            <summary> Output the specified message at <c>Verbose</c> log level with the specified log id value. </summary>
        </member>
        <member name="M:Orleans.OrleansLogger.Verbose2(System.Int32,System.String,System.Object[])">
            <summary> Output the specified message at <c>Verbose2</c> log level with the specified log id value. </summary>
        </member>
        <member name="M:Orleans.OrleansLogger.Verbose3(System.Int32,System.String,System.Object[])">
            <summary> Output the specified message at <c>Verbose3</c> log level with the specified log id value. </summary>
        </member>
        <member name="P:Orleans.OrleansLogger.SeverityLevel">
            <summary> Current SeverityLevel set for this logger. </summary>
        </member>
        <member name="P:Orleans.OrleansLogger.IsInfo">
            <summary> Whether the current SeverityLevel would output <c>Info</c> messages for this logger. </summary>
        </member>
        <member name="P:Orleans.OrleansLogger.IsVerbose">
            <summary> Whether the current SeverityLevel would output <c>Verbose</c> messages for this logger. </summary>
        </member>
        <member name="P:Orleans.OrleansLogger.IsVerbose2">
            <summary> Whether the current SeverityLevel would output <c>Verbose2</c> messages for this logger. </summary>
        </member>
        <member name="P:Orleans.OrleansLogger.IsVerbose3">
            <summary> Whether the current SeverityLevel would output <c>Verbose3</c> messages for this logger. </summary>
        </member>
        <member name="T:Orleans.OrleansLogger.Severity">
            <summary> Severity levels for log messages. </summary>
        </member>
        <member name="F:Orleans.Logger.MAX_LOG_MESSAGE_SIZE">
            <summary>
            Maximum length of log messages. 
            Log messages about this size will be truncated.
            </summary>
        </member>
        <member name="F:Orleans.Logger.excludedBulkLogCodes">
            <summary>List of log codes that won't have bulk message compaction policy applied to them</summary>
        </member>
        <member name="M:Orleans.Logger.SetSeverityLevel(Orleans.OrleansLogger.Severity)">
            <summary>
            Set a new severity level for this Logger.
            Log entries will be written if their severity is (logically) equal to or greater than this level.
            </summary>
            <param name="sev">New severity level to be used for filtering log messages.</param>
        </member>
        <member name="M:Orleans.Logger.#ctor(System.String,Orleans.Logger.LoggerType)">
            <summary>
            Constructs a Logger with the given name and type.
            </summary>
            <param name="source">The name of the source of log entries for this Logger.
            Typically this is the full name of the class that is using this Logger.</param>
            <param name="logType">The category of Logger to create.</param>
        </member>
        <member name="M:Orleans.Logger.Initialize(Orleans.ITraceConfiguration,System.Boolean)">
            <summary>
            For internal use only.
            Initialize the Orleans Logger subsystem in this process / app domain with the specified configuration settings.
            </summary>
            <remarks>
            In most cases, this call will be made automatically at the approproate poine by the Orleans runtime 
            -- must commonly during silo initialization and/or client runtime initialization.
            </remarks>
            <seealso cref="M:Orleans.OrleansClient.Initialize"/>
            <seealso cref="!:Orleans.Host.Azure.Client.OrleansAzureClient.Initialize()"/>
            <param name="config">Configuration settings to be used for initializing the Logger susbystem state.</param>
        </member>
        <member name="M:Orleans.Logger.UnInitialize">
            <summary>
            Uninitialize the Orleans Logger subsystem in this process / app domain.
            </summary>
        </member>
        <member name="M:Orleans.Logger.FindLogger(System.String)">
            <summary>
            Find the Logger with the specified name
            </summary>
            <param name="loggerName">Name of the Logger to find</param>
            <returns>Logger associated with the specified name</returns>
        </member>
        <member name="M:Orleans.Logger.GetLogger(System.String,Orleans.Logger.LoggerType)">
            <summary>
            Find existing or create new Logger with the specified name
            </summary>
            <param name="loggerName">Name of the Logger to find</param>
            <param name="logType">Type of Logger, if it needs to be created</param>
            <returns>Logger associated with the specified name</returns>
        </member>
        <member name="M:Orleans.Logger.GetLogFile(System.String)">
            <summary>
            Find the log file associated with the specified Logger
            </summary>
            <param name="loggerName">Name of the Logger to find the log file for</param>
            <returns>File info for the associated log file</returns>
        </member>
        <member name="M:Orleans.Logger.SearchLogFile(System.String,System.DateTime,System.DateTime,System.Text.RegularExpressions.Regex)">
            <summary>
            Search the specified log according to the 
            </summary>
            <param name="logName"></param>
            <param name="searchFrom"></param>
            <param name="searchTo"></param>
            <param name="searchPattern"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.Logger.SetRuntimeLogLevel(Orleans.OrleansLogger.Severity)">
            <summary>
            Set the default log level of all Runtime Loggers.
            </summary>
            <param name="newTraceLevel">The new log level to use</param>
        </member>
        <member name="M:Orleans.Logger.SetAppLogLevel(Orleans.OrleansLogger.Severity)">
            <summary>
            Set the default log level of all Grain and Application Loggers.
            </summary>
            <param name="newTraceLevel">The new log level to use</param>
        </member>
        <member name="M:Orleans.Logger.SetTraceLevelOverrides(System.Collections.Generic.List{System.Tuple{System.String,Orleans.OrleansLogger.Severity}})">
            <summary>
            Set new trace level overrides for particular loggers, beyond the default log levels.
            Any previous trace levels for particular Logger's will be discarded.
            </summary>
            <param name="overrides">The new set of log level overrided to use.</param>
        </member>
        <member name="M:Orleans.Logger.AddTraceLevelOverride(System.String,Orleans.OrleansLogger.Severity)">
            <summary>
            Add a new trace level override for a particular logger, beyond the default log levels.
            Any previous trace levels for other Logger's will not be changed.
            </summary>
            <param name="prefix">The logger names (with prefix matching) that this new log level should apply to.</param>
            <param name="level">The new log level to use for this logger.</param>
        </member>
        <member name="M:Orleans.Logger.RemoveTraceLevelOverride(System.String)">
            <summary>
            Remove a new trace level override for a particular logger.
            The log level for that logger will revert to the current global default setings.
            Any previous trace levels for other Logger's will not be changed.
            </summary>
            <param name="prefix">The logger names (with prefix matching) that this new log level change should apply to.</param>
        </member>
        <member name="M:Orleans.Logger.Verbose(System.String,System.Object[])">
            <summary>
            Writes a log entry at the Verbose severity level.
            Verbose is suitable for debugging information that should usually not be logged in production.
            Verbose is lower than Info.
            </summary>
            <param name="format">A standard format string, suitable for String.Format.</param>
            <param name="args">Any arguments to the format string.</param>
        </member>
        <member name="M:Orleans.Logger.Verbose2(System.String,System.Object[])">
            <summary>
            Writes a log entry at the Verbose2 severity level.
            Verbose2 is lower than Verbose.
            </summary>
            <param name="format">A standard format string, suitable for String.Format.</param>
            <param name="args">Any arguments to the format string.</param>
        </member>
        <member name="M:Orleans.Logger.Verbose3(System.String,System.Object[])">
            <summary>
            Writes a log entry at the Verbose3 severity level.
            Verbose3 is the lowest severity level.
            </summary>
            <param name="format">A standard format string, suitable for String.Format.</param>
            <param name="args">Any arguments to the format string.</param>
        </member>
        <member name="M:Orleans.Logger.Info(System.String,System.Object[])">
            <summary>
            Writes a log entry at the Info severity level.
            Info is suitable for information that does not indicate an error but that should usually be logged in production.
            Info is lower than Warning.
            </summary>
            <param name="format">A standard format string, suitable for String.Format.</param>
            <param name="args">Any arguments to the format string.</param>
        </member>
        <member name="M:Orleans.Logger.Verbose(System.Int32,System.String,System.Object[])">
            <summary>
            Writes a log entry at the Verbose severity level, with the specified log id code.
            Verbose is suitable for debugging information that should usually not be logged in production.
            Verbose is lower than Info.
            </summary>
            <param name="logCode">The log code associated with this message.</param>
            <param name="format">A standard format string, suitable for String.Format.</param>
            <param name="args">Any arguments to the format string.</param>
        </member>
        <member name="M:Orleans.Logger.Verbose2(System.Int32,System.String,System.Object[])">
            <summary>
            Writes a log entry at the Verbose2 severity level, with the specified log id code.
            Verbose2 is lower than Verbose.
            </summary>
            <param name="logCode">The log code associated with this message.</param>
            <param name="format">A standard format string, suitable for String.Format.</param>
            <param name="args">Any arguments to the format string.</param>
        </member>
        <member name="M:Orleans.Logger.Verbose3(System.Int32,System.String,System.Object[])">
            <summary>
            Writes a log entry at the Verbose3 severity level, with the specified log id code.
            Verbose3 is the lowest severity level.
            </summary>
            <param name="logCode">The log code associated with this message.</param>
            <param name="format">A standard format string, suitable for String.Format.</param>
            <param name="args">Any arguments to the format string.</param>
        </member>
        <member name="M:Orleans.Logger.Info(System.Int32,System.String,System.Object[])">
            <summary>
            Writes a log entry at the Info severity level, with the specified log id code.
            Info is suitable for information that does not indicate an error but that should usually be logged in production.
            Info is lower than Warning.
            </summary>
            <param name="logCode">The log code associated with this message.</param>
            <param name="format">A standard format string, suitable for String.Format.</param>
            <param name="args">Any arguments to the format string.</param>
        </member>
        <member name="M:Orleans.Logger.Warn(System.Int32,System.String,System.Object[])">
            <summary>
            Writes a log entry at the Warning severity level, with the specified log id code.
            Warning is suitable for problem conditions that the system or application can handle by itself,
            but that the administrator should be aware of.
            Typically these are situations that are expected but that may eventually require an administrative
            response if they recur.
            Warning is lower than Error.
            </summary>
            <param name="logCode">The log code associated with this message.</param>
            <param name="format">A standard format string, suitable for String.Format.</param>
            <param name="args">Any arguments to the format string.</param>
        </member>
        <member name="M:Orleans.Logger.Warn(System.Int32,System.String,System.Exception)">
            <summary>
            Writes a log entry at the Warning severity level, with the specified log id code.
            Warning is suitable for problem conditions that the system or application can handle by itself,
            but that the administrator should be aware of.
            Typically these are situations that are expected but that may eventually require an administrative
            response if they recur.
            Warning is lower than Error.
            </summary>
            <param name="logCode">The log code associated with this message.</param>
            <param name="message">The warning message to log.</param>
            <param name="exception">An exception related to the warning, if any.</param>
        </member>
        <member name="M:Orleans.Logger.Error(System.Int32,System.String,System.Exception)">
            <summary>
            Writes a log entry at the Error severity level, with the specified log id code.
            Error is suitable for problem conditions that require immediate administrative response.
            </summary>
            <param name="logCode">The log code associated with this message.</param>
            <param name="message">The error message to log.</param>
            <param name="exception">An exception related to the error, if any.</param>
        </member>
        <member name="M:Orleans.Logger.PrintDate(System.DateTime)">
            <summary>
            Utility function to convert a <c>DateTime</c> object into printable data format used by the Logger subsystem.
            </summary>
            <param name="exception">The <c>DateTime</c> value to be printed.</param>
            <returns>Formatted string representation of the input data, in the printable format used by the Logger subsystem.</returns>
        </member>
        <member name="M:Orleans.Logger.PrintTime(System.DateTime)">
            <summary>
            Utility function to convert a <c>DateTime</c> object into printable time format used by the Logger subsystem.
            </summary>
            <param name="exception">The <c>DateTime</c> value to be printed.</param>
            <returns>Formatted string representation of the input data, in the printable format used by the Logger subsystem.</returns>
        </member>
        <member name="M:Orleans.Logger.PrintException(System.Exception)">
            <summary>
            Utility function to convert an exception into printable format, including expanding and formatting any nested sub-expressions.
            </summary>
            <param name="exception">The exception to be printed.</param>
            <returns>Formatted string representation of the exception, including expanding and formatting any nested sub-expressions.</returns>
        </member>
        <member name="M:Orleans.Logger.Assert(Orleans.ErrorCode,System.Boolean,System.String)">
            <summary>
            For internal use only.
            </summary>
            <param name="condition"></param>
            <param name="message"></param>
            <param name="errorCode"></param>
        </member>
        <member name="M:Orleans.Logger.Fail(Orleans.ErrorCode,System.String)">
            <summary>
            For internal use only.
            </summary>
            <param name="message"></param>
            <param name="errorCode"></param>
        </member>
        <member name="M:Orleans.Logger.Flush">
            <summary>
            Attempt to flush any pending trace log writes to disk / backing store
            </summary>
        </member>
        <member name="M:Orleans.Logger.CreateMiniDump(Orleans.MiniDumpType)">
            <summary>
            Create a mini-dump file for the current state of this process
            </summary>
            <param name="dumpType">Type of mini-dump to create</param>
            <returns><c>FileInfo</c> for the location of the newly created mini-dump file</returns>
        </member>
        <member name="P:Orleans.Logger.MyIPEndPoint">
            <summary>
            For internal use only.
            </summary>
        </member>
        <member name="P:Orleans.Logger.BulkMessageLimit">
            <summary>
            Count limit for bulk message output.
            If the same log code is written more than <c>BulkMessageLimit</c> times in the <c>BulkMessageInterval</c> time period, 
            then only the first <c>BulkMessageLimit</c> individual messages will be written, plus a count of how bulk messages suppressed.
            </summary>
        </member>
        <member name="P:Orleans.Logger.BulkMessageInterval">
            <summary>
            Time limit for bulk message output.
            If the same log code is written more than <c>BulkMessageLimit</c> times in the <c>BulkMessageInterval</c> time period, 
            then only the first <c>BulkMessageLimit</c> individual messages will be written, plus a count of how bulk messages suppressed.
            </summary>
        </member>
        <member name="P:Orleans.Logger.LogConsumers">
            <summary>
            The set of <see cref="T:Orleans.ILogConsumer"/> references to write log events to. 
            If any .NET trace listeners are defined in app.config, then <see cref="T:Orleans.LogWriterToTrace"/> 
            is automatically added to this list to forward the Orleans log output to those trace listeners.
            </summary>
        </member>
        <member name="P:Orleans.Logger.ShowDate">
            <summary>
            Flag to suppress output of dates in log messages during unit test runs
            </summary>
        </member>
        <member name="P:Orleans.Logger.SeverityLevel">
            <summary>
            The current severity level for this Logger.
            Log entries will be written if their severity is (logically) equal to or greater than this level.
            If it is not explicitly set, then a default value will be calculated based on the logger's type and name.
            Note that changes to the global default settings will be propagated to existing loggers that are using the default severity.
            </summary>
        </member>
        <member name="P:Orleans.Logger.IsInitialized">
            <summary>
            Whether the Orleans Logger infrastructure has been previously initialized.
            </summary>
        </member>
        <member name="T:Orleans.Logger.LoggerType">
            <summary>
            The Logger class distinguishes between three categories of loggers:
            <list type="table"><listheader><term>Value</term><description>Description</description></listheader>
            <item>
            <term>Runtime</term>
            <description>Logs that are written by the Orleans run-time itself.
            This category should not be used by application code.</description>
            </item>
            <item>
            <term>Grain</term>
            <description>Logs that are written by application grains.
            This category should be used by code that runs as Orleans grains in a silo.</description>
            </item>
            <item>
            <term>Application</term>
            <description>Logs that are written by the client application.
            This category should be used by client-side application code.</description>
            </item>
            </list>
            </summary>
        </member>
        <member name="T:Orleans.Logger.TraceOverrideComparer">
            <summary>
            This custom comparer lets us sort the TraceLevelOverrides list so that the longest prefix comes first
            </summary>
        </member>
        <member name="M:Orleans.LRU`2.#ctor(System.Int32,System.TimeSpan,Orleans.LRU{`0,`1}.FetchValueDelegate)">
            <summary>
            Creates a new LRU cache.
            </summary>
            <param name="maxSize">Maximum number of entries to allow.</param>
            <param name="maxAge">Maximum age of an entry.</param>
            <param name="f"></param>
        </member>
        <member name="F:Orleans.Message.bodyBytes">
            <summary>
            NOTE: The contents of bodyBytes should never be modified
            </summary>
        </member>
        <member name="M:Orleans.Message.IsDuplicate(Orleans.Message)">
            <summary>
            Tell whether two messages are duplicates of one another
            </summary>
            <param name="other"></param>
            <returns></returns>
        </member>
        <member name="P:Orleans.Message.NewGrainType">
            <summary>
            Set by sender's placement logic when NewPlacementRequested is true
            so that receiver knows desired grain type
            </summary>
        </member>
        <member name="P:Orleans.Message.GenericGrainType">
            <summary>
            Set by caller's grain reference 
            </summary>
        </member>
        <member name="P:Orleans.Message.OnTrace">
            <summary>
            Global function that is set to monitor message lifecycle events
            </summary>
        </member>
        <member name="T:Orleans.Message.LifecycleTag">
            <summary>
            Tags used to identify points in the message processing lifecycle for logging.
            Should be fewer than 32 since bit flags are used for filtering events.
            </summary>
        </member>
        <member name="T:Orleans.OrleansGatewayTooBusyException">
            <summary>
            Signifies that a gateway silo is currently in overloaded / load shedding state 
            and is unable to currently accept this message being sent.
            </summary>
            <remarks>
            This situation is usaully a transient condition.
            The message is likely to be accepted by this or another gateway if it is retransmitted at a later time.
            </remarks>
        </member>
        <member name="T:Orleans.OrleansLimitExceededException">
            <summary>
            Signifies that a silo is in an overloaded state where some 
            runtime limit setting is currently being exceeded, 
            and so that silo is unable to currently accept this message being sent.
            </summary>
            <remarks>
            This situation is often a transient condition.
            The message is likely to be accepted by this or another silo if it is retransmitted at a later time.
            </remarks>
        </member>
        <member name="T:Orleans.OrleansDeadlockException">
            <summary>
            Signifies that a silo has detected a deadlock / loop in a call graph.
            </summary>
            <remarks>
            <para>
            Deadlock detection is not enabled by default in Orleans silos, 
            because it introduces some extra overhead in call handling.
            </para>
            <para>
            There are some constraints on the types of deadlock that can currently be detected 
            by Orleans silos.
            </para>
            </remarks>
        </member>
        <member name="T:Orleans.InvokeMethodRequest">
            <summary>
            Data object holding metadata associated with a grain Invoke request.
            </summary>
        </member>
        <member name="M:Orleans.InvokeMethodRequest.ToString">
            <summary> 
            String representation for this Invoke request. 
            </summary>
            <remarks>
            Note: This is not the serialized wire form of this Invoke request.
            </remarks>
        </member>
        <member name="P:Orleans.InvokeMethodRequest.InterfaceId">
            <summary> InterfaceId for this Invoke request. </summary>
        </member>
        <member name="P:Orleans.InvokeMethodRequest.MethodId">
            <summary> MethodId for this Invoke request. </summary>
        </member>
        <member name="P:Orleans.InvokeMethodRequest.Arguments">
            <summary> Arguments for this Invoke request. </summary>
        </member>
        <member name="T:Orleans.InvokeMethodOptions">
            <summary>
            Invoke options for an <c>InvokeMethodRequest</c>
            </summary>
            <remarks>
            These flag values are used in Orleans generated invoker code, and should not be altered. </remarks>
        </member>
        <member name="T:Orleans.SiloAddress">
            <summary>
            Data class encapsulating the details of silo addresses.
            </summary>
        </member>
        <member name="M:Orleans.SiloAddress.NewLocalAddress(System.Int32)">
            <summary>
            Factory for creating new SiloAddresses for silo on this machine with specified generation number.
            </summary>
            <param name="gen">Generation number of the silo.</param>
            <returns>SiloAddress object initialized with the non-loopback local IP address and the specified silo generation.</returns>
        </member>
        <member name="M:Orleans.SiloAddress.New(System.Net.IPEndPoint,System.Int32)">
            <summary>
            Factory for creating new SiloAddresses with specified IP endpoint address and silo generation number.
            </summary>
            <param name="ep">IP endpoint address of the silo.</param>
            <param name="gen">Generation number of the silo.</param>
            <returns>SiloAddress object initialized with specified address and silo generation.</returns>
        </member>
        <member name="M:Orleans.SiloAddress.AllocateNewGeneration">
            <summary> Allocate a new silo generation number. </summary>
            <returns>A new silo generation number.</returns>
        </member>
        <member name="M:Orleans.SiloAddress.ToParsableString">
            <summary>
            Return this SiloAddress in a standard string form, suitable for later use with the <c>FromParsableString</c> method.
            </summary>
            <returns>SiloAddress in a standard string format.</returns>
        </member>
        <member name="M:Orleans.SiloAddress.FromParsableString(System.String)">
            <summary>
            Create a new SiloAddress object by parsing string in a standard form returned from <c>ToParsableString</c> method.
            </summary>
            <param name="addr">String containing the SiloAddress info to be parsed.</param>
            <returns>New SiloAddress object created from the input data.</returns>
        </member>
        <member name="M:Orleans.SiloAddress.ToString">
            <summary> Object.ToString method override. </summary>
        </member>
        <member name="M:Orleans.SiloAddress.ToLongString">
            <summary>
            Return a long string representation of this SiloAddress.
            </summary>
            <remarks>
            Note: This string value is not comparable with the <c>FromParsableString</c> method -- use the <c>ToParsableString</c> method for that purpose.
            </remarks>
            <returns>String representaiton of this SiloAddress.</returns>
        </member>
        <member name="M:Orleans.SiloAddress.ToStringWithHashCode">
            <summary>
            Return a long string representation of this SiloAddress, including it's consistent hash value.
            </summary>
            <remarks>
            Note: This string value is not comparable with the <c>FromParsableString</c> method -- use the <c>ToParsableString</c> method for that purpose.
            </remarks>
            <returns>String representaiton of this SiloAddress.</returns>
        </member>
        <member name="M:Orleans.SiloAddress.Equals(System.Object)">
            <summary> Object.Equals method override. </summary>
        </member>
        <member name="M:Orleans.SiloAddress.GetHashCode">
            <summary> Object.GetHashCode method override. </summary>
        </member>
        <member name="M:Orleans.SiloAddress.GetConsistentHashCode">
            <summary> Get a consistent hash value for this silo address. </summary>
            <returns>Consistent hash value for this silo address.</returns>
        </member>
        <member name="M:Orleans.SiloAddress.Matches(Orleans.SiloAddress)">
            <summary>
            Two silo addresses match if they are equal or if one generation or the other is 0
            </summary>
            <param name="other"> The other SiloAddress to compare this one with. </param>
            <returns> Returns <c>true</c> if the two SiloAddresses are considered to match -- if they are equal or if one generation or the other is 0. </returns>
        </member>
        <member name="M:Orleans.SiloAddress.Equals(Orleans.SiloAddress)">
            <summary> IEquatable.Equals method override. </summary>
        </member>
        <member name="P:Orleans.SiloAddress.Zero">
            <summary> Special constant value to indicate an empty SiloAddress. </summary>
        </member>
        <member name="T:Orleans.SystemStatus">
            <summary>
            System status values and current register
            </summary>
        </member>
        <member name="F:Orleans.SystemStatus.Unknown">
            <summary>Status = Unknown</summary>
        </member>
        <member name="F:Orleans.SystemStatus.Error">
            <summary>Status = Error</summary>
        </member>
        <member name="F:Orleans.SystemStatus.Deploying">
            <summary>Status = Deploying</summary>
        </member>
        <member name="F:Orleans.SystemStatus.Deployed">
            <summary>Status = Deployed</summary>
        </member>
        <member name="F:Orleans.SystemStatus.Creating">
            <summary>Status = Creating</summary>
        </member>
        <member name="F:Orleans.SystemStatus.Created">
            <summary>Status = Created</summary>
        </member>
        <member name="F:Orleans.SystemStatus.Starting">
            <summary>Status = Starting</summary>
        </member>
        <member name="F:Orleans.SystemStatus.Running">
            <summary>Status = Running</summary>
        </member>
        <member name="F:Orleans.SystemStatus.Stopping">
            <summary>Status = Stopping</summary>
        </member>
        <member name="F:Orleans.SystemStatus.ShuttingDown">
            <summary>Status = Shuttingdown</summary>
        </member>
        <member name="F:Orleans.SystemStatus.Terminated">
            <summary>Status = Terminated</summary>
        </member>
        <member name="F:Orleans.SystemStatus.Pausing">
            <summary>Status = Pausing</summary>
        </member>
        <member name="F:Orleans.SystemStatus.Paused">
            <summary>Status = Paused</summary>
        </member>
        <member name="M:Orleans.SystemStatus.ToString">
            <see cref="M:System.Object.ToString"/>
        </member>
        <member name="M:Orleans.SystemStatus.GetHashCode">
            <see cref="M:System.Object.GetHashCode"/>
        </member>
        <member name="M:Orleans.SystemStatus.Equals(System.Object)">
            <see cref="M:System.Object.Equals(System.Object)"/>
        </member>
        <member name="M:Orleans.SystemStatus.Equals(Orleans.SystemStatus)">
            <see cref="M:System.IEquatable`1.Equals(`0)"/>
        </member>
        <member name="T:Orleans.TypeUtils">
            <summary>
            A collection of utility functions for dealing with Type information.
            </summary>
        </member>
        <member name="T:Orleans.UniqueKey.Category">
            <summary>
            Type id values encoded into UniqueKeys
            </summary>
        </member>
        <member name="T:Orleans.Serialization.SerializationContext">
            <summary>
            Maintains context information for current thread during serialization operations.
            </summary>
            <remarks>
            DeepCopier functions in Orleans generated code use the RecordObject method to 
            record the mapping of original object to the copied instance of that object
            so that object identity can be preserved when serializing .NET object graphs.
            </remarks>
        </member>
        <member name="M:Orleans.Serialization.SerializationContext.RecordObject(System.Object,System.Object)">
            <summary>
            Record an object-to-copy mapping into the current serialization context.
            Used for maintaining the .NET object graph during serialization operations.
            Used in generated code.
            </summary>
            <param name="original">Original object.</param>
            <param name="copy">Copy object that will be the serialized form of the original.</param>
        </member>
        <member name="P:Orleans.Serialization.SerializationContext.Current">
            <summary>
            The current serialization context in use for this thread.
            Used in generated code.
            </summary>
        </member>
        <member name="M:Orleans.Serialization.SerializationContext.ReferenceEqualsComparer.Equals(System.Object,System.Object)">
            <summary>
            Defines object equality by reference equality (eq, in LISP).
            </summary>
            <returns>
            true if the specified objects are equal; otherwise, false.
            </returns>
            <param name="x">The first object to compare.</param><param name="y">The second object to compare.</param>
        </member>
        <member name="T:Orleans.Serialization.SerializationManager">
            <summary>
            For internal use only. SerializationManager to oversee the Orleans syrializer susyem.
            </summary>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.Register(System.Type,Orleans.Serialization.SerializationManager.DeepCopier,Orleans.Serialization.SerializationManager.Serializer,Orleans.Serialization.SerializationManager.Deserializer)">
            <summary>
            Register a Type with the serialization system to use the specified DeepCopier, Serializer and Deserializer functions.
            </summary>
            <param name="t">Type to be registered.</param>
            <param name="cop">DeepCopier function for this type.</param>
            <param name="ser">Serializer function for this type.</param>
            <param name="deser">Deserializer function for this type.</param>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.Register(System.Type,Orleans.Serialization.SerializationManager.DeepCopier,Orleans.Serialization.SerializationManager.Serializer,Orleans.Serialization.SerializationManager.Deserializer,System.Boolean)">
            <summary>
            Register a Type with the serialization system to use the specified DeepCopier, Serializer and Deserializer functions.
            If <c>forcOverride == true</c> then this definition will replace any any previous functions registered for this Type.
            </summary>
            <param name="t">Type to be registered.</param>
            <param name="cop">DeepCopier function for this type.</param>
            <param name="ser">Serializer function for this type.</param>
            <param name="deser">Deserializer function for this type.</param>
            <param name="forceOverride">Whether these functions should replace any previously registered functions for this Type.</param>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.Register(System.Type)">
            <summary>
            For internal use only.
            This method registers a type that has no specific serializer or deserializer.
            For instance, abstract base types and interfaces need to be registered this way.
            </summary>
            <param name="t">Type to be registered.</param>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.FindSerializationInfo(System.Reflection.Assembly)">
            <summary>
            For internal use only.
            Looks for types with marked serializer and deserializer methods, and registers them if necessary.
            </summary>
            <param name="assembly">The assembly to look through.</param>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.DeepCopy(System.Object)">
            <summary>
            Deep copy the specified object, using DeepCopier functions previously registered for this type.
            </summary>
            <param name="original">The input data to be deep copied.</param>
            <returns>Deep copied clone of the original input object.</returns>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.DeepCopyInner(System.Object)">
            <summary>
            For internal use only.
            <para>
            This method makes a deep copy of the object passed to it.
            </para>
            </summary>
            <param name="original">The input data to be deep copied.</param>
            <returns>Deep copied clone of the original input object.</returns>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.GetSerializer(System.Type)">
            <summary>
            For internal use only.
            </summary>
            <param name="t"></param>
            <returns></returns>
            
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.Serialize(System.Object,Orleans.Serialization.BinaryTokenStreamWriter)">
            <summary>
            Serialize the specified object, using Serializer functions previously registered for this type.
            </summary>
            <param name="raw">The input data to be serialized.</param>
            <param name="stream">The output stream to write to.</param>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.SerializeInner(System.Object,Orleans.Serialization.BinaryTokenStreamWriter,System.Type)">
            <summary>
            For internal use only.
            <para>
            Encodes the object to the provided binary token stream.
            </para>
            </summary>
            <param name="raw">The input data to be serialized.</param>
            <param name="stream">The output stream to write to.</param>
            <param name="expected">Current expected Type on this stream.</param>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.SerializeToByteArray(System.Object)">
            <summary>
            Serialize data into byte[].
            </summary>
            <param name="raw">Input data.</param>
            <returns>Object of the required Type, rehydrated from the input stream.</returns>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.Deserialize(Orleans.Serialization.BinaryTokenStreamReader)">
            <summary>
            Deserialize the next object from the input binary stream.
            </summary>
            <param name="stream">Input stream.</param>
            <returns>Object of the required Type, rehydrated from the input stream.</returns>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.Deserialize``1(Orleans.Serialization.BinaryTokenStreamReader)">
            <summary>
            Deserialize the next object from the input binary stream.
            </summary>
            <typeparam name="T">Type to return.</typeparam>
            <param name="stream">Input stream.</param>
            <returns>Object of the required Type, rehydrated from the input stream.</returns>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.Deserialize(System.Type,Orleans.Serialization.BinaryTokenStreamReader)">
            <summary>
            Deserialize the next object from the input binary stream.
            </summary>
            <param name="t">Type to return.</param>
            <param name="stream">Input stream.</param>
            <returns>Object of the required Type, rehydrated from the input stream.</returns>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.DeserializeInner``1(Orleans.Serialization.BinaryTokenStreamReader)">
            <summary>
            Deserialize the next object from the input binary stream.
            </summary>
            <typeparam name="T">Type to return.</typeparam>
            <param name="stream">Input stream.</param>
            <returns>Object of the required Type, rehydrated from the input stream.</returns>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.DeserializeInner(System.Type,Orleans.Serialization.BinaryTokenStreamReader)">
            <summary>
            Deserialize the next object from the input binary stream.
            </summary>
            <param name="expected">Type to return.</param>
            <param name="stream">Input stream.</param>
            <returns>Object of the required Type, rehydrated from the input stream.</returns>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.GetDeserializer(System.Type)">
            <summary>
            For internal use only.
            </summary>
            <param name="t"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.DeserializeFromByteArray``1(System.Byte[])">
            <summary>
            Deserialize data from the specified byte[] and rehydrate backi into objects.
            </summary>
            <typeparam name="T">Type of data to be returned.</typeparam>
            <param name="data">Input data.</param>
            <returns>Object of the required Type, rehydrated from the input stream.</returns>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.ResolveTypeName(System.String)">
            <summary>
            For internal use only.
            </summary>
            <param name="typeName"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.Serialization.SerializationManager.RoundTripSerializationForTesting(System.Object)">
            <summary>
            Internal test method to do a round-trip Serialize+Deserialize loop
            </summary>
        </member>
        <member name="P:Orleans.Serialization.SerializationManager.UseStandardSerializer">
            <summary>
            Toggles whether or not to use the .NET serializer (true) or the Orleans serializer (false).
            This is usually set through config.
            </summary>
        </member>
        <member name="T:Orleans.Serialization.SerializationManager.DeepCopier">
            <summary>
            For internal use only. Deep copier function.
            </summary>
            <param name="original">Original object to be deep copied.</param>
            <returns>Deep copy of the original object.</returns>
        </member>
        <member name="T:Orleans.Serialization.SerializationManager.Serializer">
            <summary> For internal use only. Serializer function. </summary>
            <param name="raw">Input object to be serialized.</param>
            <param name="stream">Stream to write this data to.</param>
            <param name="expected">Current Type active in this stream.</param>
        </member>
        <member name="T:Orleans.Serialization.SerializationManager.Deserializer">
            <summary>
            For internal use only. Deserializer function.
            </summary>
            <param name="expected">Expected Type to receive.</param>
            <param name="stream">Input stream to be read from.</param>
            <returns>Rehydrated object of the specified Type read from the current position in the input stream.</returns>
        </member>
        <member name="T:Orleans.Serialization.SerializationManager.DynamicBinder">
            <summary>
            This appears necessary because the BinaryFormatter by default will not see types
            that are defined by the InvokerGenerator.
            Needs to be public since it used by generated client code.
            </summary>
        </member>
        <member name="T:Orleans.GrainBase">
            <summary>
            The abstract base class for all grains.
            </summary>
        </member>
        <member name="F:Orleans.GrainBase._Data">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="M:Orleans.GrainBase.RegisterTimer(System.Func{System.Object,System.Threading.Tasks.Task},System.Object,System.TimeSpan,System.TimeSpan)">
            <summary>
            Registers a timer to send periodic callbacks to this grain.
            </summary>
            <remarks>
            <para>
            This timer will not prevent the current grain from being deactivated.
            If the grain is deactivated, then the timer will be discarded.
            </para>
            <para>
            Until the Task returned from the asyncCallback is resolved, 
            the next timer tick will not be scheduled. 
            That is to say, timer callbacks never interleave their turns.
            </para>
            <para>
            The timer may be stopped at any time by calling the <c>Dispose</c> method 
            on the timer handle returned from this call.
            </para>
            <para>
            Any exceptions thrown by or faulted Task's returned from the asyncCallback 
            will be logged, but will not prevent the next timer tick from being queued.
            </para>
            </remarks>
            <param name="asyncCallback">Callback function to be invoked when timr ticks.</param>
            <param name="state">State object that will be passed as argument when calling the asyncCallback.</param>
            <param name="dueTime">Due time for first timer tick.</param>
            <param name="period">Period of subsequent timer ticks.</param>
            <returns>Handle for this Timer.</returns>
            <seealso cref="T:Orleans.IOrleansTimer"/>
        </member>
        <member name="M:Orleans.GrainBase.RegisterOrUpdateReminder(System.String,System.TimeSpan,System.TimeSpan)">
            <summary>
            Registers a persistent, reliable reminder to send regular notifications (reminders) to the grain.
            The grain must implement the <c>Orleans.IRemindable</c> interface, and reminders for this grain will be sent to the <c>ReceiveReminder</c> callback method.
            If the current grain is deactivated when the timer fires, a new activation of this grain will be created to receive this reminder.
            If an existing reminder with the same name already exists, that reminder will be overwritten with this new reminder.
            Reminders will always be received by one activation of this grain, even if multiple activations exist for this grain.
            </summary>
            <param name="reminderName">Name of this reminder</param>
            <param name="dueTime">Due time for this reminder</param>
            <param name="period">Frequence period for this reminder</param>
            <returns>Promise for Reminder handle.</returns>
        </member>
        <member name="M:Orleans.GrainBase.UnregisterReminder(Orleans.IOrleansReminder)">
            <summary>
            Unregisters a previously registered reminder.
            </summary>
            <param name="reminder">Reminder to unregister.</param>
            <returns>Completion promise for this operation.</returns>
        </member>
        <member name="M:Orleans.GrainBase.GetReminder(System.String)">
            <summary>
            Returns a previously registered reminder.
            </summary>
            <param name="reminderName">Reminder to return</param>
            <returns>Promise for Reminder handle.</returns>
        </member>
        <member name="M:Orleans.GrainBase.GetReminders">
            <summary>
            Returns a list of all reminders registered by the grain.
            </summary>
            <returns>Promise for list of Reminders registered for this grain.</returns>
        </member>
        <member name="M:Orleans.GrainBase.DeactivateOnIdle">
            <summary>
            Deactivate this activation of the grain after the current grain method call is completed.
            This call will mark this activation of the current grain to be deactivated and removed at the end of the current method.
            The next call to this grain will result in a different activation to be used, which typical means a new activation will be created automatically by the runtime.
            </summary>
        </member>
        <member name="M:Orleans.GrainBase.DelayDeactivation(System.TimeSpan)">
            <summary>
            Delay Deactivation of this activation at least for the specified time duration.
            A positive <c>timeSpan</c> value means “prevent GC of this activation for that time span”.
            A negative <c>timeSpan</c> value means “unlock, and make this activation available for GC again”.
            DeactivateOnIdle method would undo / override any current “keep alive” setting, 
            making this grain immediately available  for deactivation.
            </summary>
        </member>
        <member name="M:Orleans.GrainBase.ActivateAsync">
            <summary>
            This method is called at the end of the process of activating a grain.
            It is called before any messages have been dispatched to the grain.
            For grains with declared persistent state, this method is called after the State property has been populated.
            </summary>
        </member>
        <member name="M:Orleans.GrainBase.DeactivateAsync">
            <summary>
            This method is called at the begining of the process of deactivating a grain.
            </summary>
        </member>
        <member name="M:Orleans.GrainBase.GetLogger(System.String)">
            <summary>
            Returns a logger object that this grain's code can use for tracing.
            </summary>
            <returns>Name of the logger to use.</returns>
        </member>
        <member name="M:Orleans.GrainBase.GetLogger">
            <summary>
            Returns a logger object that this grain's code can use for tracing.
            The name of the logger will be derived from the grain class name.
            </summary>
            <returns>A logger for this grain.</returns>
        </member>
        <member name="P:Orleans.GrainBase.GrainState">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="P:Orleans.GrainBase.Identity">
            <summary>
            This grain's unique identifier.
            </summary>
        </member>
        <member name="P:Orleans.GrainBase.IdentityString">
            <summary>
            String representation of grain's identity including type and primary key.
            </summary>
        </member>
        <member name="P:Orleans.GrainBase.RuntimeIdentity">
            <summary>
            A unique identifier for the current silo.
            There is no semantic content to this string, but it may be useful for logging.
            </summary>
        </member>
        <member name="T:Orleans.GrainBase`1">
            <summary>
            Base class for a Grain with declared persistent state.
            </summary>
            <typeparam name="TGrainState">The interface of the persistent state object</typeparam>
        </member>
        <member name="P:Orleans.GrainBase`1.State">
            <summary>
            Strongly typed accessor for the grain state 
            </summary>
        </member>
        <member name="T:Orleans.IGrainState">
            <summary>
            Base interface for interfaces that define persistent state properties of a grain.
            </summary>
        </member>
        <member name="M:Orleans.IGrainState.ClearStateAsync">
            <summary>
            Async method to cause the current grain state data to be cleared and reset. 
            This will usually mean the state record is deleted from backin store, but the specific behavior is defined by the storage provider instance configured for this grain.
            If Etags do not match, then this operation will fail; Set Etag = <c>null</c> to indicate "always delete".
            </summary>
        </member>
        <member name="M:Orleans.IGrainState.WriteStateAsync">
            <summary>
            Async method to cause write of the current grain state data into backin store.
            If Etags do not match, then this operation will fail; Set Etag = <c>null</c> to indicate "always overwrite".
            </summary>
        </member>
        <member name="M:Orleans.IGrainState.ReadStateAsync">
            <summary>
            Async method to cause refresh of the current grain state data from backin store.
            Any previous contents of the grain state data will be overwritten.
            </summary>
        </member>
        <member name="M:Orleans.IGrainState.AsDictionary">
            <summary>
            Return a snapshot of the current grain state data, as a Dictionary of Key-Value pairs.
            </summary>
        </member>
        <member name="M:Orleans.IGrainState.SetAll(System.Collections.Generic.Dictionary{System.String,System.Object})">
            <summary>
            Update the current grain state data with the specified Dictionary of Key-Value pairs.
            </summary>
        </member>
        <member name="P:Orleans.IGrainState.Etag">
            <summary>
            Opaque value set by the storage provider representing an 'Etag' setting for the last time the state data was read from backing store.
            </summary>
        </member>
        <member name="T:Orleans.GrainState">
            <summary>
            Base class for generated grain state classes.
            </summary>
        </member>
        <member name="M:Orleans.GrainState.AsDictionaryInternal">
            <summary>
            For internal (run-time) use only.
            NOTE: This is used for serializing the state, so ALL base class fields must be here
            </summary>
        </member>
        <member name="M:Orleans.GrainState.SetAllInternal(System.Collections.Generic.Dictionary{System.String,System.Object})">
            <summary>
            For internal (run-time) use only.
            NOTE: This is used for serializing the state, so ALL base class fields must be here
            </summary>
        </member>
        <member name="M:Orleans.GrainState.InitState(System.Collections.Generic.Dictionary{System.String,System.Object})">
            <summary>
            Orleans Runtime Internal Use Only
            </summary>
        </member>
        <member name="M:Orleans.GrainState.DeepCopy">
            <summary>
            For internal (run-time) use only.
            Called from generated code.
            </summary>
            <returns>Deep copy of this grain state object.</returns>
        </member>
        <member name="M:Orleans.GrainState.SerializeTo(Orleans.Serialization.BinaryTokenStreamWriter)">
            <summary>
            For internal (run-time) use only.
            Called from generated code.
            </summary>
            <param name="stream">Stream to serialize this grain state object to.</param>
        </member>
        <member name="M:Orleans.GrainState.DeserializeFrom(Orleans.Serialization.BinaryTokenStreamReader)">
            <summary>
            For internal (run-time) use only.
            Called from generated code.
            </summary>
            <param name="stream">Stream to recover / repopulate this grain state object from.</param>
        </member>
        <member name="M:Orleans.GrainState.#ctor(System.String)">
            <summary>
            Constructs a new grain state object for a grain.
            </summary>
            <param name="reference">The type of the associated grains that use this GrainState object. Used to initialize the <c>GrainType</c> property.</param>
        </member>
        <member name="M:Orleans.GrainState.ReadStateAsync">
            <summary>
            Async method to cause refresh of the current grain state data from backin store.
            Any previous contents of the grain state data will be overwritten.
            </summary>
        </member>
        <member name="M:Orleans.GrainState.WriteStateAsync">
            <summary>
            Async method to cause write of the current grain state data into backin store.
            </summary>
        </member>
        <member name="M:Orleans.GrainState.ClearStateAsync">
            <summary>
            Async method to cause write of the current grain state data into backin store.
            </summary>
        </member>
        <member name="M:Orleans.GrainState.AsDictionary">
            <summary>
            Converts this property bag into a dictionary.
            Overridded with type-specific implementation in generated code.
            </summary>
            <returns>A Dictionary from string property name to property value.</returns>
        </member>
        <member name="M:Orleans.GrainState.SetAll(System.Collections.Generic.Dictionary{System.String,System.Object})">
            <summary>
            Populates this property bag from a dictionary.
            Overridded with type-specific implementation in generated code.
            </summary>
            <param name="values">The Dictionary from string to object that contains the values
            for this property bag.</param>
        </member>
        <member name="P:Orleans.GrainState.Etag">
            <summary>
            Opaque value set by the storage provider representing an 'Etag' setting for the last time the state data was read from backing store.
            </summary>
        </member>
        <member name="T:Orleans.GrainClient">
            <summary>
            Bridge to provide runtime services to Orleans clients, both inside and outside silos.
            </summary>
            <remarks>
            Only one GrainClient is permitted per AppDomain.
            </remarks>
        </member>
        <member name="P:Orleans.GrainClient.ClientInvokeCallback">
            <summary>
            Global pre-call interceptor function
            Synchronous callback made just before a message is about to be constructed and sent by a client to a grain.
            This call will be made from the same thread that constructs the message to be sent, so any thread-local settings 
            such as <c>Orleans.RequestContext</c> will be picked up.
            </summary>
            <remarks>This callback method should return promptly and do a minimum of work, to avoid blocking calling thread or impacting throughput.</remarks>
            <param name="request">Details of the method to be invoked, including InterfaceId and MethodId</param>
            <param name="grain">The GrainReference this request is being sent through.</param>
        </member>
        <member name="P:Orleans.GrainClient.Current">
            <summary>
            A reference to the GrainClient instance in the current app domain, 
            of the appropriate type depending on whether caller is running inside or outside silo.
            </summary>
        </member>
        <member name="P:Orleans.GrainClient.InternalCurrent">
            <summary>
            For internal (run-time) use only.
            </summary>
        </member>
        <member name="T:Orleans.GrainReference">
            <summary>
            This is the base class for all typed grain references.
            It is the grain equivalent to <c>object</c>.
            </summary>
        </member>
        <member name="M:Orleans.GrainReference.#ctor(Orleans.GrainId,System.String,Orleans.PlacementStrategy,Orleans.SiloAddress)">
            <summary>
            Constructs a reference to the grain with the specified Id.
            </summary>
            <param name="grainId">The Id of the grain to refer to.</param>
        </member>
        <member name="M:Orleans.GrainReference.#ctor(Orleans.GrainReference)">
            <summary>
            Constructs a copy of a grain reference.
            </summary>
            <param name="other">The reference to copy.</param>
        </member>
        <member name="M:Orleans.GrainReference.FromGrainId(Orleans.GrainId,System.String,Orleans.PlacementStrategy,Orleans.SiloAddress)">
            <summary>
            Constructs a reference to the grain with the specified ID.
            For internal use only.
            </summary>
            <param name="grainId">The ID of the grain to refer to.</param>
        </member>
        <member name="M:Orleans.GrainReference.ToString">
            <summary> Returns a string representation of this reference. </summary>
        </member>
        <member name="M:Orleans.GrainReference.Equals(System.Object)">
            <summary>
            Tests this reference for equality to another object.
            Two grain references are equal if they both refer to the same grain.
            </summary>
            <param name="obj">The object to test for equality against this reference.</param>
            <returns><c>true</c> if the object is equal to this reference.</returns>
        </member>
        <member name="M:Orleans.GrainReference.GetHashCode">
            <summary> Calculates a hash code for a grain reference. </summary>
        </member>
        <member name="M:Orleans.GrainReference.op_Equality(Orleans.GrainReference,Orleans.GrainReference)">
            <summary>
            Compares two references for equality.
            Two grain references are equal if they both refer to the same grain.
            </summary>
            <param name="reference1">First grain reference to compare.</param>
            <param name="reference2">Second grain reference to compare.</param>
            <returns><c>true</c> if both grain references refer to the same grain (by grain identifier).</returns>
        </member>
        <member name="M:Orleans.GrainReference.op_Inequality(Orleans.GrainReference,Orleans.GrainReference)">
            <summary>
            Compares two references for inequality.
            Two grain references are equal if they both refer to the same grain.
            </summary>
            <param name="reference1">First grain reference to compare.</param>
            <param name="reference2">Second grain reference to compare.</param>
            <returns><c>false</c> if both grain references are resolved to the same grain (by grain identifier).</returns>
        </member>
        <member name="M:Orleans.GrainReference.IsCompatible(System.Int32)">
            <summary>
            This method is for internal run-time use only.
            Implemented in Orleans generated code.
            </summary>
        </member>
        <member name="M:Orleans.GrainReference.GetMethodName(System.Int32,System.Int32)">
            <summary>
            Return the method name associated with the specified interfaceId and methodId values.
            </summary>
            <param name="interfaceId">Interface Id</param>
            <param name="methodId">Method Id</param>
            <returns>Method name string.</returns>
        </member>
        <member name="M:Orleans.GrainReference.InvokeOneWayMethod(System.Int32,System.Object[],Orleans.InvokeMethodOptions,Orleans.SiloAddress)">
            <summary>
            This method is for internal run-time use only.
            Called from Orleans generated code.
            </summary>
        </member>
        <member name="M:Orleans.GrainReference.InvokeMethodAsync``1(System.Int32,System.Object[],System.TimeSpan,Orleans.InvokeMethodOptions,Orleans.SiloAddress)">
            <summary>
            This method is for internal run-time use only.
            Called from Orleans generated code.
            </summary>
        </member>
        <member name="M:Orleans.GrainReference.CastInternal(System.Type,System.Func{Orleans.GrainReference,Orleans.IAddressable},Orleans.IAddressable,System.Int32)">
            <summary>
            Internal implementation of Cast operation for grain references
            Called from Orleans generated code.
            </summary>
            <param name="targetReferenceType">Type that this grain reference should be cast to</param>
            <param name="grainRefCreatorFunc">Delegate function to create grain references of the target type</param>
            <param name="grainRef">Grain reference to cast from</param>
            <param name="interfaceId">Interface id value for the target cast type</param>
            <returns>GrainReference that is usable as the target type</returns>
            <exception cref="T:System.InvalidCastException">if the grain cannot be cast to the target type</exception>
        </member>
        <member name="M:Orleans.GrainReference.CreateObjectReference(Orleans.IAddressable,Orleans.IGrainMethodInvoker)">
            <summary>
            This method is for internal run-time use only.
            Called from Orleans generated code.
            </summary>
        </member>
        <member name="M:Orleans.GrainReference.DeleteObjectReference(Orleans.IAddressable)">
            <summary>
            This method is for internal run-time use only.
            Called from Orleans generated code.
            </summary>
        </member>
        <member name="M:Orleans.GrainReference.SerializeGrainReference(System.Object,Orleans.Serialization.BinaryTokenStreamWriter,System.Type)">
            <summary> Serializer function for grain reference. </summary>
            <seealso cref="T:Orleans.Serialization.SerializationManager"/>
        </member>
        <member name="M:Orleans.GrainReference.DeserializeGrainReference(System.Type,Orleans.Serialization.BinaryTokenStreamReader)">
            <summary> Deserializer function for grain reference. </summary>
            <seealso cref="T:Orleans.Serialization.SerializationManager"/>
        </member>
        <member name="M:Orleans.GrainReference.CopyGrainReference(System.Object)">
            <summary> Copier function for grain reference. </summary>
            <seealso cref="T:Orleans.Serialization.SerializationManager"/>
        </member>
        <member name="M:Orleans.GrainReference.GetUniformHashCode">
            <summary> Get a uniform hash code for this grain reference. </summary>
        </member>
        <member name="M:Orleans.GrainReference.ToKeyString">
            <summary> Get the key value for this grain, as a string. </summary>
        </member>
        <member name="P:Orleans.GrainReference.GrainId">
            <summary>
            For internal use only.
            </summary>
        </member>
        <member name="P:Orleans.GrainReference.SystemTargetSilo">
            <summary>
            For internal use only.
            Called from Orleans generated code.
            </summary>
        </member>
        <member name="P:Orleans.GrainReference.IsInitializedSystemTarget">
            <summary>
            Whether the runtime environment for system targets has been initialized yet.
            Called from Orleans generated code.
            </summary>
        </member>
        <member name="P:Orleans.GrainReference.InterfaceId">
            <summary>
            Implemented by generated subclasses to return a constant
            Implemented in Orleans generated code.
            </summary>
        </member>
        <member name="P:Orleans.GrainReference.InterfaceName">
            <summary>
            Return the name of the interface for this GrainReference. 
            Implemented in Orleans generated code.
            </summary>
        </member>
        <member name="T:Orleans.OrleansUtils">
            <summary>
            General purpose utility functions.
            </summary>
        </member>
        <member name="M:Orleans.OrleansUtils.IEnumerableToString``1(System.Collections.Generic.IEnumerable{``0},System.Func{``0,System.String},System.String,System.Boolean)">
            <summary>
            Returns a human-readable text string that describes an IEnumerable collection of objects.
            </summary>
            <typeparam name="T">The type of the list elements.</typeparam>
            <param name="collection">The IEnumerable to describe.</param>
            <returns>A string assembled by wrapping the string descriptions of the individual
            elements with square brackets and separating them with commas.</returns>
        </member>
        <member name="M:Orleans.OrleansUtils.ToShortString(System.Guid)">
            <summary>
            Returns a short string representing Guid.
            </summary>
            <param name="guid">The Guid to print.</param>
            <returns>A string represting the first eight characters of guid.ToString().</returns>
        </member>
        <member name="T:Orleans.Utils">
            <summary>
            The Utils class contains a variety of utility methods for use in application and grain code.
            </summary>
        </member>
        <member name="M:Orleans.Utils.IEnumerableToString``1(System.Collections.Generic.IEnumerable{``0},System.Func{``0,System.String},System.String,System.Boolean)">
            <summary>
            Returns a human-readable text string that describes an IEnumerable collection of objects.
            </summary>
            <typeparam name="T">The type of the list elements.</typeparam>
            <param name="collection">The IEnumerable to describe.</param>
            <returns>A string assembled by wrapping the string descriptions of the individual
            elements with square brackets and separating them with commas.</returns>
        </member>
        <member name="M:Orleans.Utils.DictionaryToString``2(System.Collections.Generic.ICollection{System.Collections.Generic.KeyValuePair{``0,``1}},System.String)">
            <summary>
            Returns a human-readable text string that describes a dictionary that maps objects to objects.
            </summary>
            <typeparam name="T1">The type of the dictionary keys.</typeparam>
            <typeparam name="T2">The type of the dictionary elements.</typeparam>
            <param name="separateWithNewLine">Whether the elements should appear separated by a new line.</param>
            <param name="dict">The dictionary to describe.</param>
            <returns>A string assembled by wrapping the string descriptions of the individual
            pairs with square brackets and separating them with commas.
            Each key-value pair is represented as the string description of the key followed by
            the string description of the value,
            separated by " -> ", and enclosed in curly brackets.</returns>
        </member>
        <member name="M:Orleans.Utils.DictionaryOfListsToString``2(System.Collections.Generic.Dictionary{``0,System.Collections.Generic.List{``1}})">
            <summary>
            Returns a human-readable text string that describes a dictionary that maps objects to lists of objects.
            </summary>
            <typeparam name="T1">The type of the dictionary keys.</typeparam>
            <typeparam name="T2">The type of the list elements.</typeparam>
            <param name="dict">The dictionary to describe.</param>
            <returns>A string assembled by wrapping the string descriptions of the individual
            pairs with square brackets and separating them with commas.
            Each key-value pair is represented as the string descripotion of the key followed by
            the string description of the value list (created using <see cref="M:Orleans.Utils.IEnumerableToString``1(System.Collections.Generic.IEnumerable{``0},System.Func{``0,System.String},System.String,System.Boolean)"/>),
            separated by " -&gt; ", and enclosed in curly brackets.</returns>
        </member>
        <member name="M:Orleans.Utils.CalculateIdHash(System.String)">
            <summary>
            Calculates an integer hash value based on the consistent identity hash of a string.
            </summary>
            <param name="text">The string to hash.</param>
            <returns>An integer hash for the string.</returns>
        </member>
        <member name="M:Orleans.Utils.LeafTypes(System.Collections.Generic.IEnumerable{System.Type})">
            <summary>
            This method is for internal use only.
            </summary>
            <param name="types"></param>
            <returns></returns>
        </member>
        <member name="M:Orleans.Utils.Tail(System.String,System.Int32)">
            <summary>
            Get the last characters of a string
            </summary>
            <param name="s"></param>
            <param name="count"></param>
            <returns></returns>
        </member>
    </members>
</doc>
