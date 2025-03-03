using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Main;

public class AttackStanceCommand : IUnitCommand
{
    private bool willHitTarget;

    public AttackStanceCommand(CommandData commandData)
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
        if(willHitTarget)
        {
            if(!targetunit.IsAlive())
            {
                targetunit.Revive();
            }
            int originalPower = (targetunit.CurrentPower / 120) * 100;
            targetunit.CurrentPower = originalPower;
            targetunit.Owner.ResetCurrentActiveUnit();
        }
    }

    public override void Execute()
    {
        GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.AttackStance).PerformAction(actorunit, targetunit, willHitTarget);
    }
}
