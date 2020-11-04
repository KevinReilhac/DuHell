using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MonsterDisplay : BaseCardDisplayTemplate<MonsterCard>
{
    [Header("Monster")]
    [SerializeField] private TextMeshProUGUI healthPoints = null;
    [SerializeField] private TextMeshProUGUI attack = null;

    public override void Refresh()
    {
        base.Refresh();
        if (_cardData == null)
            return;
        healthPoints.text = _cardData.HealthPoints.ToString();
        attack.text = _cardData.Attack.ToString();
    }
}
