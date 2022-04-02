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
    public Text turnsTillGraduationTxt;
    public Button NextWeekButton;


    private int cash = 0;
    private int grades = 100;
    private int partying = 0;
    private int turnsTillGraduation = 8;
    private int hunger = 100;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = NextWeekButton.GetComponent<Button>();
        btn.onClick.AddListener(NextTurn);
    }

    private void NextTurn() {
        turnsTillGraduation -= 1;
        hunger -= 0;
        cash -= 450;
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
        turnsTillGraduationTxt.GetComponent<UnityEngine.UI.Text>().text = turnsTillGraduation.ToString();
    }
}
