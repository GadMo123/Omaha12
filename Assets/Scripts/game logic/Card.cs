using System;
using System.Collections;
using System.Collections.Generic;


public enum Suit
{
    HEART = 'h', CLUB = 'c', DIAMOND='d', SPADE = 's'
}


public class Card
{
    private Suit suit;
    private char cardValue;

    public Card(Suit suit, char cardValue)
    {
        this.suit = suit;
        this.cardValue = cardValue;
    }

    public Card(int cardAsInt)  // get a nuber between 0-51  0=2h, 1=3h, 12=Ah , 13 =2c ...
    {
        int mod = cardAsInt / 13; //suit of the card
        switch (mod)
        {
            case 0:
                suit = Suit.HEART; break;
            case 1:
                suit = Suit.CLUB; break;
            case 2:
                suit = Suit.DIAMOND; break;
            case 3:
                suit = Suit.SPADE; break;
        }
        int value = cardAsInt % 13; //value of the card 2-Ace
        switch (value)
        {
            case 0:
                cardValue = '2'; break;
            case 1:
                cardValue = '3'; break;
            case 2:
                cardValue = '4'; break;
            case 3:
                cardValue = '5'; break;
            case 4:
                cardValue = '6'; break;
            case 5:
                cardValue = '7'; break;
            case 6:
                cardValue = '8'; break;
            case 7:
                cardValue = '9'; break;
            case 8:
                cardValue = 'T'; break;
            case 9:
                cardValue = 'J'; break;
            case 10:
                cardValue = 'Q'; break;
            case 11:
                cardValue = 'K'; break;
            case 12:
                cardValue = 'A'; break;
        }
    }
 

    public override string ToString()
    {
        return "" + cardValue + ((char)suit);
    }


}
