using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System;

public class CardList : List<BaseCard>
{
    public void Shuffle()
    {
        int n = this.Count;
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();

        while (n > 1)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (Byte.MaxValue / n)));
            int k = (box[0] % n);
            n--;
            BaseCard value = this[k];
            this[k] = this[n];
            this[n] = value;
        }
    }

    public BaseCard Pop()
    {
        BaseCard cardToPop = this[0];

        this.Remove(cardToPop);

        return cardToPop;
    }
}
