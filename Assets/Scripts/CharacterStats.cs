using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class CharacterStats : MonoBehaviour, IKillable, IDamageable<float>
{

    public float currentHealth;
    public float maxHealth = 100;

    protected bool isDead = false;

    private AudioSource audioSource;

   public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
   public void Start()
    {
        currentHealth = maxHealth;
    }

  

    public void Kill()
    {
        isDead = true;

        //TODO: For player, disable input logic
        //TODO: For AI, disable attacking logic
        //Placeholder Logic
        Destroy(gameObject);
        //End Placeholder

        //TODO: Call Death Animation, play death SFX
    }

    public void ApplyDamage(float damageApplied)
    {
        //Reduce current health by the damage amount
        currentHealth -= damageApplied;

        //TODO: Play hurt SFX

        if(currentHealth <=0 && !isDead)
        {
            Kill();
        }
    }
}
