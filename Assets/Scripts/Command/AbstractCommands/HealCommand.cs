using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Main;
public class HealCommand : IUnitCommand
{
    private bool willHitTaget;

    public HealCommand(CommandData commandData)
    {
        this.commandData = commandData;
        willHitTaget = WillHitTarget();
    }

    public override bool WillHitTarget()
    {
        return true;
    }

    public override void Execute()
    {
        GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.Heal).PerformAction(actorunit, targetunit, willHitTaget);
    }
}
