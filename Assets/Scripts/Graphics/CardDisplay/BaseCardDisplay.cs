using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using TMPro;

public class BaseCardDisplayTemplate<T> : MonoBehaviour where T : BaseCard
{
    [SerializeField] private TextMeshProUGUI title = null;
    [SerializeField] private TextMeshProUGUI description = null;
    [SerializeField] private TextMeshProUGUI cost = null;
    [Header("Editor")]
    [SerializeField] private TextAsset jsonFile = null;

    protected T _cardData = default(T);

    /// <summary>
    /// Reload all fields
    /// </summary>
    [Button("Refresh")]
    public virtual void Refresh()
    {
        if (_cardData == null)
            return;
        title.text = _cardData.Title;
        description.text = _cardData.Description;
        cost.text = _cardData.Cost.ToString();
    }

    /// <summary>
    /// Load all fields from json
    /// </summary>
    [Button]
    public void LoadFromJson()
    {
        string json = jsonFile.text;

        _cardData = JsonUtility.FromJson<T>(json);
        Refresh();
    }
}
