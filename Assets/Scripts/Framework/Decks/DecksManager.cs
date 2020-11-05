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

    /// <summary>
    /// Initialize decks
    /// </summary>
    private void InitDecks()
    {
        decks = new Dictionary<DeckType, CardList>();

        foreach (DeckType type in Enum.GetValues(typeof(DeckType)))
            decks.Add(type, new CardList());
    }

    /// <summary>
    /// Add a card in a specified deck
    /// </summary>
    /// <param name="card"></param>
    /// <param name="deck"></param>
    public void AddCard(BaseCard card, DeckType deck)
    {
        decks[deck].Add(card);
    }

    /// <summary>
    /// Move a card from a deck to the specified one
    /// </summary>
    /// <param name="card"></param>
    /// <param name="deck"></param>
    public void MoveCard(BaseCard card, DeckType deck)
    {
        if (!decks[card.deck].Contains(card))
            return;

        decks[card.deck].Remove(card);

        decks[deck].Add(card);
        card.deck = deck;
    }

    /// <summary>
    /// Draw a card from Deck
    /// </summary>
    /// <param name="number"></param>
    public void Draw(int number)
    {
        for (int i = 0; i < number; i++)
        {
            decks[DeckType.Hand].Add(decks[DeckType.Deck].Pop());
        }
    }

    /// <summary>
    /// Suffle Deck
    /// </summary>
    /// <param name="deck"></param>
    public void SuffleDeck(DeckType deck)
    {
        decks[deck].Shuffle();
    }

    /// <summary>
    /// Detect if there is a possible chain in Hand
    /// </summary>
    /// <returns></returns>
    public bool CanChain()
    {
        for (int i = 0; i < decks[DeckType.Hand].Count; i ++)
        {
            if (decks[DeckType.Hand][i].TestChain())
                return true;
        }

        return false;
    }

    /// <summary>
    /// Trigger every EndTurn effects from Board
    /// </summary>
    public void TriggerEndPhaseEffects()
    {
        decks[DeckType.Board].ForEach(card =>
        {
            MonsterCard monster = card as MonsterCard;

            GameManager.instance.actionQueue.AddAction(monster.OnEndTurn, ActionStack.ActionType.EndTurn);
        });
    }
}
