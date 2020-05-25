using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Game_2 : MonoBehaviour
{
    [SerializeField] private AudioClip correctSound = null;
    [SerializeField] private AudioClip incorrectSound = null;
    [SerializeField] private Color correctColor = Color.black;
    [SerializeField] private Color incorrectColor = Color.red;
    private float waitTime = 0.5f;
    private DB_2 quizDB = null;
    private UI_2 quizUI = null;
    private AudioSource audioSource = null;
    private void Start()
    {
        quizDB = GameObject.FindObjectOfType<DB_2>();
        quizUI = GameObject.FindObjectOfType<UI_2>();
        audioSource = GetComponent<AudioSource>();
        NextQuestion();
    }
    private void NextQuestion()
    {
        quizUI.Construct(quizDB.GetRandom(), GiveAnswer);
    }
    private void GiveAnswer(OptionSelect_2 optionBtn)
    {
        StartCoroutine(Routine(optionBtn));
    }
    private IEnumerator Routine(OptionSelect_2 optionBtn)
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
        audioSource.clip = optionBtn.option.correct ? correctSound : incorrectSound;
        optionBtn.SetColor(optionBtn.option.correct ? correctColor : incorrectColor);
        audioSource.Play();
        yield return new WaitForSeconds(waitTime);
        NextQuestion();
    }
}
