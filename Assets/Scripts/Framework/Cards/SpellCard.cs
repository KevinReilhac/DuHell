using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCard : BaseCard
{
    public override CardType Type => CardType.Spell;

    public override void OnPlayCard()
    {
        List<BaseCard> cards = new List<BaseCard>();

        //SelectTarget(s)

        cards.ForEach(card =>
        {
            Effect(card);
        });

        DecksManager.instance.MoveCard(this, DeckType.Graveyard);
    }

    protected virtual void Effect(BaseCard card)
    {
    }
}
