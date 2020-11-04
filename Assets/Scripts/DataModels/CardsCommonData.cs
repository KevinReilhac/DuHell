using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Compilation;
using System.Linq;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "CardsCommonData", menuName = "Data/Common/CardsCommonData")]
public class CardsCommonData : dataObject
{
    [SerializeField] private List<GameObject> cardPrefabs = null;

    [Header("Sprites")]
    public Sprite DefaultPicture = null;
    public Sprite DefaultFrame = null;


    #region CardsPrefab
    private Dictionary<Type, GameObject> _cardPrefabsDict = null;

    /// <summary>
    /// Init card prefabs dictionary
    /// </summary>
    private void FillCardPrefabsDict()
    {
        if (_cardPrefabsDict != null)
            return;

        List<Type> types = System.Reflection.Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.BaseType != null && t.BaseType.IsGenericType &&
            t.BaseType.GetGenericTypeDefinition() == typeof(BaseCardDisplayTemplate<>)).ToList();

        _cardPrefabsDict = new Dictionary<Type, GameObject>();
        foreach (Type type in types)
        {
            foreach (GameObject prefab in cardPrefabs)
            {
                if (prefab.GetComponent(type) != null)
                {
                    _cardPrefabsDict.Add(type, prefab);
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Return the prefab of a specific card type
    /// </summary>
    /// <typeparam name="T">card type</typeparam>
    /// <returns></returns>
    public BaseCardDisplayTemplate<T> GetCardPrefab<T>() where T : BaseCard
    {
        if (_cardPrefabsDict == null)
            FillCardPrefabsDict();

        foreach (var item in _cardPrefabsDict)
        {
            if (item.Key.BaseType == (typeof(BaseCardDisplayTemplate<T>)))
                return (item.Value.GetComponent<BaseCardDisplayTemplate<T>>());
        }
        return (null);
    }
    #endregion
}
