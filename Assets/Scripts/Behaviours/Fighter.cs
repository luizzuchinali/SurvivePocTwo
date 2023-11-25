using UnityEngine;

public class Fighter : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;

    public Attack baseAttackEffect;

    private void Awake()
    {
        health = maxHealth;
    }

    public virtual void Attack(Vector3 direction)
    {
        Instantiate(baseAttackEffect, transform.position, Quaternion.LookRotation(-direction));
        // Do attack here, e.g. play animation, deal damage, etc.
        Debug.Log($"{gameObject.name} has attacked {direction}.");
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle death here, e.g. play animation, remove from game, etc.
        Debug.Log($"{gameObject.name} has died.");
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}