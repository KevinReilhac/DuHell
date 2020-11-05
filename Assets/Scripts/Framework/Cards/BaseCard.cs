using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NaughtyAttributes;

public enum CardType
{
    None,
    Monster,
    Spell
}

public enum CardGroup
{
    None
}

[System.Serializable]
public class BaseCard
{
    [System.Serializable]
    public class CustomPropertiesDict : SerializableDictionary<string, int> { };
    public const string STREAMING_PATH = "Cards";
    public const string STREAMING_EXTENTION = "json";

    public string Title = null;
    public string Description = null;
    public int Cost = 0;
    public string IdCard = null;
    public DeckType deck = DeckType.None;
    public CustomPropertiesDict CustomProperties = new CustomPropertiesDict();



    #region SERIALIZATION
    [Button]
    public virtual void SaveAsJson()
    {
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, STREAMING_PATH, Type.ToString());

        System.IO.Directory.CreateDirectory(path);
        path = System.IO.Path.Combine(path, string.Format("{0}.{1}", Title, "json"));
        System.IO.File.WriteAllText(path,  JsonUtility.ToJson(this, true));
        AssetDatabase.Refresh();

        Debug.LogFormat("{0} Card saved at {1}", Title, path);
    }
    #endregion

    #region Events
    public virtual void OnPlayCard() { }
    public virtual bool TestChain()
    {
        return false;
    }
    public virtual void OnChain() { }
    #endregion

    #region Accesors
    public virtual CardType Type => CardType.None;
    public virtual CardGroup Group => CardGroup.None;
    #endregion
}
