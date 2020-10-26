using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] private Text Title = null;
    [SerializeField] private Text Description = null;
    [SerializeField] private Text Cost = null;
    [Header("Monster")]
    [SerializeField] private GameObject MonsterLayer = null;
    [SerializeField] private Text Strenght = null;
    [SerializeField] private Text LifePoints = null;
    [Header("Images")]
    [SerializeField] private Image Picture = null;
    [SerializeField] private Image Frame = null;

    private BaseCardDataModel _cardData = null;


    /// <summary>
    /// Setup all labels and images from card data
    /// </summary>
    public void Refresh()
    {
        if (_cardData == null)
            return;

        Title.text          = _cardData.Title;
        Description.text    = _cardData.Description;
        Cost.text           = _cardData.Cost.ToString();
        Picture.sprite      = _cardData.Picture;
        Frame.sprite        = _cardData.CustomFrame;

        Cost.gameObject.SetActive(_cardData.Cost >= 0);
        SetMonsterData();
    }

    /// <summary>
    /// Setup monster layer if the card is a monster
    /// </summary>
    private void SetMonsterData()
    {
        MonsterCardDataModel monsterData = _cardData as MonsterCardDataModel;

        MonsterLayer.SetActive(monsterData != null);

        if (monsterData != null)
        {
            Strenght.text = monsterData.Strenght.ToString();
            LifePoints.text = monsterData.Strenght.ToString();
        }
    }

    /// <summary>
    /// CardData getter and setter,
    /// Set data refresh card
    /// </summary>
    public BaseCardDataModel CardData
    {
        get => _cardData;
        set
        {
            _cardData = value;
            Refresh();
        }
    }
}
