using Command.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdEyeCommand : IUnitCommand
{
    private bool willHitTarget;

    public ThirdEyeCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();
    }

    public override bool WillHitTarget()
    {
        return true;
    }

    public override void Undo()
    {
        if (willHitTarget)
        {
            if(!targetunit.IsAlive())
            {
                targetunit.Revive();
            }
            int healthToIncrease = (int)((targetunit.CurrentHealth / 75) * 0.25);
            targetunit.RestoreHealth(healthToIncrease);
            targetunit.CurrentPower -= healthToIncrease;
        }

    }

    public override void Execute()
    {
        GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.ThirdEye).PerformAction(actorunit, targetunit, willHitTarget);
    }
}
