namespace ReduxTest.Core
{
    public delegate ReducerResult<TState> Reducer<TState>(TState initialState, object action);
}
