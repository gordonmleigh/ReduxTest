namespace ReduxTest.Core
{
    public delegate IStore<TState> StoreCreator<TState>(Reducer<TState> reducer, TState initialState);
}
