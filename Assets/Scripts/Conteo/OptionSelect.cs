using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class OptionSelect : MonoBehaviour
{
    private Text text = null;
    private Button button = null;
    private Image image = null;
    private Color color = Color.black;
    public Option option { get; set; }
    public void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        text = transform.GetChild(0).GetComponent<Text>();
        color = image.color;
    }
    public void Construct(Option subOption, Action<OptionSelect> callback)
    {
        text.text = subOption.text;
        button.enabled = true;
        image.color = color;
        option = subOption;
        button.onClick.AddListener(delegate
        {
            callback(this);
        });
    }
    public void SetColor(Color c)
    {
        button.enabled = false;
        image.color = c;
    }

}
