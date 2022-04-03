using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    System.Random random = new System.Random();

    private double chanceOfHungerCard = 0.25;
    private double chanceOfCashCard = 0.25;
    private double chanceOfGradesCard = 0.25;
    private double chanceOfPartyingCard = 0.25;

    private List<Type> CardTypeSelectionTable = new List<Type>();

    public Deck() {
        UpdateTypeSelectionTable(typeof(HungerCard), chanceOfHungerCard);
        UpdateTypeSelectionTable(typeof(CashCard), chanceOfCashCard);
        UpdateTypeSelectionTable(typeof(GradesCard), chanceOfGradesCard);
        UpdateTypeSelectionTable(typeof(PartyingCard), chanceOfPartyingCard);
    }

    private void UpdateTypeSelectionTable(Type cardType, double targetChanceForDraw)
    {
        int numTypeTableInstances = (int)(targetChanceForDraw * 100.0);
        for (int i=0; i < numTypeTableInstances; i++)
        {
            CardTypeSelectionTable.Add(cardType);
        }
    }

    public ICard DrawCard() {
        int index = random.Next(CardTypeSelectionTable.Count);
        Type cardTypeToDraw = CardTypeSelectionTable[index];
        return (ICard)Activator.CreateInstance(cardTypeToDraw);
    }
}
