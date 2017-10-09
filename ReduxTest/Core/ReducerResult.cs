namespace ReduxTest.Core
{
    public sealed class ReducerResult<TState>
    {
        public TState State { get; private set; }
        public object[] Effects { get; private set; }
    }
}
