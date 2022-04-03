using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameStateManager : MonoBehaviour
{
    public Text cashTxt;
    public Text gradesTxt;
    public Text partyingTxt;
    public Text hungerTxt;
    public Slider graduationStatusSlider;
    public Button NextWeekButton;

    public GameObject cardLocation1; 
    public GameObject cardLocation2; 
    public GameObject cardLocation3; 

    private bool discardCardLocation1 = true;
    private bool discardCardLocation2 = true;
    private bool discardCardLocation3 = true;

    private Deck deck = new Deck();
    public ICard[] hand = {null, null, null};

    private int cash = 5000;
    private int grades {
        get {
            return grades;
        }
        set {
            if (value <= 100 && value >= 0)
                grades = value;
        }
        }
    private int partying = 0;
    private int turnsTillGraduation = 60;
    private int hunger = 100;
    private int TurnsTaken = 0;


    //Start is called before the first frame update
    void Start()
    {
        grades = 100;

        Button btn = NextWeekButton.GetComponent<Button>();
        btn.onClick.AddListener(NextTurn);

        Slider gradSlider = graduationStatusSlider.GetComponent<Slider>();
        gradSlider.maxValue = turnsTillGraduation;
        gradSlider.value = turnsTillGraduation;

        DrawFromDeck();
    }

    private void NextTurn() {
        DiscardUnsavedHand();
        ResetCardSavingFlags();
        DrawFromDeck();
        turnsTillGraduation -= 1;
        hunger -= 0;
        cash -= 450;

        TurnsTaken += 1;
    }

    private void DiscardUnsavedHand() {
        if (discardCardLocation1)
            DiscardFromHand(0, cardLocation1);
        if (discardCardLocation2)
            DiscardFromHand(1, cardLocation2);
        if (discardCardLocation3)
            DiscardFromHand(2, cardLocation3);
    }

    private void ResetCardSavingFlags(){
        discardCardLocation1 = true;
        discardCardLocation2 = true;
        discardCardLocation3 = true;
    }

    private void DiscardFromHand(int handLocation, GameObject cardLocation) {
        hand[handLocation] = null;
        foreach (Transform child in cardLocation.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void DrawFromDeck()
    {
        for (int i=0; i < hand.Length; i++)
        {
            if (hand[i] is null)
            {
                var handcard = deck.DrawCard();
                hand[i] = handcard;
                GameObject cardlocation = null;
                int handLocation = 0;
                if (i == 0)
                    cardlocation = cardLocation1;
                    handLocation = i;
                if(i == 1)
                    cardlocation = cardLocation2;
                    handLocation = i;
                if (i == 2)
                    cardlocation = cardLocation3;
                    handLocation = i;

                Debug.Log($"i is {i}");
                handcard.cardBackground.transform.SetParent(cardlocation.transform);
                SetRectTransformPosition(handcard.cardBackground.GetComponent<RectTransform>(), 0, 0, 0, 0);

                handcard.cardTitleText.transform.SetParent(cardlocation.transform);
                SetRectTransformPosition(handcard.cardTitleText.GetComponent<RectTransform>(), 0, 0, 0, 0);

                handcard.cardFlavorText.transform.SetParent(cardlocation.transform);
                SetRectTransformPosition(handcard.cardFlavorText.GetComponent<RectTransform>(), 0, 100, 0, 0);

                handcard.cardEffectText.transform.SetParent(cardlocation.transform);
                SetRectTransformPosition(handcard.cardEffectText.GetComponent<RectTransform>(), 0, 200, 0, 0);

                handcard.DoItButton.transform.SetParent(cardlocation.transform);
                handcard.DoItButton.transform.localPosition = new Vector3(125, -200, 0);
                Button btn = handcard.DoItButton.GetComponent<Button>();
                btn.onClick.AddListener(delegate{OnDoItButtonClick(handLocation, handcard, cardlocation);});

                handcard.SaveItButton.transform.SetParent(cardlocation.transform);
                handcard.SaveItButton.transform.localPosition = new Vector3(-125, -200, 0);
                Button btn_2 = handcard.SaveItButton.GetComponent<Button>();
                btn_2.onClick.AddListener(delegate{OnSaveItButtonClick(handLocation);});
            }
        }
    }

    public static void SetRectTransformPosition(RectTransform trs, float left, float top, float right, float bottom)
    {
        trs.offsetMin = new Vector2(left, bottom);
        trs.offsetMax = new Vector2(-right, -top);
    }

    public void OnDoItButtonClick(int handLocation, ICard card, GameObject cardLocation) {
        Debug.Log("Clicked Do It Button");
        cash += card.cashDelta;
        grades += card.gradesDelta;
        partying += card.partyingDelta;
        turnsTillGraduation += card.turnsTillGraduationDelta;
        hunger += card.hungerDelta;
        Debug.Log(handLocation);
        DiscardFromHand(handLocation, cardLocation);
    }

    public void OnSaveItButtonClick(int handLocation) {
        if (handLocation == 0)
            discardCardLocation1 = false;
        if (handLocation == 1)
            discardCardLocation2 = false;
        if (handLocation == 2)
            discardCardLocation3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        RefreshUI();
    }

    private void RefreshUI(){
        cashTxt.GetComponent<UnityEngine.UI.Text>().text = cash.ToString();
        gradesTxt.GetComponent<UnityEngine.UI.Text>().text = grades.ToString();
        hungerTxt.GetComponent<UnityEngine.UI.Text>().text = hunger.ToString();
        partyingTxt.GetComponent<UnityEngine.UI.Text>().text = partying.ToString();
        graduationStatusSlider.GetComponent<Slider>().value = turnsTillGraduation;
    }
} 
