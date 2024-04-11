using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using Unity.Burst.Intrinsics;

public class Deck
{
    Card[] cards = new Card[52];
    int currentCardIndex;
    public Deck()
    {

        //suffle ints 0-51
        int[] inOrder = new int[52];
        for (int i = 0; i < inOrder.Length; i++)
        {
            inOrder[i] = i;
        }
        Random rand = new Random();
        inOrder = inOrder.OrderBy(x => rand.Next()).ToArray();

        //from suffles ints create the deck
        for (int i = 0; i < inOrder.Length; i++)
        {
            int cardAsInt = inOrder[i];
            Card card = new Card(cardAsInt);
            cards[i] = card;
        }
        currentCardIndex = 0;
    }

    public Card GetNextCard()
    {
        if (currentCardIndex == cards.Length) { return null; }
        currentCardIndex++;
        return cards[currentCardIndex - 1];
    }

}
