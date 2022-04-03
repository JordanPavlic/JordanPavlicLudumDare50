using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerCard : ICard
{
    public Text cardTitleText {get; set;}
    public Text cardFlavorText {get; set;}
    public Text cardEffectText {get; set;}
    public int cashDelta {get; set;}
    public int gradesDelta {get; set;}
    public int partyingDelta  {get; set;}
    public int turnsTillGraduationDelta  {get; set;}
    public int hungerDelta  {get; set;}
    public Image cardBackground {get; set;}
    public Button DoItButton {get; set;}
    public Button TrashItButton {get; set;}
    public Button SaveItButton {get; set;}

    private System.Random rnd = new System.Random();

    public HungerCard(){
        gradesDelta = rnd.Next(-5, 5);
        partyingDelta = rnd.Next(-5, 5);
        turnsTillGraduationDelta = rnd.Next(-5, 0);;
        hungerDelta = rnd.Next(5, 20);
        cashDelta = rnd.Next(-500, -100);

        cardTitleText = new GameObject().AddComponent<Text>();
        cardTitleText.name = "CardTitleText";
        cardTitleText.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        cardTitleText.GetComponent<Text>().fontSize = 40;
        cardTitleText.GetComponent<Text>().color = Color.black;
        cardTitleText.text = "Hunger Card";
        cardTitleText.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        cardTitleText.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        cardTitleText.GetComponent<RectTransform>().pivot = new Vector2(0, 0);

        cardFlavorText = new GameObject().AddComponent<Text>();
        cardFlavorText.name = "cardFlavorText";
        cardFlavorText.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        cardFlavorText.GetComponent<Text>().fontSize = 30;
        cardFlavorText.GetComponent<Text>().color = Color.black;
        cardFlavorText.text = "Hunger Card";
        cardFlavorText.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        cardFlavorText.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        cardFlavorText.GetComponent<RectTransform>().pivot = new Vector2(0, 0);

        cardEffectText = new GameObject().AddComponent<Text>();
        cardEffectText.name = "cardEffectText";
        cardEffectText.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        cardEffectText.GetComponent<Text>().fontSize = 30;
        cardEffectText.GetComponent<Text>().color = Color.black;
        cardEffectText.text = $"Card Effects:\n\n Grade Boost: {gradesDelta}\n Party Boost: {partyingDelta}\n Graduation Boost: {turnsTillGraduationDelta}\n Hunger Boost: {hungerDelta}\n Cash Boost: {cashDelta}";
        cardEffectText.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        cardEffectText.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        cardEffectText.GetComponent<RectTransform>().pivot = new Vector2(0, 0);

        cardBackground = new GameObject().AddComponent<Image>();
        cardBackground.name = "cardBackground";
        cardBackground.color = Color.yellow;
        cardBackground.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
        cardBackground.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
        cardBackground.GetComponent<RectTransform>().pivot = new Vector2(0, 0);


        DoItButton = new GameObject().AddComponent<Button>();
        DoItButton.name = "DoItButton";
        
        var doItbuttonBackground = new GameObject().AddComponent<Image>();
        doItbuttonBackground.name = "doItbuttonBackground";
        doItbuttonBackground.transform.SetParent(DoItButton.transform);
        
        var DoItbuttonText = new GameObject().AddComponent<Text>();
        DoItbuttonText.name = "DoItbuttonText";
        DoItbuttonText.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        DoItbuttonText.GetComponent<Text>().fontSize = 20;
        DoItbuttonText.GetComponent<Text>().color = Color.black;
        DoItbuttonText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        DoItbuttonText.text = "Do It!";
        DoItbuttonText.transform.SetParent(DoItButton.transform);


        SaveItButton = new GameObject().AddComponent<Button>();
        SaveItButton.name = "SaveItButton";
        
        var saveItButtonBackground = new GameObject().AddComponent<Image>();
        saveItButtonBackground.name = "saveItButtonBackground";
        saveItButtonBackground.transform.SetParent(SaveItButton.transform);
        
        var SaveItButtonText = new GameObject().AddComponent<Text>();
        SaveItButtonText.name = "SaveItButtonText";
        SaveItButtonText.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        SaveItButtonText.GetComponent<Text>().fontSize = 20;
        SaveItButtonText.GetComponent<Text>().color = Color.black;
        SaveItButtonText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        SaveItButtonText.text = "Maybe Later";
        SaveItButtonText.transform.SetParent(SaveItButton.transform);
    }
}

