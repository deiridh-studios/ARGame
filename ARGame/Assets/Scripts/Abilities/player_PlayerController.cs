using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_PlayerController : MonoBehaviour
{
    public float maxPlayerLife = 500;
    public float actualPlayerLife = 500;
    public Slider playerSlider;
    public Text textMaxPlayerLife;
    public Text textActualPlayerLife;
    public bool isDead = false;
    public ScenesChanger changer;
    public void RefreshUI()
    {
        textActualPlayerLife.text = actualPlayerLife.ToString();
        textMaxPlayerLife.text = "/ " + maxPlayerLife.ToString();
        playerSlider.value = actualPlayerLife / maxPlayerLife;
    }

    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }

    public void GetDamage(int dam)
    {
        actualPlayerLife -= dam;
        Handheld.Vibrate();
        if (actualPlayerLife < 0)
        {
            isDead = true;
            changer.ChangeToScene("MainMenu");
        }
        RefreshUI();
    }
}
