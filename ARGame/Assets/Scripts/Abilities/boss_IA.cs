using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss_IA : MonoBehaviour
{
    public GameObject cam;
    Animator animator;
    public Slider sliderHP;
    public float bossTotalLife = 10000;
    public float bossActualLife = 10000;
    public bool isDead = false;
    public bool isCanHitAnim = false;
    Vector3 targetPoint;
    Quaternion targetRotation;

    [Header("Particles")]
    public GameObject kick1Particle;
    public GameObject kick2Particle;
    public GameObject kick3Particle;
    public GameObject punchLParticle;
    public GameObject punchRParticle;

    [Header("Trail")]
    public GameObject trailL1;
    public GameObject trailL2;
    public GameObject trailR1;
    public GameObject trailR2;

    public ScenesChanger changer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sliderHP.value = bossActualLife / bossTotalLife;
        StartCoroutine(DoAttacks());
    }

    private void Update()
    {
    }

    private void OnDisable()
    {
        StopCoroutine(DoAttacks());
    }

    private void OnEnable()
    {
        Start();
    }

    public void ToggleSpawnBoss(bool _active)
    {
        gameObject.SetActive(_active);
    }

    public void SpawnParticles(int i)
    {
        switch (i)
        {
            case (0):
                kick1Particle.SetActive(true);
                break;
            case (1):
                kick2Particle.SetActive(true);
                break;
            case (2):
                kick3Particle.SetActive(true);
                break;
            case (3):
                punchLParticle.SetActive(true);
                break;
            case (4):
                punchRParticle.SetActive(true);
                break;
            case (5):
                trailL1.SetActive(true);
                trailL2.SetActive(true);
                break;
            case (6):
                trailL1.SetActive(false);
                trailL2.SetActive(false);
                break;
            case (7):
                trailR1.SetActive(true);
                trailR2.SetActive(true);
                break;
            case (8):
                trailR1.SetActive(false);
                trailR2.SetActive(false);
                break;
            default:
                punchLParticle.SetActive(true);
                break;
        }
    }

    IEnumerator DoAttacks()
    {
        //TODO: Rotate Boss to view the player
        //Vector3 gg = -cam.transform.forward;
        //transform.forward = new Vector3(gg.x, transform.forward.y, gg.z);
        Vector3 targetPosition = new Vector3(cam.transform.position.x, transform.position.y, cam.transform.position.z);
        transform.LookAt(targetPosition);

        isCanHitAnim = false;
        BossAttack();
        yield return new WaitForSeconds(1.5f);
        isCanHitAnim = true;
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(DoAttacks());
    }

    void GetDamage(int dam)
    {
        bossActualLife -= dam;
        if(bossActualLife <= 0)
        {
            isDead = true;
            animator.SetTrigger("Death");
            Debug.Log("Boss Defeated");
            changer.ChangeToScene("MainMenu");
        }
        sliderHP.value = bossActualLife / bossTotalLife;
        //Debug.Log("This is the value: " + bossActualLife / bossTotalLife);
    }

    public void LookIfBlockAttackOrHit(int dam, bool isSpecial)
    {
        int i = Random.Range(0, 4);

        switch (i)
        {
            case (0):
                // In this case the boss is hitted normally
                if (isCanHitAnim == true)
                {
                    if (isSpecial == true) animator.SetTrigger("HeavyHit");
                    else animator.SetTrigger("Hit");
                }
                isCanHitAnim = false;
                GetDamage(dam);
                break;
            case (1):
                // In this case the boss is hitted normally
                if (isCanHitAnim == true)
                {
                    if (isSpecial == true) animator.SetTrigger("HeavyHit");
                    else animator.SetTrigger("Hit");
                }
                isCanHitAnim = false;
                GetDamage(dam);
                break;
            case (2):
                //In this case the boss protects the attack
                int j = Random.Range(0, 2);
                if(j == 0) animator.SetTrigger("Stop1");
                else animator.SetTrigger("Stop2");
                isCanHitAnim = false;
                break;
            case (3):
                // In this case the boss is hitted normally
                if(isCanHitAnim == true)
                {
                    if (isSpecial == true) animator.SetTrigger("HeavyHit");
                    else animator.SetTrigger("Hit");
                }
                isCanHitAnim = false;
                GetDamage(dam);
                break;
            default:
                //If is a irregular fail, the boss is hitted normally
                if (isCanHitAnim == true)
                {
                    if (isSpecial == true) animator.SetTrigger("HeavyHit");
                    else animator.SetTrigger("Hit");
                }
                isCanHitAnim = false;
                GetDamage(dam);
                break;
        }
    }

    public void BossAttack()
    {
        float average = bossActualLife / bossTotalLife;

        if(average > 0.7f) //If the boss has more than a 70% of his life do this behaviour
        {
            int randomNum = Random.Range(0, 5);
            switch (randomNum)
            {
                case (0):
                    animator.SetTrigger("Kick1");
                    break;
                case (1):
                    animator.SetTrigger("Kick2");
                    break;
                case (2):
                    animator.SetTrigger("Kick3");
                    break;
                case (3):
                    animator.SetTrigger("PunchR");
                    break;
                case (4):
                    animator.SetTrigger("PunchL");
                    break;
                default:
                    animator.SetTrigger("Kick1");
                    break;
            }
        }
        else if(average > 0.25f && average < 0.7f) //If the boss has within 25% and 70% of his life do this behaviour
        {
            int randomNum = Random.Range(0, 5);
            switch (randomNum)
            {
                case (0):
                    animator.SetTrigger("Kick1");
                    break;
                case (1):
                    animator.SetTrigger("Kick2");
                    break;
                case (2):
                    animator.SetTrigger("Kick3");
                    break;
                case (3):
                    animator.SetTrigger("PunchR");
                    break;
                case (4):
                    animator.SetTrigger("PunchL");
                    break;
                default:
                    animator.SetTrigger("Kick1");
                    break;
            }
        }
        else //If the boss has less than 25% of his life do this behaviour
        {
            int randomNum = Random.Range(0, 5);
            switch (randomNum)
            {
                case (0):
                    animator.SetTrigger("Kick1");
                    break;
                case (1):
                    animator.SetTrigger("Kick2");
                    break;
                case (2):
                    animator.SetTrigger("Kick3");
                    break;
                case (3):
                    animator.SetTrigger("PunchR");
                    break;
                case (4):
                    animator.SetTrigger("PunchL");
                    break;
                default:
                    animator.SetTrigger("Kick1");
                    break;
            }
        }
    }
}
