using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCard
{
    private Dictionary<string, int> _customProperties = new Dictionary<string, int>();
    private string _idType = null;
    private string _idCard = null;
    private int _cost = 0;
    private string _title = null;
    private bool _hasChain = false;

    #region Events
    public virtual void OnPlayCard() { }
    public virtual void TestChain() { }
    public virtual void OnChain() { }
    #endregion

    #region Accesors
    public string IdType { get => _idType; }
    public string IdCard { get => _idCard; }
    public int    Cost   { get => _cost; }
    public string Title  { get => _title; }
    public bool HasChain { get => _hasChain; }
    public Dictionary<string, int> CustomProperties { get => _customProperties; }
    #endregion
}
