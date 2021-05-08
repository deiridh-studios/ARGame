using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_SpecialAttack : MonoBehaviour
{
    public Image specialAttackImage;
    [Range(1,10)]
    public float attackCooldown = 2.0f;
    bool isInCooldown = false;
    public GameObject particle;
    float cooldownTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        specialAttackImage.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInCooldown == true)
        {
            cooldownTime += Time.deltaTime;
            if(cooldownTime < attackCooldown)
            {
                specialAttackImage.fillAmount = cooldownTime / attackCooldown;
            }
            else
            {
                isInCooldown = false;
                specialAttackImage.fillAmount = 1;
                cooldownTime = 0;
            }
        }
    }

    public void Attack()
    {
        if(isInCooldown == false)
        {
            cooldownTime = 0;
            particle.SetActive(true);
            isInCooldown = true;
            specialAttackImage.fillAmount = 0;
        }
    }
}
