using UnityEditor.Experimental.GraphView;
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
        float distance = (_newPosition - _ctx.transform.position).magnitude;
        _ctx.RigidBody.linearVelocity = direction * Mathf.Min(distance / _ctx.DestinationRadius, _ctx.FishStats.Speed);

        if(distance < .1f)
        {
            _hasReachedPositon=true;
            _ctx.RigidBody.linearVelocity = Vector2.zero;
        }
    }

    public void GetNewPosition()
    {
        Vector3 randompoint = Random.insideUnitCircle.normalized;
        float distance = Random.Range(1, _ctx.MaxWanderDistance);
        _newPosition = randompoint * distance + _ctx.transform.position;
        CheckPointPosition(_newPosition);
     
    }

    private void CheckPointPosition(Vector2 point)
    {
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(point);
        if(!(viewportPoint.x >= 0))
            point.x += 4;
        else if (!(viewportPoint.x <= 1))
            point.x -= 4;
        else if (!(viewportPoint.y >= 0))
            point.y += 4;
        else if (!(viewportPoint.y <= 1))
            point.y -= 4;
    }

}
