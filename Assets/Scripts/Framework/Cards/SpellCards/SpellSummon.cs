using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSummon : SpellCard
{
    public MonsterCard monsterToSummon = null;

    public override void OnPlayCard()
    {
        DecksManager.instance.AddCard(monsterToSummon, DeckType.Board);

        DecksManager.instance.MoveCard(this, DeckType.Graveyard);
    }
}
