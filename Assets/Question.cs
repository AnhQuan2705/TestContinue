
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question : MonoBehaviour
{
    public Question[] question; 
    public string[] answerChoices;
    public int correctAnswerIndex;
    public string explanation;
}
