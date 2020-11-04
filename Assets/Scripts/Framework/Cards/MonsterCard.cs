using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCard : BaseCard
{
    public int HealthPoints = 0;
    public int Attack = 0;
    public bool HasAction = false;

    #region Events
    public virtual void OnEnterTerrain() { }
    public virtual void OnKilled() { }
    public virtual void OnAction() { }
    public virtual void OnEndTurn() { }
    #endregion

    #region Accesor
    public override CardType Type => CardType.Monster;
    #endregion
}
