using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Main;
public class CommandInvoker : MonoBehaviour
{
    private Stack<ICommand> commandRegistry = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)=> command.Execute();

    public void Undo()
    {
        if (!IsRegistryEmpty() && CommandBelongsToActivePlayer())
        {
            commandRegistry.Pop().Undo();
        }
        
    }

    private bool CommandBelongsToActivePlayer()
    {
       return (commandRegistry.Peek() as IUnitCommand).commandData.ActorPlayerID == GameService.Instance.PlayerService.ActivePlayerID;
    }
    private bool IsRegistryEmpty()
    {
        return commandRegistry.Count==0;
    }


    public void RegisterCommand(ICommand command)=> commandRegistry.Push(command);

    public void ProcessCommand(ICommand commandToProcess)
    {
        ExecuteCommand(commandToProcess);
        RegisterCommand(commandToProcess);
    }
}
