﻿using System;
using System.Collections.Generic;

public enum Suit { Hearts, Diamonds, Clubs, Spades }
public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

// 카드 한 장을 표현하는 클래스
public class Card
{
    public Suit Suit { get; private set; }
    public Rank Rank { get; private set; }

    public Card(Suit s, Rank r)
    {
        Suit = s;
        Rank = r;
    }

    public int GetValue()
    {
        if ((int)Rank <= 10)
        {
            return (int)Rank;
        }
        else if ((int)Rank <= 13)
        {
            return 10;
        }
        else
        {
            return 11;
        }
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}

// 덱을 표현하는 클래스
public class Deck
{
    private List<Card> cards;

    public Deck()
    {
        cards = new List<Card>();

        foreach (Suit s in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                cards.Add(new Card(s, r));
            }
        }

        Shuffle();
    }

    public void Shuffle()
    {
        Random rand = new Random();

        for (int i = 0; i < cards.Count; i++)
        {
            int j = rand.Next(i, cards.Count);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    public Card DrawCard()
    {
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
}

// 패를 표현하는 클래스
public class Hand
{
    private List<Card> cards;

    public Hand()
    {
        cards = new List<Card>();
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public int GetTotalValue()
    {
        int total = 0;
        int aceCount = 0;

        foreach (Card card in cards)
        {
            if (card.Rank == Rank.Ace)
            {
                aceCount++;
            }
            total += card.GetValue();
        }

        while (total > 21 && aceCount > 0)
        {
            total -= 10;
            aceCount--;
        }

        return total;
    }
}

// 플레이어를 표현하는 클래스
public class Player
{
    public Hand Hand { get; private set; }

    public Player()
    {
        Hand = new Hand();
    }

    public Card DrawCardFromDeck(Deck deck)
    {
        Card drawnCard = deck.DrawCard();
        Hand.AddCard(drawnCard);
        return drawnCard;
    }
}

// 여기부터는 학습자가 작성
// 딜러 클래스를 작성하고, 딜러의 행동 로직을 구현하세요.
public class Dealer : Player
{
    // 코드를 여기에 작성하세요
}

// 블랙잭 게임을 구현하세요. 
public class Blackjack
{
    // 코드를 여기에 작성하세요
}

class Program
{
    static void Main(string[] args)
    {
        // 블랙잭 게임을 실행하세요
    }
}