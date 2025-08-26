using UnityEngine;

public class FishWanderState : FishBaseState
{
    Vector3 _newPosition;
    bool _hasReachedPositon = false;
  
    public FishWanderState(FishStateMachine currentContect, FishStateFactory fishStateFactory):base(currentContect, fishStateFactory)
    {
    }
    public override void EnterState()
    {
        GetNewPosition();
    }
    public override void UpdateState()
    {
        CheckSwitchStates();
        _ctx._dotObject.transform.position = _newPosition;
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
        Vector3 direction = (_newPosition - _ctx.transform.position).normalized;
    }

    public void GetNewPosition()
    {
        Vector3 randompoint = Random.insideUnitCircle.normalized;
        float distance = Random.Range(.5f, _ctx.MaxWanderDistance);
        _newPosition = randompoint * distance + _ctx.transform.position;
    }


}
