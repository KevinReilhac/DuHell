using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionStack : Stack<Action>
{
    public enum ActionType
    {
        None,
        Draw,
        Attack,
        Play,
        EnterTerrain,
        EndTurn
    }

    /// <summary>
    /// Add an action in the stack
    /// </summary>
    /// <param name="action"></param>
    /// <param name="actionType"></param>
    public void AddAction(Action action, ActionType actionType)
    {
        Push(action);

        GameManager.instance.currentAction = actionType;

        GameManager.instance.TriggerChain();
    }
}
