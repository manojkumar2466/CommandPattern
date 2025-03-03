using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Main;

public class MeditateCommand : IUnitCommand
{
    private bool willHitTarget;
    public MeditateCommand(CommandData commandData)
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
            if(targetunit.IsAlive())
            {
                int healthToDecrease = (targetunit.CurrentMaxHealth / 120) * 100;
                targetunit.TakeDamage(healthToDecrease);
                targetunit.CurrentMaxHealth -= healthToDecrease;
                targetunit.Owner.ResetCurrentActiveUnit();
            }
        }
        
    }

    public override void Execute()
    {
        GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.Meditate).PerformAction(actorunit, targetunit, willHitTarget);
    }

}
