using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CardList_tests
    {
        private CardList cardList = new CardList();


        [Test]
        public void CardList_pop()
        {
            BaseCard card = new BaseCard();

            card.Title = "TEST1";
            cardList.Add(card);
            BaseCard outCard = cardList.Pop();
            Assert.AreEqual(cardList.Count, 0);
            Assert.AreEqual(card, outCard);
        }
    }
}
