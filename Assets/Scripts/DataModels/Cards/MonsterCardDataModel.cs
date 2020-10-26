using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Monster card data model,
/// Cards that placed on the board
/// </summary>
[CreateAssetMenu(fileName = "SpellCard", menuName = "Cards/Monster")]
public class MonsterCardDataModel : BaseCardDataModel
{
    [Header("Monster data")]
    public int LifePoints = 10;
    public int Strenght = 10;
}
