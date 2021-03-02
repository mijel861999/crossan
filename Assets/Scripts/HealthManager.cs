using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;       
    }

    


    void Update()
    {
        if(currentHealth <=0)
        {
            gameObject.SetActive(false);
        }
    }

    public void damageCharacter(int damage)
    {
        currentHealth -= damage;
    }

    public void updateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }
}
