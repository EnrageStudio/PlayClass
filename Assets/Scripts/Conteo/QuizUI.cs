using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private Text question = null;
    [SerializeField] private List<OptionSelect> btnList = null;
    [SerializeField]private Image img;
    private void Start()
    {
        img = GameObject.Find("ImgQuest").GetComponent<Image>();
    }
    public void Construct(Question q, Action<OptionSelect> callback)
    {
        question.text = q.text;
        if(q.n == 1)
        {
            img.sprite = Resources.Load<Sprite>("Img/Conteo/obj_1");
        }else if(q.n == 2)
        {
            img.sprite = Resources.Load<Sprite>("Img/Conteo/obj_2");
        }
        for(int n = 0; n < btnList.Count; n++)
        {
            btnList[n].Construct(q.options[n], callback);
        }
    }
}
