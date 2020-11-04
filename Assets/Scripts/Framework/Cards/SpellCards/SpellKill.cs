using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellKill : SpellCard
{
    protected override void Effect(BaseCard card)
    {
        DecksManager.instance.MoveCard(card, DeckType.Graveyard);
    }
}
