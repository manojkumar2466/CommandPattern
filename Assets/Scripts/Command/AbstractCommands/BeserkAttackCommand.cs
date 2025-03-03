using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Main;

public class BeserkAttackCommand : IUnitCommand
{
    private bool willHitTarget;

    public BeserkAttackCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTarget = WillHitTarget();
    }

    public override void Undo()
    {
        if(willHitTarget)
        {
            if(!targetunit.IsAlive())
            {
                targetunit.Revive();
            }
            targetunit.RestoreHealth(actorunit.CurrentPower * 2);
            targetunit.Owner.ResetCurrentActiveUnit();
        }

    }
    public override bool WillHitTarget() =>  true;

    public override void Execute()
    {
        GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.BerserkAttack).PerformAction(actorunit, targetunit, willHitTarget);
    }
}
