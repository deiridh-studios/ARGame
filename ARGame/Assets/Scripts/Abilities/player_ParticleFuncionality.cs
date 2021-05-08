using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_ParticleFuncionality : MonoBehaviour
{
    public int randomRange = 5;
    public int damage = 10;
    public bool isSpecial = false;

    private void OnParticleCollision(GameObject other)
    { 
        //If the Particles touch a Enemy do damage to they
        if (other.tag == "Boss")
        {
            int j = Random.Range(damage - randomRange, damage + randomRange);
            Debug.Log("Collision done with " + damage);

            other.GetComponent<boss_IA>().LookIfBlockAttackOrHit(j, isSpecial);
        }

        //DELETE THE PARTICLE WHEN COLLISION
        ParticleSystem p_system = GetComponent<ParticleSystem>();
        ParticleSystem.Particle[] m_Particles;
        m_Particles = new ParticleSystem.Particle[p_system.main.maxParticles];

        for (int i = 0; i < p_system.main.maxParticles; i++)
        {
            m_Particles[i].remainingLifetime = -1;
            p_system.SetParticles(m_Particles);
        }
        p_system.Stop();
    }
}
