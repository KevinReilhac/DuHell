using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCard : BaseCard
{
    public int HealthPoints = 0;
    public int Attack = 0;
    public bool HasAction = false;

    #region Events
    public override void OnPlayCard()
    {
        GameManager.instance.actionStack.AddAction(OnEnterTerrain, ActionStack.ActionType.EnterTerrain);
    }

    public virtual void OnEnterTerrain()
    {
        DecksManager.instance.MoveCard(this, DeckType.Board);
    }

    public virtual void OnKilled()
    {
        DecksManager.instance.MoveCard(this, DeckType.Graveyard);
    }

    public virtual void OnAction()
    {
        List<MonsterCard> cards = new List<MonsterCard>();

        //SelectTarget(s)

        cards.ForEach(card =>
        {
            card.HealthPoints -= Attack;
        });
    }

    public virtual void OnEndTurn() { }
    #endregion

    #region Accesor
    public override CardType Type => CardType.Monster;
    #endregion
}
