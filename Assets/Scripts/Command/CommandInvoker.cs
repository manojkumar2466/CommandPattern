using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    private Stack<ICommand> commandRegistry;

    public void ExecuteCommand(ICommand command)=> command.Execute();


    public void RegisterCommand(ICommand command)=> commandRegistry.Push(command);

    public void ProcessCommand(ICommand commandToProcess)
    {
        ExecuteCommand(commandToProcess);
        RegisterCommand(commandToProcess);
    }
}
