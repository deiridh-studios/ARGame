using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_BasicAttack : MonoBehaviour
{
    public GameObject particle;

    public void Attack()
    {
        particle.SetActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
