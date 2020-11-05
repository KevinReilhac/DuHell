using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellNegate : SpellCard
{
    public override void OnPlayCard()
    {
        GameManager.instance.actionQueue.Pop();
    }
}
