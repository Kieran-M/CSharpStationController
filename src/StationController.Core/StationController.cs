using System.Data;

namespace StationController.Core;

public class StationController
{
    public StationState State { get; private set; } = StationState.IDLE;

    public event EventHandler<StateChangedEventArgs>? StateChanged;

    public void TransitionTo(StationState next)
    {

    }

    public void ForceFault(string reason)
    {

    }

    protected virtual void OnStateChanged(StationState from, StationState to)
    {
        StateChanged?.Invoke(this, new StateChangedEventArgs(from, to));
    }
}