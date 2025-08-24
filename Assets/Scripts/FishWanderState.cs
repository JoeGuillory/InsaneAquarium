using UnityEngine;

public class FishWanderState : FishBaseState
{
    Vector3 _newPosition;
    bool _hasReachedPositon;

    public FishWanderState(FishStateMachine currentContect, FishStateFactory fishStateFactory):base(currentContect, fishStateFactory)
    {
    }
    public override void EnterState()
    {
       
    }
    public override void UpdateState()
    {
        CheckSwitchStates();


    }
    public override void FixedUpdateState()
    {
        if (_hasReachedPositon)
            return;
        MoveToNewPosition();
    }
    public override void ExitState()
    {
        
    }

    public override void CheckSwitchStates()
    {
        
    }

    private void MoveToNewPosition()
    {

    }

    private void GetNewPosition()
    {
        _newPosition = (Vector3)UnityEngine.Random.insideUnitCircle * _ctx.WanderDistance + _ctx.transform.position;
    }


}
