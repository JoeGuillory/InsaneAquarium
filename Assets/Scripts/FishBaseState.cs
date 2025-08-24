using UnityEngine;

public abstract class FishBaseState
{
    protected FishStateMachine _ctx;
    protected FishStateFactory _factory;

    public FishBaseState(FishStateMachine currentContext, FishStateFactory fishStateFactory)
    {
        _ctx = currentContext;
        _factory = fishStateFactory;  
    }
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchStates();

    protected void UpdateStates() { }
    protected void SwitchStates(FishBaseState newState) 
    {
        ExitState();

        newState.EnterState();

        _ctx.CurrentState = newState;
    }
}
