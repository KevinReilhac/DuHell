using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBuff : SpellCard
{
    public int buffAttack = 0;
    public int buffHealth = 0;

    protected override void Effect(BaseCard card)
    {
        MonsterCard monster = card as MonsterCard;

        monster.Attack += buffAttack;
        monster.HealthPoints += buffHealth;
    }
}
