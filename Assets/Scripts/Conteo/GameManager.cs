using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioClip correctSound = null;
    [SerializeField] private AudioClip incorrectSound = null;
    [SerializeField] private Color correctColor = Color.black;
    [SerializeField] private Color incorrectColor = Color.red;
    private float waitTime = 0.5f;
    private QuizDB quizDB = null;
    private QuizUI quizUI = null;
    private AudioSource audioSource = null;
    private void Start()
    {
        quizDB = GameObject.FindObjectOfType<QuizDB>();
        quizUI = GameObject.FindObjectOfType<QuizUI>();
        audioSource = GetComponent<AudioSource>();
        NextQuestion();
    }
    private void NextQuestion()
    {
        quizUI.Construct(quizDB.GetRandom(), GiveAnswer);       
    }
    private void GiveAnswer(OptionSelect optionBtn)
    {
        StartCoroutine(Routine(optionBtn));
    }
    private IEnumerator Routine(OptionSelect optionBtn)
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