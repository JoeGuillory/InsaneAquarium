
public class FishStateFactory
{
    FishStateMachine _context;

    public FishStateFactory(FishStateMachine currentContect)
    {
        _context = currentContect;
    }

    public FishWanderState Wander()
    {
        return new FishWanderState(_context,this);
    }
}
