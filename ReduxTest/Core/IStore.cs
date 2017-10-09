namespace ReduxTest.Core
{
    public interface IStore<TState>
    {
        TState GetState();

        void Dispatch(object action);
    }
}
