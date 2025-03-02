using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Main;

public class CleanseCommand : IUnitCommand
{
    private bool willHitTarget;

    public CleanseCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();
    }

    public override bool WillHitTarget()
    {
        return true;
    }

    public override void Execute()
    {
        GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.Cleanse).PerformAction(actorunit, targetunit, willHitTarget);
    }
}
