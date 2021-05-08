using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSliderColor : MonoBehaviour
{
    public Color goodLife;
    public Color midLife;
    public Color badLife;
    public Slider slider;
    Image thisColor;

    private void Start()
    {
        thisColor = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value > 0.65)
        {
            thisColor.color = goodLife;
        }
        else if(slider.value < 0.65 && slider.value > 0.25)
        {
            thisColor.color = midLife;
        }
        else
        {
            thisColor.color = badLife;
        }
    }
}
