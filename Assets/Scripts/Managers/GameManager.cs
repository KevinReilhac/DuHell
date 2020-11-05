using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager<GameManager>
{
    public ActionStack actionStack = new ActionStack();
    public ActionStack.ActionType currentAction = ActionStack.ActionType.None;

    private Player playerTurn = Player.None;
    private Player playerAction = Player.None;

    private enum Player
    {
        None,
        Self,
        Enemy
    }

    private void OnEnable()
    {
        print(name + " created");
    }

    /// <summary>
    /// Set the current player turn
    /// </summary>
    private void SetPlayerTurn()
    {
        //Insérer le réseau
        if (playerTurn == Player.None)
        {
            //Récupérer le premier tour
            playerTurn = Player.Self;
        }
        else
        {
            playerTurn = SwapTurn(playerTurn);
        }

        playerAction = playerTurn;
    }

    /// <summary>
    /// Swap the turn passed
    /// </summary>
    /// <param name="turn"></param>
    /// <returns></returns>
    private Player SwapTurn(Player turn)
    {
        if (turn == Player.Self)
        {
            return Player.Enemy;
        }

        if (turn == Player.Enemy)
        {
            return Player.Self;
        }

        return Player.None;
    }

    /// <summary>
    /// Return the card played by the player
    /// </summary>
    /// <param name="playerTurn"></param>
    /// <returns></returns>
    private BaseCard GetPlayedCard(Player playerTurn)
    {
        //Insérer la selection de la carte
        if (playerTurn == Player.Self)
            return new BaseCard();

        //Insérer le réseau
        return new BaseCard();
    }

    /// <summary>
    /// Detect if the player can chain or not
    /// </summary>
    /// <param name="playerTurn"></param>
    /// <returns></returns>
    private bool CanChain(Player playerTurn)
    {
        if (playerTurn == Player.Self)
            return DecksManager.instance.CanChain();

        //Insérer le réseau
        return true;
    }

    /// <summary>
    /// Trigger a chain in actions
    /// </summary>
    public void TriggerChain()
    {
        playerAction = SwapTurn(playerAction);

        if (CanChain(playerAction))
        {
            BaseCard playedCard = GetPlayedCard(playerAction);

            if (playedCard != null)
                actionStack.AddAction(playedCard.OnChain, ActionStack.ActionType.Play);
        }
    }

    /// <summary>
    /// Draw phase
    /// </summary>
    private void DrawPhase()
    {
        if (playerTurn == Player.Self)
            DecksManager.instance.Draw(1);
    }

    /// <summary>
    /// Main phase
    /// </summary>
    private void MainPhase()
    {
        BaseCard playedCard = GetPlayedCard(playerTurn);

        if (playedCard != null)
            actionStack.AddAction(playedCard.OnPlayCard, ActionStack.ActionType.Play);

        while (actionStack.Count > 0)
        {
            Action action = actionStack.Pop();
            action();
        }
    }

    /// <summary>
    /// End phase
    /// </summary>
    private void EndPhase()
    {
        DecksManager.instance.TriggerEndPhaseEffects();
    }

    private void Update()
    {
        SetPlayerTurn();

        DrawPhase();
        MainPhase();
        EndPhase();
    }
}
