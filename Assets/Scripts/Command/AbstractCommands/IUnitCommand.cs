
using Command.Player;
public abstract class IUnitCommand: ICommand
{
    public int ActorUnitID;
    public int TargetUnitID;
    public int ActorPlayerID;
    public int TargetPlayerID;

    protected UnitController actorunit;
    protected UnitController targetunit;
    public abstract void Execute();

    public abstract bool WillHitTarget();
}