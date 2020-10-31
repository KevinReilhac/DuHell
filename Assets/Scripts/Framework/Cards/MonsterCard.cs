using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCard : BaseCard
{
    private int _healthPoints = 0;
    private bool _hasAction = false;

    #region Events
    public virtual void OnEnterTerrain() { }
    public virtual void OnKilled() { }
    public virtual void OnAction() { }
    public virtual void OnEndTurn() { }
    #endregion

    #region Accesor
    public int  HealthPoints { get => _healthPoints; }
    public bool HasAction    { get => _hasAction; }
    #endregion
}
