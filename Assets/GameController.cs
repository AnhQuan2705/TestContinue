using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Question[] question; // This is the fixed size array of the questions, answer choices, answers, and explanations.
    private static List<Question> questionsCopy; // This is the resizeable list (originally a copy of the array). The size of this list will diminish as we remove items after presenting each question.
    private Question currentQuestion;

    string path; // The path to the .json file storing the questions, answer choices, correct answer index, explanations.
    string jsonString; // The contents of the .json file.

     void Start()
    {
        path = Application.streamingAssetsPath + "D:/M?u/Unity_GetDataFromGoogleDrive - main/Unity_GetDataFromGoogleDrive - main/Assets/StreamingAssets/questionsAndAnswers.json";
        jsonString = File.ReadAllText(path);

        question = JsonUtility.FromJson<Question[]>(jsonString);

        // Debug.LogWarning("Questions:");
        Debug.LogWarning(question);

        if (questionsCopy == null || questionsCopy.Count == 0) // A list with zero elements isn't always null.
        {
            questionsCopy = question.ToList<Question>();
        }

        PickRandomQuestion();
    }
    public void PickRandomQuestion()
    {
        int randomIndex = Random.Range(0, questionsCopy.Count);
        currentQuestion = questionsCopy[randomIndex];
        questionsCopy.RemoveAt(randomIndex);
    }
}
