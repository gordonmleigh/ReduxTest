using System.Threading.Tasks;

namespace ReduxTest.Core
{
    public static class EffectsEnhancer
    {
        public static StoreEnhancer<TState> Create<TState>(Effector effector)
        {
            return create => (reducer, initialState) =>
            {
                ReducerResult<TState> result = null;

                // store effects in closure.
                Reducer<TState> effectsReducer = 
                    (state, action) => result = reducer(state, action);

                var store = create(effectsReducer, initialState);

                // dispatch then apply effects.
                return new Store<TState>(store.GetState, action =>
                {
                    store.Dispatch(action);

                    foreach (var effect in result.Effects)
                    {
                        Task.Run(() => effector(effect));
                    }
                });
            };
        }
    }
}
