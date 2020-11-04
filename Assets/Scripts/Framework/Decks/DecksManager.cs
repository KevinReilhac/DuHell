using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecksManager : Manager<DecksManager>
{
    Dictionary<DeckType, CardList> decks;

    private void Awake()
    {
        InitDecks();
    }

    private void InitDecks()
    {
        decks = new Dictionary<DeckType, CardList>();

        foreach (DeckType type in Enum.GetValues(typeof(DeckType)))
            decks.Add(type, new CardList());
    }

    public void AddCard(BaseCard card, DeckType deck)
    {
        decks[deck].Add(card);
    }

    public void MoveCard(BaseCard card, DeckType deck)
    {
        if (!decks[card.deck].Contains(card))
            return;

        decks[card.deck].Remove(card);

        decks[deck].Add(card);
        card.deck = deck;
    }

    public void Draw(int number)
    {
        for (int i = 0; i < number; i++)
        {
            decks[DeckType.Hand].Add(decks[DeckType.Deck].Pop());
        }
    }

    public void SuffleDeck(DeckType deck)
    {
        decks[deck].Shuffle();
    }
}
