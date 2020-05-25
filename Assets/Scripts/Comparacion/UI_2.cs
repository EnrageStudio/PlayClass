using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_2 : MonoBehaviour
{
    [SerializeField] private Text question = null;
    [SerializeField] private List<OptionSelect_2> btnList = null;
    [SerializeField] private Image img;
    [SerializeField] private Image img_2;
    private void Start()
    {
        img = GameObject.Find("ImgMain").GetComponent<Image>();
        img_2 = GameObject.Find("ImgMain_2").GetComponent<Image>();
    }
    public void Construct(Quest_2 op, Action<OptionSelect_2> callback)
    {
        question.text = op.text;
        if (op.n == 1)
        {
            img.sprite = Resources.Load<Sprite>("Img/Conteo/obj_1");
            img_2.sprite = Resources.Load<Sprite>("Img/Conteo/obj_2");
        }
        else if (op.n == 2)
        {
            img.sprite = Resources.Load<Sprite>("Img/Conteo/obj_2");
            img_2.sprite = Resources.Load<Sprite>("Img/Conteo/obj_1");
        }
        for (int n = 0; n < btnList.Count; n++)
        {
            btnList[n].Construct(op.options[n], callback);
        }
    }
}
