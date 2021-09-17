using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 10f;
    [SerializeField] GameObject deathVFX;
    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }
    public void TriggerDeathVFX()
    {
        if (!deathVFX) return;

        GameObject deathVFXObject =  Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }
}
