using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Main;

public class AttackStanceCommand : IUnitCommand
{
    private bool willHitTarget;
    private CommandData commandData;

    public AttackStanceCommand(CommandData commandData)
    {
        this.commandData = commnadData;
        willHitTarget = WillHitTarget();
    }

    public override bool WillHitTarget()
    {
        return true;
    }

    public override void Execute()
    {
        GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.AttackStance).PerformAction(actorunit, targetunit, willHitTarget);
    }
}
