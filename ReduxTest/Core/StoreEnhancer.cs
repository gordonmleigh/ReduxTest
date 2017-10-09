namespace ReduxTest.Core
{
    public delegate StoreCreator<TState> StoreEnhancer<TState>(StoreCreator<TState> creator);
}
