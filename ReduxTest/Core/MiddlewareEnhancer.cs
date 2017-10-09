namespace ReduxTest.Core
{
    public static class MiddlewareEnhancer
    {
        public static StoreEnhancer<TState> Create<TState>(params Middleware[] middleware)
        {
            return creator => (reducer, initialState) =>
            {
                var store = creator(reducer, initialState);
                Dispatcher dispatcher = store.Dispatch;

                foreach (var m in middleware)
                {
                    dispatcher = m(dispatcher);
                }

                return new Store<TState>(store.GetState, dispatcher);
            };
        }
    }
}
