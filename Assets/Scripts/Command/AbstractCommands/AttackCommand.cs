using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Main;
public class AttackCommand : IUnitCommand
{
    private bool willHitTarget;
    public AttackCommand(CommandData commandData)
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
        GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.Attack).PerformAction(actorunit, targetunit, willHitTarget);
    }
}
