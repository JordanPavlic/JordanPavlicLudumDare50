using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICard
{
    Text cardTitleText {get; set;}
    Text cardFlavorText {get; set;}
    Text cardEffectText {get; set;}
    int cashDelta {get; set;}
    int gradesDelta {get; set;}
    int partyingDelta  {get; set;}
    int turnsTillGraduationDelta  {get; set;}
    int hungerDelta  {get; set;}
    Image cardBackground {get; set;}
    Button DoItButton {get; set;}
    Button TrashItButton {get; set;}
    Button SaveItButton {get; set;}
}
