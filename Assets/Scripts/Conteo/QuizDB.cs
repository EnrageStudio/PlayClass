using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizDB : MonoBehaviour
{
    [SerializeField] private List<Question> questionList = null;
    public Question GetRandom(bool remove = true)
    {
        if (questionList.Count == 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        int index = Random.Range(0, questionList.Count);
        if (!remove)
            return questionList[index];
        Question q = questionList[index];
        questionList.RemoveAt(index);
        return q;
    }
}
