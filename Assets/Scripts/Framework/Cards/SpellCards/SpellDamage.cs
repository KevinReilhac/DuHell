using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDamage : SpellCard
{
    public int Damage = 0;

    protected override void Effect(BaseCard card)
    {
        MonsterCard monster = card as MonsterCard;

        monster.HealthPoints -= Damage;
    }
}
