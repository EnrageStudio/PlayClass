using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DB_2 : MonoBehaviour
{
    [SerializeField] private List<Quest_2> questionList = null;
    public Quest_2 GetRandom(bool remove = true)
    {
        if (questionList.Count == 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
        int index = Random.Range(0, questionList.Count);
        if (!remove)
            return questionList[index];
        Quest_2 q = questionList[index];
        questionList.RemoveAt(index);
        return q;
    }
}
