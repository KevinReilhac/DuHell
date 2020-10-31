using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecksManager : Manager<DecksManager>
{
    Dictionary<DeckType, CardList> decks = null;

    private void Awake()
    {
        InitDecks();
    }

    private void InitDecks()
    {
        foreach (DeckType type in Enum.GetValues(typeof(DeckType)))
            decks.Add(type, new CardList());
    }
}
