using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdEyeCommand : IUnitCommand
{
    private bool willHitTarget;
    private CommandData commandData;

    public ThirdEyeCommand(CommandData commandData)
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
        GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.ThirdEye).PerformAction(actorunit, targetunit, willHitTarget);
    }
}
