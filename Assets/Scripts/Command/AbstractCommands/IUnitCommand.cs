
using Command.Player;

public struct CommandData
{
    public int ActorUnitID;
    public int TargetUnitID;
    public int ActorPlayerID;
    public int TargetPlayerID;

    public CommandData(int ActorUnitID, int TargetUnitID, int ActorPlayerID, int TargetPlayerID)
    {
        this.ActorUnitID = ActorUnitID;
        this.TargetUnitID = TargetUnitID;
        this.ActorPlayerID = ActorPlayerID;
        this.TargetPlayerID = TargetPlayerID;
    }
}
public abstract class IUnitCommand: ICommand
{
    public int ActorUnitID;
    public int TargetUnitID;
    public int ActorPlayerID;
    public int TargetPlayerID;
    public CommandData commnadData;

    protected UnitController actorunit;
    protected UnitController targetunit;
    public abstract void Execute();

    public abstract bool WillHitTarget();

    public void SetActorUnit(UnitController actorUnit) => this.actorunit = actorUnit;

    public void SerTargetUnit(UnitController targetUnit) => this.targetunit = targetUnit;
}