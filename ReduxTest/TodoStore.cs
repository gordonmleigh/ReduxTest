using ReduxTest.Core;
using ReduxTest.State;
using System.Threading;

namespace ReduxTest
{
    public static class TodoStore
    {
        public static IStore<TodoAppState> Create(SynchronizationContext dispatcherContext)
        {
            return Store<TodoAppState>.Create(
                null, new TodoAppState(),
                MiddlewareEnhancer.Create<TodoAppState>(
                    SyncContextMiddleware.Create(dispatcherContext)
                ),
                EffectsEnhancer.Create<TodoAppState>(null)
            );
        }
    }
}
