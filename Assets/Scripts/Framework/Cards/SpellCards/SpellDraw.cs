using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDraw : SpellCard
{
    public int numberToDraw = 0;

    public override void OnPlayCard()
    {
        DecksManager.instance.Draw(numberToDraw);

        DecksManager.instance.MoveCard(this, DeckType.Graveyard);
    }
}
