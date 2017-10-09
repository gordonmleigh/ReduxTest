using System;
using System.Threading;

namespace ReduxTest.Core
{
    public class Store<TState> : IStore<TState>
    {
        /// <summary>
        /// Create a new store.
        /// </summary>
        public static IStore<TState> Create(Reducer<TState> reducer, TState initialState)
        {
            TState state = initialState;
            return new Store<TState>(() => state, action => { state = reducer(state, action).State; });
        }


        /// <summary>
        /// Create a new store and apply the specified enhancers.
        /// </summary>
        public static IStore<TState> Create(Reducer<TState> reducer, TState initialState, 
            params StoreEnhancer<TState>[] enhancers)
        {
            StoreCreator<TState> creator = Create;

            foreach (var enhancer in enhancers)
            {
                creator = enhancer(creator);
            }

            return creator(reducer, initialState);
        }


        private readonly Func<TState> getState;
        private readonly Dispatcher dispatch;


        public Store(Func<TState> getState, Dispatcher dispatch)
        {
            this.getState = getState;
            this.dispatch = dispatch;
        }


        public void Dispatch(object action)
        {
            dispatch(action);
        }


        public TState GetState()
        {
            return getState();
        }
    }
}
