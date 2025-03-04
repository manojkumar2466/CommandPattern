using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Main;

public enum ReplayState
{
    Active,
    Inactive
}
public class ReplayService : MonoBehaviour
{
    private Stack<ICommand> replayStack;

    public ReplayState replayState { get; private set; }

    public ReplayService()
    {
        SetReplayState(ReplayState.Inactive);
    }

    public void SetCommandStack(Stack<ICommand> commandsToSet)
    {
        replayStack = new Stack<ICommand>(commandsToSet);
    }
    public void SetReplayState(ReplayState replayState)
    {
        this.replayState = replayState;
    }


    public void ExecuteNext()
    {
        if (replayStack.Count > 0)
        {
            GameService.Instance.ProcessUnitCommand(replayStack.Pop());            
        }
    }
}
