using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Base card data model
/// Everything common to all cards
/// </summary>
public class BaseCardDataModel : ScriptableObject
{
    [Header("Base Card data")]
    public string Title = "Name";
    [TextArea] public string Description = "Lorem Ipsum.";
    [Tooltip("-1 if not playable")] public int Cost = 0;

    [Header("Sprites")]
    public Sprite CustomFrame = null;
    public Sprite Picture = null;
}
