using System.Threading;

namespace ReduxTest.Core
{
    public static class SyncContextMiddleware
    {
        public static Middleware Create(SynchronizationContext dispatcherContext)
        {
            return dispatcher => action => dispatcherContext.Post(new SendOrPostCallback(dispatcher), action);
        }
    }
}
