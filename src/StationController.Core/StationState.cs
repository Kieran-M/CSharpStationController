namespace StationController.Core;

public enum StationState
{
    IDLE,
    INIT,
    LOADING,
    PROCESSING,
    UNLOADING,
    COMPLETE,

    PAUSED,
    FAULT,
    STOPPING
}
public static class TransitionTable
{
    private static readonly Dictionary<StationState, HashSet<StationState>> AllowedStates = new() {
        [StationState.IDLE] = new () { StationState.INIT, StationState.PAUSED },
        [StationState.INIT] = new () { StationState.LOADING },
        [StationState.LOADING] = new () { StationState.PROCESSING  },
        [StationState.PROCESSING] = new() { StationState.UNLOADING, StationState.PAUSED },
        [StationState.UNLOADING] = new() { StationState.COMPLETE, StationState.LOADING},
        [StationState.COMPLETE] = new() { StationState.IDLE },
        [StationState.FAULT] = new() { StationState.STOPPING },
        [StationState.STOPPING] = new() { StationState.IDLE },
        [StationState.PAUSED] = new() { StationState.STOPPING, StationState.PROCESSING }
        };

    public static bool IsValid(StationState currState, StationState newState)
    {
        return AllowedStates.TryGetValue(currState, out var allowed) && allowed.Contains(newState);
    }
}
